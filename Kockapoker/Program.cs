using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kockapoker
{
  class Program
  {
    static void Main(string[] args)
    {
      //Dictionary<int, int> proba = new Dictionary<int, int>() { };
      Jatekos gep = new Jatekos("Gép");
      Jatekos ember = new Jatekos("Bazzzsi");
      int emberNyer = 0;
      int gepNyer = 0;
      string valasz = string.Empty;
      do
      {
        JatekEgykor(gep, ref gepNyer, ember, ref emberNyer);
        JatekAllasa(emberNyer, gepNyer);
        Console.Write("Akarsz még játszani? (I/N): ");
        valasz = Console.ReadLine().ToLower();
        Console.WriteLine("-------------------");
      } while (valasz == "N");
      Console.Clear();
      Console.WriteLine("A játék vége...");
      Console.ReadKey();
    }

    private static void JatekAllasa(int ember, int gep)
    {
      Console.WriteLine($"Ember: {ember.ToString().PadLeft(2)} - Gép {gep}");
    }

    private static void JatekEgykor(Jatekos gep, ref int gepNyer, Jatekos ember, ref int emberNyer)
    {
      Console.WriteLine("Szeretnél kezdeni: (I/N)");
      if (Console.ReadLine().ToLower() == "i")
      {
        ember.Kor();
        Console.WriteLine($"Az ember: {ember.Ertekszoveg}");
        // Console.WriteLine(ember.Ertek);
        gep.Kor();
        Console.WriteLine($"A gép   : {gep.Ertekszoveg}");
        // Console.WriteLine(gep.Ertek);
        eredmenykiiras(gep,  ref gepNyer, ember,  ref emberNyer);
      }
      else
      {
        gep.Kor();
        Console.WriteLine($"A gép   : {gep.Ertekszoveg}");
        ember.Kor();
        Console.WriteLine($"Az ember: {ember.Ertekszoveg}");
      }
    }

    private static void eredmenykiiras(Jatekos gep, ref int gepNyer, Jatekos ember,ref int emberNyer)
    {
      if (ember.Ertek == gep.Ertek)
      {
        Console.WriteLine("-------------------");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Az állás döntetlen!");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("-------------------");
      }
      else if (ember.Ertek > gep.Ertek)
      {
        Console.WriteLine("-------------------");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("A gép veszített!");
        emberNyer++;
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("-------------------");

      }
      else
      {
        Console.WriteLine("-------------------");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("A gép nyert!");
        gepNyer++;
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("-------------------");
      }
    }
  }
}
