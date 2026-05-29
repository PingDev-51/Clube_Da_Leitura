using ClubeDaLeitura.ConsoleApp.Dominio;
using ClubeDaLeituraWeb.WebApp.Compartilhado.Infra;
using ClubeDaLeituraWeb.WebApp.Compartilhado.Infra.Arquivos;
using ClubeDaLeituraWeb.WebApp.ModuloEmprestimo.Dominio;

namespace ClubeDaLeitura.ConsoleApp.Infraestrutura;

public class RepositorioEmprestimo : RepositorioBaseEmArquivo<Emprestimo>, IRepositorioEmprestimo
{
    public RepositorioEmprestimo(ContextoJson contexto) : base(contexto)
    {
    }

    protected override List<Emprestimo> CarregarRegistros()
    {
        return contexto.Emprestimos;
    }
}