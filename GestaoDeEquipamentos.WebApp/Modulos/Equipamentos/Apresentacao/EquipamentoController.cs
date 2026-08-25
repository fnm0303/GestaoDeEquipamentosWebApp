using GestaoDeEquipamentos.WebApp.Modulos.Equipamentos.Dominio;
using GestaoDeEquipamentos.WebApp.Modulos.Equipamentos.Infraestrutura;
using GestaoDeEquipamentos.WebApp.Modulos.Fabricantes.Infraestrutura;
using Microsoft.AspNetCore.Mvc;

namespace GestaoDeEquipamentos.WebApp.Modulos.Equipamentos.Apresentacao;

public sealed class EquipamentoController : Controller
{
    private readonly RepositorioEquipamentoEmArquivo repositorioEquipamento;
    private readonly RepositorioFabricanteEmArquivo repositorioFabricante;

    public EquipamentoController(RepositorioEquipamentoEmArquivo repositorioEq, RepositorioFabricanteEmArquivo repositorioFab)
    {
        this.repositorioEquipamento = repositorioEq;
        this.repositorioFabricante = repositorioFab;
    }

    [HttpGet]
    public ActionResult Listar()
    {
        List<ListarEquipamentoViewModel> viewModels = new List<ListarEquipamentoViewModel>();

        foreach (Equipamento equipamento in repositorioEquipamento.SelecionarTodos())
        {
            viewModels.Add(new ListarEquipamentoViewModel(
                equipamento.Id,
                equipamento.Nome,
                equipamento.PrecoAquisicao,
                equipamento.DataFabricacao,
                equipamento.Fabricante.Nome
            ));
        }

        return View(viewModels);
    }
}
