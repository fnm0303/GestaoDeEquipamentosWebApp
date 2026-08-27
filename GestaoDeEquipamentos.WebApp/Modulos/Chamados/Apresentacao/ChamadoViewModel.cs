using System.ComponentModel.DataAnnotations;
namespace GestaoDeEquipamentos.WebApp.Modulos.Chamados.Apresentacao;

public record ListarChamadoViewModel(
    int Id,
    string Titulo,
    string Descricao,
    DateTime DataAbertura,
    string NomeEquipamento
);

public record SelecionarEquipamentoViewModel(int Id, string Nome);

public record CadastrarChamadoViewModel(

    [Required(ErrorMessage = "O campo \"Título\" é obrigatório.")]
    string? Titulo,

    [Required(ErrorMessage = "O campo \"Descrição\" é obrigatório.")]
    string? Descricao,

    [Required(ErrorMessage = "O campo \"Data de abertura\" é obrigatório.")]
    DateTime? DataAbertura,

    [Range(1, int.MaxValue, ErrorMessage = "O campo \"Equipamento\" é obrigatório.")]
    int EquipamentoId,

    List<SelecionarEquipamentoViewModel>? EquipamentosDisponiveis
);

public record EditarChamadoViewModel(
    int Id,

    [Required(ErrorMessage = "O campo \"Título\" é obrigatório.")]
    string? Titulo,

    [Required(ErrorMessage = "O campo \"Descrição\" é obrigatório.")]
    string? Descricao,

    [Range(1, int.MaxValue, ErrorMessage = "O campo \"Equipamento\" é obrigatório.")]
    int EquipamentoId,

    List<SelecionarEquipamentoViewModel>? EquipamentosDisponiveis
);

public record ExcluirChamadoViewModel(
    int Id,
    string Titulo
);