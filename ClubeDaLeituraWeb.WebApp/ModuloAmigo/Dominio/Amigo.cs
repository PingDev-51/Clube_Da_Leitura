using ClubeDaLeituraWeb.WebApp.Compartilhado.Dominio;

public class Amigo : EntidadeBase<Amigo>
{
    public string Nome { get; set; } = string.Empty;
    public string NomeResponsavel { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;

    public Amigo(string nome, string nomeResponsavel, string telefone)
    {
        Nome = nome;
        NomeResponsavel = nomeResponsavel;
        Telefone = telefone;
    }

    public override List<string> Validar()
    {
        List<string> erros = new List<string>();

        if (string.IsNullOrWhiteSpace(Nome))
            erros.Add("O campo \"Nome\" deve ser preenchido.");

        else if (string.IsNullOrWhiteSpace(NomeResponsavel))
            erros.Add("O campo \"Etiqueta\" deve conter no máximo 50 caracteres.");

        if (string.IsNullOrWhiteSpace(Telefone))
            erros.Add("O Campo \"Telefone\" é obrigatório.;");

        else if (Telefone.Length != 14 && Telefone.Length != 15)
            erros.Add("O Campo \"Telefone\" deve estar no formato (XX) XXXX-XXXX ou (XX) XXXXX-XXXX.;");

        else if (Telefone[0] != '(' || Telefone[3] != ')' || Telefone[4] != ' ')
            erros.Add("O Campo \"Telefone\" deve estar no formato (XX) XXXX-XXXX ou (XX) XXXXX-XXXX.;");

        else if (Telefone.Length == 14 && Telefone[9] != '-')
            erros.Add("O Campo \"Telefone\" deve estar no formato (XX) XXXX-XXXX ou (XX) XXXXX-XXXX.;");

        else if (Telefone.Length == 15 && Telefone[10] != '-')
            erros.Add("O Campo \"Telefone\" deve estar no formato (XX) XXXX-XXXX ou (XX) XXXXX-XXXX.;");

        return erros;
    }

    // public void AdicionarEmprestimo(Emprestimo emprestimo)
    // {
    //     for (int i = 0; i < Emprestimos.Length; i++)
    //     {
    //         Emprestimo e = Emprestimos[i];

    //         if (e == null)
    //             Emprestimos[i] = emprestimo;
    //             break;
    //     }
    // }

    public override void AtualizarDados(Amigo AmigoAtualizado)
    {
        Amigo amigoAtualizado = (Amigo)AmigoAtualizado;

        Nome = amigoAtualizado.Nome;
        NomeResponsavel = amigoAtualizado.NomeResponsavel;
        Telefone = amigoAtualizado.Telefone;
    }
}