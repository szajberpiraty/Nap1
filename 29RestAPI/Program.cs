using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _29RestAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            //Lekérdezéshez a RestSharp csomagot használjuk majd
            var hostUrl = "http://jsonplaceholder.typicode.com/";

            var client = new RestClient(hostUrl);

            //Lehet az uri segítségét is használni
            //var client = new RestClient(new Uri(hostUrl));

            var request = new RestRequest("posts", Method.GET);
            //neg lehet adni neki, hogy milyen típusba posztoljon
            var result = client.Execute<List<Post>>(request); 

            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {//feldolgozás
                Console.WriteLine("Státusz {0},{1}", result.StatusCode, result.StatusDescription);
                var posts = result.Data;
                Console.WriteLine("Postok száma:{0}",posts.Count);
                Console.WriteLine(posts[0].body);
            }
            else
            {//egyéb üzenettel válaszolt a szerver, ezt fel kell dolgozni
                Console.WriteLine("Státusz {0},{1}", result.StatusCode, result.StatusDescription);
            }

            Console.WriteLine();
            //1-es poszt lekérése
            var post1 = client.Execute<Post>(new RestRequest("posts/1",Method.GET));
            Console.WriteLine(post1.Data.title);

            //2-es poszt kommentjeinek lekérdezése
            var commentRequest = new RestRequest("comments",Method.GET);
            commentRequest.AddParameter("postId", 2);




            Console.ReadLine();
        }

        //A JSON-ból, XML-ből Special
        public class Post
        {
            public int userId { get; set; }
            public int id { get; set; }
            public string title { get; set; }
            public string body { get; set; }
        }

    }
}
