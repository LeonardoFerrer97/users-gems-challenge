using System;
namespace User_gems_challenge_utils.Queries
{
    public class UserQueries
    {
        public static string GET_USER_LIKE_NAME = "select u.id, u.name, u.email, u.password, u.is_admin from public.user u where u.name like '%{0}%'";
    }
}
