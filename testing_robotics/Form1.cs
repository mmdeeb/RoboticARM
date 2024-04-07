using System.Drawing.Drawing2D;
using System.IO.Ports;
using System.Text;

namespace RoboticARM
{
    public partial class Form1 : Form
    {
        int L1 = 15, L2 = 13;
        int StartCordinatesX, StartCordinatesY, kh = 30, numCellsY = 0, numCellsX = 0;
        float StepRotateL1 = 0, OldRotateL1 = 0, StepRotateL2 = 0, OldRotateL2 = 0, AngleTargetL1 = 0, AngleTargetL2 = 0, Step = 0.4f;
        double theta2 = 0, theta1 = 0;
        public Form1()
        {
            InitializeComponent();
            StartCordinatesX = 6 * kh;
            StartCordinatesY = 3 * kh;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            pictureBox1.BackColor = Color.White;
            pictureBox1.BorderStyle = BorderStyle.None;
            pictureBox1.Paint += pictureBox1_Paint;
            pictureBox1.MouseMove += pictureBox1_MouseMove;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            numCellsX = (pictureBox1.Width - StartCordinatesX) / kh;
            numCellsY = (pictureBox1.Height - StartCordinatesY) / kh;
            Pen gridPen = new Pen(Color.LightGray);
            gridPen.DashStyle = DashStyle.Dot;
            Pen axisPen = new Pen(Color.Black, 4);
            for (int x = 6; x <= numCellsX + StartCordinatesX; x++)
            {
                e.Graphics.DrawLine(gridPen, x * kh, 0, x * kh, pictureBox1.Height - (3 * kh));
            }
            for (int y = 0; y <= numCellsY; y++)
            {
                e.Graphics.DrawLine(gridPen, 6 * kh, y * kh, pictureBox1.Width, y * kh);
            }
            e.Graphics.DrawLine(axisPen, StartCordinatesX, pictureBox1.Height - StartCordinatesY, pictureBox1.Width, pictureBox1.Height - StartCordinatesY);
            e.Graphics.DrawLine(axisPen, StartCordinatesX, pictureBox1.Height - StartCordinatesY, 6 * kh, 0);
            Pen pen = new Pen(ColorTranslator.FromHtml("#548235"), 5);
            pen.DashStyle = DashStyle.Dot;
            DrawCircleEllipse(e.Graphics, pen, StartCordinatesX, numCellsY * kh, (L1 + L2) * kh);
            DrawCircleFill(e.Graphics, ColorTranslator.FromHtml("#0B83A9"), StartCordinatesX, numCellsY * kh, 20);
            Pen pen2 = new Pen(ColorTranslator.FromHtml("#548235"), 5);
            pen2.DashStyle = DashStyle.Dot;
            DrawCircleEllipse(e.Graphics, pen, StartCordinatesX, numCellsY * kh, 3 * kh);
            DrawCircleFill(e.Graphics, ColorTranslator.FromHtml("#0B83A9"), StartCordinatesX, numCellsY * kh, 20);
            drawRobotArm(e);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (ValidInput)
            {
                var rL1 = Math.Round(AngleTargetL1);
                var rOldL1 = Math.Round(OldRotateL1);
                var rL2 = Math.Round(AngleTargetL2);
                var rOldL2 = Math.Round(OldRotateL2);
                if (rL1 == rOldL1)
                    StepRotateL1 = 0;
                if (rL2 == rOldL2)
                    StepRotateL2 = 0;
                pictureBox1.Invalidate();
            }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            double x = Convert.ToDouble(labelX.Text);
            double y = Convert.ToDouble(labelY.Text);
            error.Text = "";
            if (x == 0) x = 0.1;
            if (x <= 0 || y < 0 || (x < 3 && y < 3 && y != x) || (Math.Pow(x, 2) + Math.Pow(y, 2)) > Math.Pow(L1 + L2, 2) || (Math.Pow(x, 2) + Math.Pow(y, 2)) < Math.Pow(L1 - L2, 2))
            {
                error.Text = "The selected point \n is outside the arm space";
                return;
            }

            theta2 = Math.Acos((Math.Pow(x, 2) + Math.Pow(y, 2) - Math.Pow(L1, 2) - Math.Pow(L2, 2)) / (2 * L1 * L2));
            theta1 = (Math.Atan2(y, x)) - (Math.Asin((L2 * Math.Sin(theta2)) / (Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2)))));

