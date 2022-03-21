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
        private List<Owner> _owners = new List<Owner> { new Owner { Id = new Guid("00000000-0000-0000-0000-000000000001"), Name="A" },
        new Owner {  Id = new Guid("00000000-0000-0000-0000-000000000002"), Name="B"} };

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

        [HttpPut("{id}")]
        public IActionResult UpdateOwner(Guid id, [FromBody] Owner owner)
        {
            if (owner is null)
            {
                return BadRequest();
            }
            var ownerIndex = _owners.FindIndex((owner) => owner.Id.Equals(id));
            if (ownerIndex != -1)
            {
                _owners[ownerIndex] = owner;
                return Ok(_owners);
            }
            CreateOwner(owner);

            return Ok(_owners);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOwner(Guid id)
        {
            var ownerIndex = _owners.FindIndex((owner) => owner.Id.Equals(id));
            if (ownerIndex != -1)
            {
                _owners.RemoveAt(ownerIndex);
                return Ok(_owners);
            }
            return NotFound();
        }

    }
}
