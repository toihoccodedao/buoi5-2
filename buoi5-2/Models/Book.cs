﻿using System.ComponentModel.DataAnnotations;
namespace buoi5_2.Models
{
    public class Book
    {


        
            public int Id { get; set; }
            public string Title { get; set; }
            public string Author { get; set; }
            public string Description { get; set; }
            public decimal Price { get; set; }
            public string Image { get; set; }
        }
    }



