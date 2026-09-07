using System;
using System.Collections.Generic;
using System.Text;

namespace StorePilot.Domain.Entities;

public class Unit
{
    public int UnitId { get; set; }

    public string UnitName { get; set; } = string.Empty;


    // Navigation Property

    public ICollection<Product> Products { get; set; }
        = new List<Product>();
}