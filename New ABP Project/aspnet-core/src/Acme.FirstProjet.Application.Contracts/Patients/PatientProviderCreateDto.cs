using Dawaa24Neo.Patients;
using System;
using System.Collections.Generic;
using System.Text;

namespace Acme.FirstProjet.Patients
{
    public class PatientProviderCreateDto
    {
        public Guid ProviderId { get; set; }
        public PatientAddingType AddingType { get; set; } = ((PatientAddingType[])Enum.GetValues(typeof(PatientAddingType)))[0];
    }
}
