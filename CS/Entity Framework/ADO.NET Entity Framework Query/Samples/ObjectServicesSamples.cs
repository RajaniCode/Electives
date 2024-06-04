//Copyright (C) Microsoft Corporation.  All rights reserved.

using System;
using System.Data.Common;
using System.Data.Objects;
using NorthwindEFModel;
using System.Threading;
using System.Text;
using System.Diagnostics;
using System.Linq;
using SampleQueries.Harness;

namespace SampleQueries.Samples
{
    [Title("Object Services")]
    [Prefix("ObjectServices")]
    class ObjectServicesSamples : NorthwindBasedSample
    {
        [Category("CRUD Operations")]
        [Title("C - Create new Category named 'X'")]
        [Description("")]
        public void ObjectServices1()
        {
            Category c = new Category();

            c.CategoryName = "X";
            context.AddToCategories(c);
            ObjectDumper.Write(c);
            context.SaveChanges();
            ObjectDumper.Write(c);
        }

        [Category("CRUD Operations")]
        [Title("R - Read first category named 'X'")]
        [Description("")]
        public void ObjectServices2()
        {
            Category c = (from o in context.Categories where o.CategoryName == "X" select o).First();
            ObjectDumper.Write(c);
        }

        [Category("CRUD Operations")]
        [Title("U - Update category named 'X'")]
        [Description("")]
        public void ObjectServices3()
        {
            Category c = (from o in context.Categories where o.CategoryName == "X" select o).First();
            ObjectDumper.Write(c);
            c.Description = "Some description " + DateTime.Now.ToString();
            ObjectDumper.Write(c);
            context.SaveChanges();
        }

        [Category("CRUD Operations")]
        [Title("D - Delete all categories named 'X'")]
        [Description("")]
        public void ObjectServices4()
        {
            foreach (Category c in context.Categories.Where(c => c.CategoryName == "X"))
            {
                context.DeleteObject(c);
                ObjectDumper.Write(c);
            }
            context.SaveChanges();
            ObjectDumper.Write(from o in context.Categories where o.CategoryName == "X" select o);
        }
    }
}

