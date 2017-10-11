using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutoCMS.Models;

namespace TutoCMS.Repo
{
    public class FakeDataRepository : IDataRepository
    {
        public static class FakeData
        {
            public static string LoremIpsum = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras congue convallis urna, in mattis nisl convallis quis. 
                Sed fringilla, odio et convallis lobortis, velit nulla ullamcorper purus, at bibendum eros sapien at ligula. Maecenas a dolor lectus. 
                Nulla iaculis neque sed ornare sollicitudin. Vestibulum at lobortis nisl. Integer justo metus, bibendum eget tincidunt non, fringilla at libero. 
                Aliquam tincidunt nulla vitae commodo molestie. Ut vitae finibus orci, ac lobortis tortor. 
                Proin dolor mauris, eleifend vitae elementum malesuada, accumsan sed nisi. 
                Maecenas sit amet volutpat dui.
                Suspendisse vestibulum erat non tellus blandit, at vestibulum ipsum aliquet.
M               auris eget nisl nec massa cursus facilisis eget et ipsum.Nunc venenatis eu massa ut sollicitudin.
                Aliquam sit amet mauris efficitur, pellentesque dolor sit amet, consectetur leo. Mauris ultrices et erat quis sagittis. 
                Proin non sem id risus suscipit pellentesque.Mauris ut malesuada metus. Phasellus vehicula tristique felis eu consectetur. 
                Ut ac purus id elit blandit sagittis.Morbi ullamcorper magna sit amet urna ullamcorper efficitur. Mauris euismod rutrum mi et iaculis.
                Donec dignissim vitae ligula nec finibus. Donec vel ultrices purus. 
                Mauris ultrices varius risus a maximus. Sed non risus varius, commodo velit in, tincidunt elit. 
                Aliquam eu mi dolor. In finibus rhoncus fringilla. Morbi commodo nulla vitae lobortis congue. 
                Sed dui tellus, auctor vel est nec, vulputate condimentum felis.Morbi accumsan tempor porttitor.";

            public static List<Entry> Entries = new List<Entry>
            {
                new Entry { Id = 1, CategoryId = 1, Title = "Very awesome part 1", Content = LoremIpsum.Substring(0, 300), UpdatedOn = DateTime.Now },
                new Entry { Id = 2, CategoryId = 1, Title = "Very awesome part 2", Content = LoremIpsum.Substring(0, 300), UpdatedOn = DateTime.Now },
                new Entry { Id = 3, CategoryId = 1, Title = "Very awesome part 3", Content = LoremIpsum.Substring(0, 300), UpdatedOn = DateTime.Now },
                new Entry { Id = 4, CategoryId = 1, Title = "Very awesome part 4", Content = LoremIpsum.Substring(0, 300), UpdatedOn = DateTime.Now },
                new Entry { Id = 5, CategoryId = 1, Title = "Very awesome part 5", Content = LoremIpsum.Substring(0, 300), UpdatedOn = DateTime.Now },
                new Entry { Id = 6, CategoryId = 1, Title = "Very awesome part 6", Content = LoremIpsum.Substring(0, 300), UpdatedOn = DateTime.Now },

            };
        }
        public Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            IEnumerable<Category> categories = new[]
            {
                new Category
                {
                    Id = 1,
                    Title = "Awesome",
                    Description ="This is awesome cateogry for make more awesome courses.",
                }
            };
            foreach (var category in categories)
            {
                category.Entries = FakeData.Entries.Where(x => x.CategoryId.Equals(category.Id)).ToList();
            }
            return Task.FromResult(categories);
        }
    }
}
