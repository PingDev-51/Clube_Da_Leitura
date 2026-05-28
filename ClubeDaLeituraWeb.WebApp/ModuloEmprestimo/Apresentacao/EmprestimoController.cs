using ClubeDaLeitura.ConsoleApp.Dominio;
using ClubeDaLeitura.ConsoleApp.Infraestrutura;
using ClubeDaLeituraWeb.WebApp.Compartilhado.Infra;
using ClubeDaLeituraWeb.WebApp.ModuloAmigo.Dominio;
using ClubeDaLeituraWeb.WebApp.ModuloEmprestimo.Dominio;
using ClubeDaLeituraWeb.WebApp.ModuloRevistas.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClubeDaLeituraWeb.WebApp.ModuloEmprestimo.Apresetacao;

public class EmprestimoController : Controller
{
    private readonly IRepositorio repositorioEmprestimo;
    private readonly IRepositorioRevista repositorioRevista;
    private readonly IRepositorioAmigo repositorioAmigo;

    public EmprestimoController(IRepositorio repositorioEmprestimo, IRepositorioRevista repositorioRevista, IRepositorioAmigo repositorioAmigo)
    {
        this.repositorioEmprestimo = repositorioEmprestimo;
        this.repositorioRevista = repositorioRevista;
        this.repositorioAmigo = repositorioAmigo;

    }

    [HttpGet]
    public ActionResult Listar()
    {
        List<Emprestimo> emprestimos = new List<Emprestimo>();

        List<ListarEmprestimosViewModel> listarVm = new List<ListarEmprestimosViewModel>();

        foreach (Emprestimo e in emprestimos)
        {
            ListarEmprestimosViewModel listarEmprestimoVm = new ListarEmprestimosViewModel(
                e.Id,
                e.Revista.Titulo,
                e.Amigo.Nome,
                e.DataAbertura,
                e.DataDevolucao
            );

            listarVm.Add(listarEmprestimoVm);
        }

        return View(listarVm);
    }

    [HttpGet]

    public ActionResult Cadastrar()
    {
        ViewBag.Revista = CarregarRevista();
        ViewBag.Amigo = CarregarAmigo();

        new CadastrarEmprestimosViewModel(
            string.Empty,
            string.Empty,
            DateTime.Now
        );

        return View();
    }

    [HttpPost]
    public ActionResult Cadastrar(CadastrarEmprestimosViewModel cadastrarVm)
    {
        Revista? revista = repositorioRevista.SelecionarPorId(cadastrarVm.RevistaId);
        Amigo? amigo = repositorioAmigo.SelecionarPorId(cadastrarVm.AmigoId);

        if (revista == null)
            return RedirectToAction(nameof(Listar));
        if (amigo == null)
            return RedirectToAction(nameof(Listar));

        Emprestimo novoEmprestimo = new Emprestimo(
            revista,
            amigo,
            cadastrarVm.DataAbertura
        );
        repositorioEmprestimo.Cadastrar(novoEmprestimo);

        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]
    public ActionResult CadastrarDevolucao(string id)
    {
        Emprestimo? emprestimo = repositorioEmprestimo.SelecionarPorId(id);

        if (emprestimo == null)
            return RedirectToAction(nameof(Listar));

        CadastrarDevolucaoViewModel cadastrar = new CadastrarDevolucaoViewModel(
            string.Empty,
            string.Empty,
            DateTime.Now
        );

        ViewBag.Revista = CarregarRevista();
        ViewBag.Amigo = CarregarAmigo();

        return View(cadastrar);
    }

    [HttpPost]
    public ActionResult CadastrarDevolucao(CadastrarDevolucaoViewModel cadastrarVm)
    {

        Revista? revista = repositorioRevista.SelecionarPorId(cadastrarVm.RevistaId);
        Amigo? amigo = repositorioAmigo.SelecionarPorId(cadastrarVm.AmigoId);

        if (revista == null)
            return RedirectToAction(nameof(Listar));

        if (amigo == null)
            return RedirectToAction(nameof(Listar));


        if (!ModelState.IsValid)
        {
            ViewBag.Revista = CarregarRevista();

            return View(cadastrarVm);
        }
        Emprestimo novoEmprestimo = new Emprestimo(
            revista,
            amigo,
            cadastrarVm.DataDevolucao
        );


        repositorioEmprestimo.Cadastrar(novoEmprestimo);

        return RedirectToAction(nameof(Listar));
    }

    private List<SelectListItem> CarregarRevista()
    {
        List<Revista> revistas = repositorioRevista.SelecionarTodos();

        List<SelectListItem> selecionarRevistas = new List<SelectListItem>();


        foreach (Revista r in revistas)
        {
            SelectListItem selecionarRevistaVm = new SelectListItem(
                r.Id,
                r.Titulo
            );

            selecionarRevistas.Add(selecionarRevistaVm);
        }
        return selecionarRevistas;
    }

    private List<SelectListItem> CarregarAmigo()
    {
        List<Amigo> amigoss = repositorioAmigo.SelecionarTodos();

        List<SelectListItem> selecionarAmigos = new List<SelectListItem>();


        foreach (Amigo a in amigoss)
        {
            SelectListItem selecionarAmigoVm = new SelectListItem(
                a.Id,
                a.Nome
            );

            selecionarAmigos.Add(selecionarAmigoVm);
        }
        return selecionarAmigos;
    }
}
