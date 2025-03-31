using System;

class Program
{
    static void Main(string[] args)
    {
       // Create a list to store videos
        List<Video> videos = new List<Video>();

        // Create 3-4 videos and add comments to each
        Video video1 = new Video("Understanding C#", "John Doe", 600);
        video1.AddComment(new Comment("Alice", "Great explanation!"));
        video1.AddComment(new Comment("Bob", "Very helpful, thanks!"));
        video1.AddComment(new Comment("Charlie", "Can you make a video on LINQ?"));

        Video video2 = new Video("Introduction to Python", "Jane Smith", 900);
        video2.AddComment(new Comment("Dave", "This was so clear, thank you!"));
        video2.AddComment(new Comment("Eve", "I love Python!"));
        video2.AddComment(new Comment("Frank", "Can you cover advanced topics next time?"));

        Video video3 = new Video("Web Development Basics", "Emily Johnson", 1200);
        video3.AddComment(new Comment("Grace", "This is exactly what I needed!"));
        video3.AddComment(new Comment("Hank", "Very informative."));
        video3.AddComment(new Comment("Ivy", "Looking forward to more content!"));

        // Add videos to the list
        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        // Iterate through the list of videos and display their details
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");
            foreach (Comment comment in video.Comments)
            {
                Console.WriteLine($"- {comment.Name}: {comment.Text}");
            }
            Console.WriteLine();
        }
    }
}

class Video
{
    public string Title { get; private set; }
    public string Author { get; private set; }
    public int Length { get; private set; } // Length in seconds
    public List<Comment> Comments { get; private set; }

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        Comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return Comments.Count;
    }
}

class Comment
{
    public string Name { get; private set; }
    public string Text { get; private set; }

    public Comment(string name, string text)
    {
        Name = name;
        Text = text;
    }
}