using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer
{
    public class Category
    {
        [Key]
        public int ProductID { get; set; }
        [Required]

        public string ProductName { get; set; }
        [DisplayName("Display Order")]
        public int DisplayOrder { get; set; }
        public DateTime GetDateTime { get; set; } = DateTime.Now;
    }
}
