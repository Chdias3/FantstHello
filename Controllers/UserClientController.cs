using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using fantastHello.Models;

namespace fantastHello.Controllers
{
  public class UserClientController : Controller // : controller é uma herança 
  {
    public IActionResult Login()
    {
      return View();
    }

    //Recebe o dados preenchido
    [HttpPost]
    public IActionResult Login(UserClient usuario)
    {
      UserClientRepository ur = new UserClientRepository();
      UserClient usuarioSessao = ur.ValidarLogin(usuario);

      if (usuarioSessao == null)
      {
        //nao localizado usuario com os dados informados no objeto usuario
        ViewBag.Mensagem = "Usuario não localizado com o login e senha informado!";
        return View();
      }
      else
      {
        //significa login localizado ou encontrado 

        //1 prepara a mensagem 
        ViewBag.Mensagem = "Você está logado!";

        //2 registra na sessao os dados do usuario
        HttpContext.Session.SetInt32("IdUsuario", usuarioSessao.Id);
        HttpContext.Session.SetString("NomeUsuario", usuarioSessao.Name);

        //3 redirecionamento 
        return View();
      }
    }

    public IActionResult Logout()
    {
      //1 limpar os daods da sessao
      HttpContext.Session.Clear(); // metodo clear limpa todos os dados da minha sessao

      //2 redirecionamento 

      return View("Login");
    }


    public IActionResult List()
    {
      //validando se o usuario esta logado. Caso não esteja é redirecionado para Login
      if (HttpContext.Session.GetInt32("IdUsuario") == null)
      {
        return RedirectToAction("Login", "UserClient");
      }

      UserClientRepository ur = new UserClientRepository();
      List<UserClient> lista = ur.list();
      return View(lista);
    }

    public IActionResult Delete(int Id)
    {
      //validando se o usuario esta logado. Caso não esteja é redirecionado para Login
      if (HttpContext.Session.GetInt32("IdUsuario") == null)
      {
        return RedirectToAction("Login", "UserClient");
      }

      UserClientRepository ur = new UserClientRepository();
      UserClient userFound = ur.searchById(Id);

      if (userFound.Id > 0)
      {
        ur.remove(userFound);
      }
      else
      {
        ViewData["mansagem"] = "Usuario não localizado";
      }

      return RedirectToAction("List");
    }


    //Chama o formulario
    public IActionResult Insert()
    {
      return View();
    }

    //Recebe o dados preenchido
    [HttpPost]
    public IActionResult Insert(UserClient newUser)
    {
      UserClientRepository ur = new UserClientRepository();
      ur.insert(newUser);

      ViewData["mansagem"] = "Cadastro realizado com sucesso";
      return View();
    }

    public IActionResult ToUpdate(int Id)
    {
      //validando se o usuario esta logado. Caso não esteja é redirecionado para Login
      if (HttpContext.Session.GetInt32("IdUsuario") == null)
      {
        return RedirectToAction("Login", "UserClient");
      }

      UserClientRepository ur = new UserClientRepository();
      UserClient userFound = ur.searchById(Id);

      return View(userFound);
    }

    [HttpPost]
    public IActionResult ToUpdate(UserClient item)
    {
      UserClientRepository ur = new UserClientRepository();
      ur.toUpdate(item);

      return RedirectToAction("List");
    }


  }
}