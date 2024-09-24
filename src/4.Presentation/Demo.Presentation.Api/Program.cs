
using Demo.Domain.Core;
using Demo.Presentation.Api.Attributes;
using Demo.Presentation.Api.Filters;
using Demo.Presentation.Api.Startup;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers(options =>
{
    options.Filters.Add<ExceptionHandlerFilter>();
    options.Filters.Add<ModelStateFilter>();

    options.ModelBinderProviders.Insert(0, new RequestPatchBinderProvider());
}).AddJsonOptions(options => Json.SetOptions(options.JsonSerializerOptions));

builder.Services.RegisterAuthentication(builder.Configuration);
builder.Services.Register(builder.Configuration);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.RegisterSwagger(builder.Configuration);


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


app.RegisterMiddleware();

app.Run();