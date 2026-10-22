using System;
using System.ComponentModel.DataAnnotations;

public class User
{

    [EmailAddress]
    public string Email { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string Password { get; set; }
    public int Id { get; set; }
}
