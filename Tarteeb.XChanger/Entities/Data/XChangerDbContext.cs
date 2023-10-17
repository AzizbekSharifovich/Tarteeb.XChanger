//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using Microsoft.EntityFrameworkCore;
using Tarteeb.XChanger.Models;

namespace Tarteeb.XChanger.Entities.Data;

public class XChangerDbContext : DbContext
{
    public XChangerDbContext(DbContextOptions<XChangerDbContext> options) : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<ExternalApplicantModel> ExternalApplicants { get; set; }
}
