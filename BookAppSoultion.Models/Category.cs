using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookAppSolution.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        public int DisplayOrder { get; set; }

        public DateTime CreatedDateTime { get; set; } = DateTime.Now;

        public Category(int Id, string Name, int DisplayOrder)
        {
            this.Id = Id;
            this.Name = Name;
            this.DisplayOrder = DisplayOrder;
        }

        public Category()
        {

        }

    }
}
