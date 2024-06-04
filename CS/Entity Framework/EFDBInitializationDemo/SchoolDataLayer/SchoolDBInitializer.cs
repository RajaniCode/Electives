using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

using SchoolDomainClasses;

namespace SchoolDataLayer
{
    public class SchoolDBInitializer : DropCreateDatabaseAlways<SchoolDBContext>
    {
        protected override void Seed(SchoolDBContext context)
        {
            IList<Standard> defaultStandards = new List<Standard>();

            defaultStandards.Add(new Standard() { StandardName = "Standard 1", Description = "First Standard" });
            defaultStandards.Add(new Standard() { StandardName = "Standard 2", Description = "Second Standard" });
            defaultStandards.Add(new Standard() { StandardName = "Standard 3", Description = "Third Standard" });

            foreach (Standard std in defaultStandards)
                context.Standards.Add(std);

            //All standards will
            base.Seed(context);
        }
        
    }
}
