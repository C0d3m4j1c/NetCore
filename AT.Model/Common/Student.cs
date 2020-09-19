
using System.Collections.Generic;
using AT.IModel.Common;

namespace AT.Model.Common
{
    public class Student : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IList<StudentCourse> StudentCourses { get; set; }
    }

}