using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BindingtoCLRObjectCS
{
    class Data
    {
        public Data(string name, string age, string profile, string id,
         params string[] names)
        {
            this.name = name;
            this.age = age;
            this.profile = profile;
            this.id = id;
            foreach (string Employee in names)
            {
                this.names.Add(name);
            }
        }
        public Data()
            : this("", "", "", "")
        {
        }
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string age;
        public string Age
        {
            get { return age; }
            set { age = value; }
        }
        private string profile;
        public string Profile
        {
            get { return profile; }
            set { profile = value; }
        }
        private string id;
        public string EmployeeID
        {
            get { return id; }
            set { id = value; }
        }
        public override string ToString()
        {
            return name;
        }
        private readonly List<string> names = new List<string>();
        public string[] Names
        {
            get { return names.ToArray(); }
        }
    }
}
