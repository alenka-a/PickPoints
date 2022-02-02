using System.ComponentModel.DataAnnotations;

namespace PickPoints.Core.Entities
{
    public class Postamp : BaseEntity
    {
        [Required]
        [StringLength(8)]
        public string Number { get; set; }

        [Required]
        public string Address { get; set; }

        public bool IsActive { get; set; }
    }
}
