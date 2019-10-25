using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Recursion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String text = textBox1.Text;
            textBox1.Text = "";
            listBox1.Items.Clear();
            int elements = Int32.Parse(text);
            if (elements > 2)
            {
                listBox1.Items.Add(0);
                listBox1.Items.Add(1);
                elements -= 2;
                fibonacci(elements, 0, 1);
            }
        }

        private int fibonacci(int iterations, int start, int next)
        {
            int nextVal = start + next;
            listBox1.Items.Add(nextVal);
            if (iterations > 1)
            {              
                return fibonacci(--iterations, next, nextVal);
            }
            else
            {
                return nextVal;
            }          
        }

        private int[] mergeArrays(int[] sortedOne, int[] sortedTwo)
        {
            int indexOne = 0;
            int indexTwo = 0;
            int[] mergedArray = new int[sortedOne.Length + sortedTwo.Length];
            int mergedIndex = 0;

            while(indexOne < sortedOne.Length && indexTwo < sortedTwo.Length)
            {
                //compare values
                //add value to merged array
                //shift indexes due to comparison
                if (sortedOne[indexOne] <= sortedTwo[indexTwo])
                {
                    mergedArray[mergedIndex++] = sortedOne[indexOne];
                    indexOne++;
                }
                else
                {
                    mergedArray[mergedIndex++] = sortedTwo[indexTwo];
                    indexTwo++;
                }     
            }
            //Check which array has leftovers
            if(indexOne < sortedOne.Length)
            {
                for(int i = indexOne; i < sortedOne.Length; i++)
                {
                    mergedArray[mergedIndex++] = sortedOne[i];
                }
            }else
            {
                for(int j = indexTwo; j < sortedTwo.Length; j++)
                {
                    mergedArray[mergedIndex++] = sortedTwo[j];
                }
            }
            return mergedArray;
        }
        
        public int[] mergeSort(int[] arr)
        {
            int len = arr.Length;
            //get length. if > 2, sort left, sort right, merge.
            if(len >= 2)
            {
                //sort left
                int[] left = new int[len / 2];
                Array.Copy(arr, 0, left, 0, len / 2);
                left = mergeSort(left);

                //sort right
                int[] right = new int[len - left.Length];
                Array.Copy(arr, left.Length, right, 0, len - left.Length);
                right = mergeSort(right);

                return mergeArrays(left, right);
            }
            return arr;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            Random ran = new Random();
            int len = ran.Next(10, 20);
            for(int i = 0; i < len; i++)
            {
                listBox2.Items.Add(ran.Next(100));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int[] vals = listBox2.Items.Cast<int>().ToArray();
            listBox2.Items.Clear();
            listBox2.Items.AddRange(mergeSort(vals).Cast<object>().ToArray());
        }
    }
}
