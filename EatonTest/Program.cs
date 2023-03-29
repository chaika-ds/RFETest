using EatonTest.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterInMemory();
builder.Services.RegisterDeviceSettings();
builder.Services.RegisterDataBaseServices();
builder.Services.RegisterResources();


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.RegisterRest(builder.Services);

app.Run();
