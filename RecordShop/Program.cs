using Microsoft.EntityFrameworkCore;
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
                    options.UseInMemoryDatabase("RecordShopMemory");
                }

                // Add services to the container.

                builder.Services.AddControllers();
                // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
                builder.Services.AddEndpointsApiExplorer();
                builder.Services.AddSwaggerGen();

                var app = builder.Build();

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

                void SeedData(RecordShopDbContext dbContext)
                {
                    if (!dbContext.Artists.Any())
                    {
                        dbContext.Artists.AddRange(new Artist
                        {
                            Name = "The Beatles"
                        },
                        new Artist
                        {
                            Name = "ABBA"
                        });

                        dbContext.SaveChanges();
                    }

                    if (!dbContext.Genres.Any())
                    {
                        dbContext.Genres.AddRange(new Genre
                        {
                            Name = "Rock"
                        },
                        new Genre
                        {
                            Name = "Pop"
                        });

                        dbContext.SaveChanges();
                    }
                }
        }
    }
}

