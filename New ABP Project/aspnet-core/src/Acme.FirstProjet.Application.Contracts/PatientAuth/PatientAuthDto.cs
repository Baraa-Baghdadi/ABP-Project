using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Acme.FirstProjet.PatientAuth
{
    public class PatientAuthDto
    {
        [Required]
        public string? CountryCode { get; set; }
        [Required]
        public string? MobileNumber { get; set; }
        [Required]
        public string? Code { get; set; }
    }
}
