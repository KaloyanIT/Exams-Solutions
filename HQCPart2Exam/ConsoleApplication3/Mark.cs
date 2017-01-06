using System;
using ConsoleApplication3.Enums;

namespace ConsoleApplication3
{
    public class Mark
    {
        private float markValue;

        public Mark(Subject subject, float markValue)
        {
            this.Subject = subject;
            this.MarkValue = markValue;
        }

        public float MarkValue
        {
            get
            {
                return this.markValue;
            }

            set
            {
                if (value == 0)
                {
                    throw new ArgumentNullException();
                }

                if (value < 2 || value > 6)
                {
                    throw new Exception("Invalid mark");
                }

                this.markValue = value;
            }
        }

        public Subject Subject { get; set; }
    }
}
