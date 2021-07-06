using System;
using System.Linq;

namespace Collatz_Sequence
{
    class Program
    {

        public class SequenceFinderForCollatz
        {
            public int FindBestCollatzSequence(int start, int count)
            {
                return Enumerable.Range(start, count)
                    .Select(n => new { Number = n, SequenceLength = CalcCollatzSequence((long)n) })
                    .Aggregate((i, j) => i.SequenceLength > j.SequenceLength ? i : j)
                    .Number;
            }

            private int CalcCollatzSequence(long n)
            {
                int sequenceLength = 0;

                do
                {
                    n = CalcNextTerm(n);
                    sequenceLength++;
                }
                while (n != 1);

                return sequenceLength;
            }

            private long CalcNextTerm(long previousTerm)
            {
                return previousTerm % 2 == 0 ? previousTerm / 2 : previousTerm * 3 + 1;
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Calculando o maior número sequencial de 1000001...");

            var finder = new SequenceFinderForCollatz();
            int result = finder.FindBestCollatzSequence(1, 1000001);

            Console.Clear();

            Console.WriteLine("O maior número Inicial encontrado para a sequencia de Collatz é: {0}", result);
            Console.WriteLine("Pressione Enter para sair...");
            Console.Read();
        }
    }
}
