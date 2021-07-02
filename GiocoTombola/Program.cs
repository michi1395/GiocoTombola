using System;

namespace GiocoTombola
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Benvenuto a Tombola!");

            do
            {
                int[] myNumbers = new int[15];
                Console.WriteLine("Inserisci 15 numeri:");

                myNumbers = InsertNumber(myNumbers);

                Console.WriteLine("I numeri che hai scelto sono:");
                for (int i = 0; i < myNumbers.Length; i++)
                {
                    Console.Write($"{myNumbers[i]}  ");
                }

                int choice = levelDif();
                int[] drawnNumbers = new int[choice];
                drawnNumbers = DrawNumbers(choice);
                // stampo a schermo i valori che mi son stati generati a random per verifica:
                Console.WriteLine("I numeri estratti sono:");
                for (int i=0;i<drawnNumbers.Length;i++)
                {
                    Console.Write($"{drawnNumbers[i]}\t");
                }
                CheckWin(myNumbers, drawnNumbers);
                Console.WriteLine("Vuoi rigiocare? Premi 2 per uscire, oppure qualunque altro pulsante per continuare!");
            } while (!(Console.ReadKey().KeyChar == '2'));





            //Metodo per inserimento valori da parte dell'utente
            int[] InsertNumber(int [] numbers)
            {
                int numeroScelto; //numero scelto dall'utente 
                for (int i =0; i < numbers.Length; i++)
                {
                        while (!int.TryParse(Console.ReadLine(), out numeroScelto) || numeroScelto < 1 || numeroScelto > 90)
                        {
                        Console.WriteLine("Puoi inserire solo numeri interi compresi tra 1 e 90");
                         }
                    int found = -1; //controllo che il numero scelto dall'utente non sia già inserito
                    found = Array.IndexOf(numbers, numeroScelto);
                    if (found > -1)
                    {
                        Console.WriteLine($"Il numero {numeroScelto} è presente nell'array! Riprova!");
                        i--;
                    }
                    else
                    {
                        numbers[i] = numeroScelto;
                    }
                }
                return numbers;
            }

            //Metodo per scegliere il livello di difficoltà (Facile, Medio, Difficile)
            int levelDif()
            {
                int num;
                int M=0;
                Console.WriteLine("\nScegli il livello di difficolta! \nClicca: \n1: Facile\n2: Medio\n3: Difficile\n");
                num = CheckChoice();

                switch(num)
                {
                    case 1:
                        M = 70;
                        Console.WriteLine("Hai scelto --> Livello FACILE");
                        break;
                    case 2:
                        M = 40;
                        Console.WriteLine("Hai scelto --> Livello MEDIO");
                        break;
                    case 3:
                        M = 20;
                        Console.WriteLine("Hai scelto --> Livello DIFFICILE");
                        break;
                    default:
                        break;

                }
                return M;
            }

            //Metodo che controlla che l'utente inserisca solo 1 2 o 3 per la scelta del livello di difficoltà
            int CheckChoice()
            {
                int num;
                while (!int.TryParse(Console.ReadLine(), out num) || num < 1 || num > 3)
                {
                    Console.WriteLine("Puoi inserire solo inserire 1 2 o 3! Riprova:");
                }

                return num;
            }

            //Metodo per estrazione dei numeri
            int[] DrawNumbers(int N)
            {
                int[] numbers = new int[N];
                Random random = new Random();
                for (int i = 0; i < N; i++)
                {
                    int tomb = random.Next(1, 91);
                    int found = -1; //controllo che il numero scelto dall'utente non sia già inserito
                    found = Array.IndexOf(numbers, tomb);
                    if (found > -1)
                    { 
                        i--;
                    }
                    else
                    {
                        numbers[i] = tomb;
                    }

                }
                return numbers;
            }

            //Metodo controllo vincita
            void CheckWin(int []myNumbers, int [] drawnNumbers)
            {
                int count =0;
                int[] Check = new int[myNumbers.Length];
                for (int i=0;i<myNumbers.Length;i++)
                {
                    for(int j=0;j<drawnNumbers.Length;j++)
                    {
                        if(myNumbers[i]==drawnNumbers[j])
                        {
                            count++;
                            Check[i] = myNumbers[i];

                        }
                    }
                }
                switch (count)
                {
                    case 2:
                        Console.WriteLine("\nHai fatto ambo!");
                        Console.WriteLine("I numeri vincenti sono:");
                        for(int i=0;i<Check.Length;i++)
                        { 
                            if(Check[i]!=0)
                            {
                                Console.Write($"{Check[i]}    ");
                            }
                        }
                        break;
                    case 3:
                        Console.WriteLine("\nHai fatto terna!");
                        Console.WriteLine("I numeri vincenti sono:");
                        for (int i = 0; i < Check.Length; i++)
                        {
                            if (Check[i] != 0)
                            {
                                Console.Write($"{Check[i]}    ");
                            }
                        }
                        break;
                    case 4:
                        Console.WriteLine("\nHai fatto quaterna!");
                        Console.WriteLine("I numeri vincenti sono:");
                        for (int i = 0; i < Check.Length; i++)
                        {
                            if (Check[i] != 0)
                            {
                                Console.Write($"{Check[i]}    ");
                            }
                        }
                        break;
                    case 5:
                        Console.WriteLine("\nHai fatto cinquina!");
                        Console.WriteLine("I numeri vincenti sono:");
                        for (int i = 0; i < Check.Length; i++)
                        {
                            if (Check[i] != 0)
                            {
                                Console.Write($"{Check[i]}    ");
                            }
                        }
                        break;
                    case 15:
                        Console.WriteLine("\nHai fatto tombola!");
                        Console.WriteLine("I numeri vincenti sono:");
                        for (int i = 0; i < Check.Length; i++)
                        {
                            if (Check[i] != 0)
                            {
                                Console.Write($"{Check[i]}    ");
                            }
                        }
                        break;
                    case 6:
                    case 7:
                    case 8:
                    case 9:
                    case 10:
                    case 11:
                    case 12:
                    case 13:
                    case 14:
                        Console.WriteLine("\nPeccato! Non hai fatto tombola! I tuoi numeri vincenti sono:");
                        for (int i = 0; i < Check.Length; i++)
                        {
                            if (Check[i] != 0)
                            {
                                Console.Write($"{Check[i]}    ");
                            }
                        }
                        break;
                    default:
                        Console.WriteLine("\nHai perso...");
                        break;
                }

            }

        }
    }
}
