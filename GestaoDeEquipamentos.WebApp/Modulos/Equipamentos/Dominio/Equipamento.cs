using GestaoDeEquipamentos.WebApp.Modulos.Fabricantes.Dominio;

namespace GestaoDeEquipamentos.WebApp.Modulos.Equipamentos.Dominio;

public sealed class Equipamento : EntidadeBase
{
    public string Nome { get; set; } = string.Empty;
    public decimal PrecoAquisicao { get; set; }
    public DateTime DataFabricacao { get; set; }
    public Fabricante Fabricante { get; set; } = null!;

    public Equipamento() { }

    public Equipamento(string nome, decimal preco, DateTime dataFabricacao, Fabricante fabricante) : this()
    {
        Nome = nome;
        PrecoAquisicao = preco;
        DataFabricacao = dataFabricacao;
        Fabricante = fabricante;
    }

    public override void Atualizar(EntidadeBase entidadeAtualizada)
    {
        Equipamento equipamentoAtualizado = (Equipamento)entidadeAtualizada;

        Nome = equipamentoAtualizado.Nome;
        PrecoAquisicao = equipamentoAtualizado.PrecoAquisicao;
        DataFabricacao = equipamentoAtualizado.DataFabricacao;
        Fabricante = equipamentoAtualizado.Fabricante;
    }
}
