using Microsoft.EntityFrameworkCore;
using blazing_notes.Shared.Models;

namespace blazing_notes.Server.Context
{
    public class BlazingNotesDatabaseContext : DbContext
    {
        public BlazingNotesDatabaseContext(DbContextOptions options):base(options)
        {}

        public DbSet<Note>? Notes { get; set; }
    }
}