using System;
namespace User_gems_challenge_entity
{
    public class TweetRetweet
    {
        public int? Id { get; set; }
        public int User_Id { get; set; }
        public string User_Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int? RetweetUserId { get; set; }
        public string RetweetUserName { get; set; }
        public DateTime? Created_At { get; set; }
    }
}
