using System.ComponentModel.DataAnnotations;

namespace StorePilot.Domain.Entities;

public sealed class PaymentMethod
{
    public int MethodId { get; set; }

    [Required(ErrorMessage = "اسم طريقة الدفع مطلوب.")]
    [MaxLength(100, ErrorMessage = "لا يمكن أن يتجاوز طول اسم طريقة الدفع 100 حرف.")]
    public string Name { get; set; } = null!;
}
