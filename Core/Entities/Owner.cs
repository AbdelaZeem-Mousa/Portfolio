namespace Core.Entities
{
    public class Owner : BaseEntite
    {
        public string FullName { get; set; }
        public string Profile { get; set; }
        public string Avatar { get; set; }
        public Address address { get; set; }
    }
}
