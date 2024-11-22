using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TRP_Management_System.Validation;

namespace TRP_Management_System.DTOs
{
    public class Create_Channel_DTO
    {
        [Required]
        [MaxLength(100)]
        [Unique]
        public string ChannelName { get; set; }

        [Required]
        [CheckYear(1900)]
        public int? EstablishedYear { get; set; } = null;

        [Required]
        [MaxLength(50)]
        public string Country { get; set; }
    }
}