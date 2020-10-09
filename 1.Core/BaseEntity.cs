using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _1.Core
{
    public abstract class BaseEntity
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedDateOnUtc { get; set; }

        public DateTime? UpdatedDateOnUtc { get; set; }

        public BaseEntity()
        {
            this.CreatedDateOnUtc = DateTime.UtcNow;
        }
    }
}