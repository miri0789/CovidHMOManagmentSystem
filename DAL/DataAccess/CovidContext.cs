using DAL.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataAccess
{
    public class CovidContext :DbContext
    {
        public CovidContext(DbContextOptions<CovidContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<VaccinationsCreator> VaccinationsCreators { get; set; }
        public DbSet<VaccinationsUser> VaccinationsUsers { get; set; } 
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<VaccinationsUser>().HasOne(v => v.User).WithMany(v => v.VaccinationsUsers).HasForeignKey(v=>v.UserId);
            builder.Entity<VaccinationsUser>().HasOne(v => v.Creator).WithMany(v => v.VaccinationsUsers).HasForeignKey(v=>v.CreatorId);
            builder.Entity<User>(entity => entity.HasIndex(e => e.Identity).IsUnique());


        }
    }
}
