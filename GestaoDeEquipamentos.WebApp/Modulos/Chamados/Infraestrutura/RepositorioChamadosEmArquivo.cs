using GestaoDeEquipamentos.WebApp.Modulos.Chamados.Dominio;

namespace GestaoDeEquipamentos.WebApp.Modulos.Chamados.Infraestrutura;

public sealed class RepositorioChamadosEmArquivo : RepositorioBaseEmArquivo<Chamado>
{
    public RepositorioChamadosEmArquivo(ContextoJson contexto) : base(contexto)
    {

    }

    protected override List<Chamado> ObterRegistros()
    {
        return contexto.Chamados;
    }
}
