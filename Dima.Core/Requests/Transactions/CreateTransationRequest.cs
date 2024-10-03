using Dima.Core.Enums;
using Dima.Core.Requests;
using System.ComponentModel.DataAnnotations;

namespace Dima.Core.Requests.Transactions;
public class CreateTransactionRequest : Request
{
    [Required(ErrorMessage = "Titulo inválido")]
    public string? Title { get; set; } = "";

    [Required(ErrorMessage = "Tipo inválido")]
    public ETransactionType Type { get; set; }

    [Required(ErrorMessage = "Valor inválido")]
    public decimal Amount { get; set; }

    [Required(ErrorMessage = "Categoria inválido")]
    public long CategoryId { get; set; }

    [Required(ErrorMessage = "Data inválido")]
    public DateTime PaidOrReceivedAt { get; set; }
}

