using System.Drawing;

namespace GameOfLife
{
    public partial class Form1 : Form
    { 
        private CellManager cm;
        private PictureBox pb;
        private System.Windows.Forms.Timer timer;
        private Random rand;

        private Color cellColor, gridColor;

        private bool gridInitialized, colorChange, randomize, running;

        public Form1()
        {
            cm = new CellManager();
            
            rand = new Random();

            InitializeComponent();
            InitializePictureBox();

            cbCellColor.SelectedIndexChanged += new EventHandler(cbCellColor_SelectedIndexChanged);
            cbGridColor.SelectedIndexChanged += new EventHandler(cbGridColor_SelectedIndexChanged);

            InitializeColorLists();

            rbMoore.Checked = true;

            rbMoore.Click += new EventHandler(rbMoore_Click);
            rbVonNeumann.Click += new EventHandler(rbVonNeumann_Click);

            timer = new System.Windows.Forms.Timer();
            timer.Tick += new EventHandler(timer_Tick);
            UpdateTimerInterval();

            authorLabel.Text = Constants.AUTHOR_TEXT;

            InitializeGame();
        }

        private void InitializePictureBox()
        {
            pb = new PictureBox();
            pb.Dock = DockStyle.None;
            pb.Size = new Size((Constants.CELL_ROWS * Constants.CELL_SIZE) + 1, (Constants.CELL_COLUMNS * Constants.CELL_SIZE) + 1);
            pb.Location = new Point(0, 0);
            pb.BackColor = Color.White;
            pb.Paint += new PaintEventHandler(pb_Paint);
            this.Controls.Add(pb);
        }

        private void InitializeGame()
        {
            cm.ClearCells();
            gridInitialized = colorChange = randomize = running = false;

            btnStart.Enabled = true;
            btnPause.Enabled = false;
            btnPause.Text = "Pause";

            rbMoore.Enabled = rbVonNeumann.Enabled = true;

            pb.Invalidate();
        }
        
        private void InitializeColorLists()
        {
            cbCellColor.Items.Add(Color.Red);
            cbCellColor.Items.Add(Color.Orange);
            cbCellColor.Items.Add(Color.Yellow);
            cbCellColor.Items.Add(Color.Green);
            cbCellColor.Items.Add(Color.Blue);
            cbCellColor.Items.Add(Color.Indigo);
            cbCellColor.Items.Add(Color.Violet);
            cbCellColor.Items.Add(Color.Black);

            cbGridColor.Items.Add(Color.Red);
            cbGridColor.Items.Add(Color.Orange);
            cbGridColor.Items.Add(Color.Yellow);
            cbGridColor.Items.Add(Color.Green);
            cbGridColor.Items.Add(Color.Blue);
            cbGridColor.Items.Add(Color.Indigo);
            cbGridColor.Items.Add(Color.Violet);
            cbGridColor.Items.Add(Color.Black);

            cbCellColor.SelectedIndex = cbGridColor.SelectedIndex = 7;
        }

        private void InitializeGrid(Graphics g)
        {
            Pen pen = new Pen(gridColor, 1);

            for (int i = 0; i < Constants.CELL_ROWS; i++)
            {
                for (int j = 0; j < Constants.CELL_COLUMNS; j++)
                {
                    g.DrawRectangle(pen, new Rectangle(new Point(j * Constants.CELL_SIZE, i * Constants.CELL_SIZE), new Size(Constants.CELL_SIZE, Constants.CELL_SIZE)));
                }
            }

            pen.Dispose();
        }

        private void DrawGrid(Graphics g)
        {
            Pen pen = new Pen(gridColor, 1);
            SolidBrush aliveBrush = new SolidBrush(cellColor);

            for (int i = 0; i < Constants.CELL_ROWS; i++)
            {
                for (int j = 0; j < Constants.CELL_COLUMNS; j++)
                {
                    Rectangle rect = new Rectangle(new Point(j * Constants.CELL_SIZE, i * Constants.CELL_SIZE), new Size(Constants.CELL_SIZE, Constants.CELL_SIZE));

                    if (cm.cells[i, j] == 0)
                    {
                        g.DrawRectangle(pen, rect);
                    }
                    else
                    {
                        g.FillRectangle(aliveBrush, rect);
                        g.DrawRectangle(pen, rect);
                    }
                }
            }

            pen.Dispose();
        }

        private void UpdateTimerInterval()
        {
            timer.Interval = ((tbGameSpeed.Maximum - tbGameSpeed.Value) + 1) * 50;
        }

        private void cbCellColor_SelectedIndexChanged(Object sender, EventArgs e)
        {
            cellColor = (Color) cbCellColor.SelectedItem;
            if (!running)
            {
                colorChange = true;
                pb.Invalidate();
            }
            
        }

        private void cbGridColor_SelectedIndexChanged(Object sender, EventArgs e)
        {
            gridColor = (Color)cbGridColor.SelectedItem;
            if (!running)
            {
                colorChange = true;
                pb.Invalidate();
            }
        }

        private void rbMoore_Click(Object sender, EventArgs e)
        {
            rbVonNeumann.Checked = false;
        }

        private void rbVonNeumann_Click(Object sender, EventArgs e)
        {
            rbMoore.Checked = false;
        }

        private void timer_Tick(Object sender, EventArgs e)
        {
            UpdateTimerInterval();
            pb.Invalidate();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            running = true;

            btnStart.Enabled = false;
            btnPause.Enabled = true;

            rbMoore.Enabled = rbVonNeumann.Enabled = false;

            timer.Start();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (running)
            {
                timer.Stop();
                btnPause.Text = "Resume";
            }
            else
            {
                timer.Start();
                btnPause.Text = "Pause";
            }

            running = !running;
            
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            timer.Stop();
            InitializeGame();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void btnRandomize_Click(object sender, EventArgs e)
        {
            randomize = true;
            pb.Invalidate();
        }

        private void pb_Paint(Object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            if (!gridInitialized)
            {
                InitializeGrid(g);
                gridInitialized = true;
            }

            if (colorChange)
            {
                DrawGrid(g);
                colorChange = false;
            }

            if (randomize)
            {
                cm.GenerateRandomCells();
                DrawGrid(g);
                randomize = false;
            }

            if (running)
            {
                cm.ProcessNeighbors(rbMoore.Checked);
                DrawGrid(g);
            }
        }
    }
}