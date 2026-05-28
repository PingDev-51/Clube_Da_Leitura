namespace ClubeDaLeituraWeb.WebApp.ModuloEmprestimo.Dominio;

public interface IRepositorioEmprestimo<Emprestimo>
{
    void Cadastrar(Emprestimo emprestimo);
    List<Emprestimo> SelecionarTodos();
    Emprestimo? SelecionarPorId(string idSelecionado);
    bool Excluir(Emprestimo registro);
}