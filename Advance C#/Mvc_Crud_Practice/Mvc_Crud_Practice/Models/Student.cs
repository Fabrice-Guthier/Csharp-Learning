namespace Mvc_Crud_Practice.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
