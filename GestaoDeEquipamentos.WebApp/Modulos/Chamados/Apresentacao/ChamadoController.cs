using GestaoDeEquipamentos.WebApp.Modulos.Chamados.Dominio;
using GestaoDeEquipamentos.WebApp.Modulos.Chamados.Infraestrutura;
using GestaoDeEquipamentos.WebApp.Modulos.Equipamentos.Dominio;
using GestaoDeEquipamentos.WebApp.Modulos.Equipamentos.Infraestrutura;
using Microsoft.AspNetCore.Mvc;

namespace GestaoDeEquipamentos.WebApp.Modulos.Chamados.Apresentacao;

public sealed class ChamadoController : Controller
{
    private readonly RepositorioChamadosEmArquivo repositorioChamado;
    private readonly RepositorioEquipamentoEmArquivo repositorioEquipamento;

    public ChamadoController(RepositorioChamadosEmArquivo repositorioChamado, RepositorioEquipamentoEmArquivo repositorioEquipamento)
    {
        this.repositorioChamado = repositorioChamado;
        this.repositorioEquipamento = repositorioEquipamento;
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

    [HttpGet]
    public ActionResult Cadastrar()
    {
        CadastrarChamadoViewModel viewModel = new(
            null,
            null,
            DateTime.Now,
            0,
            ObterEquipamentosDisponiveis()
        );

        return View(viewModel);
    }

    [HttpPost]
    public ActionResult Cadastrar(CadastrarChamadoViewModel viewModel)
    {
        Equipamento? equipamentoSelecionado =
            repositorioEquipamento.SelecionarPorId(viewModel.EquipamentoId);

        if (equipamentoSelecionado == null)
            ModelState.AddModelError(nameof(viewModel.EquipamentoId), "Selecione um equipamento válido");

        if (!ModelState.IsValid)
        {
            viewModel = viewModel with
            {
                EquipamentosDisponiveis = ObterEquipamentosDisponiveis()
            };

            return View(viewModel);
        }

        Chamado chamado = new(
            viewModel.Titulo ?? string.Empty,
            viewModel.Descricao ?? string.Empty,
            viewModel.DataAbertura ?? DateTime.Now,
            equipamentoSelecionado!
        );

        repositorioChamado.Cadastrar(chamado);

        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]
    public ActionResult Editar(int id)
    {
        Chamado? chamadoSelecionado = repositorioChamado.SelecionarPorId(id);

        if (chamadoSelecionado == null)
            return NotFound();

        EditarChamadoViewModel viewModel = new(
            chamadoSelecionado.Id,
            chamadoSelecionado.Titulo,
            chamadoSelecionado.Descricao,
            chamadoSelecionado.Equipamento.Id,
            ObterEquipamentosDisponiveis()
        );

        return View(viewModel);
    }

    [HttpPost]
    public ActionResult Editar(int id, EditarChamadoViewModel viewModel)
    {
        Chamado? chamadoOriginal = repositorioChamado.SelecionarPorId(id);

        if (chamadoOriginal == null)
            return NotFound();

        Equipamento? equipamentoSelecionado =
            repositorioEquipamento.SelecionarPorId(viewModel.EquipamentoId);

        if (equipamentoSelecionado == null)
            ModelState.AddModelError(nameof(viewModel.EquipamentoId), "Selecione um equipamento válido.");

        if (!ModelState.IsValid)
        {
            ViewBag.DataAberturaOriginal = chamadoOriginal.DataAbertura;
            viewModel = viewModel with
            {
                EquipamentosDisponiveis = ObterEquipamentosDisponiveis()
            };

            return View(viewModel);
        }

        Chamado chamadoAtualizado = new(
            viewModel.Titulo ?? string.Empty,
            viewModel.Descricao ?? string.Empty,
            chamadoOriginal.DataAbertura,
            equipamentoSelecionado!
        );

        bool conseguiuEditar = repositorioChamado.Editar(id, chamadoAtualizado);

        if (!conseguiuEditar)
            return NotFound();

        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]
    public ActionResult Excluir(int id)
    {
        Chamado? chamadoSelecionado = repositorioChamado.SelecionarPorId(id);

        if (chamadoSelecionado == null)
            return NotFound();

        ExcluirChamadoViewModel viewModel = new(
            chamadoSelecionado.Id,
            chamadoSelecionado.Titulo
        );

        return View(viewModel);
    }

    [HttpPost]
    public ActionResult Excluir(ExcluirChamadoViewModel viewModel)
    {
        bool conseguiuExcluir = repositorioChamado.Excluir(viewModel.Id);

        if (!conseguiuExcluir)
            return NotFound();

        return RedirectToAction(nameof(Listar));
    }

    private List<SelecionarEquipamentoViewModel> ObterEquipamentosDisponiveis()
    {
        List<SelecionarEquipamentoViewModel> viewModels = new();

        foreach (Equipamento e in repositorioEquipamento.SelecionarTodos())
        {
            SelecionarEquipamentoViewModel viewModel = new(e.Id, e.Nome);

            viewModels.Add(viewModel);
        }

        return viewModels;
    }

}
