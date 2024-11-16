
using UdemyCarBook.Application.Features.CQRS.Commands.AboutCommands;
using UdemyCarBook.Application.Features.CQRS.Handlers.AboutHandlers;
using UdemyCarBook.Application.Features.CQRS.Handlers.BannerHandlers;
using UdemyCarBook.Application.Features.CQRS.Handlers.BrandHandlers;
using UdemyCarBook.Application.Features.CQRS.Handlers.CarHandlers;
using UdemyCarBook.Application.Features.CQRS.Handlers.CategoryHandler;
using UdemyCarBook.Application.Features.CQRS.Handlers.ContactHandlers;
using UdemyCarBook.Application.Features.RepositoryPattern;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Application.Interfaces.BlogInderfaces;
using UdemyCarBook.Application.Interfaces.CarInterfaces;
using UdemyCarBook.Application.Interfaces.CarPricingInterfaces;
using UdemyCarBook.Application.Interfaces.TagCloudInterfaces;
using UdemyCarBook.Application.Services;
using UdemyCarBook.Persistance.Context;
using UdemyCarBook.Persistance.Repositories;
using UdemyCarBook.Persistance.Repositories.BlogRepositories;
using UdemyCarBook.Persistance.Repositories.CarPricingRepositories;
using UdemyCarBook.Persistance.Repositories.CarRepositories;
using UdemyCarBook.Persistance.Repositories.CommentRepositories;
using UdemyCarBook.Persistance.Repositories.TagCloudRepositories;

namespace UdemyCarBook.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped<CarBookContext>();
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddScoped<ICarRepository, CarRepository>();
            builder.Services.AddScoped<IBlogRepository, BlogRepository>();
            builder.Services.AddScoped<ICarPricingRepository, CarPricingRepository>();
            builder.Services.AddScoped<ITagCloudRepository, TagCloudRepository>();
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(CommentRepository<>));

            builder.Services.AddScoped<GetAboutQueryHandler>();
            builder.Services.AddScoped<GetAboutByIdQueryHandler>();
            builder.Services.AddScoped<CreateAboutCommandHandler>();
            builder.Services.AddScoped<UpdateAboutCommandHandler>();
            builder.Services.AddScoped<RemoveAboutCommandHandler>();
            builder.Services.AddScoped<GetBannerQueryHandler>();
            builder.Services.AddScoped<GetBannerByIdQueryHandler>();
            builder.Services.AddScoped<CreateBannerCommandHandler>();
            builder.Services.AddScoped<UpdateBannerCommandHandler>();
            builder.Services.AddScoped<RemoveBannerCommandHandler>();
            builder.Services.AddScoped<GetBrandQueryHandler>();
            builder.Services.AddScoped<GetBrandByIdQueryHandler>();
            builder.Services.AddScoped<CreateBrandCommandHandler>();
            builder.Services.AddScoped<UpdateBrandCommandHandler>();
            builder.Services.AddScoped<RemoveBrandCommandHandler>();
            builder.Services.AddScoped<GetCarQueryHandler>();
            builder.Services.AddScoped<GetCarByIdQueryHandler>();
            builder.Services.AddScoped<GetCarWithBrandQueryHandler>();
            builder.Services.AddScoped<GetLast5CarWithBrandQueryHandler>();
            builder.Services.AddScoped<CreateCarCommandHandler>();
            builder.Services.AddScoped<UpdateCarCommandHandler>();
            builder.Services.AddScoped<RemoveCarCommandHandler>();
            builder.Services.AddScoped<GetCategoryQueryHandler>();
            builder.Services.AddScoped<GetCategoryByIdQueryHandler>();
            builder.Services.AddScoped<CreateCategoryCommandHandler>();
            builder.Services.AddScoped<UpdateCategoryCommandHandler>();
            builder.Services.AddScoped<RemoveCategoryCommandHandler>();
            builder.Services.AddScoped<GetContactQueryHandler>();
            builder.Services.AddScoped<GetContactByIdQueryHandler>();
            builder.Services.AddScoped<CreateContactCommandHandler>();
            builder.Services.AddScoped<UpdateContactCommandHandler>();
            builder.Services.AddScoped<RemoveContactCommandHandler>();


            // Add services to the container.
            builder.Services.AddApplicationService(builder.Configuration);
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
        }
    }
}
