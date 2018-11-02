using System.ComponentModel.DataAnnotations;

namespace CatMash.Business.Model
{
    public class Cat
    {
        [Key]
        public string Id { get; set; }
        public string Url { get; set; }
        //Give a default value of 100 to the score of all the cats
        public int Score { get; set; } = 100;
    }
}
