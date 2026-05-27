
using ClubeDaLeituraWeb.WebApp.Compartilhado.Dominio;
using ClubeDaLeituraWeb.WebApp.ModuloCaixa.Dominio;

namespace ClubeDaLeituraWeb.WebApp.ModuloRevistas.Dominio;

public class Revista : EntidadeBase<Revista>
{
    public string Titulo { get; set; }
    public int NumeroEdicao { get; set; }
    public int AnoPublicacao { get; set; }
    // public int StatusRevista { get; set; }
    public Caixa Caixa { get; set; }
    // public StatusRevista Status {get; set; }

    public Revista(string titulo, int numeroEdicao, int anoPublicacao, Caixa caixa)
    {

        Titulo = titulo;
        NumeroEdicao = numeroEdicao;
        AnoPublicacao = anoPublicacao;
        Caixa = caixa;
    }

    public Revista()
    {
    }

    public override List<string> Validar()
    {
        List<string> erros = new List<string>();

        if (string.IsNullOrWhiteSpace(Titulo))
            erros.Add("O campo \"Título\" é obrigatório;");

        else if (Titulo.Length < 2 || Titulo.Length > 100)
            erros.Add("O campo \"Título\" deve conter entre 2 e 100 caracteres;");

        if (NumeroEdicao < 0)
            erros.Add("O campo \"Numero da Edição\" deve conter um valor igual ou maior que 0;");

        int anoAtual = DateTime.Now.Year;

        if (AnoPublicacao < 1 || AnoPublicacao > anoAtual)
            erros.Add("O campo \"Ano de Publicação\" deve conter uma data válida;");

        if (Caixa == null)
            erros.Add("O campo \"Caixa\" deve conter uma caixa válida;");

        return erros;
    }

    public void AtualizarRegistro(Revista novaRevista)
    {
        Titulo = novaRevista.Titulo;
        NumeroEdicao = novaRevista.NumeroEdicao;
        AnoPublicacao = novaRevista.AnoPublicacao;
        Caixa = novaRevista.Caixa;
    }

    public override void AtualizarDados(Revista entidadeAtualizada)
    {

        Revista revistaAtualizada = (Revista)entidadeAtualizada;

        Titulo = revistaAtualizada.Titulo;
        NumeroEdicao = revistaAtualizada.NumeroEdicao;
        AnoPublicacao = revistaAtualizada.AnoPublicacao;
        Caixa = revistaAtualizada.Caixa;
    }

    // public void Emprestar()
    // {
    //     Status = Dominio.StatusRevista.Emprestada;
    // }

    // public void Devolver()
    // {
    //     Status = Dominio.StatusRevista.Disponivel;
    // }
}