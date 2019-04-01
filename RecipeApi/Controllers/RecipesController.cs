using Microsoft.AspNetCore.Mvc;
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
        [HttpGet]
        public IActionResult GetRecipes()
        {
            return Ok(new List<Recipe>());
        }
        [HttpGet("{id}")]
        public IActionResult GetRecipes(int id)
        {
            return Ok(new Recipe
            {
                ID = 1,
                Body = "oki",
            });
        }
    }
}
