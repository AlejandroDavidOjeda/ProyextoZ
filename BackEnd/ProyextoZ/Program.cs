using Infrastructure.DataAcces;
using Microsoft.EntityFrameworkCore;
using ProyextoZ;
using Shared.Constants;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;
IConfiguration configuration = builder.Configuration;

services.AddDbContext<AplicationDbContext>(options => options.UseSqlServer(configuration .GetConnectionString("ConnectionString")));
services.AddRazorPages();
services.AddMvc();
services.AddCustomCors();
services.RegisterSwagger();
//services.AddSwaggerGen();
//services.AddServicesDependencies();

var app = builder.Build();


app.UseSwaggerEndpoint();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseCors(CorsPolicyName.AllowAny);
app.MapControllers();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
