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
    public class OwnerController : ControllerBase
    {
        private OwnerCollectionService _ownerCollectionService;

        public OwnerController(ICollectionService<Owner> collectionService)
        {
            _ownerCollectionService = collectionService as OwnerCollectionService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult GetOwner(Guid id)
        {
            var result = _ownerCollectionService.Get(id);
            if(result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }


        [HttpGet]
        [ProducesResponseType(200)]
        public IActionResult GetOwners()
        {
            return Ok(_ownerCollectionService.GetAll());
        }



        [HttpPost]
        [ProducesResponseType(200)]
        public IActionResult CreateOwner([FromBody] Owner owner)
        {
            var create = _ownerCollectionService.Create(owner);
            if(create is false)
            {
                return BadRequest($"An object with the id {owner.Id} already exists" );
            }
            return Ok(_ownerCollectionService.GetAll());
        }

        [HttpPut("{id}")]
        public IActionResult UpdateOwner(Guid id, [FromBody] Owner owner)
        {
            if (owner is null)
            {
                return BadRequest();
            }

            var update = _ownerCollectionService.Update(id, owner);
            if(update is false)
            {
                return NotFound();
            }
            return Ok(_ownerCollectionService.GetAll());
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOwner(Guid id)
        {
            var delete = _ownerCollectionService.Delete(id);
            if(delete is false)
            {
                return NotFound();
            }
            return Ok(_ownerCollectionService.GetAll());
        }

    }
}
