using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreModel.Models
{
    [Table("MenuGroups")]
    public class MenuGroup
    {
        [Key]
        public string ID { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
