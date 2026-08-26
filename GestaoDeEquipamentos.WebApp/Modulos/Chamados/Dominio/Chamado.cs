using System.Security.Cryptography;
using GestaoDeEquipamentos.WebApp.Modulos.Equipamentos.Dominio;

namespace GestaoDeEquipamentos.WebApp.Modulos.Chamados.Dominio;

public sealed class Chamado : EntidadeBase
{
    public string Titulo { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public DateTime DataAbertura { get; set; } = DateTime.Now;
    public Equipamento Equipamento { get; set; } = null!;

    public Chamado() { }

    public Chamado(string titulo, string descricao, DateTime dataAbertura, Equipamento equipamento) : this()
    {
        Titulo = titulo;
        Descricao = descricao;
        DataAbertura = dataAbertura;
        Equipamento = equipamento;
    }

    public override void Atualizar(EntidadeBase entidadeAtualizada)
    {
        Chamado chamadoAtualizado = (Chamado)entidadeAtualizada;

        Titulo = chamadoAtualizado.Titulo;
        Descricao = chamadoAtualizado.Descricao;
        DataAbertura = chamadoAtualizado.DataAbertura;
        Equipamento = chamadoAtualizado.Equipamento;
    }
}
