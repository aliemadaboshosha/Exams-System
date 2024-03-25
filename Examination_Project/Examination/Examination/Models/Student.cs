using System;
using System.Collections.Generic;

namespace Examination.Models;

public partial class Student
{
    public int Id { get; set; }

    public string Fname { get; set; } = null!;

    public string Lname { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Street { get; set; }

    public string? City { get; set; }

    public DateOnly DateOfBirth { get; set; }

    public int BranchId { get; set; }

    public int TrackId { get; set; }

    public virtual Branch Branch { get; set; } = null!;

    public virtual ICollection<StudentExamAnswer> StudentExamAnswers { get; set; } = new List<StudentExamAnswer>();

    public virtual ICollection<StudentExam> StudentExams { get; set; } = new List<StudentExam>();

    public virtual Track Track { get; set; } = null!;
}
