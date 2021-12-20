using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace TestHangMan
{
    class Program
    {
   
        static void Main(string[] args)
        {
      
                Random rnd = new Random();
                string[] ordLista = {"fotboll","buss","jordglob","förkyld"};

                string ordAttGissa = ordLista[rnd.Next(0,ordLista.Length)];

                StringBuilder visaFörSpelaren = new StringBuilder(ordAttGissa.Length);

                for (int i = 0; i < ordAttGissa.Length; i++)
                {
                    visaFörSpelaren.Append('_');
                 }
                int liv = 10;
                bool vunnit = false;
                int fleraBokstäver = 0;
           
                char gissning;
                List<char> rättGissat = new List<char>();
                List<char> felGissat = new List<char>();
            while (!vunnit && liv > 0)
            {

                Console.WriteLine("välj om du vill försöka gissa hela ordet eller bara en bokstav");
                Console.WriteLine(" välj 1 om du vill försöka på hela ordet annars 2");
                int val = int.Parse(Console.ReadLine());
                if(val == 1)
                {
                    Console.WriteLine("skriv in ordet du gissar på");
                    string gissatOrd = Console.ReadLine();
                    if (gissatOrd == ordAttGissa)
                    {
                        Console.WriteLine("grattis du klarade gissa hela ordet som va " + ordAttGissa);
                        vunnit = true;
                    }
                    else
                        Console.WriteLine("det gissade ordet vad fel");
                    liv--;
                    continue;
                }
                else
                Console.WriteLine("gissa en bokstav");
                              
                gissning = char.Parse(Console.ReadLine());
                if (rättGissat.Contains(gissning))
                {
                    Console.WriteLine("du har redan gissat " + gissning);
                    continue;
                }
                else if (felGissat.Contains(gissning))
                {
                    Console.WriteLine("du har redan gissat " + gissning);
                    continue;
                }

                if (ordAttGissa.Contains(gissning))
                {
                    rättGissat.Add(gissning);

                    for (int i = 0; i < ordAttGissa.Length; i++)
                    {
                        if (ordAttGissa[i] == gissning)
                        {
                            visaFörSpelaren[i] = ordAttGissa[i];
                            fleraBokstäver++;
                        }
                    }
                    if (fleraBokstäver == ordAttGissa.Length)
                        vunnit = true;
                }
                else
                {
                    felGissat.Add(gissning);
                    Console.WriteLine("bokstaven finns inte i ordet " + gissning);
                    liv--;
                }
                Console.WriteLine(visaFörSpelaren);    
            }
            if (vunnit)
                Console.WriteLine("du klarade det");
            else
                Console.WriteLine("Du klarade det inte uta förlorade...... ordet som skulle gissas va " + ordAttGissa);
            Console.WriteLine("tryck enter för att avsluta");
            Console.ReadLine();

        }

        
    
}
}
