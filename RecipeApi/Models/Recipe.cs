using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApi.Models
{
    public class Recipe
    {
        public int ID { get; set; }
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }
        //[MaxLength(100)]      
        //public string Category { get; set; }
        public string Image { get; set; }
        [Required(ErrorMessage ="Body jest wymagane")]
        public string Body { get; set; }
        public virtual Category Category { get; set; }
        public int? CategoryId { get; set; }


    }
}
