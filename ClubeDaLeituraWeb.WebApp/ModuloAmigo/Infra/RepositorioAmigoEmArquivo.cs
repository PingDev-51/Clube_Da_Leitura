using ClubeDaLeituraWeb.WebApp.Compartilhado.Infra.Arquivos;

namespace ClubeDaLeituraWeb.WebApp.ModuloAmigo.Infra;

public class RepositorioAmigoEmArquivo : RepositorioBaseEmArquivo<Amigo>
{
    public RepositorioAmigoEmArquivo(ContextoJson contexto) : base(contexto) { }

    protected override List<Amigo> CarregarRegistros()
    {
        return contexto.Amigo;
    }
}