using System;

namespace Methods
{
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OtherInfo { get; set; }

        public bool IsOlderThan(Student otherStudent)
        {
            DateTime thisStudentDate =
                DateTime.Parse(this.OtherInfo.Substring(this.OtherInfo.Length - 10));
            DateTime otherStudentDate =
                DateTime.Parse(otherStudent.OtherInfo.Substring(otherStudent.OtherInfo.Length - 10));
            return thisStudentDate > otherStudentDate;
        }
    }
}
