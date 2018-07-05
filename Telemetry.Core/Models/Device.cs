using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Telemetry.Core.Models
{
    [Table("Devices")]
    public class Device : Base
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 0)]
        public int DeviceId { get; set; }

        [Required]
        [StringLength(20)]
        [Column(Order = 1)]
        public string DeviceName { get; set; }

        [Required]
        [Column(Order = 2)]
        public Category Category { get; set; }

        [Required]
        [StringLength(255)]
        [Column(Order = 3)]
        public string Description { get; set; }

        public List<DeviceData> DeviceData { get; set; }
    }

    public enum Category
    {
      Internal =1,
      External =2
    }
}
