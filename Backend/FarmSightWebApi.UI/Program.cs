using FarmSightWebApi.UI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureServices(builder.Configuration);


var app = builder.Build();


//create application pipeline
if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}


app.UseHttpLogging();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();

public partial class Program { } //make the auto-generated Program accessible programmatically
