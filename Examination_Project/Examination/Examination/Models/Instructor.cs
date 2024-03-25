using System;
using System.Collections.Generic;

namespace Examination.Models;

public partial class Instructor
{
    public int Id { get; set; }

    public string Fname { get; set; } = null!;

    public string Lname { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Street { get; set; } = null!;

    public string City { get; set; } = null!;

    public DateOnly DateOfBirth { get; set; }

    public decimal Salary { get; set; }

    public int BranchId { get; set; }

    public virtual Branch Branch { get; set; } = null!;

    public virtual ICollection<InstructorTrackCourse> InstructorTrackCourses { get; set; } = new List<InstructorTrackCourse>();

    public virtual ICollection<TrackBranch> TrackBranches { get; set; } = new List<TrackBranch>();
}
