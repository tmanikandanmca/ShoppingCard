﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using CatelogServices;
using System;
using System.Collections.Generic;

namespace CatelogServices.DBModels;

public partial class Product
{
    public int ProductId { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public decimal UnitPrice { get; set; }

    public int CategoryId { get; set; }

    public virtual Category Category { get; set; }
}