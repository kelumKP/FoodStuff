using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
public class FoodVendor
{
    public int Id { get; set; }

    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

}
