namespace LW02
{
    class Program
    {
        static void Main(string[] args)
        {
            Kernel core = new();
            Console.Write(core.GetListProcesses());
            core.StartProcesses();
            Console.WriteLine("all processes are ended");
            Console.ReadKey();

        }
    }
}