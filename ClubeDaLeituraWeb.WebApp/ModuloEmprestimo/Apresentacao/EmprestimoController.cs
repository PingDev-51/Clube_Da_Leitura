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
                e.DataConclusaoPrevista
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

        return View();
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