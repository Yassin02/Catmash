using System.ComponentModel.DataAnnotations;

namespace CatMash.Business.Model
{
    public class Cat
    {
        [Key]
        public string Id { get; set; }
        public string Url { get; set; }
        public int Score { get; set; }
    }
}
