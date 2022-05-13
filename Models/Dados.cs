using System.Collections.Generic;

namespace fantastHello.Models
{
  // 3° passo = classe Dados servirá para manipular os dados no sistema web - uma lista que recebe os itens do pedido
  public static class Dados
  {

    // como é publico eu coloco get e set
    public static Schedule ScheduleCurrent { get; set; }

    static Dados()
    {
      ScheduleCurrent = new Schedule();
    }

    private static List<itemOrder> dados = new List<itemOrder>();

    // Crie uma página com formulário para registrar um item de pedido. Cada item incluído será registrado no objeto estático PedidoAtual da classe Dados. 

    // metodo para incluir
    public static void OrderCurrent(itemOrder u)
    {
      dados.Add(u);
    }

    //  para listar 
    public static List<itemOrder> display()
    {
      return dados;
    }
  }
}