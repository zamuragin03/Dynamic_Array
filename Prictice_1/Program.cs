using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using Microsoft.VisualBasic.CompilerServices;
using static System.Console;

namespace Prictice_1
{
    class Person
    {
        private string Name;
        private int Age;

        public int age => Age;

        public Person(string Name, int Age)
        {
            this.Age = Age;
            this.Name = Name;
        }

        public static bool operator ==(Person p1, Person p2)
        {
            return p1.Age == p2.Age && p1.Name == p2.Name;
        }

        public static bool operator !=(Person p1, Person p2)
        {
            return !(p1.Age == p2.Age && p1.Name == p2.Name);
        }

        public override string ToString()
        {
            return Name + " " + Age;
        }
    }
    class MyInt<T> /*: IComparer<T>*/
    {
        private T[] arr;
        private int count;
        private T person;

        public MyInt(int capacity)
        {
            count = 0;
            arr = new T[capacity];
        }
        public T this[int ind]
        {
            get
            {
                return arr[ind];
            }
            set
            {
                arr[ind] = value;
            }
        }
        private IEnumerator GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return arr[i];
            }
        }
        public int Capacity => arr.Length;
        public int Count => arr.Length;
        public void Add(params T[] person)
        {
            for (int i = 0; i < person.Length; i++)
            {
                T[] tmp = new T[arr.Length + 1];
                Array.Copy(arr, tmp, arr.Length);
                arr = tmp;
                arr[count] = person[i];
                count++;
            }

        }

        public void Sort()
        {
            Array.Sort(arr, 0, count/*, this*/);
        }

        //public int Compare(object x, object? y)
        //{
        //    T _x = (T)x;
        //    T _y = (T)y;
        //    return _x.Equals(_y);
        //    //return _y.age.CompareTo(_x.age);

        //}

        public bool Contains(object item)
        {
            for (int i = 0; i < count; i++)
            {
                if (arr[i].Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

        public void Remove(object obj)
        {
            if (Contains(obj))
            {
                int k = 0;
                for (int i = 0; i < count; i++)
                {
                    if (arr[i].Equals(obj))
                    {
                        k = i;
                        arr[i] = default;
                    }
                }

                for (int i = k; i < count; i++)
                {
                    arr[i] = arr[i + 1];
                }
                --count;
            }


        }

        public MyInt<T> Clone()
        {
            MyInt<T> newarr = new MyInt<T>(count);
            newarr.Add(arr);
            return newarr;
        }

        public void CopyTo(ref MyInt<T> array, int arrayIndex)
        {
            array = new MyInt<T>(count);
            for (int i = arrayIndex; i < count; i++)
            {
                array.Add(arr[i]);
            }
        }

        public void Clear()
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = default;
            }
            count = 0;
        }

        public MyInt<T> GetRange(int index, int count)
        {
            MyInt<T> newarr = new MyInt<T>(this.count);

            for (int i = index; i < index+count; i++)
            {
                newarr[i] = arr[i];
            }

            return newarr;
        }

        public int IndexOf(object value, int startIndex)
        {
            for (int i = startIndex; i < arr.Length; i++)
            {
                if (arr[i].Equals(value))
                {
                    return i;
                }
            }

            return 0;
        }

        public void Insert(int index, object value)
        {
            count++;
            T[] array = new T[count];
            array[index] = (T)value;

            for (int i = 0; i < index; i++)
            {
                array[i] = arr[i];
            }
            for (int i = index; i < count - 1; i++)
            {
                array[i + 1] = arr[i];
            }

            arr = array;
        }


    }
    class Program
    {
        static void Main(string[] args)
        {
            MyInt<Person> arr = new MyInt<Person>(0);
            Person Igor = new Person("Igor", 20);
            Person Roman = new Person("Roman", 19);
            Person Stas = new Person("Stas", 21);
            Person Poline = new Person("Poline", 19);
            Person Ruslan = new Person("Ruslan", 20);

            arr.Add(Igor, Roman,Stas, Poline, Ruslan);
            //arr.Add(Igor, Roman, Stas);

            //void Print(MyInt arr)
            //{
            //    foreach (Person person in arr)
            //    {
            //        WriteLine(person + " ");
            //    }
            //}

            //WriteLine(arr.Count + " " + arr.Capacity);
            //Print(arr);

            //WriteLine("Sort");
            //arr.Sort();
            //Print(arr);

            //WriteLine();
            //WriteLine("Contains " + arr.Contains(new Person("Igor", 10)));
            //arr.Remove(new Person("Isd", 20));

            //Print(arr);

            //WriteLine("clone ");

            //MyInt newarray = arr.Clone();
            //var array = arr.Clone();
            //Print(array);

            //arr.Clear();
            //WriteLine("Clear");
            //Print(arr);


            //arr.Add(Igor, Roman, Stas);
            //MyInt test = new MyInt(arr.Count);
            //arr.CopyTo(ref test, 2);
            //WriteLine("Copy to from 2");
            //Print(test);



            //WriteLine("Get Range");
            //MyInt GetRangeInt = arr.GetRange(1, 3);

            //Print(GetRangeInt);

            //WriteLine();
            //arr.Insert(0, new Person("Petr", 16));

            //Print(arr);

            //int index = arr.IndexOf(new Person("Stas", 21), 1);

            //WriteLine(index);
            ///*Func<int, int, int> del = (x, y) => x * y;
            //WriteLine(del(3,1));*/
        }
    }
}
