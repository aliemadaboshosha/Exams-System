using System;
using System.Collections.Generic;

namespace Examination.Models;

public partial class StudentExamAnswer
{
    public int StudentId { get; set; }

    public int ExamId { get; set; }

    public int QuestionId { get; set; }

    public byte StudentAnswer { get; set; }

    public virtual Exam Exam { get; set; } = null!;

    public virtual Question Question { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
