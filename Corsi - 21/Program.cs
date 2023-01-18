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
            //dichiarazioni 
            int[] array = new int[100];
            int elemento;
            int indice = 0;
            int IndiceRicerca = 0;
            int IndiceAggiunta = 0;
            int posizione;
            int scelta = 0;

            //struttura menù
            do
            {
                //stampa delle opzioni
                Console.Clear();
                Console.WriteLine("1 - aggiunta di un elemento all'array");
                Console.WriteLine("2 - stampa degli elementi caricati");
                Console.WriteLine("3 - ricerca di un elemento nell'array");
                Console.WriteLine("4 - cancellazione di un elemento dall'array");
                Console.WriteLine("5 - Inserimento di un valore in una posizione dell'array");
                Console.WriteLine("0 - uscita dal programma");
                //scelta delle opzione
                Console.WriteLine("Inserisci la scelta: ");
                scelta = int.Parse(Console.ReadLine());
                //esecuzione dell'opzione
                switch (scelta)
                {
                    case 1:
                        //input
                        Console.WriteLine("\nInserire un elemento: ");
                        elemento = Convert.ToInt32(Console.ReadLine());
                        //richiamo della funzione
                        if (Aggiungi(array, elemento, ref indice) == true)
                            Console.WriteLine("\nElemento inserito correttamente");
                        else
                            //output in caso si sia raggiunto il numero massimo di elementi che si possono inserire
                            Console.WriteLine("\nArray pieno");
                        Console.WriteLine("Premere un pulsante per continuare...");
                        Console.ReadLine();
                        break;
                    case 2:
                        //ciclo per stampare l'array
                        Console.WriteLine("");
                        for (int i = 0; i < indice; i++)
                        {
                            Console.Write(array[i] + ", ");
                        }
                        Console.WriteLine("Premere un pulsante per continuare...");
                        Console.ReadLine();
                        break;
                    case 3:
                        //input
                        Console.WriteLine("\nInserire l'elemento da trovare nell'array: ");
                        elemento = Convert.ToInt32(Console.ReadLine());
                        //richiamo alla funzione Ricerca
                        if (Ricerca(array, elemento, ref IndiceRicerca) == true)
                            //stampa della posizione nell'array dell elemento inserito
                            Console.WriteLine("\nL'elemento è stato trovato in posizione " + IndiceRicerca + " dell'array");
                        else
                            //output in caso l'elemento inserito non sia nell'array
                            Console.WriteLine("\n-1");
                        //azzeramento dell'indice di ricerca così da averlo a 0 per poter ripetere altre ricerche senza causare errori
                        IndiceRicerca = 0;
                        Console.WriteLine("Premere un pulsante per continuare...");
                        Console.ReadLine();
                        break;
                    case 4:
                        //input
                        Console.WriteLine("\nInserire l'elemento da cancellare: ");
                        elemento = Convert.ToInt32(Console.ReadLine());
                        //richiamo alla funzione di ricerca in modo da poter cancellare un elemento che si sa che è presente nell'array
                        if (Ricerca(array, elemento, ref IndiceRicerca) == true)
                        {
                            //richiamo alla funzione di cancellazione
                            array = Cancellazione(array, elemento, ref indice);
                            Console.WriteLine("\nElemento cancellato correttamente");
                        }
                        //output in caso l'elemento inserito non sia presente nell'array
                        else
                            Console.WriteLine("\nIl numero inserito non è presente nell'array");
                        Console.WriteLine("Premere un pulsante per continuare...");
                        Console.ReadLine();
                        break;
                    case 5:
                        Console.WriteLine("\nInserire un elemento: ");
                        elemento = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("\nInserire la posizione nell'array dove si vuole inserire l'elemento: ");
                        posizione = Convert.ToInt32(Console.ReadLine());
                        if (Inserimento(ref array, elemento, IndiceAggiunta, ref indice, posizione) == true)
                        {
                            Console.WriteLine("\nElemento inserito correttamente");
                        }
                        else
                            Console.WriteLine("\nArray pieno");
                        Console.WriteLine("Premere un pulsante per continuare...");
                        Console.ReadLine();
                        break;

                }

            } while (scelta != 0);
        }

        //funzione di aggiunta
        static bool Aggiungi(int[] a, int e, ref int i)
        {
            bool inserito = true;
            //controllare se non abbiamo raggiunto la fine dell'array, se questa condizione è vera allora non fare nulla
            if (i < a.Length)
            {
                //inserimento dell'elemento
                a[i] = e;
                //incremento dell'indice
                i++;
            }
            else
                inserito = false;
            //ritorno in base allo spazio disponibile
            return inserito;
        }

        //funzione di ricerca
        static bool Ricerca(int[] a, int input, ref int indice)
        {
            bool trovato = true;
            //ciclo per controllare se l'elemento inserito è presente nell'array
            for (int i = 0; i < a.Length; i++)
            {
                //in base all'input, avremo un output true o false
                if (a[i] == input)
                {
                    trovato = true;
                    //una volta trovato il numero esci dal ciclo
                    break;
                }
                else
                    trovato = false;
                //incremento dell'indice di ricerca per l'output nel main
                indice++;
            }
            //ritorno in base all'input
            return trovato;
        }

        //funzione di cancellazione
        static int[] Cancellazione(int[] a, int input, ref int indice)
        {
            //ciclo per trovare la posizione dell'elemento inserito
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == input)
                {
                    //ripeti il ciclo fino a che non sono stati spostati tutti i numeri
                    while (i < indice)
                    {
                        //nella posizione del numero che si vuole togliere, inserire il numero successivo fino a che non si raggiunge il massimo degli elementi inseriti
                        a[i] = a[i + 1];
                        i++;
                    }
                    //decremento dell'indice data la rimozione di uno degli elementi dell'array
                    indice = indice - 1;
                    //uscita dal ciclo
                    break;
                }
            }
            //restituisci l'array nuovo
            return a;
        }

        //funzione di Inserimento in una determinata posizione
        static bool Inserimento(ref int[] a, int input, int IndiceAggiunta, ref int indice, int posizione)
        {
            //dichiarazione della variabile di controllo
            bool controllo = true;
            //condizione per verificare se l'array ha raggiunto le sue dimensioni massime
            if (indice < a.Length)
            {
                //utilizziamo una copia dell'indice per il ciclo 
                IndiceAggiunta = indice;
                while (IndiceAggiunta >= posizione)
                {
                    //spostamento di una posizione in avanti del numero
                    a[IndiceAggiunta + 1] = a[IndiceAggiunta];
                    IndiceAggiunta--;
                }
                //alla fine avremo aggiunto un elemento quindi incrementiamo di uno l'indice
                indice++;
                //dopo aver spostato tutti gli elementi inserire quello desiderato
                a[posizione] = input;
            }
            else
                controllo = false;
            //restituzione in base alle dimensioni dell'array
            return controllo;


        }
    }
}