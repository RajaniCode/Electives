using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.DirectoryServices;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Globalization;

namespace LinqToActiveDirectory
{
  public class DirectoryQuery<T> : IOrderedQueryable<T>
  {
 
    private Expression expression;
    private IDirectorySource directorySource;
    private SortOption option = null;
    private Type originalType;
    private HashSet<string> properties = new HashSet<string>();
    private Delegate project;
    private string query;

    internal DirectoryQuery(Expression expression)
    {
      this.expression = expression;
    }

    
    public Type ElementType
    {
      get { return typeof(T); }
    }

    public Expression Expression
    {
      get { return expression; }
    }

    public IQueryProvider Provider
    {
      get { return new DirectoryQueryProvider(); }
    }

    
 
    public IEnumerator<T> GetEnumerator()
    {
      Parse();
      return GetResults();
    }

 
    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }

    private void WriteLog(string text)
    {
      if (directorySource.Log != null)
        directorySource.Log.WriteLine(text);
    }

    private DirectorySchemaAttribute[] GetAttribute()
    {
      DirectorySchemaAttribute[] attribute =
              (DirectorySchemaAttribute[])originalType.GetCustomAttributes(
              typeof(DirectorySchemaAttribute), false);

      if (attribute == null || attribute.Length == 0)
        throw new InvalidOperationException("Missing schema mapping attribute.");
      return attribute;
    }

    private string GetFormattedQuery(DirectorySchemaAttribute[] attribute)
    {
      const string mask = "(&(objectClass={0}){1})";
      return String.Format(mask, attribute[0].Schema, query);
    }

    private IEnumerator<T> GetResults()
    {
      DirectorySchemaAttribute[] attribute = GetAttribute();
      DirectoryEntry root = directorySource.Root;
      string formattedQuery = GetFormattedQuery(attribute);

      DirectorySearcher searcher = new DirectorySearcher(root, 
        formattedQuery, properties.ToArray(), directorySource.Scope);
      
      if(option != null)
        searcher.Sort = option;

      WriteLog(formattedQuery);

      Type helper = attribute[0].HelperType;

      foreach (SearchResult searchResult in searcher.FindAll())
      {
        DirectoryEntry entry = searchResult.GetDirectoryEntry();

        object result = Activator.CreateInstance(project == null ? typeof(T) : originalType);

  
        if (project == null)
        {
          foreach (PropertyInfo info in typeof(T).GetProperties())
            AssignResultProperty(helper, entry, result, info.Name);

  
          yield return (T)result;
        }
        else
        {
          foreach (string prop in properties)
            AssignResultProperty(helper, entry, result, prop);

          yield return (T)project.DynamicInvoke(result);
        }
      }
    }

    private void AssignResultProperty(Type helper, DirectoryEntry entry, 
      object result, string propertyName)
    {
      PropertyInfo info = originalType.GetProperty(propertyName);
      DirectoryAttributeAttribute[] attribute = 
        info.GetCustomAttributes(typeof(DirectoryAttributeAttribute), false) 
        as DirectoryAttributeAttribute[];

      if (attribute != null && attribute.Length != 0)
      {
        if (attribute[0].QuerySource == DirectoryAttributeType.ActiveDs)
        {
          AssignActivsDsResultProperty(helper, entry, result, info, attribute);
        }
        else
        {
          AssignLdapResultProperty(entry, result, info, attribute);
        }
      }
      else
      {
        PropertyValueCollection properties = entry.Properties[propertyName];
        if (properties.Count == 1)
          info.SetValue(result, properties[0], null);
      }
    }

    private static void AssignLdapResultProperty(DirectoryEntry entry, object result, PropertyInfo info, DirectoryAttributeAttribute[] attribute)
    {
      PropertyValueCollection properties = entry.Properties[attribute[0].Attribute];
      if (info.PropertyType.IsArray)
      {
        Array array = Array.CreateInstance(
          info.PropertyType.GetElementType(), properties.Count);

        int i = 0;
        foreach (object o in properties)
          array.SetValue(o, i++);

        info.SetValue(result, array, null);
      }
      else
        if (properties.Count == 1)
          info.SetValue(result, properties[0], null);
    }

