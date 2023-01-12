using appointment_module_api.Data;
using appointment_module_api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Azure.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Configuration.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");

var dbConnectionString = builder.Configuration.GetConnectionString("appointmentAppConn");
//var dbConnectionString = builder.Configuration.GetConnectionString("Data Source=SAADPC;Initial Catalog=appointment_module; Integrated Security=true;");
builder.Services.AddDbContext<appointment_moduleContext>(o => o.UseSqlServer(dbConnectionString));
builder.Services.AddScoped<appointment_moduleContextProcedures>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().WithOrigins("https://instabook.azurewebsites.net", "http://localhost:3000")
    );
});

var app = builder.Build();

/*using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<appointment_moduleContext>();
    db.Database.Migrate();
}*/

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseCors("AllowAll");
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("api/business_services/{id}", async ([FromServices] appointment_moduleContextProcedures db, int businessId) =>
{
    var op = new OutputParameter<int>();
    return await db.selecting_business_servicesAsync(businessId, op);

});

app.MapGet("api/business_admin/{admin}", async ([FromServices] appointment_moduleContextProcedures db, string admin) =>
{
    var op = new OutputParameter<int>();
    return await db.get_business_for_adminAsync(admin, op);

});

app.MapGet("api/get_all_businesses", ([FromServices] appointment_moduleContext db) =>
{
    var businessDB = db.Business;

    return businessDB;
});

app.MapGet("api/get_times_for_service/serviceDate={serviceDate}&serviceId={serviceId}", async ([FromServices] appointment_moduleContextProcedures db, DateTime? serviceDate, int serviceId) =>
{
    var op = new OutputParameter<int>();
    return await db.get_times_for_serviceAsync(serviceDate, serviceId, op);

});

app.MapPost("api/appt_confirmed", async ([FromServices] appointment_moduleContextProcedures db, Appointments appointments) =>
{

    var op = new OutputParameter<int>();

    return await db.create_appointmentAsync(
        appointments.FirstName,
        appointments.LastName,
        appointments.StartTime,
        appointments.EndTime,
        appointments.ServiceId,
        appointments.Confirmed,
        appointments.PhoneNumber,
        appointments.Email,
        appointments.ApptDate,
        appointments.LengthMinutes,
        appointments.BusinessId
        );

});


/*app.MapPost("api/appt_confirmed", async ([FromServices] appointment_moduleContext db, [FromBody] Appointments appointments) =>
{
    var newAppt = new Appointments()
    {
        FirstName = appointments.FirstName,
        LastName = appointments.LastName,
        StartTime = appointments.StartTime,
        EndTime = appointments.EndTime,
        ServiceId = appointments.ServiceId,
        Confirmed = appointments.Confirmed,
        PhoneNumber = appointments.PhoneNumber,
        Email = appointments.Email,
        ApptDate = appointments.ApptDate,
        LengthMinutes = appointments.LengthMinutes,
        BusinessId = appointments.BusinessId,
    };

    await db.Appointments.AddAsync(newAppt);
    await db.SaveChangesAsync();
    return Results.Ok(newAppt);
});
*/


app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthorization();

app.MapControllers();

app.Run();


