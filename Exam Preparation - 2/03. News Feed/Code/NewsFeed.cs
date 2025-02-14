namespace NewsFeed;

public class NewsFeed {
    public string Name { get; set; }
    public int Capacity { get; set; }
    public List<Article> Articles { get; set; }

    public NewsFeed(string name, int capacity) {
        Name = name;
        Capacity = capacity;
        Articles = new List<Article>();
    }

    public void AddArticle(Article article) {
        if (Articles.Count >= Capacity || Articles.Any(a => a.Title == article.Title)) return; 
            
        Articles.Add(article);
    }

    public bool DeleteArticle(string title) {
        var articleToRemove = Articles.FirstOrDefault(a => a.Title == title);
        if (articleToRemove != null) {
            Articles.Remove(articleToRemove);
            return true;
        }
            
        return false;
    }

    public Article GetShortestArticle() => Articles.OrderBy(a => a.WordCount).First();

    public string GetArticleDetails(string title) {
        var article = Articles.FirstOrDefault(a => a.Title == title);
        if (article != null) return article.ToString();
            
        return $"Article with title '{title}' not found.";
    }

    public int GetArticlesCount() => Articles.Count;
        
    public string Report() {
        var orderedArticles = Articles.OrderBy(a => a.WordCount).ToList();
        var report = $"{Name} newsfeed content:\n";
        foreach (var article in orderedArticles) {
            report += $"{article.Author}: {article.Title}\n";
        }
            
        return report.Trim(); 
    }
}