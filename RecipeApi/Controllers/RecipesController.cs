﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApi.Controllers
{
    [Route("api/[controller]")]
    public class RecipesController: ControllerBase
    {
        [HttpGet]
        public string GetRecipes()
        {
            return "Recipes";
        }
        [HttpGet("{id}")]
        public string GetRecipes(int id)
        {
            return $"Recipes {id}";
        }
    }
}
