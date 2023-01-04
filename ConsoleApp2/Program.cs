using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp2
{
    
    class Program
    {

        public static void ArrayChallenge(int[] arr)
        {

            // code goes here  
            string[,] tmpData = new string[arr.Length+1,arr.Length+1];
            int tmp_y = arr.Length;
            int tmp_x = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0 ; j < arr.Length+1; j++)
                {
                    //Set axis Y
                    if (j == 0)
                    {
                        if (i == 9)
                        {
                            tmpData[i, j] = " ";
                        }
                        else
                        {
                            if (tmp_y - 1 == 0)
                                continue;
                            tmpData[i, j] = (tmp_y - 1).ToString();
                        }
                        tmp_y--;
                        continue;
                    }

                    //Set axis x
                    if (i == 9)
                    {
                        tmpData[i, j] = tmp_x.ToString();
                        tmp_x++;
                        continue;
                    }
                    
                    //Logic set matrix
                    int valData = arr[j - 1];
                    if (tmp_y <= valData)
                        tmpData[i, j] = "#";
                    else
                        tmpData[i, j] = "-";
                }
            }

            //Proses show untuk menampilkan
            for(int i = 0; i <= arr.Length; i++)
            {
                for (int j=0; j <= arr.Length; j++){
                    if (tmpData[i, j] == null)
                        continue;
                    Console.Write(tmpData[i, j]);
                    if (j == 0)
                        Console.Write(" ");
                    if (i == 9)
                    {
                        Console.Write(" ");
                        continue;
                    }
                    Console.Write("-");
                }
                Console.WriteLine();
            }

        }

        public static void CalculateData(string data)
        {
            //Prepare dan Pengolahan Data Json
            var tmpData = (JObject)JsonConvert.DeserializeObject(data);
            var list = tmpData.Properties().Select(dt => dt).ToList();
            int count_string = 0, count_bool = 0, count_number = 0;

            //Proses pemetaan pengecekan data
            foreach(var dt in list)
            {
                if(dt.First.ToList().Count > 1)
                {
                    var inner_list1 = dt.Select(dt => dt).ToList();
                    foreach(var dt1 in inner_list1)
                    {
                        var ltoken = dt1.ToList();
                        if(ltoken.Count > 1)
                        {
                            foreach (var dtToken in ltoken)
                            {
                                if(dtToken.First.ToList().Count > 1)
                                {
                                    foreach(var dtToken1 in dtToken.Select(dt => dt).ToList())
                                    {
                                        if(dtToken1.ToList().Count > 1)
                                        {
                                            foreach(var dtToken2 in dtToken1.ToList())
                                            {
                                                if(dtToken2.First.ToList().Count > 1)
                                                {
                                                    foreach(var dtToken3 in dtToken2.First.ToList())
                                                    {
                                                        if(dtToken3.First.ToList().Count > 1)
                                                        {
                                                            foreach(var dtToken4 in dtToken3.First.ToList())
                                                            {
                                                                if (dtToken4.First.Type.ToString() == "String")
                                                                    count_string++;
                                                                else if (dtToken4.First.Type.ToString() == "Boolean")
                                                                    count_bool++;
                                                                else
                                                                    count_number++;
                                                            }
                                                        }
                                                        if (dtToken3.First.Type.ToString() == "String")
                                                            count_string++;
                                                        else if (dtToken3.First.Type.ToString() == "Boolean")
                                                            count_bool++;
                                                        else
                                                            count_number++;
                                                    }
                                                    continue;
                                                }
                                                if (dtToken2.First.Type.ToString() == "String")
                                                    count_string++;
                                                else if (dtToken2.First.Type.ToString() == "Boolean")
                                                    count_bool++;
                                                else
                                                    count_number++;
                                            }
                                            continue;
                                        }
                                        if (dtToken1.First.Type.ToString() == "String")
                                            count_string++;
                                        else if (dtToken1.First.Type.ToString() == "Boolean")
                                            count_bool++;
                                        else
                                            count_number++;
                                    }
                                    continue;
                                }
                                if (dtToken.First.Type.ToString() == "String")
                                    count_string++;
                                else if (dtToken.First.Type.ToString() == "Boolean")
                                    count_bool++;
                                else
                                    count_number++;
                            }
                            continue;
                        }
                        if (dt1.Type.ToString() == "String")
                            count_string++;
                        else if (dt1.Type.ToString() == "Boolean")
                            count_bool++;
                        else
                            count_number++;
                        continue;
                    }
                    continue;
                }

                if (dt.Value.Type.ToString() == "String")
                    count_string++;
                else if (dt.Value.Type.ToString() == "Boolean")
                    count_bool++;
                else
                    count_number++;
            }
            Console.WriteLine("String: "+ count_string);
            Console.WriteLine("Boolean: " + count_bool);
            Console.WriteLine("Number: " + count_number);
        }

        public static void PemetaanData(string input, int countHello)
        {
            string tmp_groupMardi = "";
            string tmp_groupLain = "";
            string tmp_koridor = "";
            string result = "";
            var fib_val = Fibonacci_Iterative(countHello);
            var fib_valMardy = Fibonacci_Iterative2(countHello);

            foreach(var dt in fib_val)
            {
                for (int i = 0; i < dt; i++)
                {
                    if (dt == 1)
                    {
                        tmp_groupMardi = tmp_groupMardi + ">";
                        tmp_groupLain = tmp_groupLain + "<";
                    }

                    tmp_groupMardi = tmp_groupMardi + ">";
                    tmp_groupLain = tmp_groupLain + "<";
                    tmp_koridor = tmp_koridor + "-";
                }
            }

            int index = 0, tmp_lenInput= input.Length;
            while(tmp_lenInput > 0)
            {
                if(result.ToCharArray().Select(dt => (int)dt == (int)'>').ToList().Count != countHello && result.ToCharArray().Select(dt => (int)dt == (int)'>').Any(x => x == false)==false)
                {
                    result = result + tmp_groupMardi.Substring(0, fib_valMardy[index]);
                    tmp_groupMardi=tmp_groupMardi.Remove(0, fib_valMardy[index]);
                    tmp_lenInput = tmp_lenInput - fib_valMardy[index];
                }

                if (fib_val.Count-1 >= index)
                {
                    if (tmp_lenInput >= fib_val[index] && (result.ToCharArray().Select(dt => (int)dt == (int)'<').ToList().Count != countHello || !result.ToCharArray().Select(dt => (int)dt == (int)'<').Any(x => x == true)))
                    {
                        result = result + tmp_groupLain.Substring(0, fib_val[index]);
                        tmp_groupLain = tmp_groupLain.Remove(0, fib_val[index]);
                        tmp_lenInput = tmp_lenInput - fib_val[index];
                    }

                    if (tmp_lenInput >= fib_val[index])
                    {
                        result = result + tmp_koridor.Substring(0, fib_val[index]);
                        tmp_koridor = tmp_koridor.Remove(0, fib_val[index]);
                        tmp_lenInput = tmp_lenInput - fib_val[index];
                    }

                    //fib_val.RemoveAt(index);
                }
                else
                {
                    result = result + "-";
                    tmp_lenInput--;
                }
                
                index++;
            }
            Console.WriteLine("Jumlah Hello yang diucapkan adalah: " + countHello + "x");
            Console.WriteLine(result);
        }

        public static List<int> Fibonacci_Iterative(int len)
        {
            int a = 0, b = 1, c = 0;
            var tmp_val = new List<int>();
            tmp_val.Add(b);

            for (int i = 2; i < len; i++)
            {
                c = a + b;
                if (c > len)
                    return tmp_val;
                tmp_val.Add(c);
                a = b;
                b = c;
            }

            return tmp_val;
        }

        public static List<int> Fibonacci_Iterative2(int len)
        {
            int a = 2, b = 1, c = 0;
            var tmp_val = new List<int>();
            tmp_val.Add(a); tmp_val.Add(b);

            for (int i = 2; i < len; i++)
            {
                c = a + b;
                if (c > len)
                    return tmp_val;
                tmp_val.Add(c);
                a = b;
                b = c;
            }

            return tmp_val;
        }

        static void Main()
        {
            //Soal Nomor 1
            int[] arr = new int[] { 1, 4, 1, 2, 4, 2, 7, 9, 4, 6 };
            ArrayChallenge(arr);
            Console.WriteLine();
            Console.Write("================== End Number 1 ========================");
            Console.WriteLine();

            //Soal Nomor 2
            string json = "{\"trace\":{\"glass\":\"balloon\",\"rod\":{\"proud\":1093462472.0296364,\"herself\":-682850363,\"library\":{\"think\":true,\"within\":-1868199795.9589992,\"club\":true,\"may\":\"everybody\",\"angle\":\"take\",\"source\":{\"instant\":false,\"fog\":\"time\",\"map\":2112358957,\"felt\":\"cup\",\"range\":\"children\",\"molecular\":-1777693665,\"love\":true,\"using\":\"entire\",\"victory\":796881053,\"open\":true},\"fairly\":\"themselves\",\"education\":\"church\",\"wherever\":true},\"know\":false,\"best\":-155801165,\"waste\":false,\"doll\":\"soft\",\"spite\":\"no\",\"police\":{\"fully\":true,\"met\":-1677333335.3609762,\"original\":-107268423,\"pole\":\"joined\",\"me\":\"pretty\",\"shallow\":{\"creature\":true,\"spite\":{\"steep\":\"law\",\"drink\":\"tank\",\"seems\":-1226111658,\"adjective\":\"favorite\",\"price\":true,\"maybe\":-87526045.07485485,\"situation\":\"price\",\"mood\":\"contain\",\"court\":false,\"battle\":{\"member\":\"line\",\"chance\":\"door\",\"race\":{\"fish\":{\"thou\":\"toy\",\"trail\":965780053.940445,\"too\":true,\"thirty\":-167478531,\"expression\":\"lesson\",\"strength\":\"cabin\",\"grow\":{\"row\":\"structure\",\"game\":\"advice\",\"parallel\":\"fallen\",\"rocket\":{\"as\":\"sense\",\"occur\":false,\"shore\":1997139812,\"sand\":{\"cat\":false,\"root\":{\"compass\":\"place\",\"brought\":{\"connected\":-487585682.574141,\"those\":false,\"through\":false,\"dig\":-1672321846.7755303,\"powder\":{\"pretty\":-747690359,\"coast\":true,\"hat\":{\"expression\":\"indicate\",\"swing\":false,\"take\":\"front\",\"rear\":-1657392704.0950613,\"note\":\"soft\",\"satellites\":1084160187.9064755,\"itself\":\"cloth\",\"simple\":{\"pilot\":{\"sang\":{\"growth\":-841921309,\"substance\":{\"blew\":\"level\",\"officer\":false,\"basket\":-323432920.65978956,\"equipment\":\"bank\",\"shape\":false,\"western\":{\"cookies\":-712430458,\"making\":false,\"peace\":false,\"company\":\"thick\",\"lying\":722378868.5874963,\"settlers\":{\"wire\":1309540263.219521,\"atom\":false,\"indeed\":false,\"month\":true,\"involved\":735113691,\"liquid\":{\"nothing\":{\"certain\":false,\"hurry\":false,\"alive\":{\"shinning\":-135028560,\"enough\":767497807.4020486,\"composition\":false,\"duty\":true,\"arm\":1830090420.899932,\"unit\":true,\"mass\":220173982,\"rate\":\"remember\",\"enjoy\":\"pull\",\"dot\":\"hall\"},\"freedom\":\"right\",\"blood\":1156306121.01084,\"block\":\"shelter\",\"horn\":\"invented\",\"popular\":\"hurried\",\"near\":\"became\",\"round\":-1481289577.628138},\"soap\":-1144159501.6927972,\"cell\":false,\"dance\":false,\"congress\":-73090486.58999777,\"correctly\":true,\"film\":false,\"command\":2068696399,\"danger\":-1217169086,\"air\":986195010.6266227},\"milk\":false,\"plus\":\"worried\",\"definition\":\"poem\",\"religious\":false},\"learn\":-530814874.3744612,\"press\":-1507216625,\"due\":1943575919,\"mighty\":\"adult\"},\"struggle\":1795530420.2835832,\"oil\":true,\"southern\":-1295670246,\"soon\":\"tune\"},\"parallel\":\"dirt\",\"earth\":\"slept\",\"wonder\":1101533613.8198237,\"youth\":false,\"birthday\":true,\"industry\":\"mood\",\"plural\":-1231206307.3022814,\"poet\":true},\"tongue\":\"circle\",\"effect\":-635494424,\"light\":-196751642,\"atom\":\"fighting\",\"progress\":1217327212,\"torn\":\"clothes\",\"twenty\":1091974836.9641137,\"safe\":499323138.80816746,\"clearly\":false},\"behavior\":true,\"them\":\"well\",\"least\":\"policeman\",\"production\":-534623314,\"ahead\":false,\"income\":\"throat\",\"jet\":1466606355,\"closer\":-42300977,\"once\":true},\"stronger\":false,\"inch\":1059409589},\"guide\":true,\"shoe\":\"jet\",\"near\":\"square\",\"six\":true,\"forgot\":true,\"fun\":true,\"event\":true},\"directly\":1189346502.5070586,\"sad\":255764966,\"avoid\":true,\"paint\":true,\"test\":1779724798},\"task\":\"dot\",\"local\":\"giant\",\"describe\":1986066871.6839461,\"lead\":-125538402,\"unknown\":\"nation\",\"plural\":false,\"left\":true,\"shore\":123596726},\"whispered\":false,\"tea\":true,\"local\":\"division\",\"wool\":false,\"actual\":875085292,\"house\":-1862797693.9826937,\"on\":\"sides\",\"any\":false},\"sink\":612140053.5261273,\"report\":\"prize\",\"caught\":-1534378246.0595608,\"plain\":false,\"television\":true,\"company\":\"lack\"},\"exciting\":-59690153.0274601,\"during\":true,\"soft\":false,\"driver\":\"meant\",\"gone\":false,\"partly\":false},\"vapor\":1374515958.481824,\"soon\":\"year\",\"sun\":1801528143},\"about\":\"pale\",\"north\":\"yourself\",\"bank\":true,\"cry\":\"force\",\"tiny\":true,\"scene\":\"stop\",\"throw\":false,\"tongue\":2078183636.0986733,\"knife\":-2116630621.9840279},\"various\":\"made\",\"fix\":\"said\",\"apartment\":true,\"fat\":\"frighten\",\"principle\":-755910273.3889222,\"send\":true,\"equator\":\"noted\"}},\"science\":1807183548.1785083,\"statement\":\"winter\",\"funny\":false,\"steam\":false,\"research\":true,\"coal\":false,\"breakfast\":-489703945,\"grandmother\":\"game\"},\"root\":\"development\",\"chosen\":true,\"mad\":1220614477,\"sign\":401808273},\"greatest\":-217849422},\"matter\":false,\"hospital\":1820139866,\"pound\":true,\"case\":\"running\",\"rapidly\":true,\"policeman\":1022141889,\"respect\":\"ring\",\"firm\":-555546844.711504},\"tea\":-538667626,\"red\":true,\"pictured\":true,\"gulf\":542267719.2716246,\"how\":\"reason\",\"nest\":\"happy\",\"purpose\":146275162.00258493,\"waste\":false,\"leaving\":\"metal\"}";
            CalculateData(json);
            Console.WriteLine();
            Console.Write("================== End Number 2 ========================");
            Console.WriteLine();

            //Soal Nomor 3
            string input = ">----------<";
            Console.WriteLine();
            Console.WriteLine("Masukkan Jumlah Hello: ");
            string count_hello = Console.ReadLine();
            PemetaanData(input, Convert.ToInt16(count_hello));
            Console.WriteLine();
            Console.Write("================== End Number 3 ========================");
            Console.WriteLine();
        }

    }
}