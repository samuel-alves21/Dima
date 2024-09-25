using System.ComponentModel.DataAnnotations;

namespace Dima.Core.Requests;

public class UpdateCategoryRequest : Request
{
    [Required(ErrorMessage = "Titúlo inválido")]
    [MaxLength(80, ErrorMessage = "O título não pode ter mais de 80 caracteres")]
    [MinLength(3, ErrorMessage = "O título deve ter pelo menos 3 caracteres")]
    public string Title { get; set; } = "";

    [Required(ErrorMessage = "Descrição inválida")]
    public string Description { get; set; } = "";
}