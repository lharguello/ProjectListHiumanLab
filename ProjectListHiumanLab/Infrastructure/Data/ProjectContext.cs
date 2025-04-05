using Microsoft.EntityFrameworkCore;
using ProjectListHiumanLab.Domain.Entities;

namespace ProjectListHiumanLab.Infrastructure.Data;

public class ProjectContext : DbContext
{
    public ProjectContext(DbContextOptions<ProjectContext> options) : base(options) { }

    public DbSet<Project> Projects { get; set; }
}