using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public NotesController() { }

        [HttpGet]
        public IActionResult Get([FromHeader(Name = "User-Agent")] string Accept)
        {
            return Ok(Accept);
        }

        [HttpGet("id")]
        public IActionResult GetOne(string id)
        {
            return Ok("Note controller works" + id);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Note note)
        {
            return Ok(note.Title);
        }
    }

}

