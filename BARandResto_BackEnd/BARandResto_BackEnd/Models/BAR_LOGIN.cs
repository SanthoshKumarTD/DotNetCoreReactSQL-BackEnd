using System;
using System.Collections.Generic;

namespace BARandResto_BackEnd.Models;

public partial class BAR_LOGIN
{
    public int Id { get; set; }

    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;
}
