using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _1.Core.Domain
{
    public class Product : BaseEntity
    {
        [Required]
        [MaxLength(250)]
        [Column(TypeName = "NVARCHAR")]
        public string Name { get; set; }

        public string SortDescription { get; set; }
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string ImageUrl { get; set; }
        public int Stock { get; set; }

        [DefaultValue(true)]
        public bool IsActive { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }
    }
}