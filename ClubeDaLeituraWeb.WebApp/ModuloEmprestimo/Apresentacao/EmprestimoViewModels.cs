using ClubeDaLeitura.ConsoleApp.Dominio;

public record ListarEmprestimosViewModel(
    string Id,
    string Revista,
    string Amigo,
    DateTime DataAbertura,
    DateTime DataConclusaoPrevista,
    StatusEmprestimo StatusEmprestimo
);

public record CadastrarEmprestimosViewModel(
    string RevistaId,
    string AmigoId,
    DateTime DataConclusaoPrevista,
    DateTime DataAbertura
);

public record CadastrarDevolucaoViewModel(
    string Id,
    string RevistaId,
    string AmigoId,
    DateTime DataAbertura,
    DateTime DataConclusaoPrevista
);