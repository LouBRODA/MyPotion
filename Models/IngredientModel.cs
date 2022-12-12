using Microsoft.Net.Http.Headers;
using MyPotion.Models;
using System.ComponentModel.DataAnnotations;

namespace MyPotion.Models
{
    public class IngredientModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "ERR : Name limit : 20 tempers !")]
        public string Name { get; set; }

        //[Required(ErrorMessage = "ERR : Image is mandatory !")]
        public string Image { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "ERR : Name limit : 50 tempers !")]
        public string Effect { get; set; }

        [Required]
        public Boolean Special { get; set; }
    }

}