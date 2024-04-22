using Acme.FirstProjet.Providers.Mobile;
using Dawaa24Neo.ApiResponse;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Acme.FirstProjet.Patients.Mobile
{
    public interface IPatientMobileAppService
    {
        #region patientAddress
        Task<Response<PagedResultDto<PatientAddressDto>>> GetAddressListAsync(GetPatientAddressInput input);
        Task<Response<PatientAddressDto>> CreateAddressAsync(PatientAddressCreateDto input);
        Task<Response<PatientAddressDto>> UpdateAddressAsync(PatientAddressUpdateDto input);
        Task<Response<PatientAddressDto>> GetAddressAsync(Guid id);
        Task<Response<bool>> SetAddressAsDefault(Guid addressId);
        Task<Response<bool>> DeleteAddress(Guid id);

        #endregion

        #region PatientProvider
        Task<Response<bool>> AddToMyPharmacy(PatientProviderCreateDto input);
        Task<Response<PagedResultDto<PharmacyInfoDto>>> GetMyPharmacies(GetPatientOfProviderForMobile input);
        Task<Response<PharmacyInfoDto>> GetProviderAsync(Guid id);
        #endregion
    }
}
