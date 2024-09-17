using System;
using System.ComponentModel.DataAnnotations;

namespace API.Models;

public class AppUser
{
    [Key]
    public int UserID { get; set; }
    public required string Name { get; set; }
}
