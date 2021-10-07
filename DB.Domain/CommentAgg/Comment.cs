using _01_Framework.Domain;
using DB.Domain.ArticleAgg;
using System;

namespace DB.Domain.CommentAgg
{
    public class Comment:DomainBase<long>
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Message { get; private set; }
        public int Status { get; private set; }

        // Navigation Property:
        public long ArticleId { get; private set; }
        public Article Article { get; private set; }

        protected Comment()
        {
        }

        public Comment(string name, string email, string message, long articleId)
        {
            Validate(name, email, message, articleId);
            Name = name;
            Email = email;
            Message = message;
            ArticleId = articleId;
        }

        public void Confirm()
        {
            Status = Statuses.Confirmed;
        }

        public void Cancel()
        {
            Status = Statuses.Canceled;
        }

        private void Validate(string name, string email,string message, long articleId)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Name can not be empty!");
            }
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Email can not be empty!");
            }
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Message can not be empty!");
            }
            if (articleId==0)
            {
                throw new ArgumentNullException($"'Article Id' can not be empty!");
            }
        }
    }
}
