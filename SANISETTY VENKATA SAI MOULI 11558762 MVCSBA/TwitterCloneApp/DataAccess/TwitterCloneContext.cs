namespace DataAccess
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TwitterCloneContext : DbContext
    {
        public TwitterCloneContext()
            : base("name=TwitterCloneContext")
        {
        }

        public virtual DbSet<FOLLOWING> FOLLOWINGs { get; set; }
        public virtual DbSet<PERSON> People { get; set; }
        public virtual DbSet<TWEET> TWEETs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FOLLOWING>()
                .Property(e => e.user_id)
                .IsUnicode(false);

            modelBuilder.Entity<FOLLOWING>()
                .Property(e => e.following_id)
                .IsUnicode(false);

            modelBuilder.Entity<PERSON>()
                .Property(e => e.user_id)
                .IsUnicode(false);

            modelBuilder.Entity<PERSON>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<PERSON>()
                .Property(e => e.fullname)
                .IsUnicode(false);

            modelBuilder.Entity<PERSON>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<PERSON>()
                .HasMany(e => e.FOLLOWINGs)
                .WithRequired(e => e.PERSON)
                .HasForeignKey(e => e.user_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PERSON>()
                .HasMany(e => e.FOLLOWINGs1)
                .WithRequired(e => e.PERSON1)
                .HasForeignKey(e => e.following_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PERSON>()
                .HasMany(e => e.TWEETs)
                .WithRequired(e => e.PERSON)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TWEET>()
                .Property(e => e.user_id)
                .IsUnicode(false);

            modelBuilder.Entity<TWEET>()
                .Property(e => e.message)
                .IsUnicode(false);
        }
    }
}
