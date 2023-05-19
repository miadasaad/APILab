namespace APIDAL.Data.Models
{
    public class Developer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Ticket> Tickets { get;set; } = new HashSet<Ticket>();
    }
}
