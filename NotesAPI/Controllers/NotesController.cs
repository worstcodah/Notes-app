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


        private INoteCollectionService _noteCollectionService;


        public NotesController(INoteCollectionService noteCollectionService)
        {
            _noteCollectionService = noteCollectionService ??
                throw new ArgumentNullException(nameof(noteCollectionService));
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetNotes()
        {
            List<Note> notes = await _noteCollectionService.GetAll();
            return Ok(notes);

        }


        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetNote(Guid id)//  string id)
        {
            var note = await _noteCollectionService.Get(id);
            if (note is null)
                return NotFound();
            return Ok(note);

        }


        [HttpGet("owner/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetNotesByOwner(Guid id)
        {
            var foundNotes = await _noteCollectionService.GetNotesByOwnerId(id);
            if (foundNotes is null)
            {
                return NotFound();
            }
            return Ok(foundNotes);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Note note)
        {
            await _noteCollectionService.Create(note);
            return Ok(await _noteCollectionService.GetAll());
        }

        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateNote(Guid id, [FromBody] Note note)
        {
            if (await _noteCollectionService.Update(id, note))
            {
                return Ok("Update successful!");
            }
            return NotFound();
        }
        /*
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
        */
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNote(Guid id)
        {
            if (await _noteCollectionService.Delete(id))
            {
                return Ok("Delete successful!");
            }
            return NotFound();
        }
        /*
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
        */

    }

}

