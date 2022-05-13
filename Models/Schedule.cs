using System.Collections.Generic;

namespace fantastHello.Models
{
  public class Schedule
  {
    //atributos

    //modificador_acesso  tipo_dado  nome_atributo

    private List<contact> list;

    //metodos

    public Schedule()
    {
      //metodo construtor
      list = new List<contact>();
    }

    // metodo para incluir os dados
    public void AddContacts(contact c)
    {
      list.Add(c);
    }

    // metodo para totalizar
    public int TotalizeContact()
    {
      return list.Count;
    }

    // metodo para listar 
    public List<contact> ListContacts()
    {
      return list;
      //   foreach (Contato cc in lista)
      //   {
      //classe variavel_interna  in lista

      // Console.WriteLine("-----------------------------------------");

      // Console.WriteLine("Nome: " + cc.nome);

      // Console.WriteLine("Email: " + cc.email);

      // Console.WriteLine("WhattApp: " + cc.whattapp);
    }
  }
}
