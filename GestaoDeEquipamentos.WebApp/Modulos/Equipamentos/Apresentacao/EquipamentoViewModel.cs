using GestaoDeEquipamentos.WebApp.Modulos.Fabricantes.Dominio;

namespace GestaoDeEquipamentos.WebApp.Modulos.Equipamentos.Apresentacao;

public record ListarEquipamentoViewModel(
    int Id,
    string Nome,
    decimal PrecoAquisicao,
    DateTime DataFabricacao,
    string NomeFabricante
);