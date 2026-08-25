using GestaoDeEquipamentos.WebApp.Modulos.Equipamentos.Dominio;
using GestaoDeEquipamentos.WebApp.Modulos.Equipamentos.Infraestrutura;
using GestaoDeEquipamentos.WebApp.Modulos.Fabricantes.Infraestrutura;
using Microsoft.AspNetCore.Mvc;

namespace GestaoDeEquipamentos.WebApp.Modulos.Equipamentos.Apresentacao;

public sealed class EquipamentoController : Controller
{
    private readonly RepositorioEquipamentoEmArquivo repositorioEquipamento;

    public EquipamentoController(RepositorioEquipamentoEmArquivo repositorioEquipamento, RepositorioFabricanteEmArquivo repositorioFabricante)
    {
        this.repositorioEquipamento = repositorioEquipamento;
    }

    [HttpGet]
    public ActionResult Listar()
    {
        List<ListarEquipamentoViewModel> viewModels = new List<ListarEquipamentoViewModel>();

        foreach (Equipamento e in repositorioEquipamento.SelecionarTodos())
        {
            viewModels.Add(new ListarEquipamentoViewModel(
                e.Id,
                e.Nome,
                e.PrecoAquisicao,
                e.DataFabricacao,
                e.Fabricante.Nome
            ));
        }

        return View(viewModels);
    }
}
