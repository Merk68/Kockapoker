using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kockapoker
{
  class Kockak
  {
    int[] ertekek = new int[5];
    Dictionary<int, int> minta = new Dictionary<int, int>();
    public int PontErtek { get; set; }
    public void Dobas()
    {
      Feltolt();
    } 

    /// <summary>
    /// 5 db véletlen szám az értékek tömbbe
    /// </summary>

    private void Feltolt()
    {
      Random vel = new Random(Guid.NewGuid().GetHashCode());
      for (int i = 0; i < ertekek.Length; i++)
      {
        ertekek[i] = vel.Next(1, 7);
      }

    }
    /// <summary>
    /// A dobás pontértékét egész számként adja vissza.
    /// </summary>
    /// <returns></returns>
    public int Ertek()
    {
      KiErtekel();
      foreach (var m in minta)
      {
        Console.WriteLine($"{m.Key}:{m.Value}");
      }
      return PontErtek;
    }
    /// <summary>
    /// Statisztikát készít a számokból ( melyik számból mennyi van)
    /// Ha nem fordul elő a szám, akkor nem szerepel a dict-ben.
    /// </summary>

    private void Csoportosit()
    {
      foreach (var e in ertekek)
      {
        if (minta.ContainsKey(e))
        {
          minta[e]++;
        }
        else
        {
          minta.Add(e, 1);
        }
      }
    }
    /// <summary>
    /// Egy darab előfordulásokat ki veszi a dict-ből.
    /// </summary>
    private void Egyszerusit()
    {
      List<int> egyesek = new List<int>();
      foreach (var m in minta)
      {
        if (m.Value == 1)
        {
          egyesek.Add(m.Key);
        }
      }
      foreach (var e in egyesek)
      {
        minta.Remove(e);
      }
    }
    /// <summary>
    /// Elvégzi a dobás kiértékelését.
    /// </summary>

    private void KiErtekel()
    {
      Csoportosit();

      if (HaOtKulonbozo())
      {
        KissorNagysorSemmi();
      }
      else
      {
        Egyszerusit();
        //1 pár, 3 egyforma, 4 egyforma, 5 egyforma
        if (minta.Count == 1)
        {
          int melyik = 0;
          int darab = 0;
          foreach (var m in minta)
          {
            melyik = m.Key;
            darab = m.Value;
          }
          switch (darab)
          {
            case 2:
              PontErtek = melyik;
              break;
            case 3:
              PontErtek = 30 + melyik;
              break;
            case 4:
              PontErtek = 40 + melyik;
              break;
            case 5:
              PontErtek = 1000 + melyik;
              break;
            

          }
        }
        //2pár és full
        else
        {

        }
      }

    }

    private bool HaOtKulonbozo()
    {
      return minta.Count == 5;
    }

    /// <summary>
    /// Kissor, nagysor, semmi ertelet allitja be.
    /// </summary>

    private void KissorNagysorSemmi()
    {
      if (ertekek[0] == 1 && ertekek[4] == 5)
      {
        PontErtek = 100;
      }
      else if (ertekek[0] == 2 && ertekek[4] == 6)
      {
        PontErtek = 200;
      }
      else
      {
        PontErtek = 0;
      }
    }

    /// <summary>
    /// A dobást vissza adja szövegesen összefűzve.
    /// pl.: 1-1-2-3-3-3
    /// </summary>
    /// <returns></returns>
    public string ErtekSzoveg()
    {
      Sorrendbe();
      return String.Join("-", ertekek);
    }
    /// <summary>
    /// Novekvő sorrendbe rakja a dobásokat. (értékek tömb)
    /// </summary>

    private void Sorrendbe()
    {
      for (int i = 0; i < ertekek.Length-1; i++)
      {
        for (int j = i+1; j < ertekek.Length; j++)
        {
          if (ertekek[i]>ertekek[j])
          {
            int temp = ertekek[i];
            ertekek[i] = ertekek[j];
            ertekek[j] = temp;
          }
        }
      }
    }
  }
}
