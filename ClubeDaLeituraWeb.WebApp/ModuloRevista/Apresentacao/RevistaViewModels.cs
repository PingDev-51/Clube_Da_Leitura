using System.ComponentModel.DataAnnotations;
using ClubeDaLeituraWeb.WebApp.ModuloCaixa.Dominio;

namespace ClubeDaLeituraWeb.WebApp.ModuloRevistas.Apresentacao;

public record ListarRevistasViewModel(
    string Id,
    string Titulo,
    int NumeroEdicao,
    int AnoPublicacao,
    string Caixa
);

public record CadastrarRevistaViewModel(
    [Required(ErrorMessage = "O campo \"Título\" deve ser preenchido.")]
    [StringLength(100, ErrorMessage = "O campo \"Título\" deve conter no máximo 100 caracteres.")]
    string Titulo,

    [Required(ErrorMessage = "O campo \"Número Da Edição\" deve ser preenchido.")]
    int NumeroEdicao,

    [Range(1, int.MaxValue, ErrorMessage = "O campo \"Ano de publicação\" deve conter um valor maior que 0.")]
    int AnoPublicacao,

    [Required(ErrorMessage = "O campo \"Caixa\" deve ser preenchido.")]
    string CaixaId
);

public record EditarRevistasViewModel(
    string Id,

    [Required(ErrorMessage = "O campo \"Título\" deve ser preenchido.")]
    [StringLength(100, ErrorMessage = "O campo \"Título\" deve conter no máximo 100 caracteres.")]
    string Titulo,

    [Required(ErrorMessage = "O campo \"Número Da Edição\" deve ser preenchido.")]
    int NumeroEdicao,

    [Range(1, int.MaxValue, ErrorMessage = "O campo \"Ano de publicação\" deve conter um valor maior que 0.")]
    int AnoPublicacao,

    [Required(ErrorMessage = "O campo \"Caixa\" deve ser preenchido.")]
    string CaixaId
);

public record ExcluirRevistaViewModel(
    string Id,
    string Titulo,
    int NumeroEdicao,
    int AnoPublicacao,
    string Caixa
);
