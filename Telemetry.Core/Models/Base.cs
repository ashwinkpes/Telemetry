using System;
using System.ComponentModel.DataAnnotations;

namespace Telemetry.Core.Models
{
    public abstract class Base
    {
        [Required]
        [StringLength(20)]
        public string CreatedBy { get; set; }

        [Required]
        public DateTime Createdtime { get; set; }

        [StringLength(20)]
        public string UpdatedBy { get; set; }

        public DateTime? Updatedtime { get; set; }
    }
}
