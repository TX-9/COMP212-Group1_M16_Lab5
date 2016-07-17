using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP212_Group1_M16_Lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            string dirpath = Directory.GetCurrentDirectory();

            var OriginalLinkedList = new LinkedList<char>();
            var KeyLinkedList = new LinkedList<char>();
            var CodedLinkedList = new LinkedList<char>();
            var CodedLinkedList2 = new LinkedList<char>();
            var DecodedLinkedList = new LinkedList<char>();
            var coded = new StringBuilder();
            var decoded = new StringBuilder();
            string input;

            using (StreamReader r = new StreamReader(@"data.txt"))
            {
                int @char;
                while (((@char = r.Read()) != -1) && (@char != 13))
                    OriginalLinkedList.AddLast((char)@char);

                r.Read(); // Reads \0x10 character since Enter == \0x13 \0x10

                while (((@char = r.Read()) != -1) && (@char != 13))
                    KeyLinkedList.AddLast((char)@char);

                Console.Write("Word to encode  :");
                input = Console.ReadLine();


                foreach (char inputVal in input)
                {
                    int nodeIdx = -1;
                    //get the first node to interate
                    for (LinkedListNode<char> node = OriginalLinkedList.First; node != null; )
                    {
                        ++nodeIdx;
                        char nodeVal = (char)node.Value;

                        if (inputVal == nodeVal)
                        {
                            CodedLinkedList.AddLast(KeyLinkedList.ElementAt(nodeIdx));
                            break;
                        }

                        //move to next node
                        LinkedListNode<char> next = node.Next;
                        node = next;
                    }
                }

                foreach (char inputVal in CodedLinkedList)
                {
                    int idx = -1;

                    //get the first node to interate
                    for (LinkedListNode<char> node = KeyLinkedList.First; node != null; )
                    {
                        char nodeVal = (char)node.Value;
                        ++idx;
                        if (inputVal == nodeVal)
                        {
                            DecodedLinkedList.AddLast(OriginalLinkedList.ElementAt(idx));
                            break;
                        }

                        //move to next node
                        LinkedListNode<char> next = node.Next;
                        node = next;
                    }
                }

                foreach (char c in CodedLinkedList)
                    coded.Append(c);

                foreach (char c in DecodedLinkedList)
                    decoded.Append(c);
            }

            Console.Write("Encoded word    :");
            Console.WriteLine(coded);
            Console.Write("Decoded word    :");
            Console.WriteLine(decoded);
        }
    }
}
