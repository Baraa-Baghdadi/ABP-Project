using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Acme.FirstProjet.SMS
{
    public interface ISmsAppService : IApplicationService
    {
        Task<bool> SendSmsMessage(string mobileNumber, string message);
    }
}
