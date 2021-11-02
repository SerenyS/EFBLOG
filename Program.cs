using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace blog
{
    class Program
    {
        static void Main(string[] args)
        {
            int menuRequest;

            do
            {
                Console.WriteLine("Please Select Action");
                Console.WriteLine("1) Display Blogs");
                Console.WriteLine("2) Add Blog");
                Console.WriteLine("3) Display Posts");
                Console.WriteLine("4) Add Post");

                menuRequest = Int32.Parse(Console.ReadLine());

                switch (menuRequest)
                {
                    case 1:
                        Console.WriteLine("Displaying Blogs");

                        using (var db = new BlogContext())
                        {
                            System.Console.WriteLine("Here is the list of blogs");
                            foreach (var b in db.Blogs)
                            {
                                System.Console.WriteLine($"Blog-{b.BlogId}. {b.Name}");
                            }
                        }

                        break;
                    case 2:
                        Console.WriteLine("Add Blog");

                        Console.WriteLine("Enter blog name:");
                        var blogName = Console.ReadLine();

                        var blog = new Blog();
                        blog.Name = blogName;

                        using (var db = new BlogContext())
                        {
                            db.Add(blog);
                            db.SaveChanges();
                        }

                        break;
                    case 3:

                        Console.WriteLine("Select Blog");

                        using (var db = new BlogContext())
                        {
                            System.Console.WriteLine("Here is the list of blogs");
                            foreach (var b in db.Blogs)
                            {
                                System.Console.WriteLine($"Blog-{b.BlogId}. {b.Name}");
                            }
                        }
                        var selectedBlogId = Int32.Parse(Console.ReadLine());

                        Console.WriteLine("Displaying Posts");


                        using (var db = new BlogContext())
                        {

                            var posts = db.Posts.Where(p => p.BlogId == selectedBlogId);
                            foreach (var i in posts)
                            {
                                Console.WriteLine($"Post Id. {i.PostId} Post Title {i.Title}, Post Content {i.Content}");

                            }
                        }

                        break;
                    case 4:
                        Console.WriteLine("Select Blog");


                        using (var db = new BlogContext())
                        {
                            System.Console.WriteLine("Here is the list of blogs");
                            foreach (var b in db.Blogs)
                            {
                                System.Console.WriteLine($"Blog-{b.BlogId}. {b.Name}");
                            }
                        }
                        var selectedBlogId2 = Int32.Parse(Console.ReadLine());

                        var post = new Post();

                        Console.WriteLine("Enter Post Title");
                        var postTitle = Console.ReadLine();

                        Console.WriteLine("Enter Content");
                        var postContent = Console.ReadLine();


                        post.Title = postTitle;
                        post.Content = postContent;

                        using (var db = new BlogContext())
                        {
                            var posts = db.Posts.Where(p => p.BlogId == selectedBlogId2);
                            db.Add(post);
                            db.SaveChanges();
                        }
                        break;
                }

            } while (menuRequest < 5);


        }
    }
}
