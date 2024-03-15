using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Teknoroma.Application.Features.AppUserProfiles.Rules;
using Teknoroma.Application.Features.AppUserRoles.Rules;
using Teknoroma.Application.Features.AppUsers.Rules;
using Teknoroma.Application.Features.Branches.Rules;
using Teknoroma.Application.Features.Brands.Rules;
using Teknoroma.Application.Features.Categories.Rules;
using Teknoroma.Application.Features.Customers.Rules;
using Teknoroma.Application.Features.Departments.Rules;
using Teknoroma.Application.Features.Employees.Rules;
using Teknoroma.Application.Features.OrderDetails.Rules;
using Teknoroma.Application.Features.Orders.Rules;
using Teknoroma.Application.Features.Products.Rules;
using Teknoroma.Application.Features.Suppliers.Rules;
using Teknoroma.Application.Pipelines.Transaction;
using Teknoroma.Application.Pipelines.Validation;
using Teknoroma.Application.Security.JWTHelpers;
using Teknoroma.Application.Services.AppUserProfiles;
using Teknoroma.Application.Services.Branches;
using Teknoroma.Application.Services.Brands;
using Teknoroma.Application.Services.Categories;
using Teknoroma.Application.Services.Customers;
using Teknoroma.Application.Services.Departments;
using Teknoroma.Application.Services.EmailServices;
using Teknoroma.Application.Services.Employees;
using Teknoroma.Application.Services.ExpenseServices;
using Teknoroma.Application.Services.OrderDetails;
using Teknoroma.Application.Services.Orders;
using Teknoroma.Application.Services.Products;
using Teknoroma.Application.Services.StockInputs;
using Teknoroma.Application.Services.Stocks;
using Teknoroma.Application.Services.Suppliers;
using Teknoroma.Application.Services.TechnicalProblems;

namespace Teknoroma.Persistence.DependencyResolvers
{
	public static class ApplicationServiceRegistration
	{
		public static IServiceCollection AddAplicationServiceRegistration(this IServiceCollection services)
		{
            ServiceProvider provider = services.BuildServiceProvider();

            var configuration = provider.GetService<IConfiguration>();

            //AutoMapper Profile Service
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

			//FluentValidation Service
			services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());

			//JWT Service
			services.AddScoped<IJwtService, JwtService>();

			//Mail Service
			services.AddTransient<IMailService, MailService>();

			//MediatR Service
			services.AddMediatR(configuration =>
			{
				configuration.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
				configuration.AddOpenBehavior(typeof(RequestValidationBehavior<,>));
				configuration.AddOpenBehavior(typeof(TransactionScopeBehavior<,>));
			});

			//BusinessRules
			services.AddTransient<BrandBusinessRules>();
			services.AddTransient<BranchBusinessRules>();
			services.AddTransient<CategoryBusinessRules>();
			services.AddTransient<CustomerBusinessRules>();
			services.AddTransient<DepartmentBusinessRules>();
			services.AddTransient<ProductBusinessRules>();
			services.AddTransient<SupplierBusinessRules>();
			services.AddTransient<AppUserProfileBusinessRules>();
			services.AddTransient<AppUserBusinessRules>();
			services.AddTransient<AppUserRoleBusinessRules>();
			services.AddTransient<EmployeeBusinessRules>();
			services.AddTransient<OrderBusinessRules>();
			services.AddTransient<OrderDetailBusinessRules>();

			//
			services.AddScoped<IAppUserProfileService, AppUserProfileManager>();
			services.AddScoped<IBranchService, BranchManager>();
			services.AddScoped<IBrandService, BrandManager>();
			services.AddScoped<ICategoryService, CategoryManager>();
			services.AddScoped<ICustomerService , CustomerManager>();
			services.AddScoped<IDepartmentService, DepartmentManager>();
			services.AddScoped<IEmployeeService, EmployeeManager>();
			services.AddScoped<IOrderDetailService , OrderDetailManager>();
			services.AddScoped<IOrderService, OrderManager>();
			services.AddScoped<IProductService, ProductManager>();
			services.AddScoped<IStockInputService, StockInputManager>();
			services.AddScoped<IStockService, StockManager>();
			services.AddScoped<ISupplierService, SupplierManager>();
			services.AddScoped<ITechnicalProblemService, TechnicalProblemManager>();
			services.AddScoped<IExpenseService, ExpenseManager>();

            return services;
		}
	}
}
