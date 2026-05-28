public record ListarEmprestimosViewModel(
    string Id,
    string Revista,
    string Amigo,
    DateTime dataAbertura,
    DateTime DataConclusaoPrevista
);

public record CadastrarEmprestimosViewModel(
    string Revista,
    string Amigo,
    DateTime dataAbertura,
    DateTime DataConclusaoPrevista
);
