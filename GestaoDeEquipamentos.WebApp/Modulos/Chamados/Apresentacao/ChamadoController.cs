using GestaoDeEquipamentos.WebApp.Modulos.Chamados.Dominio;
using GestaoDeEquipamentos.WebApp.Modulos.Chamados.Infraestrutura;
using Microsoft.AspNetCore.Mvc;

namespace GestaoDeEquipamentos.WebApp.Modulos.Chamados.Apresentacao;

public sealed class ChamadoController : Controller
{
    private readonly RepositorioChamadosEmArquivo repositorioChamado;

    public ChamadoController(RepositorioChamadosEmArquivo repositorioChamado)
    {
        this.repositorioChamado = repositorioChamado;
    }

    [HttpGet]
    public ActionResult Listar()
    {
        List<ListarChamadoViewModel> viewModels = new List<ListarChamadoViewModel>();

        foreach (Chamado c in repositorioChamado.SelecionarTodos())
        {
            ListarChamadoViewModel viewModel = new ListarChamadoViewModel(
                c.Id,
                c.Titulo,
                c.Descricao,
                c.DataAbertura,
                c.Equipamento.Nome
            );

            viewModels.Add(viewModel);
        }

        return View(viewModels);
    }
}
