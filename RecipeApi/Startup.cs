﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RecipeApi.Models;

namespace RecipeApi
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<RecipeContext>(o => o.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<RecipeContext>(o => o.UseSqlite(configuration.GetConnectionString("SQLiteConnection")));

            services.AddMvcCore()
                .AddDataAnnotations()
                .AddJsonFormatters()
                .AddJsonOptions(o => o.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented); // dodaj mvc
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts(); //wymuszanie ssl czyli połączenie certyfikowane; sprawdzanie czasu requesta, przerwanie połaczenia w razie zbyt długiego czasu
            }

            app.UseMvc(); // dodaj mvc

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Nie znaleziono API.");
            });
        }
    }
}
