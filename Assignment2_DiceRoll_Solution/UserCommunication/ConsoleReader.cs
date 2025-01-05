

namespace Assignment2_DiceRoll_Solution.UserCommunication
{
    //It is static, because it is very much like the Console.Reader. So to make it consit
    public static class ConsoleReader
    {
        public static int ReadInteger(string message)
        {
            int result;
            do
            {
                Console.WriteLine(message);
            }
            while (!int.TryParse(Console.ReadLine(), out result));
            return result;
        }
    }
}
