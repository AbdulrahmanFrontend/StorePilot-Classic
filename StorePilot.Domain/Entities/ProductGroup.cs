using System.ComponentModel.DataAnnotations;

namespace StorePilot.Domain.Entities;

public sealed class ProductGroup
{
    public int GroupId { get; set; }

    [Required(ErrorMessage = "اسم المجموعة مطلوب!")]
    [MaxLength(20, ErrorMessage = "لا يمكن أن يتجاوز طول اسم المجموعة 20 حرف!")]
    public string GroupName { get; set; } = null!;
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public ICollection<Product> Products { get; } = new List<Product>();
}
