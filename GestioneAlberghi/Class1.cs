using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GestioneAlberghi
{
    public struct stanza
    {
        public bool stato;
        public int numero;
        public int posti;
        public decimal costo;

    }
    class Class1
    {
        
        public static int Cerca(stanza[] el, int n, int cod)
        {
            int x = default(int);
            while (x < n)
            {
                if (cod == el[x].numero)
                {
                    return x;
                }
                x++;
            }
            return -1;
        }

        public static int Cerca1(stanza[] el, int n, string cod)
        {
            int x = default(int);
            while (x < n)
            {
                if (cod == el[x].numero.ToString())
                {
                    return x;
                }
                x++;
            }
            return -1;
        }

        public static void ordinac(stanza[] elep, int n)
        {
            int x = 0;
            int y = 0;
            stanza k = default(stanza);
            while (n > x)
            {
                y = x + 1;
                while (n > y)
                {
                    if (elep[x].numero > elep[y].numero )
                    {
                        k = elep[x];
                        elep[x] = elep[y];
                        elep[y] = k;
                    }
                    y++;
                }
                x++;
            }
        }
        public static void ordinad(stanza[] elep, int n)
        {
            int x = 0;
            int y = 0;
            stanza k = default(stanza);
            while (n > x)
            {
                y = x + 1;
                while (n > y)
                {
                    if (elep[x].numero < elep[y].numero)
                    {
                        k = elep[x];
                        elep[x] = elep[y];
                        elep[y] = k;
                    }
                    y++;
                }
                x++;
            }
        }

        public static void ordinacc(stanza[] elep, int n)
        {
            int x = 0;
            int y = 0;
            stanza k = default(stanza);
            while (n > x)
            {
                y = x + 1;
                while (n > y)
                {
                    if (elep[x].costo > elep[y].costo)
                    {
                        k = elep[x];
                        elep[x] = elep[y];
                        elep[y] = k;
                    }
                    y++;
                }
                x++;
            }
        }
        public static void ordinadc(stanza[] elep, int n)
        {
            int x = 0;
            int y = 0;
            stanza k = default(stanza);
            while (n > x)
            {
                y = x + 1;
                while (n > y)
                {
                    if (elep[x].numero < elep[y].numero)
                    {
                        k = elep[x];
                        elep[x] = elep[y];
                        elep[y] = k;
                    }
                    y++;
                }
                x++;
            }
        }

        public static void ordinacs(stanza[] elep, int n)
        {
            int x = 0;
            int y = 0;
            stanza k = default(stanza);
            while (n > x)
            {
                y = x + 1;
                while (n > y)
                {
                    if (string.Compare(elep[x].stato.ToString() , elep[y].stato.ToString())<0)
                    {
                        k = elep[x];
                        elep[x] = elep[y];
                        elep[y] = k;
                    }
                    y++;
                }
                x++;
            }
        }

       

        public static int elimina(stanza[] elep, ref int n, string cod)
        {
            int x = default(int);

            int y = 0;
            x = 0;
            while (x < n)
            {
                if (elep[x].numero.ToString() == cod)
                {

                    elep[x] = elep[n - 1];
                    n = n - 1;
                    y++;
                }
                x++;
            }
            return y;
        }

        public static void salva(stanza[] elep, int n, string p)
        {
            int x = 0;


            StreamWriter miofile;
            miofile = new StreamWriter(p);
            while (x < n)
            {
                miofile.WriteLine(elep[x].stato);
                miofile.WriteLine(elep[x].numero);
                miofile.WriteLine(elep[x].posti);
                miofile.WriteLine(elep[x].costo);
                
                x++;
            }
            miofile.Close();

        }
        public static bool Carica(stanza[] el, ref int n, string p)
        {
            if (!File.Exists(p))
            {
                return false;
            }
            StreamReader miofile = default(StreamReader);
            miofile = new StreamReader(p);
            stanza k = default(stanza);
            n = 0;
            while (miofile.EndOfStream == false)
            {
                k.stato = bool.Parse(miofile.ReadLine());
                k.numero = int.Parse(miofile.ReadLine());
                k.posti = int.Parse(miofile.ReadLine());
                k.costo = decimal.Parse(miofile.ReadLine());
               

                el[n] = k;
                n++;
            }
            miofile.Close();
            return true;



        }

    }
}
