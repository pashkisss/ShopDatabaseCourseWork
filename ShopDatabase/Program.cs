using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopDatabase
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

    public class Shops
    {
        public Shop[] shops = new Shop[0];
        public Shops() { }
        public Shops(Shop[] shops)
        {
            this.shops = shops;
        }

        public void Add(Shop _shop)
        {            
            Array.Resize(ref shops, shops.Length + 1);
            shops[shops.Length - 1] = _shop;            
        }
        
        public int GetPosition(Shop _shop)
        {
            int ans = -1;
            for (int i = 0; i < shops.Length; i++)
            {
                if (shops[i].Equals(_shop))
                {
                    ans = i;
                }               
            }
            return ans;
        }
        
        public Shops Search(string _Name, string _Adress, string _Specialization, string _OwnershipType, int Open, int Close)
        {
            Shops Ans = new Shops();

            foreach (Shop item in shops)
            {
                if ((item.Name == _Name || _Name == "Не вказано" || _Name == "") &&
                    (item.Adress == _Adress || _Adress == "Не вказано" || _Adress == "") &&
                    (item.Specialization == _Specialization || _Specialization == "Не вказано" || _Specialization == "") &&
                    (item.OwnershipType == _OwnershipType || _OwnershipType == "Не вказано" || _OwnershipType == "") &&
                    (item.WorkTime.Open <= Open && item.WorkTime.Close >= Close)
                    )
                {
                    Ans.Add(item);
                }
            }
            return Ans;
        }

        public void Delete(int j)
        {
            if (j >= 0 && j < shops.Length)
            {
                if (j != shops.Length - 1)
                {
                    for (int i = j; i < shops.Length; i++)
                    {
                        shops[i] = new Shop(shops[i + 1]);
                    }
                    Array.Resize(ref shops, shops.Length - 1);
                }
            }
        }

    }

    public class StringArr
    {
        public string[] Arr = new string[0];
        public StringArr() { }
        public void Add(string _str)
        {
            if (_str != "Не вказано")
            {
                foreach (string str in Arr)
                {
                    if (str == _str)
                    {
                        return;
                    }
                }
                Array.Resize(ref Arr, Arr.Length + 1);
                Arr[Arr.Length - 1] = _str;
            }            
        }
    }


    public class Shop
    {
        public string Name { set; get; }
        public string Adress { set; get; }
        public string Tel { set; get; }
        public string Specialization { set; get; }
        public string OwnershipType { set; get; }
        public WorkTime WorkTime { set; get; }

        public Shop() { }
        public Shop(string Name, string Adress, string Tel, string Specialization, string OwnershipType, WorkTime WorkTime)
        {
            this.Name = Name;
            this.Adress = Adress;
            this.Tel = Tel;
            this.Specialization = Specialization;
            this.OwnershipType = OwnershipType;
            this.WorkTime = WorkTime;
        }

        public Shop(Shop _shop)
        {
            Name = _shop.Name;
            Adress = _shop.Adress;
            Tel = _shop.Tel;
            Specialization = _shop.Specialization;
            OwnershipType = _shop.OwnershipType;
            WorkTime.Open = _shop.WorkTime.Open;
            WorkTime.Close = _shop.WorkTime.Close;
        }

        public override bool Equals(object obj)
        {
            Shop s = (Shop)obj;
            return Name == s.Name &&
                   Adress == s.Adress &&
                   Tel == s.Tel &&
                   Specialization == s.Specialization &&
                   OwnershipType == s.OwnershipType &&
                   WorkTime.Open == s.WorkTime.Open &&
                   WorkTime.Close == s.WorkTime.Close;
        }
    }

    public class WorkTime
    {
        public int Open { set; get; }
        public int Close { set; get; }

        public WorkTime() { }
        public WorkTime(int Open, int Close)
        {
            this.Open = Open;
            this.Close = Close;
        }

        public override string ToString()
        {
            return Open + " - " + Close;
        }
    }
}
