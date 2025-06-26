using FarmSightWebApi.UI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureServices(builder.Configuration);
builder.Services.AddEndpointsApiExplorer(); // <- Required
builder.Services.AddSwaggerGen();

var app = builder.Build();


//create application pipeline
if (builder.Environment.IsDevelopment())
{
    app.UseSwagger();   
    app.UseSwaggerUI();

    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();
