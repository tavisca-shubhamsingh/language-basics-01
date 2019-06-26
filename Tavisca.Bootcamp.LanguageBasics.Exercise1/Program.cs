using System;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            Test("42*47=1?74", 9);
            Test("4?*47=1974", 2);
            Test("42*?7=1974", 4);
            Test("42*?47=1974", -1);
            Test("2*12?=247", -1);
            Console.ReadKey(true);
        }

        private static void Test(string args, int expected)
        {
            var result = FindDigit(args).Equals(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"{args} : {result}");
        }

        public static int FindDigit(string equation)
        {
            //considering a standard equation as a*b=ans

            //splitting input string at '*' and '=' sign, to get three numbers in string format
            string[] numbers = equation.Split(new Char [] {'*', '=' } ); 
            
            int operand=Int32.MinValue; //variable to store the index of number containing '?', starting from 1

            for(int i=0;i<numbers.Length;i++)
            {
                if(numbers[i].Contains('?'))
                {
                    operand=i+1;
                }
            }
            //if '?' is in first number
            if(operand==1)
            {
                //convert other two numbers into integers
                int b=Int32.Parse(numbers[1]);
                int ans=Int32.Parse(numbers[2]);

                //checking if b divides ans completely and does not gives out a floating point number
                if(ans%b==0)
                {
                    int a=ans/b;
                    string convertedA=a.ToString();
                    if(convertedA.Length==numbers[0].Length) //checking for number with leading zero
                    {
                        int index=numbers[0].IndexOf('?');
                        return convertedA[index]-'0';  
                    }
                    else{
                        return -1;
                    }
                }
                else
                {
                    return -1;
                }
            }
            else if(operand==2) //if '?' is in b
            {
                int a=Int32.Parse(numbers[0]);
                int ans=Int32.Parse(numbers[2]);
                if(ans%a==0)
                {
                    int b=ans/a;
                    string convertedB=b.ToString();
                    if(convertedB.Length==numbers[1].Length)  //checking for number with leading zero
                    {
                        int index=numbers[1].IndexOf('?');
                        return convertedB[index]-'0';
                    }
                    else{
                        return -1;
                    }
                    
                }
                else
                {
                    return -1;
                }
            }
            else //if '?' is in ans
            {
                int a=Int32.Parse(numbers[0]);
                int b=Int32.Parse(numbers[1]);

                int ans=a*b;

                string convertedAns=ans.ToString();

                int index=numbers[2].IndexOf('?');
                
                return convertedAns[index]-'0';
            }
            
        }
    }
}
