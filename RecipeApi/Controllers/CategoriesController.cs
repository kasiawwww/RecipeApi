using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeApi.Models;

namespace RecipeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly RecipeContext db;

        public CategoriesController(RecipeContext db)
        {
            this.db = db;
        }
        [HttpGet]
        public IActionResult GetCategories()
        {
            try
            {
                // throw new Exception("ohhohoh");
                return Ok(db.Categories.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            //return Ok(new List<Recipe>());
        }
        [HttpGet("{id}")]
        public IActionResult GetCategories(int id) //[FromQuery] int id
        {
            try
            {
                var category = db.Categories.SingleOrDefault(a => a.ID == id);
                if (category == null)
                {
                    return NotFound("Nie znaleziono");
                }
                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            //return Ok(new Recipe
            //{
            //    ID = 1,
            //    Body = "oki",
            //});
        }

        [HttpPost]
        public IActionResult AddCategories(Category category)// [FromBody] Recipe recipe
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //TODO dodać walidację
                    db.Categories.Add(category);
                    db.SaveChanges();
                    return CreatedAtAction(nameof(GetCategories), new { id = category.ID }, category); //zwraca 201
                }
                return BadRequest("Błedne dane wejsciowe");

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            //return CreatedAtAction(nameof(GetCategories), new { id = recipe.ID }, recipe); //zwraca 201
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCategories(int id, Category category)
        {
            try
            {
                if (id < 0)
                {
                    return BadRequest("id nie moze być mniejsze od 0");
                }
                var categoryToUpdate = db.Categories.Find(id);
                if (categoryToUpdate == null)
                {
                    return NotFound("Nie znaleziono");
                }
                categoryToUpdate = category;
                db.Update(categoryToUpdate);
                db.SaveChanges();
                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            //if (id < 0)
            //{
            //    return BadRequest();
            //}
            //return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<Category> DeleteCategories(int id)
        {
            try
            {
                var categoryToDelete = db.Categories.Find(id);
                if (categoryToDelete == null)
                {
                    return NotFound("Nie znaleziono");
                }
                db.Categories.Remove(categoryToDelete);
                db.SaveChanges();
                return Ok(categoryToDelete);

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}