using GestaoDeEquipamentos.WebApp.Modulos.Fabricantes.Dominio;
using GestaoDeEquipamentos.WebApp.Modulos.Fabricantes.Infraestrutura;
using Microsoft.AspNetCore.Mvc;

namespace GestaoDeEquipamentos.WebApp.Modulos.Fabricantes.Apresentacao;

public sealed class FabricanteController : Controller
{
    private readonly RepositorioFabricanteEmArquivo repositorio;

    public FabricanteController(RepositorioFabricanteEmArquivo repositorio)
    {
        this.repositorio = repositorio;
    }

    [HttpGet]
    public ActionResult Listar()
    {
        List<ListarFabricanteViewModel> viewModels = new List<ListarFabricanteViewModel>();

        foreach (Fabricante fabricante in repositorio.SelecionarTodos())
        {
            viewModels.Add(new ListarFabricanteViewModel(
                fabricante.Id,
                fabricante.Nome,
                fabricante.Email,
                fabricante.Telefone
            ));
        }

        return View(viewModels);
    }
}
