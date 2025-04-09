namespace ExamenCSharp.Core.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Matricule { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public List<NumeroTelephone> NumerosTelephone { get; set; }

        public Client()
        {
            NumerosTelephone = new List<NumeroTelephone>();
        }
    }
}

