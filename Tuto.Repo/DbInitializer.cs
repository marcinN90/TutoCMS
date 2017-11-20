using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tuto.Data;
using Tuto.Data.Models;

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
            new Entry {CategoryId = 1, Title = "Awesome post part 1", SeoDescription = LoremIpsum.Substring(0, 50) + "...", Content = LoremIpsum.Substring(0, 300), LastRevisionAt = DateTime.Now },
        };

        public List<Category> Categories = new List<Category>
        {
             new Category { Title = "Awesome", Description ="This is awesome cateogry for awesome content."},
        };

        public WebsiteDetails WebsiteDetails = new WebsiteDetails
        {
            Name = "WebsiteTtile",
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
            new Link {  LinkTitle = "Great link to share", UrlAddress = "example.com"},
        };
    }
    #endregion

    public static class DbInitializer
    {
        
        private const string adminInfo = "admin@example.com";
        private const string adminPassword = "Secret123$";
        public static void SeeDbWithFakeData(TutoContext context)
        {
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();
            FakeData fakeData = new FakeData();
            if (!context.Category.Any())
            {
                context.Category.AddRange(fakeData.Categories);
                context.SaveChanges();
            }

            if (!context.EntryPost.Any())
            {
                context.EntryPost.AddRange(fakeData.Entries);
                context.SaveChanges();
            }
            if (!context.WebsiteDetails.Any())
            {
                context.WebsiteDetails.Add(fakeData.WebsiteDetails);
                context.SaveChanges();
            }
            if (!context.HomePageSettings.Any())
            {
                context.HomePageSettings.Add(fakeData.HomePageSettings);
                context.SaveChanges();
            }
            if (!context.Link.Any())
            {
                context.Link.AddRange(fakeData.Links);
                context.SaveChanges();
            }
        }

        public static async Task SeedAdminUser(UserManager<ApplicationUser> userManager)
        {
            //ApplicationUser user;
            // = await userManager.FindByEmailAsync(adminInfo);
            ApplicationUser user = new ApplicationUser
            {
                Email = adminInfo,
                UserName = adminInfo
            };
            var userexist = await userManager.FindByEmailAsync(adminInfo);
            if (userexist != null)
            {
                userManager.CreateAsync(user, adminPassword).Wait();
            }
        }
    }
}
