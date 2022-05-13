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
  public class itemOrderController : Controller
  {
    public IActionResult Insert()
    {


      return View();
    }

    [HttpPost]
    public IActionResult Insert(itemOrder order)
    {

      //validando se o usuario esta logado. Caso não esteja é redirecionado para Login
      if (HttpContext.Session.GetInt32("IdUsuario") == null)
      {
        return RedirectToAction("Login", "UserClient");
      }
      itemOrderRepository ur = new itemOrderRepository();
      ur.insert(order);

      return RedirectToAction("List");
    }


    public IActionResult List()
    {

      //validando se o usuario esta logado. Caso não esteja é redirecionado para Login
      if (HttpContext.Session.GetInt32("IdUsuario") == null)
      {
        return RedirectToAction("Login", "UserClient");
      }
      itemOrderRepository ur = new itemOrderRepository();
      List<itemOrder> list = ur.list();
      return View(list);
    }


    public IActionResult Delete(int idProduct)
    {
      //validando se o usuario esta logado. Caso não esteja é redirecionado para Login
      if (HttpContext.Session.GetInt32("IdUsuario") == null)
      {
        return RedirectToAction("Login", "UserClient");
      }

      itemOrderRepository ur = new itemOrderRepository();
      itemOrder OrderFound = ur.searchById(idProduct);

      if (OrderFound.idProduct > 0)
      {
        ur.remove(OrderFound);
      }
      else
      {
        ViewData["mansagem"] = "Pedido não localizado";
      }

      return RedirectToAction("List");
    }


    public IActionResult ToUpdate(int idProduct)
    {
      //validando se o usuario esta logado. Caso não esteja é redirecionado para Login
      if (HttpContext.Session.GetInt32("IdUsuario") == null)
      {
        return RedirectToAction("Login", "UserClient");
      }

      itemOrderRepository ur = new itemOrderRepository();
      itemOrder OrderFound = ur.searchById(idProduct);

      return View(OrderFound);
    }

    [HttpPost]
    public IActionResult ToUpdate(itemOrder item)
    {
      itemOrderRepository ur = new itemOrderRepository();
      ur.toUpdate(item);

      return RedirectToAction("List");
    }
  }
}

