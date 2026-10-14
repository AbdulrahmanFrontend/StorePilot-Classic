using System.ComponentModel.DataAnnotations;

namespace StorePilot.Domain.Entities;

public sealed class ProductGroup
{
    public int GroupId { get; set; }

    [Required(ErrorMessage = "اسم المجموعة مطلوب.")]
    [MaxLength(100, ErrorMessage = "لا يمكن أن يتجاوز طول اسم المجموعة 100 حرف.")]
    public string Name { get; set; } = null!;
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public ICollection<Product> Products { get; } = new List<Product>();
}
