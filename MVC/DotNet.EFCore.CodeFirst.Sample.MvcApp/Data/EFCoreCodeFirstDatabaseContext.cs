﻿using DotNet.EFCore.CodeFirst.Sample.Library.Constants;
using DotNet.EFCore.CodeFirst.Sample.MvcApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNet.EFCore.CodeFirst.Sample.MvcApp.Data
{
    /// <summary>
    /// Entity Framework Database Context
    /// </summary>
    public class EFCoreCodeFirstDatabaseContext : DbContext
    {
        /// <summary>
        /// Constructor to initialize the Context Class
        /// </summary>
        public EFCoreCodeFirstDatabaseContext()
        {
        }

        /// <summary>
        /// Constructor to initialize the Context Class with DBContextOptions arguments.
        /// </summary>
        /// <param name="options">DB Context Options</param>
        public EFCoreCodeFirstDatabaseContext(DbContextOptions<EFCoreCodeFirstDatabaseContext> options)
            : base(options)
        {   
        }

        /// <summary>
        /// Department Class DbSet
        /// </summary>
        public virtual DbSet<Department> Departments { get; set; } = null!;
        /// <summary>
        /// Employee Class DbSet
        /// </summary>
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        /// <summary>
        /// EmployeeSkill Class DbSet
        /// </summary>
        public virtual DbSet<EmployeeSkill> EmployeeSkills { get; set; } = null!;
        /// <summary>
        /// Skill Class DbSet
        /// </summary>
        public virtual DbSet<Skill> Skills { get; set; } = null!;

        /// <summary>
        /// Overriding the Configuration of DBContext with sql server connection.
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var builder = new ConfigurationBuilder().AddJsonFile(WebConstants.ConfigurationFileName, false, true);
                var configuration = builder.Build();
                var connectionString = configuration.GetConnectionString(WebConstants.ConnectionName);
                
                optionsBuilder.UseSqlServer(connectionString, options => options.EnableRetryOnFailure());
            }
        }

        /// <summary>
        /// Overriding the model builder and entity configurations.
        /// </summary>
        /// <param name="modelBuilder">Model Builder</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
