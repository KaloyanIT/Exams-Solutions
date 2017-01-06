using System;

namespace ConsoleApplication3.Models.Human
{
    public abstract class Human : IHuman
    {
        private string firstName;
        private string lastName;

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("First name is null");
                }

                if (value.Length < 2 || value.Length > 31)
                {
                    throw new Exception("First name is not in valid length 2 and 31");
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Last name is null");
                }

                if (value.Length < 2 || value.Length > 31)
                {
                    throw new Exception("Last name is not in valid length 2 and 31");
                }

                this.lastName = value;
            }
        }
    }
}