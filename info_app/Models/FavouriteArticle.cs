namespace info_app.Models
{
    public class FavouriteArticle
    {
        public int UserId { get; set; }
        public int ArticleId { get; set; }
        public virtual User User { get; set; }
        public virtual Article Article { get; set; }
    }
}
