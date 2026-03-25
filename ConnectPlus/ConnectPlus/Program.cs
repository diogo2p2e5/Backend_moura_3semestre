using ConnectPlus.BdContextConnect;
using ConnectPlus.Interfaces;
using ConnectPlus.Repositories;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ConnectContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<DbContext, ConnectContext>(); 

builder.Services.AddScoped<IContatoRepository, ContatoRepository>();
builder.Services.AddScoped<ITipoContatoRepository, TipoContatoRepository>();


builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.OpenApiInfo
    {
        Version = "v1",
        Title = "Api de Evento",
        Description = "Aplicação para gerenciamentos de eventos",
        TermsOfService = new Uri("https://i.pinimg.com/736x/26/b3/2e/26b32e24c4a22ad1e708fd2d0627ae31.jpg"),
        Contact = new OpenApiContact
        {
            Name = "Diogo Aldrovandi",
            Url = new Uri("https://i.pinimg.com/736x/a8/ef/a9/a8efa9ab42ab285b36f1abc6880340fb.jpg")
        },
        License = new OpenApiLicense
        {
            Name = "Licença e Exemplo",
            Url = new Uri("https://i.pinimg.com/736x/a4/df/85/a4df858853b9ef4dc35544cb66843caf.jpg")
        }
    });

   
});



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

    app.MapOpenApi();

    app.UseSwagger(options => { });

    app.UseSwaggerUI(options => {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
