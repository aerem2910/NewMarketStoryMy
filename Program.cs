using Autofac;
using Autofac.Extensions.DependencyInjection;
using LessonThree.Abstractions;
using LessonThree.GraphQL;
using LessonThree.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using StoreMarket.Abstractions;
using StoreMarket.Context;
using StoreMarket.Mappers;
using StoreMarket.Services;
using HotChocolate.AspNetCore;

namespace LessonThree
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<StoreContext>();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

            builder.Services.AddSingleton<IProductService, ProductService>()
                           .AddSingleton<ICategoryService, CategoryService>();

            builder.Services.AddAutoMapper(typeof(MappingProfile));

            builder.Services.AddMemoryCache(m => m.TrackStatistics = true);
            builder.Services.AddGraphQLServer();
            var app = builder.Build();
            app.MapGraphQL();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.Run();
        }
    }
}
