using ClubeDaLeitura.ConsoleApp.Dominio;
using ClubeDaLeituraWeb.WebApp.Compartilhado.Infra.Arquivos;
using ClubeDaLeituraWeb.WebApp.ModuloEmprestimo.Dominio;

namespace ClubeDaLeitura.ConsoleApp.Infraestrutura;

public class RepositorioEmprestimo : IRepositorio
{
    public ContextoJson contexto = new ContextoJson();
    List<Emprestimo> registrosDeEmpréstimo = new List<Emprestimo>();
    public void Cadastrar(Emprestimo emprestimo)
    {
        registrosDeEmpréstimo.Add(emprestimo);

        contexto.Salvar();
    }

    public List<Emprestimo> SelecionarTodos()
    {
        return registrosDeEmpréstimo;
    }

    public Emprestimo? SelecionarPorId(string idSelecionado)
    {
        foreach (Emprestimo registro in registrosDeEmpréstimo)
        {
            if (registro.Id == idSelecionado)
                return registro;
        }

        return null;
    }

    public bool Excluir(Emprestimo registro)
    {
        bool conseguiuExcluir = registrosDeEmpréstimo.Remove(registro);

        if (conseguiuExcluir)
            contexto.Salvar();

        return conseguiuExcluir;
    }

    public bool Excluir(string idSelecionado)
    {
        Emprestimo? EmprestimoSelecionado = SelecionarPorId(idSelecionado);

        if (EmprestimoSelecionado == null)
            return false;

        return Excluir(EmprestimoSelecionado);
    }
}
