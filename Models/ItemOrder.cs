using System.Collections.Generic;

namespace fantastHello.Models
{

  public class itemOrder
  {
    public int idProduct { get; set; }
    public string description { get; set; }
    public string productPhoto { get; set; }

    public double value_unitary { get; set; }

    public int idUser { get; set; }

    public int quantity { get; set; }

  }
}