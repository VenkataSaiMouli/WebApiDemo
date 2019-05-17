using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class TweetRepository
    {
        public void AddTweet(TWEET objTweet)
        {
            try
            {
                using (TwitterCloneContext objContext = new TwitterCloneContext())
                {
                    objContext.TWEETs.Add(objTweet);
                    objContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<TWEET> GetTweetsByName(string userid)
        {
            List<TWEET> objTweets = new List<TWEET>();
            try
            {
                using (TwitterCloneContext objContext = new TwitterCloneContext())
                {
                    var tweets = from obj in objContext.TWEETs
                                 where obj.user_id == userid
                                 select obj;
                    foreach(var item in tweets)
                    {
                        objTweets.Add(new TWEET {user_id = item.user_id, tweet_id = item.tweet_id, message = item.message, created = item.created});
                    }
                }
                return objTweets;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<TWEET> GetAllTweets()
        {
            List<TWEET> objTweets = new List<TWEET>();
            try
            {
                using (TwitterCloneContext objContext = new TwitterCloneContext())
                {
                    var tweets = from obj in objContext.TWEETs
                                 
                                 select obj;
                    foreach (var item in tweets)
                    {
                        objTweets.Add(new TWEET { user_id = item.user_id, tweet_id = item.tweet_id, message = item.message, created = item.created });
                    }
                }
                return objTweets;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EditTweet(TWEET objTweet)
        {
            try
            {
                using (TwitterCloneContext objContext = new TwitterCloneContext())
                {

                    objContext.TWEETs.Attach(objTweet);
                    objContext.Entry(objTweet).State = System.Data.Entity.EntityState.Modified;
                    objContext.SaveChanges();

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteTweet(int id)
        {
            try
            {
                using (TwitterCloneContext objContext = new TwitterCloneContext())
                {
                    var query = (from obj in objContext.TWEETs
                                where obj.tweet_id == id
                                select obj).FirstOrDefault();
                    objContext.TWEETs.Remove(query);
                    objContext.SaveChanges();

                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TWEET FindTweet(int id)
        {
            try
            {
                using (TwitterCloneContext objContext = new TwitterCloneContext())
                {
                    var query = (from obj in objContext.TWEETs
                                 where obj.tweet_id == id
                                 select obj).FirstOrDefault();
                    return query;

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
