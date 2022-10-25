using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace Server.Context
{
    public class BlazingNotesDatabaseContext : DbContext
    {
        public BlazingNotesDatabaseContext(DbContextOptions options):base(options)
        {}

        public DbSet<Note>? Notes { get; set; }
    }
}