using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ntvspace.GlobalStoreApi.Data.Entities
{
  public class Customer
  {
    [Key]
    public int Id { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string UserName { get; set; }
    [Required]
    public string Email { get; set; }
    public string CellNumber { get; set; }
    public string AlternativeNumber { get; set; }
    public DateTime DateOfBirth { get; set; }
    public DateTime JoinDate { get; set; }
    public virtual ICollection<Address> Addresses { get; set; }
    public virtual ICollection<Order> Orders { get; set; }
  }
}
