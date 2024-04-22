using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Acme.FirstProjet.Patients
{
    public class Patient : FullAuditedAggregateRoot<Guid>
    {
        public string PatientId { get; set; }
        public virtual string?  MobileNumber { get; set; }
        public virtual string?  CountryCode { get; set; }
        public ICollection<PatientAddress>? PatientAddresses { get; set; }
        public ICollection<PatientProvider>? PatientProviders { get; set; }

        protected Patient() { }

        public Patient(Guid id,string mobileNumber,string countryCode, string patientId)
        {
            Id = id;
            MobileNumber = mobileNumber;
            CountryCode = countryCode;
            PatientId = patientId;
        }

    }
}
