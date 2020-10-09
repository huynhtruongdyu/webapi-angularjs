using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace _1.Core.Domain
{
    public class ProductCategory : BaseEntity
    {
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }

        public string ImageUrl { get; set; }

        [DefaultValue(true)]
        public bool ShowOnMenu { get; set; }

        [DefaultValue(true)]
        public bool IsActive { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}