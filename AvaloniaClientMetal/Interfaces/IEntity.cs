using System;

namespace AvaloniaClientMetal.Interfaces;

public interface IEntity
{
    int Id { get; set; }
    DateTime CreationDate { get; set; }
}