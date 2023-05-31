using EfTest02.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

public class TodoAppContext : DbContext
{
    public DbSet<TodoModel> Todos { get; set; }
    public DbSet<Subtask> Substask { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<User> Users { get; set; }



    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=104.247.162.242\MSSQLSERVER2017;Database=akadem58_az;User Id=akadem58_az;Password=81mD0*6ik;TrustServerCertificate=True;");
    }
}