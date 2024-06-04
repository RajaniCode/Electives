using System;
using System.Collections.Generic;
using System.Text;

namespace CommonGenericOperations
{
    public class Person
    {
        public Person()
        {

        }

        public Person(int id, string first_name, string mid_name, string last_name, short age, char sex)
        {
            this.p_id  = id;
            this.first_name = first_name;
            this.mid_name = mid_name;
            this.last_name = last_name;
            this.p_age = age;
            this.p_sex = sex;
        }

        private int p_id = -1;
        private string first_name = String.Empty;
        private string mid_name = String.Empty;
        private string last_name = String.Empty;
        private short p_age = 0;
        private char? p_sex = null;


        public int ID
        {
            get
            {
                return p_id;
            }
            set
            {
                p_id = value;
            }
        }

        public string FirstName
        {
            get
            {
                return first_name;
            }
            set
            {
                first_name = value;
            }

        }

        public string MiddleName
        {
            get
            {
                return mid_name;
            }
            set
            {
                mid_name = value;
            }
        }

        public string LastName
        {
            get
            {
                return last_name;
            }
            set
            {
                last_name = value;
            }
        }

        public short Age
        {
            get
            {
                return p_age;
            }
            set
            {
                p_age = value;
            }
        }

        public char? Sex
        {
            get
            {
                return p_sex;
            }
            set
            {
                p_sex = value;
            }
        }
    }   
}
