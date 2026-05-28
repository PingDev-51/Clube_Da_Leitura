public record ListarEmprestimosViewModel(
    string Id,
    string Revista,
    string Amigo,
    DateTime dataAbertura,
    DateTime DataConclusaoPrevista
);

public record CadastrarEmprestimosViewModel(
    string RevistaId,
    string AmigoId,
    DateTime DataAbertura,
    DateTime DataConclusaoPrevista
);

public record CadastrarDevolucaoViewModel(
    string RevistaId,
    string AmigoId,
    DateTime DataDevolucao,
    DateTime DataConclusaoPrevista
);