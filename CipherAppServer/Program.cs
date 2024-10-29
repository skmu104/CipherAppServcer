using CipherAppServer.Services;
using CipherAppServer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<CaesarService>();
builder.Services.AddTransient<VigenereService>();

// Register the factory
builder.Services.AddSingleton<CipherServiceFactory>();

// Register the CipherContext which will use the factory
builder.Services.AddScoped<CipherContext>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.Run();
