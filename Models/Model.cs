using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EfTest02.Models;

public class TodoModel
{
    
    public int Id { get; set; }
    public string Title { get; set; }
    public string? Content { get; set; }
    public bool Completed { get; set; }
    public DateTime? DueDate { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime UpdatedOn { get; set; }
    public List<Tag> Tags { get; set; }
    public List<Subtask> Subtasks { get; set; }



    public int CarId { get; set; }
    public List<Car> Cars { get; }
}

public class Subtask
{
    public int Id { get; set; }
    public string Title { get; set; }
    public bool Completed { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime UpdatedOn { get; set; }

    public int TodoId { get; set; }
    public TodoModel Todo { get; set; }
}


public class Tag
{
    public int Id { get; set; }
    public string Title { get; set; }

    public int TodoId { get; set; }
    public TodoModel Todos { get; set; }

}

public class Group
{
    public int Id { get; set; }
    public string Title { get; set; }

    public int UserId { get; set; }
    public List<User> Users { get;}

}

public class Car
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Slug { get; set;}
    public string Detail { get; set; }
    public string Thumb { get; set; }
    public string Image { get; set; }
    public string WhatCityCarIn { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime UpdatedOn { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }

    public int TodoId { get; set; }
    public List<TodoModel> Todos { get; set; }
}
public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? LastName { get; set; }
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    [DataType(DataType.Password)]
    [PasswordPropertyText]
    public string Password { get; set; }
    public bool IsActive { get; set; }
    public DateTime? DueDate { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime UpdatedOn { get; set; }

    public int GroupId { get; set; }
    public Group Group { get; }

    public int CarId { get; set; }
    public List<Car> Cars { get; set; }
}