namespace APIDAL.Data.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public ICollection<Developer> Developers { get; set; } = new HashSet<Developer>();
    }
}
