using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Examination.Models;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;
    [DataType(DataType.Password)]// added after scaffolding
    public string? Password { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
}