    private static void AssignActivsDsResultProperty(Type helper, DirectoryEntry entry, object result, PropertyInfo info, DirectoryAttributeAttribute[] attribute)
    {
      PropertyInfo p = helper.GetProperty(attribute[0].Attribute,
        BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
      try
      {
        info.SetValue(result, p.GetValue(entry.NativeObject, null), null);
      }
      catch (TargetInvocationException) { }
    }

  
    public void Parse()
    {
      Parse(expression);
    }


    private SortDirection GetSortDirection(string name)
    {
      if (name == "OrderByDescending")
        return SortDirection.Descending;
      else
        return SortDirection.Ascending;
    }

    private string GetPropertyNameFromUnary(LambdaExpression unary)
    {
      return unary.Body.ToString().Split('.')[1];
    }

    private void BuildConstantExpression(ConstantExpression constantExpression)
    {
      directorySource = constantExpression.Value as IDirectorySource;
      originalType = directorySource.OriginalType;
    }

    public void Parse(Expression expression)
    {

      var constantExpression = expression as ConstantExpression;
      var methodCallExpression = expression as MethodCallExpression;

      if (constantExpression != null)
      {
        BuildConstantExpression(constantExpression);
      }
      else if (methodCallExpression != null)
        BuildMethodCallExpression(methodCallExpression);
      else
        throw new NotSupportedException("Invalid expression node detected.");
    }

    private void BuildMethodCallExpression(MethodCallExpression methodCallExpression)
    {
      CheckDeclaringType(methodCallExpression);

      Parse(methodCallExpression.Arguments[0]);

      // always a unary expression
      LambdaExpression unary = ((UnaryExpression)
        methodCallExpression.Arguments[1]).Operand as LambdaExpression;

      switch (methodCallExpression.Method.Name)
      {
        case "Where":
          BuildPredicate(unary);
          break;

        case "Select":
          BuildProjection(unary);
          break;

        case "OrderBy":
        case "OrderByDescending":
          option = new SortOption();
          option.PropertyName = GetPropertyNameFromUnary(unary);
          option.Direction = GetSortDirection(methodCallExpression.Method.Name);
          break;
          
        default:
          ThrowUnsupported(methodCallExpression.Method.Name);
          break;
      }
    }

    private static void ThrowUnsupported(string name)
    {
      throw new NotSupportedException("Unsupported query operator: " + name);
    }

    private static void CheckDeclaringType(MethodCallExpression methodCallExpression)
    {
      if (methodCallExpression.Method.DeclaringType != typeof(Queryable))
        throw new NotSupportedException("Detected invalid top-level method-call.");
    }

    private void BuildProjection(LambdaExpression lambda)
    {
      project = lambda.Compile();
      originalType = lambda.Parameters[0].Type;

      MemberInitExpression memberInitExpression = lambda.Body as MemberInitExpression;

      if (memberInitExpression != null)
        foreach (MemberAssignment memberAssignment in memberInitExpression.Bindings)
          FindProperties(memberAssignment.Expression);
      else
        foreach (PropertyInfo info in originalType.GetProperties())
          properties.Add(info.Name);
    }

    /// <summary>
    /// Recursive helper method to finds all required properties for projection.
    /// </summary>
    /// <param name="expression">Expression to detect property uses for.</param>
    private void FindProperties(Expression expression)
    {
      if (expression.NodeType == ExpressionType.MemberAccess)
      {
        AddMemberExpressionName(expression);
      }
      else
      {
        FindExpressionProperties(expression);
      }
    }

    private void FindExpressionProperties(Expression expression)
    {
      BinaryExpression binary;
      UnaryExpression unary;
      ConditionalExpression conditional;
      InvocationExpression invocation;
      LambdaExpression lambda;
      ListInitExpression listInit;
      MemberInitExpression memberInit;
      MethodCallExpression methodCall;
      NewExpression newEx;
      NewArrayExpression newArray;
      TypeBinaryExpression typeBinary;

      if ((binary = expression as BinaryExpression) != null)
      {
        FindProperties(binary.Left);
        FindProperties(binary.Right);
      }
      else if ((unary = expression as UnaryExpression) != null)
      {
        FindProperties(unary.Operand);
      }
      else if ((conditional = expression as ConditionalExpression) != null)
      {
        FindProperties(conditional.IfFalse);
        FindProperties(conditional.IfTrue);
        FindProperties(conditional.Test);
      }
      else if ((invocation = expression as InvocationExpression) != null)
      {
        FindProperties(invocation.Expression);
        foreach (Expression ex in invocation.Arguments)
          FindProperties(ex);
      }
      else if ((lambda = expression as LambdaExpression) != null)
      {
        FindProperties(lambda.Body);
        foreach (Expression ex in lambda.Parameters)
          FindProperties(ex);
      }
      else if ((listInit = expression as ListInitExpression) != null)
      {
        FindProperties(listInit.NewExpression);
        foreach (ElementInit init in listInit.Initializers)
          foreach (Expression ex in init.Arguments)
            FindProperties(ex);
      }
      else if ((memberInit = expression as MemberInitExpression) != null)
      {
        FindProperties(memberInit.NewExpression);
        foreach (MemberAssignment ma in memberInit.Bindings)
          FindProperties(ma.Expression);
      }
      else if ((methodCall = expression as MethodCallExpression) != null)
      {
        FindProperties(methodCall.Object);
        foreach (Expression ex in methodCall.Arguments)
          FindProperties(ex);
      }
      else if ((newEx = expression as NewExpression) != null)
      {
        foreach (Expression ex in newEx.Arguments)
          FindProperties(ex);
      }
      else if ((newArray = expression as NewArrayExpression) != null)
      {
        foreach (Expression ex in newArray.Expressions)
          FindProperties(ex);
      }
      else if ((typeBinary = expression as TypeBinaryExpression) != null)
      {
        FindProperties(typeBinary.Expression);
      }
    }

    private void AddMemberExpressionName(Expression expression)
    {
      MemberExpression memberExpression = expression as MemberExpression;
      if (memberExpression.Member.DeclaringType == originalType)
      {
        DirectoryAttributeAttribute[] attribute =
          memberExpression.Member.GetCustomAttributes(
          typeof(DirectoryAttributeAttribute), false) as DirectoryAttributeAttribute[];
        if (attribute != null && attribute.Length != 0)
        {
          if (attribute[0].QuerySource != DirectoryAttributeType.ActiveDs)
            properties.Add(memberExpression.Member.Name);
        }
        else
          properties.Add(memberExpression.Member.Name);
      }
    }

    private void BuildPredicate(LambdaExpression lambda)
    {
      StringBuilder builder = new StringBuilder();
      ParsePredicate(lambda.Body, builder);
      query = builder.ToString();
    }

    private void ParsePredicate(Expression expression, StringBuilder builder)
    {

      builder.Append("(");
      if (expression as BinaryExpression != null)
      {
        ParseBinaryPredicate(builder, expression as BinaryExpression);
      }
      else if (expression as UnaryExpression != null)
      {
        ParseUnaryExpression(builder, expression as UnaryExpression);
      }
      else if (expression as MethodCallExpression != null)
      {
        ParseMethodCallExpression(builder, expression as MethodCallExpression);
      }
      else
        throw new NotSupportedException(
          "Unsupported query expression detected. Cannot translate to LDAP equivalent.");
      builder.Append(")");
    }

    private static void ParseMethodCallExpression(StringBuilder builder, 
      MethodCallExpression mmethodCall)
    {
      MemberExpression o = (mmethodCall.Object as MemberExpression);
      if (mmethodCall.Method.DeclaringType == typeof(string))
      {
        switch (mmethodCall.Method.Name)
        {
          case "Contains":
            {
              ConstantExpression c = mmethodCall.Arguments[0] as ConstantExpression;
              builder.AppendFormat("{0}=*{1}*", GetFieldName(o.Member), c.Value);
              break;
            }
          case "StartsWith":
            {
              ConstantExpression c = mmethodCall.Arguments[0] as ConstantExpression;
              builder.AppendFormat("{0}={1}*", GetFieldName(o.Member), c.Value);
              break;
            }
          case "EndsWith":
            {
              ConstantExpression c = mmethodCall.Arguments[0] as ConstantExpression;
              builder.AppendFormat("{0}=*{1}", GetFieldName(o.Member), c.Value);
              break;
            }
          default:
            ThrowUnsupportedLdap();
            break;
        }
      }
      else
        ThrowUnsupportedLdap();
    }

    private static void ThrowUnsupportedLdap()
    {
      throw new NotSupportedException(
        "Unsupported: Cannot translate to LDAP equivalent.");
    }

    private void ParseUnaryExpression(StringBuilder builder, UnaryExpression unary)
    {
      if (unary.NodeType == ExpressionType.Not)
      {
        builder.Append("!");
        ParsePredicate(unary.Operand, builder);
      }
      else
        throw new NotSupportedException(
          "Unsupported query operator detected: " + unary.NodeType);
    }

    private void ParseBinaryPredicate(StringBuilder builder, BinaryExpression binary)
    {
      switch (binary.NodeType)
      {
        case ExpressionType.AndAlso:
          builder.Append("&");
          ParsePredicate(binary.Left, builder);
          ParsePredicate(binary.Right, builder);
          break;
        case ExpressionType.OrElse:
          builder.Append("|");
          ParsePredicate(binary.Left, builder);
          ParsePredicate(binary.Right, builder);
          break;
        default: //E.g. Equal, NotEqual, GreaterThan
          builder.Append(GetCondition(binary));
          break;
      }
    }

    private string GetCondition(BinaryExpression binary)
    {
      string str, attribute;
      bool negative;

      GetAttributeAndExpressionString(binary, out str, out attribute, out negative);
      return ConvertToLdapBinaryQuery(binary, str, attribute, negative);
    }

    private static string ConvertToLdapBinaryQuery(
      BinaryExpression binary, string str, string attribute, bool negative)
    {
      Func<string,string> Format =
         mask => string.Format(CultureInfo.InvariantCulture, mask, attribute, str);

      string expression = GetExpression(binary.NodeType, negative);
      return Format(expression);
    }

    private static string GetExpression(ExpressionType type, bool negative)
    {
      switch (type)
      {
        case ExpressionType.Equal:
          return "{0}={1}";
        case ExpressionType.NotEqual:
          return "!({0}={1})";
        case ExpressionType.GreaterThanOrEqual:
          if (!negative)
            return "{0}>={1}";
          else
            return "{0}<={1}";
        case ExpressionType.GreaterThan:
          if (!negative)
            return "&({0}>={1})(!({0}={1}))";
          else
            return "&({0}<={1})(!({0}={1}))";
        case ExpressionType.LessThanOrEqual:
          if (!negative)
            return "{0}<={1}";
          else
            return "{0}>={1}";
        case ExpressionType.LessThan:
          if (!negative)
            return "&({0}<={1})(!({0}={1}))";
          else
            return "&({0}>={1})(!({0}={1}))";
        default:
          throw new NotSupportedException(
            "Unsupported filtering operator detected: " + type);
      }
    }



    private void GetAttributeAndExpressionString(
      BinaryExpression binary, out string str, out string attribute, out bool negative)
    {
      if (binary.Left is MemberExpression &&
        ((MemberExpression)binary.Left).Member.DeclaringType == originalType)
      {
        negative = false;

        attribute = GetFieldName(((MemberExpression)binary.Left).Member);
        str = Expression.Lambda(binary.Right).Compile().DynamicInvoke().ToString();
      }
      else if (binary.Right is MemberExpression
        && ((MemberExpression)binary.Right).Member.DeclaringType == originalType)
      {
        negative = true;

        attribute = GetFieldName(((MemberExpression)binary.Right).Member);
        str = Expression.Lambda(binary.Left).Compile().DynamicInvoke().ToString();
      }
      else
        throw new NotSupportedException(
          "A filtering expression should contain an entity member selection expression.");

      str = str.ToString().Replace("(", "0x28").Replace(")", "0x29").Replace(@"\", "0x5c");
    }

    private static string GetFieldName(MemberInfo member)
    {
      DirectoryAttributeAttribute[] attribute = 
        member.GetCustomAttributes(typeof(DirectoryAttributeAttribute), 
        false) as DirectoryAttributeAttribute[];
      if (attribute != null && attribute.Length != 0 && attribute[0] != null)
      {
        if (attribute[0].QuerySource == DirectoryAttributeType.ActiveDs)
          throw new InvalidOperationException(
            "Can't execute query filters for ADSI properties.");
        else
          return attribute[0].Attribute;
      }
      else
        return member.Name;
    }
  }
}