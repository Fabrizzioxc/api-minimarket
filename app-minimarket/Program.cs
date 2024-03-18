using app_minimarket.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka..IO.InvalidDataException: 'Failed to load configuration from file 'C:\Users\Alumno\Desktopms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Insertar la clase Configuracion usando la cadena de conecxión de appsettings.json
var Configuracion = new Configuracion(builder.Configuration.GetConnectionString("bd_minimarket"));
builder.Services.AddSingleton(Configuracion);

//Agregar al contenedor de dependencias la interface y la clae CRUDproducto
builder.Services.AddScoped<IProducto, CRUDProducto>();
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
