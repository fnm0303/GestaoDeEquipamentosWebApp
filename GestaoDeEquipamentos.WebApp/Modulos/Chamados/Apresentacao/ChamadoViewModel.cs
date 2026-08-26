using System.ComponentModel.DataAnnotations;
namespace GestaoDeEquipamentos.WebApp.Modulos.Chamados.Apresentacao;

public record ListarChamadoViewModel(
    int Id,
    string Titulo,
    string Descricao,
    DateTime DataAbertura,
    string NomeEquipamento
);