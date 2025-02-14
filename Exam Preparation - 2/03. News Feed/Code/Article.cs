namespace NewsFeed;

public class Article {
    public string Title { get; set; }
    public string Author { get; set; }
    public int WordCount { get; set; }

    public Article(string title, string author, int wordCount) {
        Title = title;
        Author = author;
        WordCount = wordCount;
    }

    public override string ToString() {
        return $"Article: '{Title}' by {Author} - {WordCount} words";
    }
}