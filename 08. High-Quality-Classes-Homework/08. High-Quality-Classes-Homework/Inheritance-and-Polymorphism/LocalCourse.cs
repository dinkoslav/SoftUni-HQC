using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceAndPolymorphism
{
    public class LocalCourse : Course
    {
        public LocalCourse(string courseName)
            : base(courseName)
        {
        }

        public LocalCourse(string courseName, string teacherName)
            :base(courseName, teacherName)
        {
        }

        public LocalCourse(string courseName, string teacherName, List<string> students)
            :base(courseName, teacherName, students)
        {
        }

        public string Lab { get; set; }

        private string GetStudentsAsString()
        {
            if (this.Students == null || this.Students.Count == 0)
            {
                return "{ }";
            }
            else
            {
                return "{ " + string.Join(", ", this.Students) + " }";
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("LocalCourse " + base.ToString());
            if (this.Lab != null)
            {
                result.Append("; Lab = ");
                result.Append(this.Lab);
            }

            result.Append(" }");
            return result.ToString();
        }
    }
}
