using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankSmall.Models;

public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = null!;

    [Required]
    public string CardNumber { get; set; } = null!;

    public bool Deleted { get; set; }


    public bool ? DepartmentId { get; set; }
    //public virtual DepartmentId Department { get; set; }


}
