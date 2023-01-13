using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corsi___21
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //dichiarazione es 1
            int[] array = new int[100];
            int elemento;
            int N;
            int indice = 0;
            int scelta = 0;

            //struttura menù
            do
            {
                //stampa delle opzioni
                Console.Clear();
                Console.WriteLine("1 - aggiunta elemento");
                Console.WriteLine("2 - stampa elementi caricati");
                Console.WriteLine("0 - uscita dal programma");
                //scelta delle opzione
                Console.WriteLine("Inserisci la scelta: ");
                scelta = int.Parse(Console.ReadLine());
                //esecuzione dell'opzione
                switch (scelta)
                {
                    case 1:
                        Console.WriteLine("Inserire un elemento: ");
                        elemento = Convert.ToInt32(Console.ReadLine());
                        //richiamo della funzione
                        if(Aggiungi(array, elemento, ref indice) == true)
                            Console.WriteLine("Elemento inserito correttamente");
                        else
                            Console.WriteLine("Array pieno");
                            
                        break;
                    case 2:
                        for (int i = 0; i < indice; i++)
                        {
                            Console.WriteLine(array[i]);
                        }
                        Console.WriteLine("Premere un pulsante per continuare...");
                        Console.ReadLine();
                        break;
                }
                
            }while(scelta != 0);
            


        }
        static bool Aggiungi(int[] a, int e,ref int i)
        {
            bool inserito = true;
            //controllare se non abbiamo raggiunto la fine dell'array, se questa condizione è vera allora non fare nulla
            if(i < a.Length)
            {
                //inserimento dell'elemento
                a[i] = e;
                //incremento dell'indice
                i++;
            }
            else
                inserito = false;

            return inserito;
            
            
           
        }
        static string Visualizza(string[] a, int i)
        {
            string caricamento = a[i];
            string html = "<html> <head> </head> <body>"+a[i]+"</body> </html>";
            return html;
            Console.WriteLine(html);
        }
    }
}
