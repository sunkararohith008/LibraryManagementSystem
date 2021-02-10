using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace LibraryManagementSystem.Models.ApplicationModels
{
    public partial class DataContext : DbContext
    {
        public DataContext()
            : base("name=DataContext")
        {
        }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<IssueBook> IssueBooks { get; set; }
        public virtual DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .Property(e => e.Gender)
                .IsFixedLength();

            modelBuilder.Entity<Student>()
                .Property(e => e.ContactNumber)
                .IsFixedLength();
        }
    }
}
