using GestaoDeEquipamentos.WebApp.Modulos.Equipamentos.Dominio;

namespace GestaoDeEquipamentos.WebApp.Modulos.Equipamentos.Infraestrutura;

public sealed class RepositorioEquipamentoEmArquivo : RepositorioBaseEmArquivo<Equipamento>
{
    public RepositorioEquipamentoEmArquivo(ContextoJson contexto) : base(contexto)
    {

    }

    protected override List<Equipamento> ObterRegistros()
    {
        return contexto.Equipamentos;
    }
}
