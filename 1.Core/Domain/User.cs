using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _1.Core.Domain
{
    public class User : BaseEntity
    {
        [Required]
        [MaxLength(250)]
        [Column(TypeName = "VARCHAR")]
        public string Email { get; set; }

        [Required]
        [MaxLength(250)]
        [Column(TypeName = "VARCHAR")]
        public string Password { get; set; }

        [MaxLength(250)]
        [Column(TypeName = "NVARCHAR")]
        public string DisplayName { get; set; }

        [DefaultValue(true)]
        public bool IsActive { get; set; }

        [DefaultValue(false)]
        public bool IsStaff { get; set; }
    }
}