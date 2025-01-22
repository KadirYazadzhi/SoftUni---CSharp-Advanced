using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EvenLines {
    public class EvenLines {
        static void Main() {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath) {
            int counter = 0;
            string[] words = new string[]{};
            List<string> result = new List<string>();
            
            using (StreamReader reader = new StreamReader(inputFilePath)) {
                while (!reader.EndOfStream) {
                    string line = reader.ReadLine();

                    if (counter % 2 == 0) {
                        words = SpecialSymbols(line).Split();
                        Array.Reverse(words);
                        
                        result.Add(string.Join(" ", words));
                    }

                    counter++;
                }
            }

            return string.Join("\n", result);
        }

        public static string SpecialSymbols(string line) {
            char[] specialSymbols = new[] { '.', ',', '!', '?', '-' };
            
            foreach (char specialSymbol in specialSymbols) {
                line = line.Replace(specialSymbol.ToString(), "@");
            }
      
            return line;
        }
    }
}
