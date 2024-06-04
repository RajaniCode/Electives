using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Data.Common;
using System.IO;
using System.Reflection;
using System.Data.Objects;
using System.Windows.Forms;
using SampleQueries.Harness;

namespace SampleQueries.Dumper
{
    public class ObjectDumper : IObjectDumper
    {
        public TreeView TreeView { get; set; }
        public TextBox GeneratedSqlTextBox { get; set; }
        public TextBox OutputTextBox { get; set; }

        public static bool CatchExceptions = true;

        public void Write(object o)
        {
            Write(o, 0);
        }

        public void Write(object o, int expandDepth)
        {
            Write(o, expandDepth, 10);
        }

        public void Write(object o, int expandDepth, int maxLoadDepth)
        {
            if (o != null && o is IEnumerable && CatchExceptions)
            {
                // ObjectResult<T> collections cannot be iterated twice, so we cache them
                // in an ObjectCollectionCache object

                o = new ObjectCollectionCache(o);
            }

            try
            {
                if (TreeView != null)
                {
                    TreeGenerator gen = new TreeGenerator(Math.Max(expandDepth, 1), maxLoadDepth);
                    TreeNode node = gen.GetTreeNode(o);
                    TreeView.Nodes.Add(node);
                }
                if (o != null && GeneratedSqlTextBox != null)
                {
                    MethodInfo mi = o.GetType().GetMethod("ToTraceString");
                    if (mi != null)
                        GeneratedSqlTextBox.Text = (string)mi.Invoke(o, null);
                }
                if (OutputTextBox != null)
                {
                    StringWriter sw = new StringWriter();
                    PrettyPrinter printer = new PrettyPrinter(sw, maxLoadDepth);
                    printer.Write(o);
                    OutputTextBox.Text = sw.ToString();
                }
            }
            catch (Exception ex)
            {
                if (!CatchExceptions)
                    throw;
                MessageBox.Show("EXCEPTION: " + ex.ToString());
            }
        }
    }
}
