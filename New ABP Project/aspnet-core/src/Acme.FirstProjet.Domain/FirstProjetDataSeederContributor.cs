using Acme.Basket.Baskets;
using Acme.FirstProjet.Otps;
using Acme.FirstProjet.Patients;
using Dawaa24Neo.Providers;
using Dawaa24Neo.SharedDomains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;
using Volo.Abp.Identity;
using Volo.Abp.Uow;

namespace Acme.BookStore
{
    public class FirstProjetDataSeederContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IGuidGenerator _guidGenerator;
        private readonly IdentityUserManager _identityUserManager;
        private readonly PatientManager _patientManager;
        private readonly IRepository<Product> _productRepo;
        private readonly IRepository<Otp,Guid> _otpRepository;
        IRepository<Currency, Guid> _currencyRepo;
        IRepository<City, int> _cityRepo;
        IRepository<Country, int> _countruRepo;
      
        public FirstProjetDataSeederContributor(IGuidGenerator guidGenerator, IdentityUserManager identityUserManager,
            IRepository<Product> productRepo,
            IRepository<Currency, Guid> currencyRepo,
            IRepository<City, int> cityRepo,
            IRepository<Country, int> countruRepo,
            IRepository<Otp, Guid> otpRepository,
            PatientManager patientManager)
        {
            _guidGenerator = guidGenerator;
            _identityUserManager = identityUserManager;
            _productRepo = productRepo;
            _currencyRepo = currencyRepo;
            _cityRepo = cityRepo;
            _countruRepo = countruRepo;
            _otpRepository = otpRepository;
            _patientManager = patientManager;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            await SeedCategoryAsync();
            await DawaaSeedAsync();
        }

        [UnitOfWork]
        private async Task SeedCategoryAsync()
        {
            if (await _productRepo.GetCountAsync() <= 0)
            {
                await _productRepo.InsertAsync(new Product(_guidGenerator.Create(), "Boats1", "Desc for Boats1", 100));
                await _productRepo.InsertAsync(new Product(_guidGenerator.Create(), "Boats2", "Desc for Boats2", 200));
                await _productRepo.InsertAsync(new Product(_guidGenerator.Create(), "Boats3", "Desc for Boats3", 300));
                await _productRepo.InsertAsync(new Product(_guidGenerator.Create(), "Boats4", "Desc for Boats4", 400));
            }
        }

        [UnitOfWork]
        private async Task DawaaSeedAsync()
        {
            List<Currency> currencyList = new List<Currency>
            {
                Currency.Create("ISO 4217",2,"AED"),
                Currency.Create("ISO 4217",2,"SAR")
            };
            if (await _currencyRepo.GetCountAsync() <= 0)
            {
                await _currencyRepo.InsertManyAsync(currencyList);
            }
           

            List<City> cityList = new List<City>
            {
                City.Create(name : "Dubai")
            };
            if (await _cityRepo.GetCountAsync() <= 0)
            {
                await _cityRepo.InsertManyAsync(cityList);
            }


            List<Country> countryList = new List<Country>
            {
                Country.Create(name:"United Arab Emirates",iSOCode2:"AE",iSOCode3:"UAE",currencyId:currencyList[0].Id)
            };
            if (await _countruRepo.GetCountAsync() <= 0)
            {
                await _countruRepo.InsertManyAsync(countryList);
            }

            /* For mobile default account */

            if (await _otpRepository.CountAsync() == 0)
            {
                await _otpRepository.InsertAsync(new Otp(_guidGenerator.Create(),"+963932912812","1111"),autoSave:true);
            };

            if ((await _identityUserManager.FindByNameAsync("+963932912812")) is null)  
            {
                IdentityUser newUser = new IdentityUser(_guidGenerator.Create(), "+963932912812", "+963932912812@email.com", null);
                newUser.SetIsActive(true);
                await _identityUserManager.CreateAsync(newUser, "P@ssw0rd");
                await _patientManager.CreateAsync("932912812", "+963", "1A2B3C");
            }

            /* End */
        }

    }
}
