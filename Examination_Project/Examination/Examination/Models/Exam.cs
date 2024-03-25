using System;
using System.Collections.Generic;

namespace Examination.Models;

public partial class Exam
{
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public decimal Duration { get; set; }

    public int CourseId { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual ICollection<StudentExamAnswer> StudentExamAnswers { get; set; } = new List<StudentExamAnswer>();

    public virtual ICollection<StudentExam> StudentExams { get; set; } = new List<StudentExam>();

    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();
}
