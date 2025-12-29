using Application.Interfaces;
using Application.Services;
using Domain.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class DependencyInjection
    {
        public static void Register(IServiceCollection services)
        {



            //// Services
            services.AddScoped<IUserService, UserService>();
           

          
        }
    }
}
