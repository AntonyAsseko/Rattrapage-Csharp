using Microsoft.AspNetCore.Mvc;
using ExamenCSharp.Core.Models;
using ExamenCSharp.Services;

namespace ExamenCSharp.WebApp.Controllers
{
    public class ClientsController : Controller
    {
        private readonly ClientService _clientService;

        public ClientsController(ClientService clientService)
        {
            _clientService = clientService;
        }

        public IActionResult Index()
        {
            var clients = _clientService.ListerClients();
            return View(clients);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Client client)
        {
            if (ModelState.IsValid)
            {
                _clientService.AjouterClient(client);
                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }

        
    }
}
