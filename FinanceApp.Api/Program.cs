using FinanceApp.Financeiro.Application.Despesas.Handlers;
using FinanceApp.Financeiro.Infrastructure;
using FinanceApp.Usuario.Application.Usuarios.Handler;
using FinanceApp.Usuarios.Application.Usuarios.Handlers;
using FinanceApp.Usuarios.Infrastructure;
using FinanceApp.Usuarios.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Financeiro
builder.Services.AddDbContext<FinanceiroDbContext>(options =>
    options.UseSqlServer(connectionString));

// Usuário
builder.Services.AddDbContext<UsuarioDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblies(
        typeof(RegistrarUsuarioCommandHandler).Assembly, 
        typeof(ObterUsuarioQueryHandler).Assembly,       
        typeof(RegistrarDespesaCommandHandler).Assembly,
        typeof(ObterDespesasQueryHandler).Assembly
    );
});

builder.Services.AddScoped<IDespesaRepository, DespesaRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var financeiroContext = services.GetRequiredService<FinanceiroDbContext>();
    financeiroContext.Database.Migrate();

    var usuarioContext = services.GetRequiredService<UsuarioDbContext>();
    usuarioContext.Database.Migrate();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
