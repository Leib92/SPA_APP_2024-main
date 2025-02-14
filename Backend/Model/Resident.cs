namespace Backend.Model
{
    public class Resident
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Job { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
