using System;
using System.Collections.Generic;
using System.Text;

namespace Acme.FirstProjet.PatientAuth
{
    public class PatientLoginDto
    {
        public string? CountryCode { get; set; }
        public string? MobileNumber { get; set; }
    }
}
