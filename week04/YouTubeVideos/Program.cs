using System;
using System.Collections.Generic;

namespace YouTubeVideos
{
    // The Video class stores video information and its associated comments.
    class Video
    {
        // Properties to store video details.
        public string Title { get; set; }
        public string Author { get; set; }
        public int Length { get; set; } // Length in seconds

        // A list to hold Comment objects.
        public List<Comment> Comments { get; set; }

        // Constructor to initialize the video with title, author, and length.
        public Video(string title, string author, int length)
        {
            Title = title;
            Author = author;
            Length = length;
            Comments = new List<Comment>();
        }

        // Adds a comment to the video.
        public void AddComment(Comment comment)
        {
            Comments.Add(comment);
        }

        // Returns the number of comments for this video.
        public int GetCommentCount()
        {
            return Comments.Count;
        }
    }

    // The Comment class stores details about a comment.
    class Comment
    {
        // Properties to store the commenter's name and the comment text.
        public string Commenter { get; set; }
        public string Text { get; set; }

        // Constructor to initialize the comment with a commenter and text.
        public Comment(string commenter, string text)
        {
            Commenter = commenter;
            Text = text;
        }
    }

    // Main program class.
    class Program
    {
        static void Main(string[] args)
        {
            // Create a list to hold our videos.
            List<Video> videos = new List<Video>();

            // Create and initialize first video.
            Video video1 = new Video("Introduction to C#", "BYU-I Instructor", 300);
            video1.AddComment(new Comment("Alice", "Great explanation on classes!"));
            video1.AddComment(new Comment("Bob", "Very clear and helpful."));
            video1.AddComment(new Comment("Charlie", "I liked the examples."));
            videos.Add(video1);

            // Create and initialize second video.
            Video video2 = new Video("Advanced C# Concepts", "BYU-I Instructor", 450);
            video2.AddComment(new Comment("David", "This helped me understand abstraction."));
            video2.AddComment(new Comment("Eva", "Looking forward to more videos like this."));
            video2.AddComment(new Comment("Frank", "Awesome content!"));
            videos.Add(video2);

            // Create and initialize third video.
            Video video3 = new Video("C# Project Walkthrough", "BYU-I Instructor", 600);
            video3.AddComment(new Comment("Grace", "The walkthrough was very detailed."));
            video3.AddComment(new Comment("Heidi", "I appreciated the clear instructions."));
            video3.AddComment(new Comment("Ivan", "Great project idea."));
            videos.Add(video3);

            // Iterate through the list of videos and display details.
            foreach (Video video in videos)
            {
                Console.WriteLine("=======================================");
                Console.WriteLine($"Title: {video.Title}");
                Console.WriteLine($"Author: {video.Author}");
                Console.WriteLine($"Length: {video.Length} seconds");
                Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");
                Console.WriteLine("Comments:");
                foreach (Comment comment in video.Comments)
                {
                    Console.WriteLine($"- {comment.Commenter}: {comment.Text}");
                }
                Console.WriteLine();
            }

            // Wait for user input before closing (optional for VS Code debugging).
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
