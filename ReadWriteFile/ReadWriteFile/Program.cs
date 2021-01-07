using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadWriteFile
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Tuple<int, string>> tup = new List<Tuple<int, string>>();
            List<string> finalStr = new List<string>();
            try
            {
                string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "InputFile.txt");
                using (StreamReader sr = new StreamReader(path))
                {
                    string line;

                    // Read lines from the file until 
                    // the end of the file is reached. 
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] strArray;
                        strArray = line.Split('.');

                        for (int i = 0; i < strArray.Length; i++)
                        {
                            tup.Add(new Tuple<int, string>(countvowel(strArray[i]), strArray[i]));
                        }
                        //sorting tuple in the descending order of number of vowels
                        tup.Sort((a, b) => b.Item1.CompareTo(a.Item1));
                        //tup.Sort();

                        int countvowel(string s)
                        {
                            int count = 0;
                            for (int k = 0; k < s.Length; k++)
                                if (isVowel(s[k])) // Check for vowel
                                    ++count;
                            return count;
                        }

                        bool isVowel(char ch)
                        {
                            ch = char.ToUpper(ch);
                            return (ch == 'A' || ch == 'E'
                                || ch == 'I' || ch == 'O'
                                || ch == 'U');
                        }
                    }

                }

            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            try
            {
                string path1 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "OutputFile.txt");
                using (StreamWriter sw = new StreamWriter(path1))
                {
                    for (int l = 0; l < tup.Count; l++)
                    {
                        sw.WriteLine(tup[l].Item2);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in writting to the file");
                Console.WriteLine(e.Message);
            }

        }
    }
}
