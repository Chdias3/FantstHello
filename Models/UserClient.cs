using System;

namespace fantastHello.Models
{
  public class UserClient
  {
    public int Id { get; set; }

    public string Name { get; set; }

    public string Login { get; set; }

    public string PasswordClient { get; set; }

    public DateTime Birthdate { get; set; }
  }
}