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

        [HttpGet("{id}")]
        public async Task<ActionResult<Note>> GetNoteById(int id)
        {
            var result = await _context.Notes!.Include(r => r.Tags).FirstOrDefaultAsync(r => r.Id == id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPost("new")]
        public async Task<ActionResult<string>> NewNote([FromBody] NoteDto request)
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
                return Ok($"created => {note.Title}");
            }
            return BadRequest();
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<string>> UpdateNote(int id, [FromBody]NoteDto update)
        {
            var note = await _context.Notes!.FirstOrDefaultAsync(r => r.Id == id);
            if (note != null)
            {}
            return BadRequest();
        }

    }
}