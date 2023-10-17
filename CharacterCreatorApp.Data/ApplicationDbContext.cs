using CharacterCreatorApp.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CharacterCreatorApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<UserEntity, IdentityRole<int>, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) {}

        public DbSet<WarriorCharacterClassEntity> Warriors {get; set;}
        public DbSet<WizardCharacterClassEntity> Wizards {get; set;}
        public DbSet<RogueCharacterClassEntity> Rogues {get; set;}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserEntity>().ToTable("Users");
            

        }
    }
}