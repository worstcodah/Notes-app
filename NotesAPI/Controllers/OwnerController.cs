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
    public class OwnerController : ControllerBase
    {
        private List<Owner> _owners = new List<Owner>();

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult GetOwner(string id)
        {
            if (_owners.Count > int.Parse(id))
                return Ok(_owners[int.Parse(id)]);
            return NotFound();
        }

        [HttpPost]
        [ProducesResponseType(200)]
        public IActionResult CreateOwner([FromBody] Owner owner)
        {
            _owners.Add(owner);
            return Ok(_owners);
        }
    }
}
