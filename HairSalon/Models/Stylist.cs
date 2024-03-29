using System.Collections.Generic;

namespace HairSalon.Models
{
    public class Stylist
    {
        public int StylistID { get; set; }
        public string Name { get; set; }
        public string Specialty { get; set; }
        public virtual ICollection<Client> Clients { get; set; }

        public Stylist()
        {
            this.Clients = new HashSet<Client>();
        }
    }
}