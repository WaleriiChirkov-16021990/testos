using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessDomain.Model;

namespace Persistence.ExperimentalData
{
    public class TestDataProvider
    {
        public static async Task Provide(DataContext context, int count = 30)
        {
            if (context.Activities.Any()) return;

            List<Activeness> activities = new List<Activeness>();

            for (int i = 1; i <= count; i++)
            {
                int month = Random.Shared.Next(1, 6);
                int category = Random.Shared.Next(1, 10);
                int city = Random.Shared.Next(1, 10);
                int location = Random.Shared.Next(1, 10);

                activities.Add(
                    new Activeness
                    {
                        Title = $"Тестовая активность #{i}",
                        PointTime = DateTime.SpecifyKind(DateTime.Now.AddMonths(month), DateTimeKind.Utc),
                        Description = $"Описание #{month}",
                        Category = $"Категория #{category}",
                        City = $"Город #{city}",
                        Location = $"Место проведения #{location}",
                    }
                );
            }

            await context.Activities.AddRangeAsync(activities);
            await context.SaveChangesAsync();
        }
    }
}
