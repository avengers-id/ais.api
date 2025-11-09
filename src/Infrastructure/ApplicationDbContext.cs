using Application.Common;
using Domain.Entities;
using EntityFramework.Exceptions.PostgreSQL;
using Infrastructure.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastructure;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>, IContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Hero> Heroes { get; set; } = null!;
    public DbSet<Role> SystemRoles { get; set; } = null!;
    public DbSet<User> SystemUsers { get; set; } = null!;
    public DbSet<IdentityVerification> IdentityVerifications { get; set; } = null!;
    public DbSet<Stage> Stages { get; set; } = null!;
    public DbSet<Grade> Grades { get; set; } = null!;
    public DbSet<Generation> Generations { get; set; } = null!;
    public DbSet<SchoolYear> SchoolYears { get; set; } = null!;
    public DbSet<Student> Students { get; set; } = null!;
    public DbSet<SchoolYearStudent> SchoolYearStudents { get; set; } = null!;
    public DbSet<SchoolCalendar> SchoolCalendars { get; set; } = null!;
    public DbSet<NoteType> NoteTypes { get; set; } = null!;
    public DbSet<SchoolYearStudentNote> SchoolYearStudentNotes { get; set; } = null!;
    public DbSet<SchoolYearStudentNoteDetail> SchoolYearStudentNoteDetails { get; set; } = null!;
    public DbSet<HighlightType> HighlightTypes { get; set; } = null!;
    public DbSet<SchoolHighlight> SchoolHighlights { get; set; } = null!;
    public DbSet<SchoolSchedule> SchoolSchedules { get; set; } = null!;
    public DbSet<SchoolGuideline> SchoolGuidelines { get; set; } = null!;
    public DbSet<Employee> Employees { get; set; } = null!;
    public DbSet<SchoolYearEmployee> SchoolYearEmployees { get; set; } = null!;
    public DbSet<InvoiceType> InvoiceTypes { get; set; } = null!;
    public DbSet<SchoolYearInvoice> SchoolYearInvoices { get; set; } = null!;
    public DbSet<SchoolYearInvoiceStatement> SchoolYearInvoiceStatements { get; set; } = null!;
    public DbSet<RewardType> RewardTypes { get; set; } = null!;
    public DbSet<Reward> Rewards { get; set; } = null!;
    public DbSet<Saving> Savings { get; set; } = null!;
    public DbSet<SavingStatement> SavingStatements { get; set; } = null!;
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(HeroConfiguration).Assembly);
    }
}