using Acme.Basket.Baskets;
using Acme.FirstProjet.Carts;
using Acme.FirstProjet.Otps;
using Acme.FirstProjet.Patients;
using Acme.FirstProjet.Providers;
using Dawaa24Neo;
using Dawaa24Neo.SharedDomains;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;
using static System.Net.WebRequestMethods;

namespace Acme.FirstProjet.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class FirstProjetDbContext :
    AbpDbContext<FirstProjetDbContext>,
    IIdentityDbContext,
    ITenantManagementDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */

    #region Entities from the modules

    /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityDbContext and ITenantManagementDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    //Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }
    public DbSet<IdentityUserDelegation> UserDelegations { get; set; }

    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion
    public DbSet<Cart> Carts { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<Product> Products { get; set; }

    // second section:
    public DbSet<PatientProvider> PatientProviders { get; set; } = null!;
    public DbSet<WorkingTime> WorkingTimes { get; set; } = null!;
    public DbSet<Provider> Providers { get; set; } = null!;
    public DbSet<Otp> Otps { get; set; }
    public DbSet<PatientAddress> PatientAddresses { get; set; } = null!;
    public DbSet<Patient> Patients { get; set; } = null!;
    public DbSet<Country> Countries { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Currency> Currencies { get; set; }
    public DbSet<VerficationCode> VerficationCodes { get; set; }
    public FirstProjetDbContext(DbContextOptions<FirstProjetDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();

        /* Configure your own tables/entities inside here */

        //builder.Entity<YourEntity>(b =>
        //{
        //    b.ToTable(FirstProjetConsts.DbTablePrefix + "YourEntities", FirstProjetConsts.DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    //...
        //});



        if (builder.IsHostDatabase())
        {
                builder.Entity<Cart>(b =>
                {
                    b.ToTable("Carts");
                    b.ConfigureByConvention();
                    b.HasMany(p => p.Items).WithOne().HasForeignKey(p => p.CartId).IsRequired();
                });
            }

            if (builder.IsHostDatabase())
            {
                builder.Entity<Item>(b =>
                {
                    b.ToTable("Items");
                    b.ConfigureByConvention();
                    b.HasOne<Cart>().WithMany(p => p.Items).HasForeignKey(p => p.CartId).IsRequired()
                    .OnDelete(DeleteBehavior.NoAction);
                    b.HasOne<Product>(p => p.Product).WithMany(p => p.Items).HasForeignKey(p => p.ProductId).IsRequired()
                    .OnDelete(DeleteBehavior.NoAction);
                });
            }

            if (builder.IsHostDatabase())
            {
                builder.Entity<Product>(b =>
                {
                    b.ToTable("Products");
                    b.ConfigureByConvention();
                });
            }


            // second section:


            builder.Entity<PatientAddress>(b =>
            {
                b.ToTable(Dawaa24NeoConsts.DbTablePrefix + "PatientAddresses", Dawaa24NeoConsts.DbSchema);
                b.ConfigureByConvention();
                b.HasOne<Patient>().WithMany(x => x.PatientAddresses).HasForeignKey(x => x.PatientId).IsRequired().OnDelete(DeleteBehavior.NoAction);
            });


            // WorkingTimes
            builder.Entity<WorkingTime>(b =>
            {
                b.ToTable(Dawaa24NeoConsts.DbTablePrefix + "WorkingTimes", Dawaa24NeoConsts.DbSchema);
                b.ConfigureByConvention();
                b.HasOne<Provider>().WithMany(x => x.WorkingTimes).HasForeignKey(x => x.ProviderId).IsRequired().OnDelete(DeleteBehavior.NoAction);
            });

            builder.Entity<Patient>(b =>
            {
                b.ToTable(Dawaa24NeoConsts.DbTablePrefix + "Patients", Dawaa24NeoConsts.DbSchema);
                b.ConfigureByConvention();
                b.HasMany(p => p.PatientAddresses).WithOne().HasForeignKey(x => x.PatientId).IsRequired().OnDelete(DeleteBehavior.NoAction);
            });
            builder.Entity<PatientProvider>(b =>
            {
                b.ToTable(Dawaa24NeoConsts.DbTablePrefix + "PatientProviders", Dawaa24NeoConsts.DbSchema);
                b.ConfigureByConvention();
            });

            builder.Entity<Otp>(b =>
            {
                b.ToTable(Dawaa24NeoConsts.DbTablePrefix + "Otps", Dawaa24NeoConsts.DbSchema);
                b.ConfigureByConvention();
            });


            builder.Entity<Provider>(b =>
            {
                b.ToTable(Dawaa24NeoConsts.DbTablePrefix + "Providers", Dawaa24NeoConsts.DbSchema);
                b.ConfigureByConvention();
                // For value object:
                b.OwnsOne(x => x.LocationInfo);
                b.Property(x => x.Email).HasColumnName(nameof(Provider.Email)).IsRequired();
                b.Property(x => x.PharmacyName).HasColumnName(nameof(Provider.PharmacyName)).IsRequired();
                b.Property(x => x.PharmacyPhone).HasColumnName(nameof(Provider.PharmacyPhone)).IsRequired();
                b.HasMany(x => x.WorkingTimes).WithOne().HasForeignKey(x => x.ProviderId).IsRequired().OnDelete(DeleteBehavior.NoAction);
            });


            builder.Entity<Currency>(b =>
            {
                b.ToTable(Dawaa24NeoConsts.DbTablePrefix + "Currencies", Dawaa24NeoConsts.DbSchema);
                b.ConfigureByConvention();
            });

            builder.Entity<City>(b =>
            {
                b.ToTable(Dawaa24NeoConsts.DbTablePrefix + "Cities", Dawaa24NeoConsts.DbSchema);
                b.ConfigureByConvention();
            });

            builder.Entity<Country>(b =>
            {
                b.ToTable(Dawaa24NeoConsts.DbTablePrefix + "Countries", Dawaa24NeoConsts.DbSchema);
                b.ConfigureByConvention();
            });

            builder.Entity<VerficationCode>(b =>
            {
                b.ToTable(Dawaa24NeoConsts.DbTablePrefix + "VerficationCodes", Dawaa24NeoConsts.DbSchema);
                b.ConfigureByConvention();
            });

            // For enable MultiTenancy in this table:
            builder.Entity<PatientProvider>().HasQueryFilter(e => e.Provider!.TenantId == CurrentTenant.Id);
  }
}

