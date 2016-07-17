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
            var InputLinkedList = new LinkedList<char>();
            var OriginalLinkedList = new LinkedList<char>();
            var KeyLinkedList = new LinkedList<char>();
            var CodedLinkedList = new LinkedList<char>();
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
            }
                Console.Write("Word to encode  :");
                input = Console.ReadLine();            
                foreach (char inputVal in input)
                    InputLinkedList.AddLast(inputVal);

                Ciphering(InputLinkedList, CodedLinkedList, OriginalLinkedList, KeyLinkedList);
                Ciphering(CodedLinkedList, DecodedLinkedList, KeyLinkedList, OriginalLinkedList);

                foreach (char c in CodedLinkedList)
                    coded.Append(c);

                foreach (char c in DecodedLinkedList)
                    decoded.Append(c);
            
            
            Console.Write("Encoded word    :");
            Console.WriteLine(coded);
            Console.Write("Decoded word    :");
            Console.WriteLine(decoded);

        }
        private static void Ciphering(LinkedList<char> InList, LinkedList<char> OutList, LinkedList<char> OriginalList, LinkedList<char> KeyList)
        {
            foreach (char inputVal in InList)
            {
                int idx = -1;
                bool isNotFound = true;

                for (LinkedListNode<char> node = OriginalList.First; node != null;)
                {
                    char nodeVal = (char)node.Value;
                    ++idx;
                    if (inputVal == nodeVal)
                    {
                        OutList.AddLast(KeyList.ElementAt(idx));
                        isNotFound = false;
                        break;
                    }

                    //move to next node
                    LinkedListNode<char> next = node.Next;
                    node = next;
                }
                if (isNotFound)
                    OutList.AddLast(inputVal);
            }
        }
    }
}
