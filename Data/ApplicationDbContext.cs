using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NBSTimeReporting.Models.SettingModels;
using NBSTimeReporting.Models.DataModels;
using NBSTimeReporting.Models.AccountingModels;

namespace NBSTimeReporting.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<NBSTimeReporting.Models.SettingModels.PersonRole> PersonRole { get; set; }
        public DbSet<NBSTimeReporting.Models.SettingModels.PersonStatus> PersonStatus { get; set; }
        public DbSet<NBSTimeReporting.Models.SettingModels.PersonType> PersonType { get; set; }        
        public DbSet<NBSTimeReporting.Models.SettingModels.SiteRole> SiteRole { get; set; }
        public DbSet<NBSTimeReporting.Models.SettingModels.SiteStatus> SiteStatus { get; set; }
        public DbSet<NBSTimeReporting.Models.SettingModels.SiteType> SiteType { get; set; }
        public DbSet<NBSTimeReporting.Models.DataModels.Person> Person { get; set; }
        public DbSet<NBSTimeReporting.Models.DataModels.Company> Company { get; set; }
        public DbSet<NBSTimeReporting.Models.SettingModels.CompanyRole> CompanyRole { get; set; }
        public DbSet<NBSTimeReporting.Models.SettingModels.CompanyStatus> CompanyStatus { get; set; }
        public DbSet<NBSTimeReporting.Models.SettingModels.CompanyType> CompanyType { get; set; }
        public DbSet<NBSTimeReporting.Models.DataModels.Site> Site { get; set; }
        public DbSet<NBSTimeReporting.Models.SettingModels.TicketPriority> TicketPriority { get; set; }
        public DbSet<NBSTimeReporting.Models.SettingModels.TicketStatus> TicketStatus { get; set; }
        public DbSet<NBSTimeReporting.Models.SettingModels.TicketType> TicketType { get; set; }
        public DbSet<NBSTimeReporting.Models.DataModels.Ticket> Ticket { get; set; }
        public DbSet<NBSTimeReporting.Models.SettingModels.ReportStatus> ReportStatus { get; set; }
        public DbSet<NBSTimeReporting.Models.SettingModels.ReportType> ReportType { get; set; }
        public DbSet<NBSTimeReporting.Models.DataModels.Report> Report { get; set; }        
        public DbSet<NBSTimeReporting.Models.SettingModels.SurveyStatus> SurveyStatus { get; set; }
        public DbSet<NBSTimeReporting.Models.SettingModels.SurveyType> SurveyType { get; set; }
        public DbSet<NBSTimeReporting.Models.DataModels.Survey> Survey { get; set; }
        public DbSet<NBSTimeReporting.Models.SettingModels.AccountStatus> AccountStatus { get; set; }
        public DbSet<NBSTimeReporting.Models.AccountingModels.EmployeeAccount> EmployeeAccount { get; set; }
        public DbSet<NBSTimeReporting.Models.AccountingModels.WeeklyTimeReport> WeeklyTimeReport { get; set; }
        public DbSet<NBSTimeReporting.Models.AccountingModels.MonthlyTimeReport> MonthlyTimeReport { get; set; }
    }
}
