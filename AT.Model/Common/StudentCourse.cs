using AT.IModel.Common;

namespace AT.Model.Common
{
    public class StudentCourse : IEntity
    {
        public int Id {get; set;}
        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}