            theta1 = theta1 * (180.0 / Math.PI);
            theta2 = theta2 * (180.0 / Math.PI);

            labelTheta1.Text = theta1.ToString("F3");
            labelTheta2.Text = theta2.ToString("F3");

            theta1 = theta1 - OldRotateL1;
            theta2 = theta2 - OldRotateL2;

            ValidInput = true;

            AngleTargetL1 = OldRotateL1 + (float)theta1;
            AngleTargetL2 = OldRotateL2 + (float)theta2;

            if (theta1 > 0)
                StepRotateL1 = Step;
            else
                StepRotateL1 = -Step;

            if (theta2 > 0)
                StepRotateL2 = Step;
            else
                StepRotateL2 = -Step;

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            float x = (e.X / kh) - 6;
            float y = ((pictureBox1.Height - e.Y) / kh) - 3;
            labelX.Text = x.ToString();
            labelY.Text = y.ToString();
        }
        private void DrawCircleEllipse(Graphics g, Pen pen, int x, int y, int radius)
        {
            g.DrawEllipse(pen, x - radius, y - radius, radius * 2, radius * 2);
        }

        private void DrawLine(Graphics g, Pen pen, Point p1, Point p2)
        {
            g.DrawLine(pen, p1, p2);
        }

        private void DrawCircleFill(Graphics g, Color color, int x, int y, int radius)
        {
            SolidBrush brush = new SolidBrush(color);
            g.FillEllipse(brush, x - radius, y - radius, radius * 2, radius * 2);
            brush.Dispose();
        }

        Point startPointL1;
        Point endPointL1;
        Point startPointL2;
        Point endPointL2;
        bool ValidInput = false;
        private void drawRobotArm(PaintEventArgs e)
        {

            startPointL1 = new Point(StartCordinatesX, pictureBox1.Height - StartCordinatesY);
            endPointL1 = new Point((L1 * kh) + StartCordinatesX, pictureBox1.Height - StartCordinatesY);

            startPointL2 = endPointL1;
            endPointL2 = new Point(startPointL2.X + (L2 * kh), pictureBox1.Height - StartCordinatesY);

            e.Graphics.TranslateTransform(StartCordinatesX, numCellsY * kh);
            e.Graphics.RotateTransform(-OldRotateL1);
            e.Graphics.RotateTransform(-StepRotateL1);
            e.Graphics.TranslateTransform(-StartCordinatesX, -numCellsY * kh);
            Pen pen = new Pen(ColorTranslator.FromHtml("#0B83A9"), 15);
            DrawLine(e.Graphics, pen, startPointL1, endPointL1);
            DrawCircleFill(e.Graphics, ColorTranslator.FromHtml("#8ABFFA"), endPointL1.X, endPointL1.Y, 15);
            OldRotateL1 += StepRotateL1;
            e.Graphics.TranslateTransform(startPointL2.X, numCellsY * kh);
            e.Graphics.RotateTransform(-OldRotateL2);
            e.Graphics.RotateTransform(-StepRotateL2);
            e.Graphics.TranslateTransform(-startPointL2.X, -numCellsY * kh);
            pen = new Pen(ColorTranslator.FromHtml("#8ABFFA"), 10);
            DrawLine(e.Graphics, pen, startPointL2, endPointL2);
            OldRotateL2 += StepRotateL2;
            pen = new Pen(ColorTranslator.FromHtml("#990000"), 10);
            DrawCircleFill(e.Graphics, ColorTranslator.FromHtml("#990000"), endPointL2.X, endPointL2.Y, 10);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string portName = "COM1";

            using (SerialPort port = new SerialPort(portName, 9600))
            {

                port.Parity = Parity.None;

                port.DataBits = 8;

                port.BaudRate = 9600;

                port.StopBits = StopBits.One;

                try
                {

                    port.Open();

                    int angle1 = (int)Math.Round(theta1);
                    int angle2 = (int)Math.Round(theta2);

                    byte[] anglesBytes = new byte[4];

                    anglesBytes[0] = (byte)(angle1 >> 8);
                    anglesBytes[1] = (byte)angle1;

                    anglesBytes[2] = (byte)(angle2 >> 8);
                    anglesBytes[3] = (byte)angle2;

                    port.Write(anglesBytes, 0, 4);
                }
                catch (Exception ex)
                {

                    Console.WriteLine("حدث خطأ أثناء الاتصال بمنفذ السلسلة: " + ex.Message);
                }
                finally
                {

                    port.Close();
                }
            }
        }
    }
}
