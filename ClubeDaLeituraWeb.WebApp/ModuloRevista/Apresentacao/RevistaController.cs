using ClubeDaLeituraWeb.WebApp.Compartilhado.Infra;
using ClubeDaLeituraWeb.WebApp.ModuloCaixa.Apresentacao;
using ClubeDaLeituraWeb.WebApp.ModuloCaixa.Dominio;
using ClubeDaLeituraWeb.WebApp.ModuloCaixa.Infra;
using ClubeDaLeituraWeb.WebApp.ModuloRevistas.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClubeDaLeituraWeb.WebApp.ModuloRevistas.Apresentacao;

public class RevistaController : Controller
{
    private readonly IRepositorioRevista repositorioRevista;
    private readonly IRepositorioCaixa repositorioCaixa;

    public RevistaController(IRepositorioRevista repositorioRevista, IRepositorioCaixa repositorioCaixa)
    {
        this.repositorioRevista = repositorioRevista;
        this.repositorioCaixa = repositorioCaixa;
    }

    [HttpGet]

    public ActionResult Listar()
    {
        List<Revista> revistas = repositorioRevista.SelecionarTodos();

        List<ListarRevistasViewModel> listarVms = new List<ListarRevistasViewModel>();

        foreach (Revista r in revistas)
        {
            ListarRevistasViewModel viewModel = new ListarRevistasViewModel(
                r.Id,
                r.Titulo,
                r.NumeroEdicao,
                r.AnoPublicacao,
                r.Caixa.Etiqueta
            );

            listarVms.Add(viewModel);
        }

        return View(listarVms);
    }

    [HttpGet]
    public ActionResult Cadastrar()
    {
        ViewBag.Caixas = CarregarCaixas();

        CadastrarRevistaViewModel cadastrarVm = new CadastrarRevistaViewModel(
            string.Empty,
            0,
            0,
            string.Empty
        );

        return View(cadastrarVm);
    }

    [HttpPost]
    public ActionResult Cadastrar(CadastrarRevistaViewModel cadastrarVm)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Caixas = CarregarCaixas();
            return View(cadastrarVm);
        }

        Caixa? caixa = repositorioCaixa.SelecionarPorId(cadastrarVm.CaixaId);

        if (caixa == null)
        {
            ViewBag.Caixas = CarregarCaixas();
            ModelState.AddModelError("CaixaId", "Selecione uma caixa válida.");
            return View(cadastrarVm);
        }

        Revista novaRevista = new Revista(
            cadastrarVm.Titulo,
            cadastrarVm.NumeroEdicao,
            cadastrarVm.AnoPublicacao,
            caixa
        );

        repositorioRevista.Cadastrar(novaRevista);

        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]
    public ActionResult Editar(string id)
    {
        Revista? revista = repositorioRevista.SelecionarPorId(id);

        if (revista == null)
            return RedirectToAction(nameof(Listar));

        EditarRevistasViewModel editarChamadoVm = new EditarRevistasViewModel(
            revista.Id,
            revista.Titulo,
            revista.NumeroEdicao,
            revista.AnoPublicacao,
            revista.Caixa.Id
        );

        ViewBag.Caixas = CarregarCaixas();

        return View(editarChamadoVm);
    }

    [HttpPost]
    public ActionResult Editar(EditarRevistasViewModel editarVm)
    {
        Caixa? caixa =
            repositorioCaixa.SelecionarPorId(editarVm.CaixaId);

        if (!string.IsNullOrWhiteSpace(editarVm.CaixaId) && caixa == null)
        {
            ModelState.AddModelError(
                nameof(editarVm.CaixaId),
                "Selecione uma caixa válida."
            );
        }

        if (!ModelState.IsValid)
        {
            ViewBag.Caixas = CarregarCaixas();

            return View(editarVm);
        }

        Revista revistaAtualizada = new Revista(
            editarVm.Titulo,
            editarVm.NumeroEdicao,
            editarVm.AnoPublicacao,
            caixa!
        );

        repositorioRevista.Editar(editarVm.Id, revistaAtualizada);

        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]
    public ActionResult Excluir(string id)
    {
        Revista? revista = repositorioRevista.SelecionarPorId(id);

        if (revista == null)
            return RedirectToAction(nameof(Listar));

        ExcluirRevistaViewModel excluirVm = new ExcluirRevistaViewModel(
            revista.Id,
            revista.Titulo,
            revista.NumeroEdicao,
            revista.AnoPublicacao,
            revista.Caixa.Etiqueta
        );

        return View(excluirVm);
    }

    [HttpPost]
    [ActionName("Excluir")]
    public ActionResult ExcluirConfirmado(ExcluirRevistaViewModel excluirVm)
    {
        Revista? revista = repositorioRevista.SelecionarPorId(excluirVm.Id);

        if (revista != null)
            repositorioRevista.Excluir(revista);

        return RedirectToAction(nameof(Listar));
    }

    private List<SelectListItem> CarregarEquipamentos()
    {
        List<Revista> revistas = repositorioRevista.SelecionarTodos();

        List<SelectListItem> selecionarRevistas = new List<SelectListItem>();

        foreach (Revista e in revistas)
        {
            SelectListItem selecionarRevistaVm = new SelectListItem(
                e.Titulo,
                e.Id
            );

            selecionarRevistas.Add(selecionarRevistaVm);
        }

        return selecionarRevistas;
    }

    private List<SelectListItem> CarregarCaixas()
    {
        List<Caixa> caixas = repositorioCaixa.SelecionarTodos();

        List<SelectListItem> selecionarCaixas = new List<SelectListItem>();


        foreach (Caixa e in caixas)
        {
            SelectListItem selecionarRevistaVm = new SelectListItem(
                e.Etiqueta,
                e.Id
            );

            selecionarCaixas.Add(selecionarRevistaVm);
        }
        return selecionarCaixas;
    }
}