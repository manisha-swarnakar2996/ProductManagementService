
using System;
using System.ComponentModel.DataAnnotations;
namespace ProductManagement.RequestModels;


public class ProductRequestModel
{
    public int Id { get; set; }

    public string UniqueNumber { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public double Price { get; set; }

    public int Stock { get; set; }
}

