using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RolForServer.Models;

namespace RolForServer.Controllers {
    public class HomeController : Controller {
        public IActionResult Index() {
            return View();
        }

        public IActionResult Forums() {
            return View();
        }

        public IActionResult Forum() {
            ViewBag.Messages = new Messages {
                Topic = new List<Message> {
                    new Message {Text = "Первое сообщение."},
                    new Message {Text = "Второе сообщение, текста стало больше, строка имеет достаточно большую длину. Теперь работают переносы строк.<br>1<br>2<br>3<br>4<br>5<br>6<br>7<br>8<br>9<br>10<br>11<br>12<br>13<br>14"},
                    new Message {Text = "Третье. Ещё текст."},
                    new Message {Text = "4"}
                }
            };
            return View();
        }
    }
}