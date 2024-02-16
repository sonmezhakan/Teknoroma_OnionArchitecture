using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;
using Teknoroma.Persistence.DependencyResolvers;
namespace Teknoroma.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            
            //DbContext Service
            builder.Services.AddDbContextServiceRegistration();

            //Repository  DependencyInjection
            builder.Services.AddRegisterServiceRegistration();

            //Auto Mapper Service
            builder.Services.AddAutoMapperServiceRegistration();

            //Email Service
            builder.Services.AddEmailServiceRegistration();

            //builder.Services.AddMediatR(Assembly.GetExecutingAssembly());   
            builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            //JWT Configuration
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,

                    ValidateAudience = true,

                    ValidateLifetime = true,

                    ValidateIssuerSigningKey = true,

                    ValidIssuer = builder.Configuration["JWT:Issuer"],

                    ValidAudience = builder.Configuration["JWT:Audience"],

                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
                };
            });

            builder.Services.AddCors(cors =>
            {
                cors.AddPolicy("JwtCors", options =>
                {
                    options.AllowAnyHeader();
                    options.AllowAnyMethod();
                    options.AllowAnyOrigin();
                });
            });


            
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            app.UseHttpsRedirection();


            app.UseAuthentication();
            app.UseAuthorization();
            

            app.MapControllers();

            app.Run();
        }
    }
}
