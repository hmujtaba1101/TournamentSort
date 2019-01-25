using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentSort
{
    class Program
    {
        static void Main(string[] args)
        {

            //we will sort this array

            Console.WriteLine("Enter the size of array");
            int n = Convert.ToInt16(Console.ReadLine());
            tournametn ob = new tournametn();

            Console.WriteLine("Before sorting ");
            int[] arr = ob.rand(n);

            Console.WriteLine("Sorted array is");
            ob.sorted(arr);
            ob.printArray(arr);

            Console.ReadLine();
        }
    }
    class tournametn
    {

        //tournament works so much like heapsort 
        //in this we will also make a heap 
        //it will make a min heap

        public int[] rand(int n)
        {
            Random r = new Random();

            int[] arr = new int[n];
            for (int k = 0; k < n; k++)
            {
                arr[k] = r.Next(1, n);
                Console.Write(arr[k] + "  ");
            }
            Console.WriteLine();
            return arr;
        }

        public void sorted(int[] array)
        {

            int num = array.Length;


            //it  will divide total number of elements from 2
            //it will strt checking from 
            for (int i = num / 2; i >= 0; i--)
            {
                swapping(array, num, i);
            }
            //it will remove element from one by one
            //means one by one palyers getting out from the tournament
            for (int i = num - 1; i >= 0; i--)
            {
                if (array[0] > array[i])
                {
                    // swapping current root to end
                    int swap = array[0];
                    array[0] = array[i];
                    array[i] = swap;
                    swapping(arr, i, 0);
                }

            }
            //call min heapify on the reduced heap




        }
        void swapping(int[] arr, int n, int k)
        {
            int minimum = k;//we are initializing that the the minimum is the root ;
            int left = 2 * k;//the left child is 2*k index;
            int right = 2 * k + 1;//the right child is 2*k+1 index;
            try
            {

                //it works 
                if (left < n && arr[left] > arr[minimum])
                    minimum = left;//if the left child is lesser than the root it will become a root;


                if (right < n && arr[right] > arr[minimum])
                    minimum = right;//if the right child is lesser than the root than it willl become an root;


                //if the  root is not minimum

                if (minimum != k)
                {
                    int temp = arr[k];//if the root is not minimum then we will swap the root with its minimum child.
                    arr[k] = arr[minimum];
                    arr[minimum] = temp;
                    swapping(arr, n, minimum);

                }
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine("array index out of bpunds" + e.Message);
            }


        }



        public void printArray(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n; i++)
                Console.Write(arr[i] + " ");
            Console.Read();
        }
    }

}
