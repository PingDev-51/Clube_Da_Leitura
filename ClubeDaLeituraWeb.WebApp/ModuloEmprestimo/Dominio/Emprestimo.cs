using System.Security.Cryptography;
using ClubeDaLeituraWeb.WebApp.ModuloRevistas.Dominio;

namespace ClubeDaLeitura.ConsoleApp.Dominio;

public class Emprestimo
{
    public string Id { get; private set; } = string.Empty;
    public Revista Revista { get; private set; }
    public Amigo Amigo { get; private set; }
    public DateTime DataAbertura { get; private set; }
    public DateTime DataConclusaoPrevista { get; private set; }


    public Emprestimo(Revista revista, Amigo amigo)
    {
        Id = Convert
                .ToHexString(RandomNumberGenerator.GetBytes(4))
                .ToLower()
                .Substring(0, 7);

        Revista = revista;
        Amigo = amigo;
    }

    public string[] Validar()
    {
        string erros = string.Empty;

        if (Revista == null)
            erros = "O campo \"Revista\" deve ser preenchido;";

        if (Amigo == null)
            erros = "O campo \"Amigo\" deve ser preenchido;";

        return erros.Split(';', StringSplitOptions.RemoveEmptyEntries);
    }

    // public void Abrir()
    // {
    //     DataAbertura = DateTime.Now;
    //     Status = StatusEmprestimo.Aberto;

    //     Revista.Emprestar();
    //     Amigo.AdicionarEmprestimo(this);
    // }

    // public void Concluir()
    // {
    //     Status = StatusEmprestimo.Concluido;
    //     Revista.Devolver();
    // }

    // public int ObterQuantidadeDiasAtraso(DateTime dataConclusao)
    // {
    //     return (dataConclusao - DataConclusaoPrevista).Days;
    // }
}
