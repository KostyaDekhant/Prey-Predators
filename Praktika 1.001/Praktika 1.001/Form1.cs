using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Praktika_1._001
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public int size_map = 400;
        public int size_obj = 10;
        public static int count_obj = 40;
        public int speed = 100;
        public static int coef_prey_born = 0;
        public static int coef_predator_born = 0;
        public static int[,] map = new int[40, 40];
        public int[,] localmap = new int[3, 3];
        public bool stop_flag = false;
        
        public static List<Creature> creatures = new List<Creature>(); 

        public int time = 0;

        public int count_Predators_text = 0;
        public int Predator_count = 2;

        public static int count_Prey = 2;

        public int count_Prey_text = 0; 

        static PictureBox [,] creture_pic = new PictureBox[40, 40];
        private void Form1_Load(object sender, EventArgs e)
        {
            size_map = 400;
            size_obj = 10;
            count_obj = size_map / size_obj;

            SetMap();
            SetGroupChartLocation(true);
            CreatePictureMap(true, true);
            SetSpeedSizeTrack();
            TrackBarCreatures();

            Axis ax = new Axis();
            ax.Title = "Время"; 
            chart1.ChartAreas[0].AxisX = ax;
            Axis ay = new Axis();
            ay.Title = "Количество особей";
            chart1.ChartAreas[0].AxisY = ay;

            timer1.Tick += new EventHandler(update);
            timer1.Interval = speed;
            stop_bttn.Enabled = false;
            Predator_count = predator_trackbar.Value;
            count_Prey = prey_trackbar.Value;
            coef_prey_born = 100 - prey_born_trackbar.Value;
        }

        public void SetSpeedSizeTrack()
        {
            speed_trackbar.Minimum = 1;
            speed_trackbar.Maximum = 10;
            speed_trackbar.Value = 5;
            speed_trackbar.TickFrequency = 1;
            size_trackbar.Minimum = 1;
            size_trackbar.Maximum = 3;
            size_trackbar.Value = 1;
            size_trackbar.TickFrequency = 1;
            speed_text.Text = String.Format("Скорость: {0}", speed_trackbar.Value);
            size_map_lab.Text = String.Format("Размер: {0}", size_trackbar.Value);
        }
        private void CreatePictureMap(bool flag, bool mapflag)
        {
            count_obj = size_map / size_obj;
            for (int i = 0; i < count_obj; i++) //Отрисовка старта  
            {
                for (int j = 0; j < count_obj; j++)
                {
                    if(flag)
                        creture_pic[i, j] = new PictureBox();
                    creture_pic[i, j].Location = new Point(i * size_obj + 41, j * size_obj + 41); // задаем положение каждого PictureBox-а
                    creture_pic[i, j].Size = new Size(size_obj, size_obj); // задаем размер каждого PictureBox-а
                    if (flag)
                        this.Controls.Add(creture_pic[i, j]); // добавляем каждый PictureBox на форму
                    if(mapflag)
                        map[i, j] = 0;
                }
            }
        }

        public void SetMap()
        {
            top_pictureBox.Width = size_map;
            bottom_pictureBox.Width = size_map;
            bottom_pictureBox.Location = new Point(40, size_map + 40);
            right_pictureBox.Height = size_map;
            right_pictureBox.Location = new Point(size_map + 40, 40);
            left_pictureBox.Height = size_map;
        }

        public void SetGroupChartLocation(bool flag)
        {
            groupbox.Location = new Point(size_map+50, size_map + 40 - 190);
            chart1.Location = new Point(size_map+50,40);
            if(flag)
            {
                chart1.Size = new Size(567, 177);
            }
            else
            {
                chart1.Size = new Size(this.ClientSize.Width - 850 - 40, 177*3);
            }
        }
        public void SpawnCreatures()
        {
            Random random = new Random();
            int tempX, tempY;
            for (int i = 0; i < count_Prey; i++)
            {
                do{
                    tempX = random.Next(0, count_obj);
                    tempY = random.Next(0, count_obj);
                } while (map[tempY, tempX] != 0);
                map[tempY, tempX] = 1;

                Prey prey = new Prey(tempX, tempY, random.Next(1, 5), random.Next(6, 10), SetColor(1));
                creatures.Add(prey);
            }
            for (int i = 0; i < Predator_count; i++)
            {
                do
                {
                    tempX = random.Next(0, count_obj);
                    tempY = random.Next(0, count_obj);
                } while (map[tempY, tempX] != 0);
                map[tempY, tempX] = 2;

                Predator predator = new Predator(tempX, tempY, random.Next(0, 3), random.Next(12, 18), SetColor(2));
                creatures.Add(predator);
            }
        }
        //public void SetLocalMap(int x, int y)
        //{
        //    localmap[0, 0] = map[(y - 1 + count_obj) % count_obj, (x - 1 + count_obj) % count_obj];
        //    localmap[0, 1] = map[(y - 1 + count_obj) % count_obj, (x + count_obj) % count_obj];
        //    localmap[0, 2] = map[(y - 1 + count_obj) % count_obj, (x + 1 + count_obj) % count_obj];
        //    localmap[1, 0] = map[(y + count_obj) % count_obj, (x - 1 + count_obj) % count_obj];
        //    localmap[1, 1] = map[(y + count_obj) % count_obj, (x + count_obj) % count_obj];
        //    localmap[1, 2] = map[(y + count_obj) % count_obj, (x + 1 + count_obj) % count_obj];
        //    localmap[2, 0] = map[(y + 1 + count_obj) % count_obj, (x - 1 + count_obj) % count_obj];
        //    localmap[2, 1] = map[(y + 1 + count_obj) % count_obj, (x + count_obj) % count_obj];
        //    localmap[2, 2] = map[(y + 1 + count_obj) % count_obj, (x + 1 + count_obj) % count_obj];
        //}
        public static void Draw(int x, int y, Color clr)
        {
            creture_pic[y,x].BackColor = clr;
        }

        //public void Draw_map(int size, int[,] lmap, int num)
        //{
        //    string str = "";
        //    for (int i = 0; i < size; i++)
        //    {
        //        for (int j = 0; j < size; j++)
        //        {
        //            str += lmap[i, j] + " ";
        //        }
        //        str += "\n";
        //    }
        //}

        //public static void CorrectXY(Creature creature, int Creature)
        //{
        //    int tempX, tempY;
        //    tempX = creature.GetPos().X;
        //    tempY = creature.GetPos().Y;
        //    if (tempX >= count_obj)
        //        creature.Movement(-count_obj, 0);
        //    if (tempY >= count_obj)
        //        creature.Movement(0, -count_obj);
        //    if (tempX < 0)
        //        creature.Movement(count_obj, 0);
        //    if (tempY < 0)
        //        creature.Movement(0, count_obj);
        //}

        public static Color SetColor(int num)
        {
            Random ran = new Random();
            int r, g, b;
            r = ran.Next(0, 150);
            g = 255;
            b = ran.Next(0, 150);
            Color clr;
            if (num == 1)
                clr = Color.FromArgb(r, g, b);
            else
                clr = Color.FromArgb(g, r, b);
            return clr;
        }

        public static void RemoveCreatures(Creature creature)
        {
            creatures.Remove(creature);
        }

        public static Creature GetCreature(Point point)
        {
            foreach (var creature in creatures)
            {
                if (creature.pos.X == point.X && creature.pos.Y == point.Y)
                {
                    return creature;
                }
            }

            return null;
        }


        public void update(Object myObject, EventArgs eventsArgs)
        {
            count_Prey_text = 0;
            count_Predators_text = 0;
            foreach (var creature in creatures.ToArray())
            {
                creature.Step();
                
            }
            foreach (var creature in creatures)
            {
                if (creature.isAlive())
                {
                    if (creature is Prey)
                    {
                        count_Prey_text++;
                    }
                    else
                    {
                        count_Predators_text++;
                    }
                }
            }
            int temp_time = time / 1000;
            time += speed;
            if (temp_time != time / 1000)
            {
                chart1.Series[0].Points.AddXY((time / 1000), count_Prey_text);
                chart1.Series[1].Points.AddXY((time / 1000), count_Predators_text);
            }
        }

        

        private void play_bttn_Click(object sender, EventArgs e)
        {
            size_trackbar.Enabled = false;
            prey_trackbar.Enabled = false;
            predator_trackbar.Enabled = false;
            stop_bttn.Enabled = true;
            Predator_count = predator_trackbar.Value;
            count_Prey = prey_trackbar.Value;
            coef_prey_born = 100 - prey_born_trackbar.Value;
            timer1.Start();
            if(!stop_flag)
            {
                CreatePictureMap(false, true);
                SpawnCreatures();
                chart1.Series.Add("Всего жертв");
                chart1.Series.Add("Всего хищников");
                for (int i = 0; i < 2; i++)
                {
                    chart1.Series[i].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
                }
                chart1.Series[1].Color = Color.Red;
            }
            stop_flag = false;

        }

        private void stop_bttn_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            stop_flag = true;
            stop_bttn.Enabled = false;

        }

        private void restart_bttn_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            for (int i = 0; i < count_obj; i++)
            {
                for (int j = 0; j < count_obj; j++)
                {
                    creture_pic[i, j].BackColor = Color.LightGray;
                    map[i, j] = 0;
                }
            }
            creatures.Clear();
            chart1.Series.Clear();
            time = 0;       
            size_trackbar.Enabled = true;
            prey_trackbar.Enabled = true;
            predator_trackbar.Enabled = true;
            stop_flag = false;
        }

        private void speed_trackbar_Scroll(object sender, EventArgs e)
        {
            speed = 550 - 50*speed_trackbar.Value;
            speed_text.Text = String.Format("Скорость: {0}", speed_trackbar.Value);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = speed;
        }

        public void TrackBarCreatures()
        {
            prey_trackbar.Maximum = count_obj * count_obj * 6 / 10;
            prey_trackbar.Minimum = 0;
            prey_trackbar.TickFrequency = count_obj / 2;
            prey_trackbar.Value = count_obj * 4;
            prey_count_lab.Text = String.Format("Количество жертв: {0}", prey_trackbar.Value);

            predator_trackbar.Maximum = count_obj * 6 / 10;
            predator_trackbar.Minimum = 0;
            predator_trackbar.TickFrequency = count_obj / 3;
            predator_trackbar.Value = count_obj / 2;
            predator_count_lab.Text = String.Format("Количество хищников: {0}", predator_trackbar.Value);

            prey_born_trackbar.Maximum = 100;
            prey_born_trackbar.Minimum = 0;
            prey_born_trackbar.TickFrequency = 10;
            prey_born_trackbar.Value = 20;
            prey_born_lab.Text = String.Format("Уровень рождаемости: {0}", prey_born_trackbar.Value);

            predator_born_trackbar.Maximum = 100;
            predator_born_trackbar.Minimum = 0;
            predator_born_trackbar.TickFrequency = 10;
            predator_born_trackbar.Value = 20;
            predator_born_lab.Text = String.Format("Уровень рождаемости: {0}", predator_born_trackbar.Value);

        }
        private void size_trackbar_Scroll(object sender, EventArgs e)
        {
            if(size_trackbar.Value == 3)
                size_obj = 40;
            else
                size_obj = size_trackbar.Value * 10;
            count_obj = size_map / size_obj;
            size_map_lab.Text = String.Format("Размер: {0}", size_trackbar.Value);

            TrackBarCreatures();

            prey_count_lab.Text = String.Format("Количество жертв: {0}", prey_trackbar.Value);
        }

        private void prey_trackbar_Scroll_1(object sender, EventArgs e)
        {
            count_Prey = prey_trackbar.Value;
            prey_count_lab.Text = String.Format("Количество жертв: {0}", prey_trackbar.Value);
        }

        private void predator_trackbar_Scroll(object sender, EventArgs e)
        {
            Predator_count = predator_trackbar.Value;
            predator_count_lab.Text = String.Format("Количество хищников: {0}", predator_trackbar.Value);
        }

        private void prey_born_trackbar_Scroll(object sender, EventArgs e)
        {
            coef_prey_born = 100 - prey_born_trackbar.Value;
            prey_born_lab.Text = String.Format("Уровень рождаемости: {0}", prey_born_trackbar.Value);
        }

        private void predator_born_trackbar_Scroll(object sender, EventArgs e)
        {
            coef_predator_born = 100 - predator_born_trackbar.Value;
            predator_born_lab.Text = String.Format("Уровень рождаемости: {0}", predator_born_trackbar.Value);
        }
    }
}
