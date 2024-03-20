using System;
using System.Collections.Generic;

namespace Examination.Models;

public partial class Course
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Exam> Exams { get; set; } = new List<Exam>();

    public virtual ICollection<InstructorTrackCourse> InstructorTrackCourses { get; set; } = new List<InstructorTrackCourse>();

    public virtual ICollection<Topic> Topics { get; set; } = new List<Topic>();
}
