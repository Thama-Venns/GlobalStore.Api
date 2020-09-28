using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ntvspace.GlobalStoreApi.Data.Entities
{
  public class Account
  {
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    [StringLength(15)]
    public string Reference { get; set; }
    public double Balance { get; set; }
    public double CreditLimit { get; set; }
    public double AmountDue { get; set; }
    public double LastPaymentAmount { get; set; }
    public DateTime NextPayment { get; set; }
    public DateTime PreviousPayment { get; set; }
    public int CustomerId { get; set; }
    public virtual Customer Customer { get; set; }
    public virtual ICollection<Creditor> Creditors { get; set; }
  }
}
