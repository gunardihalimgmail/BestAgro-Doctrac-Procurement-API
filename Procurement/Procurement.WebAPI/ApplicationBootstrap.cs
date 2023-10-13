using AutoMapper;
using BestAgroCore.Common.Domain;
using BestAgroCore.CrossCutting;
using BestAgroCore.CrossCutting.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Procurement.Domain.Aggregate.ApprovalOP;
using Procurement.Domain.Aggregate.ApprovalTTIS;
using Procurement.Domain.Aggregate.Penutupan;
using Procurement.Infrastructure;
using Procurement.Infrastructure.Repositories;
using Procurement.Infrastructure.Repositories.ApprovalOP;
using Procurement.Infrastructure.Repositories.ApprovalTTIS;
using Procurement.Infrastructure.Repositories.Penutupan;
using Procurement.WebAPI.Application.Commands.ApprovalOP;
using Procurement.WebAPI.Application.Commands.ApprovalTTIS;
using Procurement.WebAPI.Application.Commands.Penutupan;
using Procurement.WebAPI.Application.Queries;
using Procurement.WebAPI.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Procurement.WebAPI
{
    public static class ApplicationBootstrap
    {

        public static IServiceCollection InitBootstraper(this IServiceCollection services, IConfiguration configuration)
        {
            services.InitBestAgroBootstrap_v2()
                .RegisterEf()
                .AddDbContext<ProcurementContext>(options =>
                        options.UseSqlServer(configuration.GetConnectionString("JVE")));

            return services;
        }

        public static IServiceCollection InitAppServices(this IServiceCollection services)
        {
            #region Command
            // add scope for command handler
            services.AddScoped<IDt_ApprovalOPRepository, Dt_ApprovalOPRepository>();
            services.AddScoped<IPs_SppRepository, Ps_SppRepository>();
            services.AddScoped<IPs_OPRepository, Ps_OPRepository>();
            services.AddScoped<IPs_PenutupanRepository, Ps_PenutupanRepository>();
            services.AddScoped<IInv_PengeluaranBarangKeCabangLainRepository, Inv_PengeluaranBarangKeCabangLainRepository>();
            services.AddScoped<IPs_TTISRepository, Ps_TTISRepository>();
            #endregion

            #region Query
            // add scope for query
            services.AddScoped<IOPApprovalQueries, OPApprovalQueries>();
            services.AddScoped<IPenutupanQueries, PenutupanQueries>();
            services.AddScoped<ITTISApprovalQueries, TTISApprovalQueries>();
            services.AddScoped<IListOPQueries, ListOPQueries>();
            #endregion

            return services;
        }

        public static IServiceCollection InitEventHandlers(this IServiceCollection services)
        {
            services.AddTransient<ICommandHandler<UpdateApprovalOPCommand>, UpdateApprovalOPCommandHandler>();
            services.AddTransient<ICommandHandler<UpdatePenutupanCommand>, UpdatePenutupanCommandHandler>();
            services.AddTransient<ICommandHandler<UpdateApprovalTTISCommand>, UpdateApprovalTTISCommandHandler>();
            services.AddTransient<ICommandHandler<UpdateMultipleApprovalTTISCommand>, UpdateMultipleApprovalTTISCommandHandler>();

            return services;
        }


        //public static IServiceCollection InitMapperProfile(this IServiceCollection services)
        //{
        //    var mapperConfig = new MapperConfiguration(cfg =>
        //    {
        //        cfg.AddProfile(new CommandToEventMapperProfile());
        //        cfg.AddProfile(new CommandToDomainMapperProfile());

        //    });

        //    services.AddSingleton(provider => mapperConfig.CreateMapper());

        //    return services;
        //}



    }
}
