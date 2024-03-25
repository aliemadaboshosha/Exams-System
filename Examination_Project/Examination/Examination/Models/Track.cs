using System;
using System.Collections.Generic;

namespace Examination.Models;

public partial class Track
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<InstructorTrackCourse> InstructorTrackCourses { get; set; } = new List<InstructorTrackCourse>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    public virtual ICollection<TrackBranch> TrackBranches { get; set; } = new List<TrackBranch>();
}
