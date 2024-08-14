using CleanCode.Infra.CleanCodeContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanCode.Infra;

public static class PersistenceExtension
{
    public static void ConfigureInfra(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Database");

        services.AddDbContext<DataContext>(opt => opt.UseSqlite(connectionString));

        //services.AddScoped<IUnitOfWork, UnitOfWork>();
        //services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        //services.AddScoped<IProdutoRepository, ProdutoRepository>();
        //services.AddScoped<IItemListaRepository, ItemListaRepository>();
        //services.AddScoped<IListaCompraRepository, ListaCompraRepository>();
    }
}
