namespace ExamenCSharp.Core.Models
{
    public class NumeroTelephone
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}
