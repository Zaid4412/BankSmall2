using Microsoft.EntityFrameworkCore;
using BankSmall.Models;

namespace BankSmall.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        //public DbSet<DepartmentId> Departments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // فلتر لإخفاء المستخدمين المحذوفين بشكل افتراضي
            modelBuilder.Entity<User>().HasQueryFilter(u => !u.Deleted);

            // إذا لديك علاقات، مثلاً:
            //modelBuilder.Entity<User>()
            //    .HasOne<DepartmentId>()  // أو HasOne(u => u.Department) إذا لديك خاصية Navigation
            //    .WithMany()
            //    .HasForeignKey(u => u.Department)
            //    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
