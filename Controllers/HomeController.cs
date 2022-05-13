using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using fantastHello.Models;

namespace fantastHello.Controllers
{
  public class HomeController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }
    public IActionResult home()
    {
      return View();
    }

    public IActionResult stories()
    {
      return View();
    }

    public IActionResult articles()
    {
      return View();
    }

    public IActionResult article()
    {
      return View();
    }
    public IActionResult gallery()
    {
      return View();
    }
    public IActionResult galleryVideo()
    {
      return View();
    }
    public IActionResult listing()
    {
      List<contact> l = Dados.ScheduleCurrent.ListContacts();
      return View(l);
    }
    public IActionResult contact()
    {
      // finalidade é chamar o formulario do contato
      return View();
    }

    [HttpPost]
    public IActionResult contact(contact c)
    {
      // finalidade é receber os dados informado no formulario
      // aqui nao vou listar contato mas sim adicionar
      Dados.ScheduleCurrent.AddContacts(c);
      return RedirectToAction("listing");
      //com RedirectToAction quando clicar em enviar no formulario vai direto para lista
    }

    // metodo para receber e listar --
    public IActionResult cart(itemOrder item)
    {
      Dados.OrderCurrent(item);
      List<itemOrder> lists = Dados.display();
      return View(lists);
    }

  }
}
