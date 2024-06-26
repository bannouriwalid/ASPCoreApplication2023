﻿namespace OnlineFoodOrderApp.Models;

public class Food
{
    public int FoodId { get; set; }
    public string? Name { get; set; }
    public string? ShortDescription { get; set; }
    public string? LongDescription { get; set; }
    public decimal Price { get; set; }
    public string? ImageUrl { get; set; }
    public bool IsPreferredFoods { get; set; }
    public int CategoryId { get; set; }
    public virtual Category? Category { get; set; }
}