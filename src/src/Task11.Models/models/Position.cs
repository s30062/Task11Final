using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace src.Task11.Models;

public partial class Position
{
    public int Id { get; set; }


    public string Name { get; set; }
    
    public int ExpYears { get; set; }

    
    public virtual ICollection<Employee> Employees { get; set; }
}