using System;
using System.Collections.Generic;
using System.Text;

namespace StorePilot.Domain.Entities;

public class Group
{
    public int GroupId { get; set; }

    public string GroupName { get; set; } = string.Empty;

    // Navigation Property

    public ICollection<Product> Products { get; set; }
        = new List<Product>();
}