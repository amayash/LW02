namespace LW02
{
    public partial class Visualization : System.Windows.Forms.Form
    {
        public Visualization()
        {
            InitializeComponent();
        }
        Kernel kernel;
        private void Draw()
        {
            Bitmap bmp = new(pictureBox.Width, pictureBox.Height);
            Graphics gr = Graphics.FromImage(bmp);
            kernel.DrawProcesses(gr, pictureBox.Height, pictureBox.Width);
            label.Text = kernel.GetListProcesses();
            pictureBox.Image = bmp;
        }

        private void button_Click(object sender, EventArgs e)
        {
            kernel = new Kernel();
            Draw();
        }
    }
}
