using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coderingen.Pattern
{
    public class BlokCodering : ACodering
    {

        // static readonly om te voorkomen dat elke instantie een kopie heeft van deze tabel
        private static readonly char[,] code = new char[,]
        {{'a', 'z', 'e', 'r', 't', '1'},
        {'2', 'y', 'u', 'i', 'o', 'p'},
        {'q', '3', 's', '4', '8', 'd'},
        {'f', 'g', 'h', 'n', 'j', 'k'},
        {'9', '7', 'l', 'm', '6', 'w'},
        {'5', '0', 'x', 'c', 'v', 'b'}};


        private readonly Dictionary<char, int[]> letterLocatie;

        public BlokCodering(ICodering codering) : base(codering)
        {
            // opvullen dictionary om snel locatie van letter in code te vinden
            letterLocatie = new Dictionary<char, int[]>();
            for (int i = 0; i < code.GetLength(0); i++)
            {
                for (int j = 0; j < code.GetLength(1); j++)
                {
                    char c = code[i, j];
                    letterLocatie.Add(c, new int[] { i, j });
                }
            }
        }

        protected override StringBuilder Codeer(StringBuilder zinBuffer)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < zinBuffer.Length; i += 2)
            {
                if (zinBuffer[i] == zinBuffer[i + 1])
                {
                    result.Append(zinBuffer[i]);
                    result.Append(zinBuffer[i]);
                }
                else {
                    int[] loc1, loc2;
                    loc1 = letterLocatie[zinBuffer[i]];
                    loc2 = letterLocatie[zinBuffer[i + 1]];

                    if (loc1[0] == loc2[0] || loc1[1] == loc2[1])
                    {
                        result.Append(zinBuffer[i + 1]);
                        result.Append(zinBuffer[i]);
                    }
                    else
                    {
                        result.Append(code[loc1[0], loc2[1]]);
                        result.Append(code[loc2[0], loc1[1]]);
                    }
                }
            }
            return result;
        }
    }
}
