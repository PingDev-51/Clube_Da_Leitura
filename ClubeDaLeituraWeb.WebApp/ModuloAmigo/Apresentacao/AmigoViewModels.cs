using System.ComponentModel.DataAnnotations;

public record ListarAmigosViewModel(
    string Id,
    string Nome,
    string NomeResponsavel,
    string Telefone
);

public record CadastrarAmigosViewModel(
    [Required()]
    [StringLength(100, MinimumLength = 3, ErrorMessage ="O campo Nome deve conter entre 3 a 100 caracteres")]
    string Nome,

    [Required()]
    [StringLength(100, MinimumLength = 3, ErrorMessage ="O campo Nome do responsavel deve conter entre 3 a 100 caracteres")]
    string NomeResponsavel,

    [Required()]
    [StringLength(11, MinimumLength = 10, ErrorMessage ="O campo Telefone deve conter entre 10 a 11 caracteres")]
    string Telefone
);

public record EditarAmigosViewModel(
    string Id,

    [Required(ErrorMessage = "O campo Nome é obrigatorio")]
    [StringLength(100, MinimumLength = 3, ErrorMessage ="O campo Nome deve conter entre 3 a 100 caracteres")]
    string Nome,

    [Required(ErrorMessage = "O campo Nome do responsavel é obrigatorio")]
    [StringLength(100, MinimumLength = 3, ErrorMessage ="O campo Nome do responsavel deve conter entre 3 a 100 caracteres")]
    string NomeResponsavel,

    [Required()]
    [StringLength(11, MinimumLength = 10, ErrorMessage ="O campo Telefone deve conter entre 10 a 11 caracteres")]
    string Telefone
);

public record ExcluirAmigosViewModel(
    string Id,
    string Nome,
    string NomeResponsavel,
    string Telefone
);