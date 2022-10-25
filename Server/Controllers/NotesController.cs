using blazing_notes.Shared.Models;
using blazing_notes.Server.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace blazing_notes.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotesController : ControllerBase
    {
        private readonly BlazingNotesDatabaseContext _context;

        public NotesController(BlazingNotesDatabaseContext context)
        {
            _context = context;
        }

        [HttpGet("all")]
        public async Task<ActionResult<Note[]>> GetNotes()
        {
            // TODO: Retrieve only pusblished
            var results = await _context.Notes!.Include(r => r.Tags).ToListAsync();
            if (results == null)
                return NotFound();
            return Ok(results);
        }

        [HttpPost("new")]
        public async Task<ActionResult<Note>> NewNote([FromBody] NoteDto request)
        {
            Note note = new Note(){
                Title = request.Title,
                Content = request.Content,
                Tags = request.Tags,
                Created = DateTime.UtcNow
            };
            if (ModelState.IsValid)
            {
                await _context.Notes!.AddAsync(note);
                await _context.SaveChangesAsync();
                return Ok(note);
            }
            return BadRequest();
        }
    }
}