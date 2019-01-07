using CodingChallenge.IServices;
using CodingChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingChallenge.Services
{
    public class FibanocciService: IFibinocciService
    {
        public Fibonacci GenerateFebinocciSeries(int? num)
        {
            Fibonacci FibonacciResponse = new Fibonacci();
            List<int> fibonacciSeries = new List<int>();

            if (num != null && num > 0) 
            {
                for (int i = 0; i < num; i++)
                {
                    fibonacciSeries.Add(GenerateFibonacciNumber(i));
                }
                FibonacciResponse.FibonacciSequence = fibonacciSeries;
                FibonacciResponse.Message = "Success";
            }
            else
            {
                FibonacciResponse.Message = "Please enter a numeric value greater than 0.";
            }

            return FibonacciResponse;
        }

        /// <summary>
        /// method togenerate the next Fibonacci number
        /// </summary>
        /// <param name="n">length of the Fibonacci series</param>
        /// <returns> </returns>
        private int GenerateFibonacciNumber(int n)
        {
            int FirstFibonacci = 0, SecondFibonacci = 1, result = 0;

            if (n == 0) return 0; //To return the first Fibonacci number   
            if (n == 1) return 1; //To return the second Fibonacci number   

            for (int i = 2; i <= n; i++)
            {
                result = FirstFibonacci + SecondFibonacci;
                FirstFibonacci = SecondFibonacci;
                SecondFibonacci = result;
            }
            return result;
        }

       
    }


}
