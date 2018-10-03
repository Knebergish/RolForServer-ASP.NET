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
                    new Message {Text = "1"},
                    new Message {Text = "2"},
                    new Message {Text = "3"},
                    new Message {Text = "4"}
                }
            };
            return View();
        }
    }
}