using Business.Interface;
using Business.Manager;
using Entity.Context;
using Entity.Helper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Business
{
    public static class ServiceRegistration
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IStudentService, StudentManager>();
            services.AddScoped<IClassService, ClassManager>();
            services.AddScoped<ILogService, LogManager>();
        }
    }
}
