using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tuto.Data.Models;
using TutoDataRepo;

namespace TutoRepo
{
    #region FakeData
    public class FakeData
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

        public List<Entry> Entries = new List<Entry>
        {
            new Entry { Id = 1, CategoryId = 1, Title = "Very awesome part 1", Content = LoremIpsum.Substring(0, 300), LastRevisionAt = DateTime.Now },
            new Entry { Id = 2, CategoryId = 1, Title = "Very awesome part 2", Content = LoremIpsum.Substring(0, 300), LastRevisionAt = DateTime.Now },
            new Entry { Id = 3, CategoryId = 1, Title = "Very awesome part 3", Content = LoremIpsum.Substring(0, 300), LastRevisionAt = DateTime.Now },
            new Entry { Id = 4, CategoryId = 1, Title = "Very awesome part 4", Content = LoremIpsum.Substring(0, 300), LastRevisionAt = DateTime.Now },
            new Entry { Id = 5, CategoryId = 1, Title = "Very awesome part 5", Content = LoremIpsum.Substring(0, 300), LastRevisionAt = DateTime.Now },
            new Entry { Id = 6, CategoryId = 1, Title = "Very awesome part 6", Content = LoremIpsum.Substring(0, 300), LastRevisionAt = DateTime.Now },
            new Entry { Id = 7, CategoryId = 2, Title = "Very awesome part 5", Content = LoremIpsum.Substring(0, 300), LastRevisionAt = DateTime.Now },
            new Entry { Id = 8, CategoryId = 2, Title = "Very awesome part 6", Content = LoremIpsum.Substring(0, 300), LastRevisionAt = DateTime.Now },
        };

        public List<Category> Categories = new List<Category>
        {
             new Category { Id = 1, Title = "Awesome", Description ="This is awesome cateogry for make more awesome courses."},
             new Category  {Id = 2, Title = "Very Awesome",Description ="This is second awesome cateogry for make more awesome courses."}
        };

        public WebsiteDetails WebsiteDetails = new WebsiteDetails
        {
            Title = "WebsiteTtile",
            OwnerEmail = "example@example.com"
        };

        public HomePageSettings HomePageSettings = new HomePageSettings()
        {
            Title = "HomeTitle",
            SeoDescription = "Awesome SEO Description",
            Descritpion = LoremIpsum.Substring(0, 500)
        };
        public List<Link> Links = new List<Link>
        {
            new Link { Id = 1, LinkTitle = "Great link to share", UrlAddress = "example.com"},
            new Link { Id = 2, LinkTitle = "Second great link to share", UrlAddress = "example.com2"}
        };
    }
    #endregion

    public class FakeTutoDataRepo : ITudoDataRepository
    {
        FakeData fakeData = new FakeData();
        public Task<List<Category>> GetAllCategories()
        {
            var categories = fakeData.Categories;
            foreach (var category in categories)
            {
                category.Entries = fakeData.Entries.Where(x => x.CategoryId.Equals(category.Id)).ToList();
            }
            return Task.FromResult(categories.ToList());
        }

        public Task<List<Link>> GetAllLinks()
        {
            return Task.FromResult(fakeData.Links);
        }

        public Category GetCategoryById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Entry> GetEntryById(int? id)
        {
            var entry = fakeData.Entries
                .Where(x => x.Id.Equals(id))
                .FirstOrDefault()
                ;
            if (entry == null)
            {
                Entry nulledEntry = null;
                return Task.FromResult(nulledEntry);
            }


            entry.Category = fakeData.Categories.Where(x => x.Id.Equals(entry.CategoryId)).FirstOrDefault();
            return Task.FromResult(entry);
        }

        public Task<HomePageSettings> GetHomePageSettings()
        {
            return Task.FromResult(fakeData.HomePageSettings);
        }

        public Task<WebsiteDetails> GetWebsiteDetails()
        {
            return Task.FromResult(fakeData.WebsiteDetails);
        }

    }
}
