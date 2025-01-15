using Microsoft.EntityFrameworkCore;
using RecordShop.Model;
using RecordShop.Services;
using System;

namespace RecordShop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<RecordShopDbContext>(options =>
            {
                if (builder.Environment.IsDevelopment())
                {
                    // Use In-Memory Database for development
                    options.UseInMemoryDatabase("RecordShopInMemory");
                }
            });

                // Add services to the container.

                builder.Services.AddControllers();
                // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
                builder.Services.AddEndpointsApiExplorer();
                builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IAlbumService, AlbumService>();
            builder.Services.AddScoped<IAlbumRepository, AlbumRepository>();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<RecordShopDbContext>();
                dbContext.Database.EnsureCreated();
            }

                // Configure the HTTP request pipeline.
                if (app.Environment.IsDevelopment())
                {
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }

                app.UseHttpsRedirection();

                app.UseAuthorization();


                app.MapControllers();

                app.Run();




            
        
        }
    }
}

