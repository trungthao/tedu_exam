﻿using System.IO;
using System.Reflection;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Identity.API.Factories
{
    public class ConfigurationDbContextFactory : IDesignTimeDbContextFactory<ConfigurationDbContext>
    {
        public ConfigurationDbContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
               .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
               .AddJsonFile("appsettings.json")
               .AddEnvironmentVariables()
               .AddUserSecrets(Assembly.GetAssembly(typeof(Program)))
               .Build();

            var optionsBuilder = new DbContextOptionsBuilder<ConfigurationDbContext>();
            var storeOptions = new ConfigurationStoreOptions();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"), sqlServerOptionsAction: o => o.MigrationsAssembly(typeof(Program).Assembly.FullName));


            return new ConfigurationDbContext(optionsBuilder.Options, storeOptions);
        }
    }
}