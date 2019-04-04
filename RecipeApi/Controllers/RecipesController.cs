using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipeApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController: ControllerBase
    {
        private readonly RecipeContext db;

        public RecipesController(RecipeContext db)
        {
            this.db = db;
        }
        [HttpGet]
        public IActionResult GetRecipes()
        {
            try
            {
               // throw new Exception("ohhohoh");
                return Ok(db.Recipes.Include(a=>a.Category).ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            //return Ok(new List<Recipe>());
        }
        [HttpGet("{id}")]
        public IActionResult GetRecipes(int id) //[FromQuery] int id
        {
            try
            {
                var recipe = db.Recipes.Include(a=>a.Category).SingleOrDefault(a => a.ID == id);
                if (recipe == null)
                {
                    return NotFound("Nie znaleziono");
                }
                return Ok(recipe);               
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
        public IActionResult AddRecipes(Recipe recipe)// [FromBody] Recipe recipe
        {
            try
            {
                if (ModelState.IsValid && CategoryExists(recipe.CategoryId))
                {
                    //TODO dodać walidację
                    db.Recipes.Add(recipe);
                    db.SaveChanges();
                    return CreatedAtAction(nameof(GetRecipes), new { id = recipe.ID }, recipe); //zwraca 201
                }
                return BadRequest("Błedne dane wejsciowe");

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            //return CreatedAtAction(nameof(GetRecipes), new { id = recipe.ID }, recipe); //zwraca 201
        }

        [HttpPut("{id}")]
        public IActionResult UpdateRecipes(int id, Recipe recipe)
        {
            try
            {
                if (ModelState.IsValid && CategoryExists(recipe.CategoryId))
                {
                    if (id < 0)
                    {
                        return BadRequest("id nie moze być mniejsze od 0");
                    }
                    var recipeToUpdate = db.Recipes.Find(id);
                    if (recipeToUpdate == null)
                    {
                        return NotFound("Nie znaleziono");
                    }
                    recipeToUpdate = recipe;
                    db.Update(recipeToUpdate);
                    db.SaveChanges();
                    return NoContent();
                }

                return BadRequest("Błędne dane wejściowe");
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
        public ActionResult<Recipe> DeleteRecipes(int id)
        {
            try
            {
                var recipeToDelete = db.Recipes.Find(id);
                if (recipeToDelete == null)
                {
                    return NotFound("Nie znaleziono");
                }
                db.Recipes.Remove(recipeToDelete);
                db.SaveChanges();
                return Ok(recipeToDelete);
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        private bool CategoryExists(int? id)
        {
            if (id == null)            
                return true;
            
            return db.Categories.Any(a => a.ID == id);
        }
    }
}
