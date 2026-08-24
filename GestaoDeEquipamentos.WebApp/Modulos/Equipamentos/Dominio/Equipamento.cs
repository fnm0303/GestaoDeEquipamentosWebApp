using GestaoDeEquipamentos.WebApp.Modulos.Fabricantes.Dominio;

namespace GestaoDeEquipamentos.WebApp.Modulos.Equipamentos.Dominio;

public sealed class Equipamento : EntidadeBase
{
    public string Nome { get; set; }
    public decimal Preco { get; set; }
    Fabricante Fabricante { get; set; }
    public DateTime DataFabricacao { get; set; }

    public Equipamento() { }

    public Equipamento(string nome, decimal preco, Fabricante fabricante, DateTime dataFabricacao) : this()
    {
        Nome = nome;
        Preco = preco;
        Fabricante = fabricante;
        DataFabricacao = dataFabricacao;
    }

    public override void Atualizar(EntidadeBase entidadeAtualizada)
    {
        Equipamento equipamentoAtualizado = (Equipamento)entidadeAtualizada;
        Nome = equipamentoAtualizado.Nome;
        Preco = equipamentoAtualizado.Preco;
        Fabricante = equipamentoAtualizado.Fabricante;
        DataFabricacao = equipamentoAtualizado.DataFabricacao;
    }
}
