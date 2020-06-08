using System;
using System.IO;
using practical_task12;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestIntInput()
        {
            Console.SetIn(new StreamReader("intInput.txt"));

            double input = Program.IntInput(lBound: 0, uBound: 100, info: "some info");

            Assert.AreEqual(2, input);
        }

        [TestMethod]
        public void TestRandomFill()
        {
            int n = 11;
            bool[] exists = new bool[n];
            int[] arr = Program.RandomFilling(n);
            for (int i = 0; i < n; i++) exists[arr[i]] = true;
            bool result = true;
            for (int i = 0; i < n; i++) result = result && exists[i];

            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void TestSelectionSort1()
        {
            int n = 114;
            bool result = true;
            int[] arr = Program.RandomFilling(n);
            Program.SelectionSort(arr, out int c, out int p);
            for (int i = 0; i < n - 1; i++) result = result && arr[i] <= arr[i+1];

            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void TestSelectionSort2()
        {
            int n = 114;
            bool result = true;
            int[] arr = new int[n];
            for (int i = 0; i < n; i++) arr[i] = i;
            Program.SelectionSort(arr, out int c, out int p);
            for (int i = 0; i < n - 1; i++) result = result && arr[i] <= arr[i + 1];

            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void TestSelectionSort3()
        {
            int n = 114;
            bool result = true;
            int[] arr = new int[n];
            for (int i = 0; i < n; i++) arr[i] = n - i;
            Program.SelectionSort(arr, out int c, out int p);
            for (int i = 0; i < n - 1; i++) result = result && arr[i] <= arr[i + 1];

            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void TestShellSort1()
        {
            int n = 114;
            bool result = true;
            int[] arr = Program.RandomFilling(n);
            Program.ShellSort(arr, out int c, out int p);
            for (int i = 0; i < n - 1; i++) result = result && arr[i] <= arr[i + 1];

            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void TestShellSort2()
        {
            int n = 114;
            bool result = true;
            int[] arr = new int[n];
            for (int i = 0; i < n; i++) arr[i] = i;
            Program.ShellSort(arr, out int c, out int p);
            for (int i = 0; i < n - 1; i++) result = result && arr[i] <= arr[i + 1];

            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void TestShellSort3()
        {
            int n = 114;
            bool result = true;
            int[] arr = new int[n];
            for (int i = 0; i < n; i++) arr[i] = n - i;
            Program.ShellSort(arr, out int c, out int p);
            for (int i = 0; i < n - 1; i++) result = result && arr[i] <= arr[i + 1];

            Assert.AreEqual(true, result);
        }
    }
}
