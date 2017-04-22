using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using System.Threading;

namespace FBBFExecution
{
    class Program
    {
        static void Main(string[] args)
        {
            BLL.Generate.Start();
            //API.FilaPrincipal = new ConcurrentQueue<string>();
            //for (int i = 0; i < 2; i++)
            //{
            //    API.FilaPrincipal.Enqueue("gustavinho");
            //    API.FilaPrincipal.Enqueue("gustavow");
            //    API.FilaPrincipal.Enqueue("gustavov");
            //    API.FilaPrincipal.Enqueue("gustavos");
            //    API.FilaPrincipal.Enqueue("gustavod");
            //    API.FilaPrincipal.Enqueue("gustavor");
            //    API.FilaPrincipal.Enqueue("gustavoa");
            //    API.FilaPrincipal.Enqueue("gustavosd");
            //    API.FilaPrincipal.Enqueue("gustavoddd");
            //    API.FilaPrincipal.Enqueue("gustavobb");
            //    API.FilaPrincipal.Enqueue("gustavosa");
            //    API.FilaPrincipal.Enqueue("gustavosasa");
            //    API.FilaPrincipal.Enqueue("gustavob");
            //    API.FilaPrincipal.Enqueue("gustavobd");
            //    API.FilaPrincipal.Enqueue("gustavodbdd");
            //    API.FilaPrincipal.Enqueue("gustavobdfdf");
            //    API.FilaPrincipal.Enqueue("gustavosdf");
            //    API.FilaPrincipal.Enqueue("gustavoeee");
            //    API.FilaPrincipal.Enqueue("gustavoesa");
            //}
            //API.FilaPrincipal.Enqueue("notrightnotdownrightdown");
            //API.FilaPrincipal.Enqueue("asdfasd");
            //API.FilaPrincipal.Enqueue("eeeee");
            //API.User = Generate.usuario;
            //Thread a = new Thread(API.StartFBBF);
            //a.Start();
            //API.FilaPrincipal = new Queue<string>();
            //API.FilaPrincipal.Enqueue("notrightnotdownrightdown");
            //API.User = "gustavo.henrique.3382118";
            //API.StartFBBF();
            Console.ReadKey();
        }
    }
}
