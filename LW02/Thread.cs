using System.Text;

namespace LW02
{
    internal class Thread
    {
        private int? time;
        private Random random = new Random();
        public bool End = false;
        public Thread()
        {
            time = random.Next(0, 120);
        }
        public int Time { get { return (int)time; } set { time = value; } }
        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            if (time!=null)
            {
                s.Append(time);
            }
            return s.ToString();
        }
    }
}
