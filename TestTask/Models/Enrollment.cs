using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TestTask.Models
{
    public enum Payed
    {
        YES, NO
    }
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int OrganizationID { get; set; }
        public int ClientID { get; set; }
        public Payed? Payed { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual Client Client { get; set; }
    }
}