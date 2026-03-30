using System;

namespace OZ_Coding_CS
{
    internal class Program
    {
        float InputNumber()
        {
            Console.Write("숫자를 입력해주세요 : ");
            return float.Parse(Console.ReadLine());
        }

        char InputOperator()
        {
            Console.Write("연산을 입력해주세요( +, -, *, /, % ) : ");
            return char.Parse(Console.ReadLine());
        }

        float Calculate(float inputA, float inputB, char operatorChar)
        {
            switch (operatorChar)
            {
                case '+':
                    return inputA + inputB;
                case '-':
                    return inputA - inputB;
                case '*':
                    return inputA * inputB;
                case '/':
                    return inputA / inputB;
                case '%':
                    return inputA % inputB;
            }
            return 0;
        }

        static void Main(string[] args)
        {
            Program program = new Program();

            // 입력 값
            float inputA, inputB;
            char operatorChar;

            // 수 입력
            inputA = program.InputNumber();
            inputB = program.InputNumber();

            // 연산 종류 입력
            operatorChar = program.InputOperator();

            Console.WriteLine($"연산 결과 : {program.Calculate(inputA, inputB, operatorChar)}");
        }
    }
}
