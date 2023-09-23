using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }//Primary Key
        [Required]
        [MaxLength(30,ErrorMessage ="Name Must be within 30 character limit")]
        [DisplayName("Category Name")]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1,1000,ErrorMessage ="Please entert Display Value between 1-1000 \n please try again")]
        public int DisplayOrder { get; set; }
    }
}
