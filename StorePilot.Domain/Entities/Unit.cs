using System.ComponentModel.DataAnnotations;

namespace StorePilot.Domain.Entities;

public sealed class Unit
{
    public int UnitId { get; set; }

    [Required(ErrorMessage = "اسم الوحدة مطلوب!")]
    [MaxLength(20, ErrorMessage = "لا يمكن أن يتجاوز طول اسم الوحدة 20 حرف!")]
    public string UnitName { get; set; } = null!;
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public ICollection<Product> Products { get; } = new List<Product>();
}
