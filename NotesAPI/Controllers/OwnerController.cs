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
        public async Task<IActionResult> GetOwner(Guid id)
        {
            var result = await _ownerCollectionService.Get(id);
            if (result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }


        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetOwners()
        {
            return Ok(await _ownerCollectionService.GetAll());
        }



        [HttpPost]
        [ProducesResponseType(200)]
        public async Task<IActionResult> CreateOwner([FromBody] Owner owner)
        {

            var create = await _ownerCollectionService.Create(owner);
            if (create is false)
            {
                return BadRequest($"An object with the id {owner.Id} already exists");
            }
            return Ok(await _ownerCollectionService.GetAll());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOwner(Guid id, [FromBody] Owner owner)
        {
            if (owner is null)
            {
                return BadRequest();
            }

            var update = await _ownerCollectionService.Update(id, owner);
            if (update is false)
            {
                return NotFound();
            }
            return Ok(await _ownerCollectionService.GetAll());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOwner(Guid id)
        {
            var delete = await _ownerCollectionService.Delete(id);
            if (delete is false)
            {
                return NotFound();
            }
            return Ok(await _ownerCollectionService.GetAll());
        }

    }
}
