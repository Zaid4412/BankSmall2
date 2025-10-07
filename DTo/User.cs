using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BankSmall.Models
{
    public class UserView
    {
     
        public int? Id { get; set; }
        public string? Name { get; set; }

        public string? CardNumber { get; set; }
  


    }

}
