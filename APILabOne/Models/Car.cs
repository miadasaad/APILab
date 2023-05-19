using LabOne.validators;

namespace LabOne.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        [MustBeInPast]
        public DateTime ProductionDate { get; set; }
        public string type { get; set; }
    }
}
