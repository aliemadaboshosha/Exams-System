using System;
using System.Collections.Generic;

namespace Examination.Models;

public partial class InstructorTrackCourse
{
    public int InstructorId { get; set; }

    public int TrackId { get; set; }

    public int CourseId { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual Instructor Instructor { get; set; } = null!;

    public virtual Track Track { get; set; } = null!;
}
