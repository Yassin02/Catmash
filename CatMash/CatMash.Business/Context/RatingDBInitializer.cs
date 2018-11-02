using CatMash.Business.Model;
using CatMash.Core.Json;
using System.Collections.Generic;
using System.Data.Entity;

namespace CatMash.Business.Context
{
    public class RatingDBInitializer : CreateDatabaseIfNotExists<RatingContext>
    {
        protected override void Seed(RatingContext context)
        {
            IList<Cat> defaultCats = new List<Cat>();

            //Serialize Cats's data (Images) into object CatsData 
            var data = JsonSerializer.DeserializeJson<CatsData>("https://latelier.co/data/cats.json");
            foreach (var item in data.Images)
            {
                defaultCats.Add(item);
            }

            context.Cats.AddRange(defaultCats);

            base.Seed(context);
        }

    }
}
