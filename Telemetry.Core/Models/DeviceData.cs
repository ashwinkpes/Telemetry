using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Telemetry.Core.Models
{
    [Table("DeviceData")]
    public class DeviceData : Base
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DeviceDataId { get; set; }

        public float? Temperature { get; set; }

        public float? Humidity { get; set; }

        [Required]
        public string Severity { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        //Foreign properties
        public int DeviceId { get; set; }

        public virtual Device Device { get; set; }

    }
}
