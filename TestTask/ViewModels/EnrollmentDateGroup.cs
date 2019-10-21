using System;
using System.ComponentModel.DataAnnotations;

namespace TestTask.ViewModels
{
    public class EnrollmentDateGroup
    {
        [DataType(DataType.Date)]
        public DateTime? DateOfRegister { get; set; }

        public int ClientCount { get; set; }
    }
}