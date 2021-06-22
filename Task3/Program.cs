using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    /*Используя Visual Studio, создайте проект по шаблону Console Application.
   Создайте программу, в которой, создайте структуру с именем Price, содержащую следующие поля: название товара, название магазина, 
    в котором продается товар, тоимость товара в гривнах. Написать логику, которая будет выполнять следующие действия: 
    1) ввод с клавиатуры данных в массив, состоящий из двух элементов типа Price(записи должны быть упорядочены в алфавитном порядке
    по названиям магазинов); 2) вывод на экран информации о товарах, продающихся в магазине, название которого введено с 
    клавиатуры(если такого магазина нет, вывести исключение).*/

    class Program
    {

        static void Main(string[] args)
        {
            Price[] price = new Price[2];
       
            string[] shopNames = new string[2];
            string []goodsFromFirstShop = new string[5];
            string[] goodsFromSecondShop = new string[5];
            double[] pricesFromFirstShop = new double[5];
            double[] pricesFromSecondShop = new double[5];

            Price.SetShopsNames(shopNames);
            price[0] = new Price(shopNames[0], Price.SetGoods(goodsFromFirstShop,shopNames[0]), Price.SetPrices(pricesFromFirstShop,goodsFromFirstShop));
            price[1] = new Price(shopNames[1], Price.SetGoods(goodsFromSecondShop,shopNames[1]), Price.SetPrices(pricesFromSecondShop,goodsFromSecondShop));

            Console.Write("Enter shop name: ");
            string name = Console.ReadLine();

            try
            {
                if (name != price[0].ShopName && name != price[1].ShopName)
                {
                    throw new Exception($"Shop is not found...\nAvailable shops: {price[0].ShopName},{price[1].ShopName}");
                }
                else if (name == price[0].ShopName) { price[0].DisplayShopItems(); }
                else { price[1].DisplayShopItems(); }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            Console.ReadLine();
        }
    }
    }
    public struct Price
    {
        private string[] itemName;
        public string[] ItemName
    {
        get { return itemName; }
        set { itemName = value; }   
    }
        private string shopName;
        public string ShopName
    {
        get { return shopName; }
        set { shopName = value; }
    }
        private double []cost;
        public double[] Cost
    {
        get { return cost; }
        set { cost = value; }
    }
        
    public Price(string shopName,string[] goods,double[]cost)
    {
        this.shopName = shopName;
        this.itemName = goods;
        this.cost = cost;
    }
    public static void SetShopsNames(string[] shopNames)
    {
        for (int i = 0; i < 2; i++)
        {
            Console.Write("Enter shop name: ");
            shopNames[i] = Console.ReadLine();
        }

        if (shopNames[0].Length <= shopNames[1].Length)
        {
            for (int i = 0; i < shopNames[0].Length; i++)
            {
                if (shopNames[0][i].Equals(shopNames[1][i]))
                {
                    continue;
                }
                if (shopNames[0][i] > shopNames[1][i])
                {
                    var hold = shopNames[0];
                    shopNames[0] = shopNames[1];
                    shopNames[1] = hold;
                }
                break;
            }
        }
        else
        {
            for (int i = 0; i < shopNames[1].Length; i++)
            {
                if (shopNames[0][i].Equals(shopNames[1][i]))
                {
                    continue;
                }
                if (shopNames[1][i] < shopNames[0][i])
                {
                    var hold = shopNames[0];
                    shopNames[0] = shopNames[1];
                    shopNames[1] = hold;
                }
                break;
            }
        }
    }
    public static string[] SetGoods(string[] goods,string shopName)
    {
        for (int i = 0; i < 5; i++)
        {
                Console.Write("Enter goods for {0}: ",shopName);
                goods[i] = Console.ReadLine();
        }
        return goods;
    }
    public static double[] SetPrices(double[] cost,string[]goods)
    {
        for (int i = 0; i < 5; i++)
        {
            Console.Write("Enter price for {0}: ",goods[i]);
            cost[i] = double.Parse(Console.ReadLine());
        }
        return cost;
    }
    public void DisplayShopItems()
    {
        Console.WriteLine(ShopName);
        int counter = 0;
        foreach (var item in ItemName)
        {
            Console.WriteLine(item+": "+Cost[counter]);
            counter++;
        }
    }
}
        
    

