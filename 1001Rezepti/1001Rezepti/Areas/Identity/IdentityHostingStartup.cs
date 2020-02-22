using System;
using _1001Rezepti.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(_1001Rezepti.Areas.Identity.IdentityHostingStartup))]
namespace _1001Rezepti.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<RecepieContext>()
                .AddErrorDescriber<CustomIdentityErrorDescriber>();
            });
        }
    }
}