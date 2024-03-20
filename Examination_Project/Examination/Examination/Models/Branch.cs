using System;
using System.Collections.Generic;

namespace Examination.Models;

public partial class Branch
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? BuildingNumber { get; set; }

    public string? Street { get; set; }

    public string? City { get; set; }

    public virtual ICollection<Instructor> Instructors { get; set; } = new List<Instructor>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    public virtual ICollection<TrackBranch> TrackBranches { get; set; } = new List<TrackBranch>();
}
