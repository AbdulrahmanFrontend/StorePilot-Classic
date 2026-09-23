using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StorePilot.Domain.Entities;

public sealed class Unit
{
    public int UnitId { get; set; }

    [Required(ErrorMessage = "اسم الوحدة مطلوب.")]
    [MaxLength(100, ErrorMessage = "لا يمكن أن يتجاوز طول اسم الوحدة 100 حرف.")]
    public string Name { get; set; } = null!;

    public ICollection<Product> Products { get; } = new List<Product>();
}
