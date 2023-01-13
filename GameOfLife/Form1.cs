using System.Drawing;

namespace GameOfLife
{
    public partial class Form1 : Form
    { 
        const int cellRows = 128;
        const int cellColumns = 128;
        const int cellSize = 4;

        private PictureBox pb;
        private System.Windows.Forms.Timer timer;
        private Random rand;

        int[,] cells;

        private bool gridInitialized, randomize, running;

        public Form1()
        {
            cells = new int[cellRows, cellColumns];
            
            rand = new Random();

            InitializeComponent();
            InitializePictureBox();
            InitializeGame();

            rbMoore.Checked = true;

            rbMoore.Click += new EventHandler(rbMoore_Click);
            rbVonNeumann.Click += new EventHandler(rbVonNeumann_Click);

            timer = new System.Windows.Forms.Timer();
            timer.Tick += new EventHandler(timer_Tick);
            UpdateTimerInterval();
        }

        private void InitializePictureBox()
        {
            pb = new PictureBox();
            pb.Dock = DockStyle.None;
            pb.Size = new Size((cellRows * cellSize) + 1, (cellColumns * cellSize) + 1);
            pb.Location = new Point(0, 0);
            pb.BackColor = Color.White;
            pb.Paint += new PaintEventHandler(pb_Paint);
            this.Controls.Add(pb);
        }

        private void InitializeGame()
        {
            Array.Clear(cells);
            gridInitialized = randomize = running = false;

            btnStart.Enabled = true;
            btnPause.Enabled = false;
            btnPause.Text = "Pause";

            rbMoore.Enabled = rbVonNeumann.Enabled = true;

            pb.Invalidate();
        }

        private void InitializeGrid(Graphics g)
        {
            Pen pen = new Pen(Color.DimGray, 1);

            for (int i = 0; i < cellRows; i++)
            {
                for (int j = 0; j < cellColumns; j++)
                {
                    g.DrawRectangle(pen, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)));
                }
            }

            pen.Dispose();
        }

        private void DrawGrid(Graphics g)
        {
            Pen pen = new Pen(Color.DimGray, 1);
            SolidBrush aliveBrush = new SolidBrush(Color.Violet);

            for (int i = 0; i < cellRows; i++)
            {
                for (int j = 0; j < cellColumns; j++)
                {
                    Rectangle rect = new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize));

                    if (cells[i, j] == 0)
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

        private void RandomizeGrid(Graphics g)
        {
            // Randomly assign each cell a status of alive or dead
            for (int i = 0; i < cellRows; i++)
            {
                for (int j = 0; j < cellColumns; j++)
                {
                    cells[i, j] = rand.Next(2);
                }
            }

            // Draw the resulting grid
            DrawGrid(g);
        }

        private void ProcessGameState()
        {
            int[] neighbors;
            int[,] cellsCopy = cells;

            if (rbMoore.Checked)
            {
                neighbors = new int[8];

                for (int i = 0; i < cellRows; i++)
                {
                    for (int j = 0; j < cellColumns; j++)
                    {
                        // Get all neighbors
                        if (i < cellRows - 1)
                        {
                            neighbors[0] = cellsCopy[i + 1, j];
                        }
                        else
                        {
                            neighbors[0] = cellsCopy[0, j];
                        }

                        if (i > 0)
                        {
                            neighbors[1] = cellsCopy[i - 1, j];
                        }
                        else
                        {
                            neighbors[1] = cellsCopy[cellRows - 1, j];
                        }

                        if (j < cellColumns - 1)
                        {
                            neighbors[2] = cellsCopy[i, j + 1];
                        }
                        else
                        {
                            neighbors[2] = cellsCopy[i, 0];
                        }

                        if (j > 0)
                        {
                            neighbors[3] = cellsCopy[i, j - 1];
                        }
                        else
                        {
                            neighbors[3] = cellsCopy[i, cellColumns - 1];
                        }

                        if (i < cellRows - 1 && j < cellColumns - 1)
                        {
                            neighbors[4] = cellsCopy[i + 1, j + 1];
                        }
                        else if (i > cellRows - 1 && j > cellColumns - 1)
                        {
                            neighbors[4] = cellsCopy[0, 0];
                        }

                        if (i > 0 && j > 0)
                        {
                            neighbors[5] = cellsCopy[i - 1, j - 1];
                        }
                        else if (i < 0 && j < 0)
                        {
                            neighbors[5] = cellsCopy[cellRows - 1, cellColumns - 1];
                        }

                        if (i < cellRows - 1 && j > 0)
                        {
                            neighbors[6] = cellsCopy[i + 1, j - 1];
                        }
                        else if (i > cellRows - 1 && j < 0)
                        {
                            neighbors[6] = cellsCopy[0, cellColumns - 1];
                        }

                        if (i > 0 && j < cellColumns - 1)
                        {
                            neighbors[7] = cellsCopy[i - 1, j + 1];
                        }
                        else if (i < 0 && j > cellColumns - 1)
                        {
                            neighbors[7] = cellsCopy[cellRows - 1, 0];
                        }

                        ProcessCell(i, j, neighbors);
                    }
                }
            }
            else
            {
                neighbors = new int[4];

                for (int i = 0; i < cellRows; i++)
                {
                    for (int j = 0; j < cellColumns; j++)
                    {
                        if (i > 0)
                        {
                            neighbors[0] = cells[i - 1, j];
                        }
                        else
                        {
                            neighbors[0] = cells[cellRows - 1, j];
                        }

                        if (i < cellRows - 1)
                        {
                            neighbors[1] = cells[i + 1, j];
                        }
                        else
                        {
                            neighbors[1] = cells[0, j];
                        }

                        if (j > 0)
                        {
                            neighbors[2] = cells[i, j - 1];
                        }
                        else
                        {
                            neighbors[2] = cells[i, cellColumns - 1];
                        }

                        if (j < cellColumns - 1)
                        {
                            neighbors[3] = cells[i, j + 1];
                        }
                        else
                        {
                            neighbors[3] = cells[i, 0];
                        }

                        ProcessCell(i, j, neighbors);
                    }
                }
            }
        }

        private void ProcessCell(int i, int j, int[] neighbors)
        {
            int aliveCount = 0;

            // Get all of the live neighbors 
            for (int k = 0; k < neighbors.Length; k++)
            {
                if (neighbors[k] == 1)
                {
                    aliveCount++;
                }
            }

            if (cells[i, j] == 1)   // Live cell logic 
            {
                if (aliveCount != 2 && aliveCount != 3)
                {
                    cells[i, j] = 0;
                }
            }
            else    // Dead cell logic 
            {
                if (aliveCount == 3)
                {
                    cells[i, j] = 1;
                }
            }
        }

        private void UpdateTimerInterval()
        {
            timer.Interval = ((tbGameSpeed.Maximum - tbGameSpeed.Value) + 1) * 50;
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

            if (randomize)
            {
                RandomizeGrid(g);
                randomize = false;
            }

            if (running)
            {
                ProcessGameState();
                DrawGrid(g);
            }
        }
    }
}