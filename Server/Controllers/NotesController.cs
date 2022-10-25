using blazing_notes.Shared.Models;
using blazing_notes.Server.Context;
using Microsoft.AspNetCore.Mvc;

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