using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UAS_012
{
    class Node
    {
        public int Nomor;
        public string Judul;
        public string Nama;
        public int Tahun;
        public Node Next;

        class List
        {
            Node START;

            public List()
            {
                START = null;
            }
            public void insert()
            {
                int No, Th;
                string Jdl, Nm;
                Console.Write("Masukkan nomor buku : ");
                No = Convert.ToInt32(Console.ReadLine());
                Console.Write("Masukkan judul buku : ");
                Jdl = Console.ReadLine();
                Console.Write("Masukkan nama pengarang : ");
                Nm = Console.ReadLine();
                Console.Write("Masukkan tahun terbit buku : ");
                Th = Convert.ToInt32(Console.ReadLine());

                Node newnode = new Node();

                newnode.Nomor = No;
                newnode.Judul = Jdl;
                newnode.Nama = Nm;
                newnode.Tahun = Th;

                if (START == null || No >= START.Nomor)
                {
                    if ((START != null) && (No == START.Nomor))
                    {
                        Console.WriteLine("Duplikat nomor buku tidak diizinkan");
                        return;
                    }
                    newnode.Next = START;
                    START = newnode;
                    return;
                }

                Node previous, current;
                previous = START;
                current = START;

                while ((current != null) && (No >= current.Nomor))
                {
                    if (No == current.Nomor)
                    {
                        Console.WriteLine("Duplikat nomor buku tidak diizinkan");
                        return;
                    }
                    previous = current;
                    current = current.Next;
                }
                newnode.Next = current;
                previous.Next = newnode;
            }
            public bool Search(int Th, ref Node previous, ref Node current)
            {
                previous = START;
                current = START;

                while ((current != null) && (Th != current.Tahun))
                {
                    previous = current;
                    current = current.Next;
                }
                if (current == null)
                    return(false);
                else
                    return(true);
            }
            public bool ListEmpty()
            {
                if (START == null)
                    return true;
                else
                    return false;
            }

            public void traverse()
            {
                if (ListEmpty())
                    Console.WriteLine("\nList is Empty");
                else
                {
                    Console.WriteLine("\nList data buku : ");
                    Console.Write("Nomor" + "   " + "Judul" + "   " + "Pengarang" + "   " + "Tahun terbit" + "\n");
                    Node currentNode;
                    for (currentNode = START; currentNode != null; currentNode = currentNode.Next)
                    {
                        Console.Write(currentNode.Nomor + "      " + currentNode.Judul + "      " + currentNode.Nama + "      " + currentNode.Tahun + "\n");
                    }
                    Console.WriteLine();
                }
            }
        }
        static void Main(string[] args)
        {
            List obj = new List();
            while (true)
            {
                try
                {
                    Console.WriteLine("\nMenu");
                    Console.WriteLine("1. Add a record to be the list");
                    Console.WriteLine("2. View all the records in the list");
                    Console.WriteLine("3. Search for a record in the list");
                    Console.WriteLine("4. Exit");
                    Console.Write("Enter your choise (1-4) : ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.insert();
                            }
                            break;
                        case '2':
                            {
                                obj.traverse();
                            }
                            break;
                        case '3':
                            {
                                if (obj.ListEmpty() == true)
                                {
                                    Console.WriteLine("\nList is Empty\n");
                                    break;
                                }
                                Node previous, current;
                                previous = current = null;
                                Console.Write("\nMasukkan tahun terbit buku yang ingin dicari : ");
                                int num = Convert.ToInt32(Console.ReadLine());
                                if (obj.Search(num, ref previous, ref current) == false)
                                    Console.WriteLine("\nRecord not found");
                                else
                                {
                                    Console.WriteLine("Record found");
                                    Console.WriteLine("\nNomor buku" +  current.Nomor);
                                    Console.WriteLine("\nJudul buku" +  current.Judul);
                                    Console.WriteLine("\n Nama pengarang" +  current.Nama);
                                    Console.WriteLine("\nTahun terbit buku" +  current.Tahun);
                                }
                            }
                            break;
                        case '4':
                            return;
                        default:
                            {
                                Console.WriteLine("\nInvalid option");
                                break;
                            }
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("\nCheck for the values entered.");
                }
            }
        }
    }
}
//2. DoublelingkedList karena kasus diatas membuhtukan dua arah masuknya data.
//3. Push dan Pop.
//4. Rear dan Front.
//5. a.5.
//   b.Inorder yaitu pertama-tama dengan cara menampilkan data pada subtree di posisi kiri
//     kemudian menampilkan akarnya dan yang terkahir dengan cara menampilkan data yang ada pada posisi
//     kanan subtree. Dibaca dari 1,5,8,10,12,15,20,22,25,36,38,40,45,48,50.
