using System;
using System.Drawing;
using System.Windows.Forms;

namespace TorusCheck
{
    public class MainForm : Form
    {
        private TextBox txtX, txtY, txtR, txtR2, txtDistance;
        private Label lblX, lblY, lblR, lblR2, lblDistance, lblResultTitle, lblResult;
        private Button btnExecute, btnClose, btnAbout;
        private PictureBox pictureBox;

        public MainForm()
        {
            this.Text = "Перевірка точки на належність тору";
            this.Size = new Size(600, 400); 

            InitializeComponent();
        }

        private void InitializeComponent()
        {
            var lblTitle = new Label { Text = "Введите координаты точки A(x,y):", Location = new Point(20, 10), Width = 300 };
            lblX = new Label { Text = "X:", Location = new Point(0, 40) };
            lblY = new Label { Text = "Y:", Location = new Point(0, 70) };
            lblR = new Label { Text = "Радіус R:", Location = new Point(0, 100) };
            lblR2 = new Label { Text = "Радіус r:", Location = new Point(0, 130) };
            lblDistance = new Label { Text = "Відстань до точки A:", Location = new Point(20, 160) };
            lblResultTitle = new Label { Text = "Результат:", Location = new Point(0, 190) };

            txtX = new TextBox { Location = new Point(100, 40), Width = 100 };
            txtY = new TextBox { Location = new Point(100, 70), Width = 100 };
            txtR = new TextBox { Location = new Point(100, 100), Width = 100 };
            txtR2 = new TextBox { Location = new Point(100, 130), Width = 100 };
            txtDistance = new TextBox { Location = new Point(150, 160), Width = 100, ReadOnly = true };
            lblResult = new Label { Location = new Point(100, 190), Width = 200, Height = 30 };

            btnExecute = new Button { Text = "Виконати", Location = new Point(20, 220) };
            btnClose = new Button { Text = "Закрити", Location = new Point(120, 220) };
            btnAbout = new Button { Text = "Про програму", Location = new Point(220, 220) };

            pictureBox = new PictureBox
            {
                Location = new Point(300, 40),
                Size = new Size(250, 250),
                Image = Image.FromFile(@"C:\picture\image1.png"), 
                SizeMode = PictureBoxSizeMode.StretchImage
            };

            btnExecute.Click += new EventHandler(btnExecute_Click);
            btnClose.Click += new EventHandler(btnClose_Click);
            btnAbout.Click += new EventHandler(btnAbout_Click);

            this.Controls.Add(lblTitle);
            this.Controls.Add(lblX);
            this.Controls.Add(lblY);
            this.Controls.Add(lblR);
            this.Controls.Add(lblR2);
            this.Controls.Add(lblDistance);
            this.Controls.Add(lblResultTitle);
            this.Controls.Add(txtX);
            this.Controls.Add(txtY);
            this.Controls.Add(txtR);
            this.Controls.Add(txtR2);
            this.Controls.Add(txtDistance);
            this.Controls.Add(lblResult);
            this.Controls.Add(btnExecute);
            this.Controls.Add(btnClose);
            this.Controls.Add(btnAbout);
            this.Controls.Add(pictureBox); 
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            double x, y, r, R;
            bool isXValid = double.TryParse(txtX.Text, out x);
            bool isYValid = double.TryParse(txtY.Text, out y);
            bool isRValid = double.TryParse(txtR.Text, out r);
            bool isRValid2 = double.TryParse(txtR2.Text, out R);

            if (!isXValid || !isYValid || !isRValid || !isRValid2 || r <= 0 || R <= 0 || R <= r)
            {
                txtX.Text = txtY.Text = txtR.Text = txtR2.Text = "1";
                txtX.ForeColor = txtY.ForeColor = txtR.ForeColor = txtR2.ForeColor = Color.Red;
                lblResult.Text = "Некоректне введення!";
                return;
            }

            double distanceSquared = x * x + y * y;
            double distance = Math.Sqrt(distanceSquared);
            txtDistance.Text = distance.ToString("F2");

            if (distanceSquared >= r * r && distanceSquared <= R * R)
            {
                lblResult.Text = "Точка належить тору.";
            }
            else
            {
                lblResult.Text = "Точка не належить тору.";
            }
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Завдання: визначити, чи лежить дана точка всередині тора, утвореного кола з радіусами r і R з центром у точці O(0,0).\nВиконав: Владислав Полівода", "Про програму");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new MainForm());
        }
    }
}
