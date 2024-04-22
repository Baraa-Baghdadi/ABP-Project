using Dawaa24Neo.ApiResponse;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Acme.FirstProjet.Providers.Mobile
{
    public interface IProviderMobileAppService : IApplicationService
    {
        Task<Response<ProviderDto>> ScanQR(string providerCode);
    }
}
