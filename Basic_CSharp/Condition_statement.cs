namespace Basic_CSharp
{
    class Condition
    {
        //Pattern matching with 'when' keyword and switch-case statements
        public void Switchcase()
        {
            List<int> numberList = new List<int>() { 1, 2, 3, 4, 5 };
            // Traditional switch-case
            foreach (var number in numberList)
            {
                switch (number)
                {
                    case 1:
                    case 2:
                    case 3:
                        Console.WriteLine("yes");
                        break;
                    case 4:
                    case 5:
                        Console.WriteLine("no");
                        break;
                    default:
                        Console.WriteLine("unknown");
                        break;
                }
            }

            // C# 7.0 pattern matching with 'when' clause
            foreach (var number in numberList)
            {
                switch (number)
                {
                    case var x when x >= 1 && x <= 3:// C# 7.0 pattern matching with 'when' clause
                        Console.WriteLine("yes");
                        break;
                    case var x when x >= 4 && x <= 5:
                        Console.WriteLine("no");
                        break;
                    default:
                        Console.WriteLine("unknown");
                        break;
                }
            }
        }

    }
}
