using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
         * Get all notes
         */
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_categories);
        }

        [HttpGet("{id}")]
        public IActionResult GetCategory(string id)
        {
            if (_categories.Count > int.Parse(id))
                return Ok(_categories[int.Parse(id)]);
            return NotFound();
        }

        [HttpPost]
        public IActionResult CreateCategory([FromBody] Category category)
        {
            _categories.Add(category);
            return Ok(_categories);
        }

        [HttpDelete("id")]
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
