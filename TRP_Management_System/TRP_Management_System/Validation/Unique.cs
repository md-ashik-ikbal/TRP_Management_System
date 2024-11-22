using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TRP_Management_System.EF;

namespace TRP_Management_System.Validation
{
    public class Unique : ValidationAttribute
    {
        private readonly TRP_Management_System_Entities entitiy = new TRP_Management_System_Entities();

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("Required!");
            }
            else if (entitiy.Channels.FirstOrDefault(c => c.ChannelName == value.ToString()) == null)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Channel is already exist!");
            }
        }
    }
}