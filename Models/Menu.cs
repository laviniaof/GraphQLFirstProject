namespace GraphQLProject.Models
{
    public class Menu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description{ get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }

        public int CategoryId { get; set; }
    }
}
