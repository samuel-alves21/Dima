using System.ComponentModel.DataAnnotations;

namespace Dima.Core.Requests;

public class UpdateCategoryRequest : Request
{
    [Required(ErrorMessage = "Tit�lo inv�lido")]
    [MaxLength(80, ErrorMessage = "O t�tulo n�o pode ter mais de 80 caracteres")]
    [MinLength(3, ErrorMessage = "O t�tulo deve ter pelo menos 3 caracteres")]
    public string Title { get; set; } = "";

    [Required(ErrorMessage = "Descri��o inv�lida")]
    public string Description { get; set; } = "";
}