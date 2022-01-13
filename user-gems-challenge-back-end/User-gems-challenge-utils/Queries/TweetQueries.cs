using System;
namespace User_gems_challenge_utils.Queries
{
    public class TweetQueries
    {
        public static string GET_TWEET_BY_FOLLOWER = @"
			select t.id, t.user_id, u.name as user_name, t.description, t.image, t.created_at, null as RetweetUserId, null as RetweetUserName
				from tweets t inner join public.user u on u.id = t.user_id
					where user_id = {0}
			union all 
			select r.id, r.user_id, u.name as user_name, t.description, t.image, r.created_at, t.user_id as RetweetUserId, u2.name as RetweetUserName
				from retweets r 
					inner join tweets t on r.tweet_id =t.id 
					inner join public.user u on u.id = r.user_id
					left join public.user u2 on u2.id = t.user_id
				where r.user_id = {0}
			union all
			select t.id, t.user_id,u.name as user_name, t.description, t.image, t.created_at, null as RetweetUserId, null as RetweetUserName
				from public.following f 
					inner join tweets t on t.user_id = f.following_id 
					inner join public.user u on u.id = t.user_id
					where f.user_id = {0}
			union all 
			select r.id, r.user_id,u.name as user_name, t.description, t.image, t.created_at, r.user_id as RetweetUserId, u2.name as RetweetUserName
				from public.following f 
					inner join retweets r on r.user_id = f.following_id 
					inner join tweets t on r.tweet_id =t.id
					inner join public.user u on u.id = r.user_id
					left join public.user u2 on u2.id = t.user_id
				where f.user_id = {0}";
    }
}
