using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotesAPI.Models;
using NotesAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private static List<Note> _notes = new List<Note> { new Note { Id = new Guid("00000000-0000-0000-0000-000000000001"), CategoryId = "1", OwnerId = new Guid("00000000-0000-0000-0000-000000000001"), Title = "First Note", Description = "First Note Description" },
        new Note { Id = new Guid("00000000-0000-0000-0000-000000000002"), CategoryId = "1", OwnerId = new Guid("00000000-0000-0000-0000-000000000001"), Title = "Second Note", Description = "Second Note Description" },
        new Note { Id = new Guid("00000000-0000-0000-0000-000000000003"), CategoryId = "1", OwnerId = new Guid("00000000-0000-0000-0000-000000000001"), Title = "Third Note", Description = "Third Note Description" },
        new Note { Id = new Guid("00000000-0000-0000-0000-000000000004"), CategoryId = "1", OwnerId = new Guid("00000000-0000-0000-0000-000000000001"), Title = "Fourth Note", Description = "Fourth Note Description" },
        new Note { Id = new Guid("00000000-0000-0000-0000-000000000005"), CategoryId = "1", OwnerId = new Guid("00000000-0000-0000-0000-000000000001"), Title = "Fifth Note", Description = "Fifth Note Description" }
        };

        private INoteCollectionService _noteCollectionService;


        public NotesController(INoteCollectionService noteCollectionService)
        {
            _noteCollectionService = noteCollectionService ??
                throw new ArgumentNullException(nameof(noteCollectionService));
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public IActionResult GetNotes()
        {
            List<Note> notes = _noteCollectionService.GetAll();
            return Ok(notes);

        }


        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult GetNote(Guid id)//  string id)
        {
            var note = _noteCollectionService.Get(id);
            if (note is null)
                return NotFound();
            return Ok(note);

        }


        [HttpGet("owner/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult GetNotesByOwner(Guid id)
        {
            var foundNotes = _noteCollectionService.GetNotesByOwnerId(id);
            if(foundNotes is null)
            {
                return NotFound();
            }
            return Ok(foundNotes);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Note note)
        {
            _notes.Add(note);
            //var locationHeader = HttpContext.Request.Headers["Location"];
            // return Ok(note.Title);
            //return CreatedAtRoute(locationHeader, new { Id = note.Id, Title = note.Title });
            return Ok(_notes);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult UpdateNote(Guid id, [FromBody] Note note)
        {
            if (_noteCollectionService.Update(id, note))
            {
                return Ok("Update successful!");
            }
            return NotFound();
        }
        [HttpPut("{noteId},{ownerId}")]
        public IActionResult UpdateNoteByOwner(Guid noteId, Guid ownerId, [FromBody] Note note)
        {
            if (note == null)
            {
                return BadRequest("Note cannot be null");
            }
            var noteIndex = _notes.FindIndex((listNote) => listNote.Id.Equals(noteId) && listNote.OwnerId.Equals(ownerId));
            if (noteIndex != -1)
            {
                _notes[noteIndex] = note;
                return Ok(_notes);
            }
            //return NotFound();
            //_notes.Add(note);
            note.Id = noteId;
            Post(note);
            return Ok(_notes);
        }


        [HttpDelete("{noteId},{ownerId}")]
        public IActionResult DeleteNote(Guid noteId, Guid ownerId)
        {
            var noteIndex = _notes.FindIndex((listNote) => listNote.Id.Equals(noteId) && listNote.OwnerId.Equals(ownerId));
            if (noteIndex != -1)
            {
                _notes.RemoveAt(noteIndex);
                return Ok(_notes);
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteNote(Guid id)
        {
            if (_noteCollectionService.Delete(id))
            {
                return Ok("Delete successful!");
            }
            return NotFound();
        }

        [HttpDelete("owner/{ownerId}")]
        public IActionResult DeleteNotesByOwner(Guid ownerId)
        {
            var ownerNotes = _notes.Where((note) => !note.OwnerId.Equals(ownerId)).ToList();
            if (ownerNotes.Count.Equals(_notes.Count))
            {
                return NotFound();
            }
            return Ok(ownerNotes);
        }


    }

}

