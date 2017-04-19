using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FBBF;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Linq;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private const int NUMERO_DE_TREADS = 2;
        private const string usuario = "gustavo.henrique.3382118";
        public int MaxLength { get { return 30; } }
        public int MinLength { get { return 6; } }
        public int QuantidadeTestada { get; set; }
        public Queue<String> FilaPrincipal { get; set; }

        public string ValidChars
        {
            get
            {
                return "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ!@#$%&*()-+.;:, 1234567890";
            }
        }
        public StreamWriter SW { get; set; }

        //[TestMethod]
        public void TestMethod1()
        {
            int n = NUMERO_DE_TREADS;
            API.WordListCompleta = new List<string>();
            API.User = usuario;
            StreamReader sr = new StreamReader(@"E:\Militao\wordlist.lst");
            string linha = String.Empty;
            while (!String.IsNullOrEmpty(linha = sr.ReadLine()))
            {
                API.WordListCompleta.Add(linha);
            }

            sr.Close();

            List<List<String>> listaDeListasDeString = API.SplitList(API.WordListCompleta, API.WordListCompleta.Count / n + 1).ToList();

            List<Thread> listaThreads = new List<Thread>();

            API api;

            for (int i = 0; i < n; i++)
            {
                api = new API();
                api.ThreadWordList = listaDeListasDeString.FirstOrDefault();
                listaDeListasDeString.RemoveAt(0);
                listaThreads.Add(new Thread(api.StartFBBF));
            }

            foreach (Thread t in listaThreads)
            {
                t.Start();
            }
            //Console.ReadKey();
        }

        [TestMethod]
        public void GerarWordList()
        {
            API.User = usuario;
            GenerateWordList("");
        }


        private async void GenerateWordList(string prefix)
        {
            foreach (char c in ValidChars)
            {
                if (prefix.Length + 1 >= MinLength && prefix.Length + 1 <= MaxLength)
                {
                    FilaPrincipal.Enqueue(prefix + c);
                }
                if (prefix.Length < MaxLength)
                {
                    GenerateWordList(prefix + c);
                }
            }
        }

        private void escreverOla()
        {
            Console.WriteLine("Olá");
        }

        //[TestMethod]
        public void teste()
        {
            GenerateWordList2("abcsdsadf");
        }

        private async void GenerateWordList2(string senha)
        {
            API.User = usuario;
            while (true)
            {
                //await API.StartBruteForceForThread(API.User, senha);
                QuantidadeTestada++;
            }
        }

        public void GerarSequencia(ref string word, int index)
        {
            if(word.All(elem => elem == ValidChars[index+1]))
            {
                return;
            }

        }
    }
}
