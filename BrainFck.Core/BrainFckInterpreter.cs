using System;
using static System.Console;

namespace BrainFck.Core
{
    public class BrainFckInterpreter
    {
        public byte[] memory;
        public int pointer;
        public char[] input;

        public BrainFckInterpreter(string program) {
            input = program.ToCharArray();
            memory = new byte[1000];
        }

        public void Run() {
            int brackets = 0;

            for (int i = 0; i < input.Length; i++) {
                switch(input[i]) {
                    case '>': pointer++; break;
                    case '<': pointer--; break;
                    case '+': memory[pointer]++; break;
                    case '-': memory[pointer]--; break;
                    case '.': Write((char)(memory[pointer])); break;
                    case ',': memory[pointer] = (byte)ReadKey().KeyChar; break;
                    case '[':
                              if (memory[pointer] == 0) {
                                  brackets++;
                                  while (input[i] != ']' || brackets != 0) {
                                      i++;
                                      if (input[i] == '[')
                                          brackets++;
                                      else if (input[i] == ']')
                                          brackets--;
                                  }
                              }
                              break;
                    case ']':
                              if (memory[pointer] != 0) {
                                  brackets++;
                                  while (input[i] != '[' || brackets != 0) {
                                      i--;
                                      if (input[i] == ']')
                                          brackets++;
                                      else if (input[i] == '[')
                                          brackets--;
                                  }
                              }
                              break;
                }
            }
        }

    }
}
