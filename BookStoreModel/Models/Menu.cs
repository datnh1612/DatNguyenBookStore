using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreModel.Models
{
    [Table("Menu")]
    public class Menu
    {
        [Key]
        public string ID { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
