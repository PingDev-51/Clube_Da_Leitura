using ClubeDaLeituraWeb.WebApp.Compartilhado.Dominio;
using ClubeDaLeituraWeb.WebApp.ModuloAmigo.Dominio;
using ClubeDaLeituraWeb.WebApp.ModuloRevistas.Dominio;
namespace ClubeDaLeitura.ConsoleApp.Dominio;

public class Emprestimo : EntidadeBase<Emprestimo>
{
    public Revista Revista { get; set; }
    public Amigo Amigo { get; set; }
    public DateTime DataEmprestimo { get; set; }
    public DateTime DataDevolucao { get; set; }
    public DateTime? DataDevolvido { get; set; }
    public StatusEmprestimo Status
    {
        get
        {
            if (DataDevolvido.HasValue)
                return StatusEmprestimo.Concluido;
            if (DateTime.Today > DataDevolucao.Date)
                return StatusEmprestimo.Atrasado;

            return StatusEmprestimo.Aberto;
        }
    }

    public Emprestimo() { }
    public Emprestimo(Amigo amigo, Revista revista, DateTime dataEmprestimo, DateTime dataDevolucao)
    {
        Amigo = amigo;
        Revista = revista;
        DataEmprestimo = dataEmprestimo;
        DataDevolucao = dataDevolucao;
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

    public void RegistrarDevolucao()
    {
        DataDevolvido = DateTime.Today;
        Revista.Status = StatusRevista.Disponivel;
    }

    public override void AtualizarDados(Emprestimo entidadeAtualizada)
    {
        Amigo = entidadeAtualizada.Amigo;
        Revista = entidadeAtualizada.Revista;
        DataEmprestimo = entidadeAtualizada.DataEmprestimo;
        DataDevolucao = entidadeAtualizada.DataDevolucao;
        DataDevolvido = entidadeAtualizada.DataDevolvido;
    }

    // public void Abrir()
    // {
    //     DataAbertura = DateTime.Now;
    //     Status = StatusEmprestimo.Aberto;
    // }

    // public void Concluir()
    // {
    //     Status = StatusEmprestimo.Concluido;
    // }

    // public void Atrasado()
    // {
    //     Status = StatusEmprestimo.Atrasado;
    // }


    // public int ObterQuantidadeDiasAtraso(DateTime dataConclusao)
    // {
    //     return (dataConclusao - Status).Days;
    // }
}