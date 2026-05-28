using ClubeDaLeituraWeb.WebApp.Compartilhado.Infra;
using ClubeDaLeituraWeb.WebApp.ModuloAmigo.Dominio;
using ClubeDaLeituraWeb.WebApp.ModuloAmigo.Infra;
using Microsoft.AspNetCore.Mvc;

namespace ClubeDaLeituraWeb.WebApp.ModuloAmigo.Apresentacao;

public class AmigoController : Controller
{
    private readonly IRepositorioAmigo repositorioAmigo;

    public AmigoController(IRepositorioAmigo repositorioAmigo)
    {
        this.repositorioAmigo = repositorioAmigo;
    }

    [HttpGet]
    public ActionResult Listar()
    {
        List<Amigo> amigos = repositorioAmigo.SelecionarTodos();

        List<ListarAmigosViewModel> listarVm = new List<ListarAmigosViewModel>();

        foreach (Amigo a in amigos)
        {
            ListarAmigosViewModel viewModel = new ListarAmigosViewModel(
                a.Id,
                a.Nome,
                a.NomeResponsavel,
                a.Telefone
            );

            listarVm.Add(viewModel);
        }

        return View(listarVm);
    }

    [HttpGet]
    public ActionResult Cadastrar()
    {

        return View();
    }

    [HttpPost]
    public ActionResult Cadastrar(CadastrarAmigosViewModel cadastrarVm)
    {
        if (!ModelState.IsValid)
            return View(cadastrarVm);

        Amigo novoAmigo = new Amigo(
            cadastrarVm.Nome,
            cadastrarVm.NomeResponsavel,
            cadastrarVm.Telefone
        );

        repositorioAmigo.Cadastrar(novoAmigo);

        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]
    public ActionResult Editar(string id)
    {
        Amigo? amigo = repositorioAmigo.SelecionarPorId(id);

        if (amigo == null)
            return RedirectToAction(nameof(Listar));

        EditarAmigosViewModel editarAmigoVm = new EditarAmigosViewModel(
            id,
            amigo.Nome,
            amigo.NomeResponsavel,
            amigo.Telefone
        );


        return View(editarAmigoVm);
    }

    [HttpPost]
    public ActionResult Editar(EditarAmigosViewModel editarVm)
    {
        if (!ModelState.IsValid)
            return View(editarVm);

        Amigo amigoAtualizado = new Amigo(
            editarVm.Nome,
            editarVm.NomeResponsavel,
            editarVm.Telefone
        );

        repositorioAmigo.Editar(editarVm.Id, amigoAtualizado);

        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]
    public ActionResult Excluir(string id)
    {
        Amigo? amigo = repositorioAmigo.SelecionarPorId(id);

        if (amigo == null)
            return RedirectToAction(nameof(Listar));

        ExcluirAmigosViewModel excluirAmigoVm = new ExcluirAmigosViewModel(
            id,
            amigo.Nome,
            amigo.NomeResponsavel,
            amigo.Telefone
        );

        return View(excluirAmigoVm);
    }

    [HttpPost]
    public ActionResult Excluir(ExcluirAmigosViewModel excluirVm)
    {
        Amigo? amigo = repositorioAmigo.SelecionarPorId(excluirVm.Id);

        if (amigo != null)
            repositorioAmigo.Excluir(amigo);

        return RedirectToAction(nameof(Listar));
    }
}