using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace Task_C_
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            ExecultarComTask();
            sw.Stop();
            Console.WriteLine("Quanto tempo levou para fazer essa tarefa " + sw.ElapsedMilliseconds);



        }
        static void ExecutarComThreads(){
            var t =  new Thread(()=>{

                RealizarOperacao(1,"Ricardo" , "Rias");
            });

              var t2 =  new Thread(()=>{

                RealizarOperacao(2,"sdaldkal" , "dsad");
            });

             var t3 =  new Thread(()=>{

                RealizarOperacao(3,"dada" , "sakduisauji");
            });
            t.Start();
            t2.Start();
            t3.Start();

            t.Join();
            t2.Join();
            t3.Join();
        }

        

        static void RealizarOperacao(int op, string nome, string sobrenome)
        {
            Console.WriteLine("Iniciando operacao" +  op);

            for (int i = 0; i < 1000000; i++)
            {
                var p = new Pessoa(nome,  sobrenome , 35);
            }

            Console.WriteLine("Finalizando" +  op);
        }


        static void ExecultarComTask(){
              var t =  new Task<int>.Run(()=>{

                RealizarOperacao(1,"Ricardo" , "Rias");
                return 1;
            });

              var t2 =  new  Task<int>.Run(()=>{

                RealizarOperacao(2,"sdaldkal" , "dsad");
                return 2;
            });

             var t3 =  new  Task<int>.Run(()=>{

                RealizarOperacao(3,"dada" , "sakduisauji");
                return 3;
            });
           t.Result();

        }

        private static void ExecutarSequencial()
        {
            RealizarOperacao(1, "Fulano", "Dias");
            RealizarOperacao(2, "Ricardo", "Dias");
            RealizarOperacao(3, "Fulano", "Dias");
        }   
    }
    internal class Pessoa{
        public Pessoa(string nome, string sobrenome , int v)
        {
            this.nome = nome;
            this.sobrenome =  sobrenome;
            this.v = v;
        }

        private string nome;
        private string sobrenome;
        private int v;

        
    }
}
