using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotesAPI.Models;
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
        private List<Note> _notes = new List<Note> 
        { new Note { Id = Guid.NewGuid(), OwnerId = new Guid("124ad338-b6a7-4abf-a49d-1669e653fa82"), 
            CategoryId = "1", Description = "desc", Title = "title" } };
        public NotesController() { }

        [HttpGet]
        [ProducesResponseType(200)]
        public IActionResult GetNotes()
        {
            return Ok(_notes);
        }


        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult GetNote(string id)
        {
            if (_notes.Count > int.Parse(id))
                return Ok(_notes[int.Parse(id)]);
            //CreatedAtRoute(routeName: "sd", routeValues: new {id:id } , _notes[int.Parse(id)]);
            return NotFound();
        }

        [HttpGet("owner/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult GetNoteByOwner(Guid id)
        {
            var foundNote = _notes.Where(note => note.OwnerId.Equals(id));
            if (foundNote is null)
                return NotFound();
            return Ok(foundNote);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Note note)
        {
            return Ok(note.Title);
        }
    }

}

