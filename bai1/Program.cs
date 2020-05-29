using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace bai1
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\Admin\source\repos\BT_AnhKhoa\bai1\";
            PayLoad payLoad = new PayLoad()
            {
                Numbers = new List<number>()
            };
            ResPay resPay = new ResPay()
            {
                SumTotal = new List<total>()
            };
            using (StreamReader sr = File.OpenText($@"{path}intput.json"))
            {
                var data = sr.ReadToEnd();
                payLoad = JsonConvert.DeserializeObject<PayLoad>(data);
                
            }
            foreach (number num in payLoad.Numbers)
            {
                Console.WriteLine($"{num.a} {num.b} {num.c}");
            }

            foreach (number num in payLoad.Numbers)
            {
                resPay.SumTotal.Add(new total() { sum = (num.a + num.b + num.c) });
            }


            using (StreamWriter sw = File.CreateText($@"{path}output1.json"))
            {
                var data = JsonConvert.SerializeObject(resPay);
                sw.WriteLine(data);
            }

            using (StreamWriter sw = File.CreateText($@"{path}output2.json"))
            {
                ResPay2 resPay2 = new ResPay2()
                {
                    NumbersX2 = new List<numberX2>()
                };
                foreach (number num in payLoad.Numbers)
                {
                    resPay2.NumbersX2.Add(new numberX2()
                    {
                        aX2 = num.a * 2,
                        bX2=num.b*2,
                        cX2=num.c*2
                    });
                }

                var data = JsonConvert.SerializeObject(resPay2);
                sw.WriteLine(data);
            }
        }
    }
    class PayLoad
    {
        public List<number> Numbers { get; set; }
    }
    class ResPay
    {
        public List<total> SumTotal { get; set; }
    }
    class ResPay2
    {
        public List<numberX2> NumbersX2 { get; set; }
    }
    class number
    {
        public int a { get; set; }
        public int b { get; set; }
        public int c { get; set; }
    }
    class total
    {
        public int sum { get; set; }
    }
    class numberX2
    {
        public int aX2 { get; set; }
        public int bX2 { get; set; }
        public int cX2 { get; set; }
    }

}