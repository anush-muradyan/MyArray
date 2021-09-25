using System;

namespace MyArray {
    class Program {
        static void Main(string[] args) {
            Map<string, int> map = new Map<string, int>();
            map.Add("a", 1);
            map.Add("aa", 2);
            map.Add("aaa", 3);
            map.Add("aaaa", 4);
            map.Add("aaaaa", 5);
            map.Add("a o", 6);
            map.Remove("aa");
            foreach (KeyValue<string, int> m in map) {
                Console.WriteLine(m);
            }

            MyArray<int> a = new MyArray<int>();

            a.Add(12);
            a.Add(11);
            a[2] = 45;
            foreach (var i in a) {
                Console.WriteLine(i);
            }
        }
    }
}