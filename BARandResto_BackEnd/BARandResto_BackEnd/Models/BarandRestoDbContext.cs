using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BARandResto_BackEnd.Models;

public partial class BarandRestoDbContext : DbContext
{
    public BarandRestoDbContext()
    {
    }

    public BarandRestoDbContext(DbContextOptions<BarandRestoDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BAR_LOGIN> BAR_LOGIN { get; set; }   
}
