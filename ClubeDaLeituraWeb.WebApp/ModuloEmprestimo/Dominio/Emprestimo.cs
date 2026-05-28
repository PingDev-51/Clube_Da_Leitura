using System.Security.Cryptography;
using ClubeDaLeituraWeb.WebApp.Compartilhado.Dominio;
using ClubeDaLeituraWeb.WebApp.ModuloRevistas.Dominio;

namespace ClubeDaLeitura.ConsoleApp.Dominio;

public class Emprestimo : EntidadeBase<Emprestimo>
{
    public string Id { get; set; } = string.Empty;
    public Revista Revista { get; set; }
    public Amigo Amigo { get; set; }
    public bool Status { get; set; }
    public DateTime DataAbertura { get; set; }
    // public DateTime ConclusaoPrevista
    // {
    //     get
    //     {
    //         int diasDeEmprestimo = Revista.Caixa.DiasDeEmprestimo;

    //         DateTime conclusao = Abertura.AddDays(diasDeEmprestimo);

    //         return conclusao;
    //     }
    // }

    // public bool EstaAtrasado
    // {
    //     get
    //     {
    //         return Status == StatusEmprestimo.Aberto && DateTime.Now > ConclusaoPrevista;
    //     }
    // }

    public Emprestimo() { }
    public Emprestimo(Revista revista, Amigo amigo, DateTime dataAbertura)
    {
        Id = Convert
                .ToHexString(RandomNumberGenerator.GetBytes(4))
                .ToLower()
                .Substring(0, 7);

        Revista = revista;
        Amigo = amigo;
        DataAbertura = dataAbertura;
    }

    public override List<string> Validar()
    {
        List<string> erros = new List<string>();

        if (Revista == null)
            erros.Add("O campo \"Revista\" deve ser preenchido;");

        if (Amigo == null)
            erros.Add("O campo \"Amigo\" deve ser preenchido;");

        return erros;
    }

    public override void AtualizarDados(Emprestimo entidadeAtualizada)
    {
        throw new NotImplementedException();
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
