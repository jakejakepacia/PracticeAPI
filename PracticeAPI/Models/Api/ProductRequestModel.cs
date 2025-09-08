namespace PracticeAPI.Models.Api
{
    public class ProductRequestModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price  { get; set; }
        public  int UserId { get; set; }
    }
}
