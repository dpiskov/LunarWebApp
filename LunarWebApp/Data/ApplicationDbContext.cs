using LunarWebApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LunarWebApp.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
    {
        public DbSet<Notebook> Notebooks { get; set; }
        public DbSet<Folder> Folders { get; set; }
        public DbSet<Note> Notes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Notebook>()
                .HasMany(n => n.Folders)
                .WithOne(f => f.Notebook)
                .HasForeignKey(f => f.NotebookId);

            modelBuilder.Entity<Notebook>()
                .HasMany(n => n.Notes)
                .WithOne(note => note.Notebook)
                .HasForeignKey(note => note.NotebookId);

            modelBuilder.Entity<Folder>()
                .HasMany(f => f.Folders)
                .WithOne(pf => pf.ParentFolder)
                .HasForeignKey(pf => pf.ParentFolderId);

            modelBuilder.Entity<Folder>()
                .HasMany(f => f.Notes)
                .WithOne(n => n.Folder)
                .HasForeignKey(n => n.FolderId);

            base.OnModelCreating(modelBuilder);
        }
    }
}