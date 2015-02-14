using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceAndPolymorphism
{
    public class Course
    {
        private string name;
        private IList<string> students = new List<string>(); 

        public Course(string name)
        {
            this.Name = name;
        }

        public Course(string name, string teacherName)
            :this(name)
        {
            this.TeacherName = teacherName;
        }

        public Course(string name, string teacherName, List<string> students)
            :this(name, teacherName)
        {
            this.Students = students;
        }

        public string Name {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name can not be null or empty");
                }

                this.name = value;
            } 
        }

        public string TeacherName { get; set; }

        public List<string> Students
        {
            get
            {
                return new List<string>(students);
            }
            set { this.students = value; }
        }

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

            result.Append("{ Name = " + this.Name);
            if (this.TeacherName != null)
            {
                result.Append("; Teacher = ");
                result.Append(this.TeacherName);
            }
            result.Append("; Students = ");
            result.Append(this.GetStudentsAsString());

            return result.ToString();
        }
    }
}
