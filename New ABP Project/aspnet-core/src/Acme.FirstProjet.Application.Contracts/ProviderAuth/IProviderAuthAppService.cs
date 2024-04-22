using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Acme.FirstProjet.ProviderAuth
{
    public interface IProviderAuthAppService : IApplicationService
    {
        public Task<bool> Register(ProviderRegisterInfoDto input);
        public Task SendVerificationEmail(string email,string pharmacyName,string tenantName);
        public Task SendWelcomeEmail(string email,Guid providerId,string pharmacyName,string tenantName);
        public Task<bool> Verify(VerifyCodeDto input);
        public Task ResendVerficationEmail(string targetEmail);
        public MemoryStream downloadQrCode();
    }
}
