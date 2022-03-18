using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        private List<Category> _categories = new List<Category> { new Category { Id = "0", Name = "To Do" }, new Category {Id="1", Name="Done" },
        new Category{ Id="2", Name="To Be Done"}
        };

        /*
         * Summary
         * Get all categories
         */
        [HttpGet]
        [ProducesResponseType(200)]
        public IActionResult Get()
        {
            return Ok(_categories);
        }

        /*
         * 
         * Summary
         * Get category by id
         * 
         */
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult GetCategory(string id)
        {
            if (_categories.Count > int.Parse(id))
                return Ok(_categories[int.Parse(id)]);
            return NotFound();
        }

        /*
         * Summary
         * Create category
         */
        [HttpPost]
        [ProducesResponseType(200)]
        public IActionResult CreateCategory([FromBody] Category category)
        {
            _categories.Add(category);
            return Ok(_categories);
        }

        /*
         * Summary
         * Delete category
         */
        [HttpDelete("id")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult DeleteCategory(string id)
        {
            if (int.Parse(id) >= _categories.Count)
            {
                return NotFound("Index sent larger than or equal to array length (" + _categories.Count + ")");
            }
            return Ok(_categories.Where(category => !category.Id.Equals(id)).ToList());
        }
    }
}
