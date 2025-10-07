using BankSmall.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
public class ViewModel
{
    public User NewUser { get; set; }
    public List<User> Users { get; set; }
    //public List<DepartmentId> Departments { get; set; }
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Card number is required")]
    public string CardNumber { get; set; }

    public bool Deleted { get; set; }

    [Display(Name = "Department")]
    public int? DepartmentId { get; set; }

    public SelectList DepartmentOptions { get; set; }
}


