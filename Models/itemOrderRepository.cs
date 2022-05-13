using MySqlConnector;
using System;
using System.Collections.Generic;

namespace fantastHello.Models
{
  public class itemOrderRepository
  {
    // metodos, operaçoes
    // testar a Connection com o banco de dados
    private const string DataConnection = "Database=FantastHello;Data Source=localhost;User Id=root;";

    // 4 metodos para CRUD
    // Inserir, alterar, listar e excluir usuario no banco de dados

    public void insert(itemOrder newOrder)
    {
      //1 aqui é ABERTO a Connection
      MySqlConnection Connection = new MySqlConnection(DataConnection);
      Connection.Open();

      //2 preparar a query
      string Query = "INSERT INTO itemOrder (description,productPhoto,value_unitary,quantity,idUser) VALUES (@description,@productPhoto,@value_unitary,@quantity,@idUser)";

      //3 preparar o Command
      MySqlCommand Command = new MySqlCommand(Query, Connection);

      //4 trata do SQL INJECTION
      Command.Parameters.AddWithValue("@description", newOrder.description);
      Command.Parameters.AddWithValue("@productPhoto", newOrder.productPhoto);
      Command.Parameters.AddWithValue("@value_unitary", newOrder.value_unitary);
      Command.Parameters.AddWithValue("@quantity", newOrder.quantity);
      Command.Parameters.AddWithValue("@idUser", newOrder.idUser);


      //5 aqui executamos o Command 
      Command.ExecuteNonQuery();

      //6 aqui é FECHADO a Connection
      Connection.Close();
    }

    public void toUpdate(itemOrder order)
    {
      //1 aqui é ABERTO a Connection
      MySqlConnection Connection = new MySqlConnection(DataConnection);
      Connection.Open();

      //2 preparar a query
      string Query = "UPDATE itemOrder SET  description=@description, productPhoto=@productPhoto, value_unitary=@value_unitary, quantity=@quantity, idUser=@idUser  WHERE idProduct=@idProduct";

      //3 preparar o Command
      MySqlCommand Command = new MySqlCommand(Query, Connection);

      //4 trata do SQL INJECTION
      Command.Parameters.AddWithValue("@idProduct", order.idProduct);
      Command.Parameters.AddWithValue("@description", order.description);
      Command.Parameters.AddWithValue("@productPhoto", order.productPhoto);
      Command.Parameters.AddWithValue("@value_unitary", order.value_unitary);
      Command.Parameters.AddWithValue("@quantity", order.quantity);
      Command.Parameters.AddWithValue("@idUser", order.idUser);

      //substituir o valor informado na variavel @Id pelo user.Id // e validar internamente, se o valor passado nao é mal intencionado (SQL INJECTION)

      //5 aqui executamos o Command 
      Command.ExecuteNonQuery();

      //6 aqui é FECHADO a Connection
      Connection.Close();

    }


    public void remove(itemOrder item)
    {
      //1 aqui é ABERTO a Connection
      MySqlConnection Connection = new MySqlConnection(DataConnection);
      Connection.Open();

      //2 informando uma query do objeto Connection
      string Query = "DELETE FROM itemOrder WHERE idProduct=@idProduct";
      MySqlCommand Command = new MySqlCommand(Query, Connection);


      //3 trata do SQL INJECTION
      Command.Parameters.AddWithValue("@idProduct", item.idProduct); //substituir o valor informado na variavel @Id
      // e validar internamente, se o valor passado nao é mal intencionado (SQL INJECTION)

      //4 aqui executamos o Command no banco de dados
      Command.ExecuteNonQuery();

      //5  aqui é FECHADO a Connection
      Connection.Close();
    }


    //BUSCAR por Id 
    public itemOrder searchById(int idProduct)
    {
      //1 aqui é ABERTO a Connection
      MySqlConnection Connection = new MySqlConnection(DataConnection);
      Connection.Open();

      //2 cria um usuario vazio
      itemOrder OrderFound = new itemOrder();

      //3 informando uma query 
      string Query = "SELECT * FROM itemOrder WHERE idProduct=@idProduct";

      //4 prepara o Command e executa
      MySqlCommand Command = new MySqlCommand(Query, Connection);

      //5 trata do SQL INJECTION
      Command.Parameters.AddWithValue("@idProduct", idProduct);

      //6 aqui executamos o Command e guardamos as informaçoes retornadas  no objeto da classe MySqlDataReader 
      MySqlDataReader Reader = Command.ExecuteReader();

      //7 percurso
      if (Reader.Read())
      {
        OrderFound.idProduct = Reader.GetInt32("idProduct");

        if (!Reader.IsDBNull(Reader.GetOrdinal("description"))) //quer dizer, se não for nulo ele entra, por isso o "!" sem ! tudo que for nulo entra
        {
          OrderFound.description = Reader.GetString("description");
        }

        if (!Reader.IsDBNull(Reader.GetOrdinal("productPhoto")))
        {
          OrderFound.productPhoto = Reader.GetString("productPhoto");
        }

        if (!Reader.IsDBNull(Reader.GetOrdinal("value_unitary")))
        {
          OrderFound.value_unitary = Reader.GetDouble("value_unitary");
        }

        if (!Reader.IsDBNull(Reader.GetOrdinal("quantity")))
        {
          OrderFound.quantity = Reader.GetInt32("quantity");
        }



      }

      //8 aqui é FECHADO a Connection
      Connection.Close();

      //9 retorno a lista 
      return OrderFound;
    }



    public List<itemOrder> list()
    {
      //1 aqui é ABERTO a Connection
      MySqlConnection Connection = new MySqlConnection(DataConnection);
      Connection.Open();

      //2 criando a lista, logo ela esta vazia 
      List<itemOrder> ListOfOrder = new List<itemOrder>();

      string Query = "SELECT * FROM itemOrder";
      //3 informando uma query do objeto Connection 
      MySqlCommand Command = new MySqlCommand(Query, Connection);

      //4 aqui executamos o Command e guardamos as informaçoes executadas no objeto da classe MySqlDataReader 
      MySqlDataReader Reader = Command.ExecuteReader();

      //5 percorrer registro e registro o reader retornando 
      while (Reader.Read())
      {
        itemOrder OrderFound = new itemOrder();

        OrderFound.idProduct = Reader.GetInt32("idProduct");

        if (!Reader.IsDBNull(Reader.GetOrdinal("description")))
        {
          // tratativa para nao permitir incerir na lista dados Null 
          OrderFound.description = Reader.GetString("description");
        }

        if (!Reader.IsDBNull(Reader.GetOrdinal("productPhoto")))
        {
          // tratativa para nao permitir incerir na lista dados Null 
          OrderFound.productPhoto = Reader.GetString("productPhoto");
        }

        if (!Reader.IsDBNull(Reader.GetOrdinal("value_unitary")))
        {
          OrderFound.value_unitary = Reader.GetDouble("value_unitary");
        }

        if (!Reader.IsDBNull(Reader.GetOrdinal("quantity")))
        {
          OrderFound.quantity = Reader.GetInt32("quantity");
        }

        if (!Reader.IsDBNull(Reader.GetOrdinal("idUser")))
        {
          OrderFound.idUser = Reader.GetInt32("idUser");
        }

        ListOfOrder.Add(OrderFound);
      }

      //6 aqui é FECHADO a Connection
      Connection.Close();

      //7 retorno a lista 
      return ListOfOrder;
    }
  }
}