using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Data;
using Volo.Abp.MultiTenancy;

namespace Acme.FirstProjet.Patients
{
  [Authorize]
  public class PatientAppService : ApplicationService, IPatientAppService
    {
        private readonly IPatientProviderRepository _patientProviderRepository;
        private readonly IDataFilter _dataFilter;
        public PatientAppService(IPatientProviderRepository patientProviderRepository, IDataFilter dataFilter)
        {
                _patientProviderRepository = patientProviderRepository;
                _dataFilter = dataFilter;
        }



        [Authorize]
        public async Task<PagedResultDto<PatientProviderDto>> GetAllPatientsOfProviderAsync(GetPatientInput input)
        {
            var totalCount = await _patientProviderRepository.GetCountAsync(input.FilterText, input.MobileNumber, input.CountryCode);
            var items = await _patientProviderRepository.GetListAsync(input.FilterText, input.MobileNumber, input.CountryCode,
                input.Sorting, input.MaxResultCount, input.SkipCount);
            return new PagedResultDto<PatientProviderDto>
            {
              TotalCount = totalCount,
              Items = ObjectMapper.Map<List<PatientProvider>, List<PatientProviderDto>>(items)
            };
        }

        [Authorize]
        public async Task<PatientProviderDto> GetPatientsOfProviderAsync(Guid id)
            {
                var patientProvider = await _patientProviderRepository.GetAsync(id);
                return ObjectMapper.Map<PatientProvider,PatientProviderDto>(patientProvider);
            }
        }
}
