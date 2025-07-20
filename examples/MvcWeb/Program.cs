using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MvcWeb.Data;
using MvcWeb.Models;
using MvcWeb.Services;
using Piranha;
using Piranha.AspNetCore.Identity.SQLite;
using Piranha.AspNetCore.Identity.SQLServer;
using Piranha.AttributeBuilder;
using Piranha.Data.EF.SQLite;
using Piranha.Data.EF.SQLServer;
using Piranha.Manager.Editor;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var connectionString = builder.Configuration.GetConnectionString("ecom")
                               ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString));


        builder.AddPiranha(options =>
        {
            options.AddRazorRuntimeCompilation = true;

            options.UseCms();
            options.UseManager();

            options.UseFileStorage(naming: Piranha.Local.FileStorageNaming.UniqueFolderNames);
            options.UseImageSharp();
            options.UseTinyMCE();
            options.UseMemoryCache();

            var piranhaConnectionString = builder.Configuration.GetConnectionString("cms");
            options.UseEF<SQLServerDb>(db => db.UseSqlServer(piranhaConnectionString));
            var identityConnectionString = builder.Configuration.GetConnectionString("ecom");
            options.UseIdentityWithSeed<IdentitySQLServerDb>(db => db.UseSqlServer(identityConnectionString));
        });

        // Register Identity for ApplicationUser
        //builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
        //    .AddEntityFrameworkStores<ApplicationDbContext>()
        //    .AddDefaultTokenProviders();

        builder.Services.AddScoped<ICartService, CartService>();
        builder.Services.AddScoped<ICategoryService, CategoryService>();
        builder.Services.AddScoped<IOrderService, OrderService>();
        builder.Services.AddScoped<IProductService, ProductService>();

        builder.Services.AddControllersWithViews();
        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UsePiranha(options =>
        {
            App.Init(options.Api);

            new ContentTypeBuilder(options.Api)
                .AddAssembly(typeof(Program).Assembly)
                .Build()
                .DeleteOrphans();

            EditorConfig.FromFile("editorconfig.json");

            options.UseManager();
            options.UseTinyMCE();
            options.UseIdentity();
        });

        app.Run();
    }
}
