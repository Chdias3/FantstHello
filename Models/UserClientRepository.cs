using MySqlConnector;
using System;
using System.Collections.Generic;

namespace fantastHello.Models
{
  public class UserClientRepository
  {
    // metodos, operaçoes
    // testar a Connection com o banco de dados
    private const string DataConnection = "Database=FantastHello;Data Source=localhost;User Id=root;";

    // 4 metodos para CRUD
    // Inserir, alterar, listar e excluir usuario no banco de dados

    public void insert(UserClient newClient)
    {
      //1 aqui é ABERTO a Connection
      MySqlConnection Connection = new MySqlConnection(DataConnection);
      Connection.Open();

      //2 preparar a query
      string Query = "INSERT INTO UserClient (Name,Login,PasswordClient,Birthdate) VALUES (@Name,@Login,@PasswordClient,@Birthdate)";

      //3 preparar o Command
      MySqlCommand Command = new MySqlCommand(Query, Connection);

      //4 trata do SQL INJECTION
      Command.Parameters.AddWithValue("@Name", newClient.Name);
      Command.Parameters.AddWithValue("@Login", newClient.Login);
      Command.Parameters.AddWithValue("@PasswordClient", newClient.PasswordClient);
      Command.Parameters.AddWithValue("@Birthdate", newClient.Birthdate);


      //5 aqui executamos o Command 
      Command.ExecuteNonQuery();

      //6 aqui é FECHADO a Connection
      Connection.Close();
    }



    public void toUpdate(UserClient update)
    {
      //1 aqui é ABERTO a Connection
      MySqlConnection Connection = new MySqlConnection(DataConnection);
      Connection.Open();

      //2 preparar a query
      string Query = "UPDATE UserClient SET  Name=@Name, Login=@Login, PasswordClient=@PasswordClient, Birthdate=@Birthdate  WHERE Id=@Id";

      //3 preparar o Command
      MySqlCommand Command = new MySqlCommand(Query, Connection);

      //4 trata do SQL INJECTION
      Command.Parameters.AddWithValue("@Id", update.Id);
      Command.Parameters.AddWithValue("@Name", update.Name);
      Command.Parameters.AddWithValue("@Login", update.Login);
      Command.Parameters.AddWithValue("@PasswordClient", update.PasswordClient);
      Command.Parameters.AddWithValue("@Birthdate", update.Birthdate);

      //substituir o valor informado na variavel @Id pelo user.Id // e validar interNamente, se o valor passado nao é mal intencionado (SQL INJECTION)

      //5 aqui executamos o Command 
      Command.ExecuteNonQuery();

      //6 aqui é FECHADO a Connection
      Connection.Close();

    }


    public void remove(UserClient item)
    {
      //1 aqui é ABERTO a Connection
      MySqlConnection Connection = new MySqlConnection(DataConnection);
      Connection.Open();

      //2 informando uma query do objeto Connection
      string Query = "DELETE FROM UserClient WHERE Id=@Id";
      MySqlCommand Command = new MySqlCommand(Query, Connection);


      //3 trata do SQL INJECTION
      Command.Parameters.AddWithValue("@Id", item.Id); //substituir o valor informado na variavel @Id
      // e validar interNamente, se o valor passado nao é mal intencionado (SQL INJECTION)

      //4 aqui executamos o Command no banco de dados
      Command.ExecuteNonQuery();

      //5  aqui é FECHADO a Connection
      Connection.Close();
    }


    //BUSCAR por Id 
    public UserClient searchById(int Id)
    {
      //1 aqui é ABERTO a Connection
      MySqlConnection Connection = new MySqlConnection(DataConnection);
      Connection.Open();

      //2 cria um usuario vazio
      UserClient contactFound = new UserClient();

      //3 informando uma query 
      string Query = "SELECT * FROM UserClient WHERE Id=@Id";

      //4 prepara o Command e executa
      MySqlCommand Command = new MySqlCommand(Query, Connection);

      //5 trata do SQL INJECTION
      Command.Parameters.AddWithValue("@Id", Id);

      //6 aqui executamos o Command e guardamos as informaçoes retornadas  no objeto da classe MySqlDataReader 
      MySqlDataReader Reader = Command.ExecuteReader();

      //7 percurso
      if (Reader.Read())
      {
        contactFound.Id = Reader.GetInt32("Id");

        if (!Reader.IsDBNull(Reader.GetOrdinal("Name"))) //quer dizer, se não for nulo ele entra, por isso o "!" sem ! tudo que for nulo entra
        {
          contactFound.Name = Reader.GetString("Name");
        }

        if (!Reader.IsDBNull(Reader.GetOrdinal("Login")))
        {
          contactFound.Login = Reader.GetString("Login");
        }

        if (!Reader.IsDBNull(Reader.GetOrdinal("PasswordClient")))
        {
          contactFound.PasswordClient = Reader.GetString("PasswordClient");
        }


        contactFound.Birthdate = Reader.GetDateTime("Birthdate");


      }

      //8 aqui é FECHADO a Connection
      Connection.Close();

      //9 retorno a lista 
      return contactFound;
    }



