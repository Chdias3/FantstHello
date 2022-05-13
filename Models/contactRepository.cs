using MySqlConnector;
using System;
using System.Collections.Generic;

namespace fantastHello.Models
{
  public class contactRepository
  {

    // metodos, operaçoes
    // testar a Connection com o banco de dados
    private const string DataConnection = "Database=FantastHello;Data Source=localhost;User Id=root;";

    // 4 metodos para CRUD
    // Inserir, alterar, listar e excluir usuario no banco de dados

    public void insert(contact newContact)
    {
      //1 aqui é ABERTO a Connection
      MySqlConnection Connection = new MySqlConnection(DataConnection);
      Connection.Open();

      //2 preparar a query
      string Query = "INSERT INTO contact (name,email,whattsapp,doubt) VALUES (@name,@email,@whattsapp,@doubt)";

      //3 preparar o Command
      MySqlCommand Command = new MySqlCommand(Query, Connection);

      //4 trata do SQL INJECTION
      Command.Parameters.AddWithValue("@name", newContact.name);
      Command.Parameters.AddWithValue("@email", newContact.email);
      Command.Parameters.AddWithValue("@whattsapp", newContact.whattsapp);
      Command.Parameters.AddWithValue("@doubt", newContact.doubt);



      //5 aqui executamos o Command 
      Command.ExecuteNonQuery();

      //6 aqui é FECHADO a Connection
      Connection.Close();
    }

    public void toUpdate(contact update)
    {
      //1 aqui é ABERTO a Connection
      MySqlConnection Connection = new MySqlConnection(DataConnection);
      Connection.Open();

      //2 preparar a query
      string Query = "UPDATE contact SET  name=@name, email=@email, whattsapp=@whattsapp, doubt=@doubt WHERE idContact=@idContact";

      //3 preparar o Command
      MySqlCommand Command = new MySqlCommand(Query, Connection);

      //4 trata do SQL INJECTION
      Command.Parameters.AddWithValue("@idContact", update.idContact);
      Command.Parameters.AddWithValue("@name", update.name);
      Command.Parameters.AddWithValue("@email", update.email);
      Command.Parameters.AddWithValue("@whattsapp", update.whattsapp);
      Command.Parameters.AddWithValue("@doubt", update.doubt);


      //substituir o valor informado na variavel @Id pelo user.Id // e validar internamente, se o valor passado nao é mal intencionado (SQL INJECTION)

      //5 aqui executamos o Command 
      Command.ExecuteNonQuery();

      //6 aqui é FECHADO a Connection
      Connection.Close();

    }


    public void remove(contact item)
    {
      //1 aqui é ABERTO a Connection
      MySqlConnection Connection = new MySqlConnection(DataConnection);
      Connection.Open();

      //2 informando uma query do objeto Connection
      string Query = "DELETE FROM contact WHERE idContact=@idContact";
      MySqlCommand Command = new MySqlCommand(Query, Connection);


      //3 trata do SQL INJECTION
      Command.Parameters.AddWithValue("@idContact", item.idContact); //substituir o valor informado na variavel @Id
      // e validar internamente, se o valor passado nao é mal intencionado (SQL INJECTION)

      //4 aqui executamos o Command no banco de dados
      Command.ExecuteNonQuery();

      //5  aqui é FECHADO a Connection
      Connection.Close();
    }


    //BUSCAR por Id 
    public contact searchById(int idContact)
    {
      //1 aqui é ABERTO a Connection
      MySqlConnection Connection = new MySqlConnection(DataConnection);
      Connection.Open();

      //2 cria um usuario vazio
      contact contactFound = new contact();

      //3 informando uma query 
      string Query = "SELECT * FROM contact WHERE idContact=@idContact";

      //4 prepara o Command e executa
      MySqlCommand Command = new MySqlCommand(Query, Connection);

      //5 trata do SQL INJECTION
      Command.Parameters.AddWithValue("@idContact", idContact);

      //6 aqui executamos o Command e guardamos as informaçoes retornadas  no objeto da classe MySqlDataReader 
      MySqlDataReader Reader = Command.ExecuteReader();

      //7 percurso
      if (Reader.Read())
      {
        contactFound.idContact = Reader.GetInt32("idContact");

        if (!Reader.IsDBNull(Reader.GetOrdinal("name"))) //quer dizer, se não for nulo ele entra, por isso o "!" sem ! tudo que for nulo entra
        {
          contactFound.name = Reader.GetString("name");
        }

        if (!Reader.IsDBNull(Reader.GetOrdinal("email")))
        {
          contactFound.email = Reader.GetString("email");
        }

        if (!Reader.IsDBNull(Reader.GetOrdinal("whattsapp")))
        {
          contactFound.whattsapp = Reader.GetString("whattsapp");
        }

        if (!Reader.IsDBNull(Reader.GetOrdinal("doubt")))
        {
          contactFound.doubt = Reader.GetString("doubt");
        }

      }

      //8 aqui é FECHADO a Connection
      Connection.Close();

      //9 retorno a lista 
      return contactFound;
    }



    public List<contact> list()
    {
      //1 aqui é ABERTO a Connection
      MySqlConnection Connection = new MySqlConnection(DataConnection);
      Connection.Open();

      //2 criando a lista, logo ela esta vazia 
      List<contact> ListOfContact = new List<contact>();

      string Query = "SELECT * FROM contact";
      //3 informando uma query do objeto Connection 
      MySqlCommand Command = new MySqlCommand(Query, Connection);

      //4 aqui executamos o Command e guardamos as informaçoes executadas no objeto da classe MySqlDataReader 
      MySqlDataReader Reader = Command.ExecuteReader();

      //5 percorrer registro e registro o reader retornando 
      while (Reader.Read())
      {
        contact OrderFound = new contact();

        OrderFound.idContact = Reader.GetInt32("idContact");

        if (!Reader.IsDBNull(Reader.GetOrdinal("name")))
        {
          // tratativa para nao permitir incerir na lista dados Null 
          OrderFound.name = Reader.GetString("name");
        }

        if (!Reader.IsDBNull(Reader.GetOrdinal("email")))
        {
          // tratativa para nao permitir incerir na lista dados Null 
          OrderFound.email = Reader.GetString("email");
        }

        if (!Reader.IsDBNull(Reader.GetOrdinal("whattsapp")))
        {
          OrderFound.whattsapp = Reader.GetString("whattsapp");
        }

        if (!Reader.IsDBNull(Reader.GetOrdinal("doubt")))
        {
          OrderFound.doubt = Reader.GetString("doubt");
        }

        ListOfContact.Add(OrderFound);
      }

      //6 aqui é FECHADO a Connection
      Connection.Close();

      //7 retorno a lista 
      return ListOfContact;
    }


  }
}