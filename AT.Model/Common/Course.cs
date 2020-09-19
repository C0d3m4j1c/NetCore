using AT.IModel.Common;
using System.Collections.Generic;

namespace AT.Model.Common
{
    public class Course : IEntity
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }

        public IList<StudentCourse> StudentCourses { get; set; }
    }
}