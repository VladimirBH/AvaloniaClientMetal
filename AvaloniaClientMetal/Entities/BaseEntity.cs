using System;
using AvaloniaClientMetal.Interfaces;

namespace AvaloniaClientMetal.Models;

public class BaseEntity : IEntity
{
    public int Id { set; get; }
    public DateTime CreationDate { set; get; }
}