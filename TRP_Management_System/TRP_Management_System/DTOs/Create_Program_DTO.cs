using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TRP_Management_System.DTOs
{
    public class Create_Program_DTO
    {
        public string ProgramName {  get; set; }
        public int TRPScore { get; set; }
        public TimeSpan AirTime { get; set; }
    }
}