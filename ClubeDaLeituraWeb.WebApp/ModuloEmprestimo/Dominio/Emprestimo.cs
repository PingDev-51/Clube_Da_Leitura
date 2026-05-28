using System.Security.Cryptography;
using ClubeDaLeituraWeb.WebApp.Compartilhado.Dominio;
using ClubeDaLeituraWeb.WebApp.ModuloRevistas.Dominio;

namespace ClubeDaLeitura.ConsoleApp.Dominio;

public class Emprestimo : EntidadeBase<Emprestimo>
{
    public Revista Revista { get; set; }
    public Amigo Amigo { get; set; }
    public StatusEmprestimo Status { get; set; }
    public DateTime DataAbertura { get; set; }
    public DateTime ConclusaoPrevista
    {
        get
        {
            int diasDeEmprestimo = Revista.Caixa.DiasDeEmprestimo;

            DateTime conclusao = DataAbertura.AddDays(diasDeEmprestimo);

            return conclusao;
        }
    }

    public Emprestimo() { }
    public Emprestimo(Revista revista, Amigo amigo, DateTime dataAbertura)
    {
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
        Revista = entidadeAtualizada.Revista;
        Amigo = entidadeAtualizada.Amigo;
        DataAbertura = entidadeAtualizada.DataAbertura;
        Status = entidadeAtualizada.Status;
    }

    public void Abrir()
    {
        DataAbertura = DateTime.Now;
        Status = StatusEmprestimo.Aberto;
    }

    public void Concluir()
    {
        Status = StatusEmprestimo.Concluido;
    }

    public void Atrasado()
    {
        Status = StatusEmprestimo.Atrasado;
    }


    public int ObterQuantidadeDiasAtraso(DateTime dataConclusao)
    {
        return (dataConclusao - ConclusaoPrevista).Days;
    }
}