using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DVUProject.Models.Entity
{
    [Table("Product")]
    public class Product
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "You are required to enter a name.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Category is required")]
        public int CategoryId { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive value.")] 
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Quantity is required")] 
        public int Quantity { get; set; } 
        public bool IsActive {  get; set; }


    }
}
