using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLibrary
{
    class Order
    {
        protected int id;
        public int GetId()
        {
            return id;
        }
        public void SetId(int id)
        {
            this.id = id;
        }
    }
    class Book : Order
    {
        private string author;
        private string name;
        private string publication;
        private int year;
        private double price;
        private bool availability;
        public string GetAuthor()
        {
            return author;
        }
        public string GetName()
        {
            return name;
        }
        public string GetPublication()
        {
            return publication;
        }
        public int GetYear()
        {
            return year;
        }
        public double GetPrice()
        {
            return price;
        }
        public bool GetАvailability()
        {
            return availability;
        }
        public void SetAuthor(string author)
        {
            this.author = author;
        }
        public void SetName(string name)
        {
            this.name = name;
        }
        public void SetPublication(string publication)
        {
            this.publication = publication;
        }
        public void SetYear(int year)
        {
            this.year = year;
        }
        public void SetPrice(double price)
        {
            this.price = price;
        }
        public void SetAvailability(bool availability)
        {
            this.availability = availability;
        }
        public void Print()
        {
            Console.WriteLine("Id: " + id);
            Console.WriteLine("Автор: " + author);
            Console.WriteLine("Название: " + name);
            Console.WriteLine("Издательство: " + publication);
            Console.WriteLine("Год: " + year);
            Console.WriteLine("Цена: " + price);
            if (availability)
                Console.WriteLine("В наличии");
            else
                Console.WriteLine("Нет в наличии");
            Console.WriteLine();
        }
    }
    class Menu
    {
        public void PrintMenu()
        {
            Console.WriteLine("1 - Просмотреть полный каталог");
            Console.WriteLine("2 - Купить книгу");
            Console.WriteLine("3 - Изменить значение наличия книги(админ)");
            Console.WriteLine("0 - выход");
            Console.Write("Ввод: ");
        }
    }
    class Continuation
    {
        public void Continue()
        {
            Console.WriteLine("Для продолжения нажмите любую клавишу");
            Console.ReadKey(true);
            Console.Clear();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = 100;
            int count = 0;
            int count1 = 0;
            Menu menu = new Menu();
            Continuation continuation = new Continuation();
            Book[] book = new Book[size];
            Order[] order = new Order[size];
            book[count] = new Book();
            book[count].SetId(6778);
            book[count].SetAuthor("Аджей Сапковский");
            book[count].SetName("Послееднее желание");
            book[count].SetPublication("ACT");
            book[count].SetYear(1986);
            book[count].SetPrice(450);
            book[count].SetAvailability(true);
            count++;
            book[count] = new Book();
            book[count].SetId(6779);
            book[count].SetAuthor("Аджей Сапковский");
            book[count].SetName("Меч предназначений");
            book[count].SetPublication("ACT");
            book[count].SetYear(1993);
            book[count].SetPrice(450);
            book[count].SetAvailability(false);
            count++;
            int n, temp;
            do
            {
                foreach (var Element in order)
                {
                    if (Element == null)
                        break;
                    else
                    {
                        foreach (var Element1 in book)
                        {
                            if (Element1 == null)
                                break;
                            if (Element1.GetId() == Element.GetId())
                            {
                                if (Element1.GetАvailability())
                                {
                                    Console.WriteLine("Уведомление: ваш заказ " + Element.GetId() + " готов");
                                    order[count1] = null;
                                }
                            }
                        }
                    }
                }
                menu.PrintMenu();
                n = int.Parse(Console.ReadLine());
                if (n == 1)
                {
                    Console.Clear();
                    foreach (var Element in book)
                    {
                        if (Element == null)
                            break;
                        else
                        {
                            Element.Print();
                        }
                    }
                    continuation.Continue();
                }
                if (n == 2)
                {
                    Console.Clear();
                    Console.Write("Введите id книги: ");
                    temp = int.Parse(Console.ReadLine());
                    bool btemp = false;
                    bool btemp1 = false;
                    int temptemp = 0;
                    foreach (var Element in book)
                    {
                        if (Element == null)
                            break;
                        else
                        {
                            if (Element.GetId() == temp)
                            {
                                btemp = true;
                            }
                            if (btemp)
                            {
                                if (Element.GetАvailability())
                                {
                                    btemp1 = true;
                                }
                                break;
                            }
                            temptemp++;
                        }
                    }
                    if (btemp)
                    {
                        if (btemp1)
                        {
                            Console.WriteLine("Ваш заказ оформлен");
                            continuation.Continue();
                        }
                        else
                        {
                            order[count1] = new Order();
                            order[count1].SetId(book[temptemp].GetId());
                            Console.WriteLine("Ваша заявка оставлена, как только заказ будет готов, мы вас оповестим");
                            continuation.Continue();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Данного id не найдено");
                        continuation.Continue();
                    }
                }
                if (n == 3)
                {
                    int c = 0;
                    Console.Clear();
                    Console.Write("Введите id книги: ");
                    temp = int.Parse(Console.ReadLine());
                    bool btemp = false;
                    foreach (var Element in book)
                    {
                        if (Element == null)
                            break;
                        else
                        {
                            if (Element.GetId() == temp)
                            {
                                btemp = true;
                            }
                            if (btemp)
                            {
                                break;
                            }
                        }
                        c++;
                    }
                    if (btemp)
                    {
                        Console.Clear();
                        Console.Write("Значения наличия(1/0): ");
                        temp = int.Parse(Console.ReadLine());
                        if (temp == 1)
                        {
                            book[c].SetAvailability(true);
                            continuation.Continue();
                        }
                        else if (temp == 0)
                        {
                            book[c].SetAvailability(false);
                            continuation.Continue();
                        }
                        else
                        {
                            Console.WriteLine("Ошибка");
                            continuation.Continue();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Данного id не найдено");
                        continuation.Continue();
                    }
                }
            } while (n != 0);
        }
    }
}
