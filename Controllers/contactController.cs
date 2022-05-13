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
  public class contactController : Controller
  {
    public IActionResult Insert()
    {

      return View();
    }

    [HttpPost]
    public IActionResult Insert(contact newContact)
    {
      contactRepository ur = new contactRepository();
      ur.insert(newContact);

      return RedirectToAction("List");
    }


    public IActionResult List()
    {

      //validando se o UserClient esta logado. Caso não esteja é redirecionado para Login
      if (HttpContext.Session.GetInt32("IdUsuario") == null)
      {
        return RedirectToAction("Login", "UserClient");
      }

      contactRepository ur = new contactRepository();
      List<contact> list = ur.list();
      return View(list);
    }


    public IActionResult Delete(int idContact)
    {
      //validando se o usuario esta logado. Caso não esteja é redirecionado para Login
      if (HttpContext.Session.GetInt32("IdUsuario") == null)
      {
        return RedirectToAction("Login", "UserClient");
      }

      contactRepository ur = new contactRepository();
      contact conatctFound = ur.searchById(idContact);

      if (conatctFound.idContact > 0)
      {
        ur.remove(conatctFound);
      }
      else
      {
        ViewData["mansagem"] = "Contato não localizado";
      }

      return RedirectToAction("List");
    }


    public IActionResult ToUpdate(int idContact)
    {
      //validando se o usuario esta logado. Caso não esteja é redirecionado para Login
      if (HttpContext.Session.GetInt32("IdUsuario") == null)
      {
        return RedirectToAction("Login", "UserClient");
      }

      contactRepository ur = new contactRepository();
      contact contactFound = ur.searchById(idContact);

      return View(contactFound);
    }

    [HttpPost]
    public IActionResult ToUpdate(contact item)
    {
      contactRepository ur = new contactRepository();
      ur.toUpdate(item);

      return RedirectToAction("List");
    }
  }
}
