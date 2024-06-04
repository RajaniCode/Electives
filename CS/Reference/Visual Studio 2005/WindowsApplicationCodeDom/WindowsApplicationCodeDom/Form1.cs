#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.CodeDom;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.IO;
#endregion

namespace WindowsApplicationCodeDom
{
	partial class frmCodeDom : Form
	{
		public frmCodeDom()
		{
			InitializeComponent();
		}

		private void cmdGenerateCodeDom_Click(object sender, EventArgs e)
		{
			CodeCompileUnit unit = GenerateCode();

			// Set up options for source code style 
			CodeGeneratorOptions opts = new CodeGeneratorOptions();
			opts.BracingStyle = "C";
			opts.IndentString = "\t";

			// Create code generator and write code file 
			CSharpCodeProvider cscp = new CSharpCodeProvider();
			
			ICodeGenerator gen = cscp.CreateGenerator();
			StreamWriter sw = new StreamWriter("MyCode.cs");
			gen.GenerateCodeFromCompileUnit(unit, sw, opts);
			sw.Close();

			CompilerParameters compilerParams = new CompilerParameters();
			compilerParams.GenerateExecutable = true;
			compilerParams.OutputAssembly = "MyCode.exe";
			ICodeCompiler compiler = cscp.CreateCompiler();
			compiler.CompileAssemblyFromFile(compilerParams, "MyCode.cs");
		}

		private CodeCompileUnit GenerateCode()
		{
			CodeEntryPointMethod objMainMethod = new CodeEntryPointMethod();
			objMainMethod.Name = "Main";

			// generate this expression: Console 
			CodeTypeReferenceExpression consoleType = new  CodeTypeReferenceExpression();
			consoleType.Type = new CodeTypeReference(typeof(Console));

			// Set up the argument list to pass to Console.WriteLine() 
			CodeExpression[] writeLineArgs = new CodeExpression[1];
			CodePrimitiveExpression arg0 = new CodePrimitiveExpression("Hello from Interview Question series");
			writeLineArgs[0] = arg0;

			// generate this statement: Console.WriteLine(message) 
			CodeMethodReferenceExpression writeLineRef = new   CodeMethodReferenceExpression(consoleType, "WriteLine");
			CodeMethodInvokeExpression writeLine = new	   CodeMethodInvokeExpression(writeLineRef, writeLineArgs);
			
			// generate this statement: Console.ReadLine() 
			CodeMethodReferenceExpression readLineRef = new CodeMethodReferenceExpression(consoleType, "ReadLine");
			CodeMethodInvokeExpression readLine = new CodeMethodInvokeExpression(readLineRef);
			
			// Add Main() method to a class 
			CodeTypeDeclaration theClass = new CodeTypeDeclaration();
			theClass.Members.Add(objMainMethod);
			theClass.Name = "EntryPoint";
			
			// Add both the code of WriteLine and Readline
			objMainMethod.Statements.Add(writeLine);
			objMainMethod.Statements.Add(readLine);

			// Add namespace and add class 
			CodeNamespace ns = new CodeNamespace("InterviewQuestions");
			ns.Imports.Add(new CodeNamespaceImport("System"));
			ns.Types.Add(theClass);

			// Generate the Compile Unit
			CodeCompileUnit unit = new CodeCompileUnit();
			unit.Namespaces.Add(ns);

			return unit;
		}
	}
}