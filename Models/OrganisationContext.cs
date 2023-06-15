using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Organization.Models;

namespace Organization.Models;

public partial class OrganisationContext : DbContext
{
    public OrganisationContext()
    {
    }

    public OrganisationContext(DbContextOptions<OrganisationContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    public virtual DbSet<Organization.Models.Department>? Department { get; set; }

    public virtual DbSet<Organization.Models.Employee>? Employee { get; set; }

    public virtual DbSet<Organization.Models.Product>? Product { get; set; }

    public virtual DbSet<Organization.Models.Customer>? Customer { get; set; }

    public virtual DbSet<Organization.Models.Project>? Project { get; set; }



}