    public List<UserClient> list()
    {
      //1 aqui é ABERTO a Connection
      MySqlConnection Connection = new MySqlConnection(DataConnection);
      Connection.Open();

      //2 criando a lista, logo ela esta vazia 
      List<UserClient> ListOfContact = new List<UserClient>();

      string Query = "SELECT * FROM UserClient";
      //3 informando uma query do objeto Connection 
      MySqlCommand Command = new MySqlCommand(Query, Connection);

      //4 aqui executamos o Command e guardamos as informaçoes executadas no objeto da classe MySqlDataReader 
      MySqlDataReader Reader = Command.ExecuteReader();

      //5 percorrer registro e registro o reader retornando 
      while (Reader.Read())
      {
        UserClient OrderFound = new UserClient();

        OrderFound.Id = Reader.GetInt32("Id");

        if (!Reader.IsDBNull(Reader.GetOrdinal("Name")))
        {
          // tratativa para nao permitir incerir na lista dados Null 
          OrderFound.Name = Reader.GetString("Name");
        }

        if (!Reader.IsDBNull(Reader.GetOrdinal("Login")))
        {
          // tratativa para nao permitir incerir na lista dados Null 
          OrderFound.Login = Reader.GetString("Login");
        }

        if (!Reader.IsDBNull(Reader.GetOrdinal("PasswordClient")))
        {
          OrderFound.PasswordClient = Reader.GetString("PasswordClient");
        }

        if (!Reader.IsDBNull(Reader.GetOrdinal("Birthdate")))
        {
          OrderFound.Birthdate = Reader.GetDateTime("Birthdate");
        }

        ListOfContact.Add(OrderFound);
      }

      //6 aqui é FECHADO a Connection
      Connection.Close();

      //7 retorno a lista 
      return ListOfContact;
    }



    public UserClient ValidarLogin(UserClient usuario)
    {

      //1 aqui é ABERTO a conexao
      MySqlConnection Conexao = new MySqlConnection(DataConnection);
      Conexao.Open();

      //2 cria um usuario vazio com null
      UserClient UsuarioEncontrado = null;

      //3 informando uma query 
      string Query = "SELECT * FROM UserClient WHERE Login=@Login and PasswordClient=@PasswordClient";

      //4 prepara o comando e executa
      MySqlCommand Comando = new MySqlCommand(Query, Conexao);

      //5 trata do SQL INJECTION
      Comando.Parameters.AddWithValue("@Login", usuario.Login);
      Comando.Parameters.AddWithValue("@PasswordClient", usuario.PasswordClient);

      //6 aqui executamos o comando e guardamos as informaçoes retornadas  no objeto da classe MySqlDataReader 
      MySqlDataReader Reader = Comando.ExecuteReader();

      //7 percurso
      if (Reader.Read())
      {

        UsuarioEncontrado = new UserClient();
        UsuarioEncontrado.Id = Reader.GetInt32("Id");

        if (!Reader.IsDBNull(Reader.GetOrdinal("Name"))) //quer dizer, se não for nulo ele entra, por isso o "!" sem ! tudo que for nulo entra
        {
          UsuarioEncontrado.Name = Reader.GetString("Name");
        }

        if (!Reader.IsDBNull(Reader.GetOrdinal("Login")))
        {
          UsuarioEncontrado.Login = Reader.GetString("Login");
        }

        if (!Reader.IsDBNull(Reader.GetOrdinal("PasswordClient")))
        {
          UsuarioEncontrado.PasswordClient = Reader.GetString("PasswordClient");
        }

        UsuarioEncontrado.Birthdate = Reader.GetDateTime("Birthdate");
      }

      //8 aqui é FECHADO a conexao
      Conexao.Close();

      //9 retorno a lista , se não localizado, retorna null
      return UsuarioEncontrado;
    }
  }
}