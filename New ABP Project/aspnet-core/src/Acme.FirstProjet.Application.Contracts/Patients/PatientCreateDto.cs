using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Acme.FirstProjet.Patients
{
    public class PatientCreateDto
    {
        [Required]
        public string MobileNumber { get; set; } = null!;
        [Required]
        public string CountryCode { get; set; } = null!;
    }
}
