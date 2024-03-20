using System;
using System.Collections.Generic;

namespace Examination.Models;

public partial class Topic
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int CourseId { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();
}
