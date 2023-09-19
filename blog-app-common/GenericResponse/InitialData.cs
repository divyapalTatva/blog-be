
using blog_app_models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog_app_common.GenericResponse
{
    public class InitialData
    {

        #region InitialDictionary Data
        public static Dictionary<int, BlogVM> BlogData()
        {
            var blogData = new Dictionary<int, BlogVM>()
            {
                { 1, new BlogVM() { Id = 1, Title = "His mother had always taught him", Description =       "His mother had always taught him not to ever think of himself as better than others. He'd tried to live by this motto. He never looked down on those who were less fortunate or who had less money than him. But the stupidity of the group of people he was talking to made him change his mind.", Tags = new List<string> { "history", "american", "crime" }, CreatedAt = DateTime.Now ,ImageUrl="/assets/anirudh-YQYacLW8o2U-unsplash.jpg"} },
                { 2, new BlogVM() { Id = 2, Title = "He was an expert but not in a discipline", Description = "He was an expert but not in a discipline that anyone could fully appreciate. He knew how to hold the cone just right so that the soft server ice  discipline that anyone could fully appreciate. He knew how to hold the cone just right so that the soft server ice  discipline that anyone could fully appreciate. He knew how to hold the cone just right so that the soft server ice  discipline that anyone could fully appreciate. He knew how to hold the cone  discipline that anyone could fully appreciate. He knew how to hold the cone just right so that the soft server ice  discipline that anyone could fully appreciate. He knew how to hold the cone just right so that the soft server ice  discipline that anyone could fully appreciate. He knew how to hold the cone just right so that the soft server ice  discipline that anyone could fully appreciate. He knew how to hold the cone just right so that the soft server ice  discipline that anyone could fully appreciate. He knew how to hold the cone just right so that the soft server ice  discipline that anyone could fully appreciate. He knew how to hold the cone just right so that the soft server ice discipline that anyone could fully appreciate. He knew how to hold the cone just right so that the soft server ice discipline that anyone could fully appreciate. He knew how to hold the cone just right so that the soft server ice  discipline that anyone could fully appreciate. He knew how to hold the cone just right so that the soft server ice just right so that the soft server ice-cream fell into it at the precise angle to form a perfect cone each and every time. It had taken years to perfect and he could now do it without even putting any thought behind it,He was an expert but not in a discipline that anyone could fully appreciate. He knew how to hold the cone just right so that the soft server ice-cream fell into it at the precise angle to form a perfect cone each and every time. It had taken years to perfect and he could now do it without even putting any thought behind it.", Tags = new List<string> { "french", "fiction", "english" }, CreatedAt = DateTime.Now,ImageUrl="/assets/waranont-joe-T7qyLNPwgKA-unsplash.jpg" } },
                { 3, new BlogVM() { Id = 3, Title = "Dave watched as the forest burned up on the hill.", Description = "Dave watched as the forest burned up on the hill, only a few miles from her house. The car had been hastily packed and Marta was inside trying to round up the last of the pets. Dave went through his mental list of the most important papers and documents that they couldn't leave behind. He scolded himself for not having prepared these better in advance and hoped that he had remembered everything that was needed. He continued to wait for Marta to appear with the pets, but she still was nowhere to be seen.", Tags = new List<string> { "magical", "history", "french", "orange", "pear" }, CreatedAt = DateTime.Now,ImageUrl="/assets/cristi-ursea-Q2gOwYB4EaM-unsplash.jpg" } },
                { 4, new BlogVM() { Id = 4, Title = "All he wanted was a candy bar.", Description = "All he wanted was a candy bar. It didn't seem like a difficult request to comprehend, but the clerk remained frozen and didn't seem to want to honor the request. It might have had something to do with the gun pointed at his face.", Tags = new List<string> { "mystery", "english", "american", "orange", "pear" }, CreatedAt = DateTime.Now,ImageUrl="/assets/dhiva-krishna-GRV4ypBKgxE-unsplash.jpg" } },
                { 5, new BlogVM() { Id = 5, Title = "Hopes and dreams were dashed that day.", Description = "Hopes and dreams were dashed that day. It should have been expected, but it still came as a shock. The warning signs had been ignored in favor of the possibility, however remote, that it could actually happen. That possibility had grown from hope to an undeniable belief it must be destiny. That was until it wasn't and the hopes and dreams came crashing down.", Tags = new List<string> { "crime", "mystery", "love", "orange", "pear" }, CreatedAt = DateTime.Now,ImageUrl="/assets/anirudh-YQYacLW8o2U-unsplash.jpg" } },
                { 6, new BlogVM() { Id = 6, Title = "Dave wasn't exactly sure how he had ended up", Description = "Dave wasn't exactly sure how he had ended up in this predicament. He ran through all the events that had lead to this current situation and it still didn't make sense. He wanted to spend some time to try and make sense of it all, but he had higher priorities at the moment. The first was how to get out of his current situation of being naked in a tree with snow falling all around and no way for him to get down.", Tags = new List<string> { "english", "classic", "american", "orange", "pear" }, CreatedAt = DateTime.Now,ImageUrl="/assets/anirudh-YQYacLW8o2U-unsplash.jpg" } },
                { 7, new BlogVM() { Id = 7, Title = "This is important to remember.", Description = "This is important to remember. Love isn't like pie. You don't need to divide it among all your friends and loved ones. No matter how much love you give, you can always give more. It doesn't run out, so don't try to hold back giving it as if it may one day run out. Give it freely and as much as you want.", Tags = new List<string> { "english", "classic", "american", "magical", "crime" }, CreatedAt = DateTime.Now,ImageUrl="/assets/spencer-davis-yVekjvme2oU-unsplash.jpg" } },
            };
            return blogData;
        }

        #endregion

    }
}
