using System;
using System.Collections.Generic;

namespace Examination.Models;

public partial class MultiChoicesQuestionAnswer
{
    public int QuestionId { get; set; }

    public int NumberOfChoice { get; set; }

    public string BodyOfChoice { get; set; } = null!;

    public virtual Question Question { get; set; } = null!;
}
