using System;
using System.Collections.Generic;

namespace Examination.Models;

public partial class TrackBranch
{
    public int BranchId { get; set; }

    public int TrackId { get; set; }

    public int SupervisorId { get; set; }

    public virtual Branch Branch { get; set; } = null!;

    public virtual Instructor Supervisor { get; set; } = null!;

    public virtual Track Track { get; set; } = null!;
}
