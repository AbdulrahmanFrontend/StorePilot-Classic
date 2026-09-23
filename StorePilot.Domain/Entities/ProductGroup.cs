using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StorePilot.Domain.Entities;

public sealed class ProductGroup
{
    public int GroupId { get; set; }

    [Required(ErrorMessage = "اسم المجموعة مطلوب.")]
    [MaxLength(100, ErrorMessage = "لا يمكن أن يتجاوز طول اسم المجموعة 100 حرف.")]
    public string Name { get; set; } = null!;

    public ICollection<Product> Products { get; } = new List<Product>();
}
