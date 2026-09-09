using GestaoDeEquipamentos.WebApp.Modulos.Chamados.Infraestrutura;
using GestaoDeEquipamentos.WebApp.Modulos.Equipamentos.Infraestrutura;
using GestaoDeEquipamentos.WebApp.Modulos.Fabricantes.Dominio;
using GestaoDeEquipamentos.WebApp.Modulos.Fabricantes.Infraestrutura;

namespace GestaoDeEquipamentos.WebApp.Compartilhado.Infraestrutura;

public static class InjecaoDeDependencia
{
    public static void AdicionarCamadaInfraEstrutura(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped(services =>
        {
            ContextoJson contexto = new ContextoJson();

            contexto.Carregar();

            return contexto;
        });

        string connectionString = configuration.GetConnectionString("SqlServerDocker")
            ?? throw new InvalidOperationException("A string de conexão não foi configurada.");

        services.AddScoped<IRepositorioFabricante>(_ =>
        {
            return new RepositorioFabricanteEmSql(connectionString);
        });
        services.AddScoped<RepositorioEquipamentoEmArquivo>();
        services.AddScoped<RepositorioChamadosEmArquivo>();
    }
}
