using System.Linq;
using ExamenCSharp.Core.Models;
using ExamenCSharp.Data;

namespace ExamenCSharp.Services
{
    public class ClientService
    {
        private readonly AppDbContext _context;

        public ClientService(AppDbContext context)
        {
            _context = context;
        }

        public void AjouterClient(Client client)
        {
            _context.Clients.Add(client);
            _context.SaveChanges();
        }

        public List<Client> ListerClients()
        {
            return _context.Clients.ToList();
        }

        public void AjouterNumeroTelephone(int clientId, string numero)
        {
            var client = _context.Clients.Find(clientId);
            if (client != null)
            {
                var numeroTelephone = new NumeroTelephone { Numero = numero, ClientId = clientId };
                _context.NumerosTelephone.Add(numeroTelephone);
                _context.SaveChanges();
            }
        }

        public List<NumeroTelephone> ListerNumerosTelephone()
        {
            return _context.NumerosTelephone.ToList();
        }

        public List<NumeroTelephone> FiltrerParClient(int clientId)
        {
            return _context.NumerosTelephone.Where(n => n.ClientId == clientId).ToList();
        }

        public List<NumeroTelephone> FiltrerParOperateur(string operateur)
        {
            return _context.NumerosTelephone.Where(n => GetOperateur(n.Numero) == operateur).ToList();
        }

        public (Client, int) ClientAvecPlusDeNumeros()
        {
            return _context.Clients
                .OrderByDescending(c => c.NumerosTelephone.Count)
                .FirstOrDefault();
        }

        public (string, int) OperateurAvecPlusDeNumeros()
        {
            var grouped = _context.NumerosTelephone
                .GroupBy(n => GetOperateur(n.Numero))
                .Select(g => new { Operateur = g.Key, Count = g.Count() });

            return grouped.OrderByDescending(g => g.Count).FirstOrDefault();
        }

        private string GetOperateur(string numero)
        {
            if (numero.StartsWith("77") || numero.StartsWith("78"))
                return "Orange";
            if (numero.StartsWith("76"))
                return "Yas";
            if (numero.StartsWith("70"))
                return "Expresso";
            return "Inconnu";
        }
    }
}

