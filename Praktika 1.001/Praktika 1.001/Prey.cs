using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Praktika_1._001
{
    public class Prey : Creature
    {
        private int Energy = 0;
        private int MaxEnergy = 5;
        private Point pos = new Point();
        private bool isalive;   
        private bool Energyflag = false;
        private int[,] localmap = new int[3, 3];
        public Color clr;
        public Prey(int x, int y, int start_energy, int max_energy, Color clr) : base(x,y)
        {
            pos.X = x;
            pos.Y = y;
            Energy = start_energy;
            MaxEnergy = max_energy;
            isalive = true;
            this.clr = clr;
            CorrectXY();
        }

        public void SetEnergy(int Energy)
        {
            this.Energy = Energy;
        }
        public void ConsumeEnergy()
        {
            Energy--;
        }
        public void Rest()
        {
            if (Energy < MaxEnergy)
                Energy++;
        }

        public override void Death()
        {
            isalive = false;
        }

        public override void Birth()
        {
            isalive = true;
            Energy = random.Next(1, MaxEnergy);
            Energyflag = false;
        }

        public Color GetColor()
        {
            return clr;
        }


        public override bool isAlive()
        {
            return isalive;
        }
        public override void Movement(int x, int y)
        {
            pos.X += x;
            pos.Y += y;
        }
        public Point EmptyPlace(int[,] local_map)
        {
            Point point = new Point();
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    if (local_map[i+1, j+1] == 0 && (i != 0 || j != 0))
                    {
                        point = new Point(pos.X + j, pos.Y + i);
                        return point;
                    }
                }
            }
            return point;
        }

        public Point GiveBirth()
        {
            Random rand = new Random();
            Point pos_birth = new Point();
            pos_birth = EmptyPlace(localmap);
            //Energy -= 4;
            Energy -= rand.Next(1, 4);

            return pos_birth;
        }

        public void SetPos(Point pos)
        {
            this.pos = pos;
        }

        public void SetColor(Color clr)
        {
            this.clr = clr;
        }

        public void CorrectXY()
        {
            int tempX, tempY;
            tempX = this.GetPos().X;
            tempY = this.GetPos().Y;
            if (tempX >= Form1.count_obj)
                this.Movement(-Form1.count_obj, 0);
            if (tempY >= Form1.count_obj)
                this.Movement(0, -Form1.count_obj);
            if (tempX < 0)
                this.Movement(Form1.count_obj, 0);
            if (tempY < 0)
                this.Movement(0, Form1.count_obj);
        }

        public override void Step()
        {
            Point clear_point = this.GetPos();
            Random rd = new Random();
            int coef = rd.Next(0, 101);
            int coef_form = Form1.coef_prey_born;
            SetLocalMap(clear_point.X, clear_point.Y);
            if (!CheckPlace())
            {
                this.Death();
                Form1.RemoveCreatures(this);
                Form1.Draw(clear_point.Y, clear_point.X, Color.LightGray);
                Form1.map[clear_point.Y, clear_point.X] = 0;
                return;
            }
            if(Energy == 0 || (Energy < MaxEnergy && Energyflag))
            {
                if (Energy == 0)
                    Energyflag = true;
                else if (Energy == MaxEnergy - 1)
                    Energyflag = false;
                Rest();
                return;
            }
            if (coef > coef_form)
            {
                Energyflag = false;
                CorrectXY();               // Корректирует элемент цикла
                Point loc_p = this.GetPos();
                SetLocalMap(loc_p.X, loc_p.Y);
                Point temp_point = this.GiveBirth(); //Место рождения
                Prey prey = new Prey(temp_point.X, temp_point.Y, random.Next(1, 5), random.Next(5, 10), Form1.SetColor(1));
                temp_point = prey.GetPos();
                Form1.map[temp_point.Y, temp_point.X] = 1;
                Form1.Draw(temp_point.Y, temp_point.X, prey.GetColor());
                Form1.creatures.Add(prey);
                return;
            }
            else
            {
                Random rand = new Random();
                int tempX, tempY;
                do
                {
                    tempX = rand.Next(-1, 2);
                    tempY = rand.Next(-1, 2);
                } while (localmap[tempY+1, tempX+1] != 0);
                Movement(tempX, tempY);
                ConsumeEnergy();
                CorrectXY();
                Point pos_prey = this.GetPos();
                Form1.Draw(clear_point.Y, clear_point.X, Color.LightGray);
                Form1.map[clear_point.Y, clear_point.X] = 0;
                Form1.map[pos_prey.Y, pos_prey.X] = 1;
                Form1.Draw(pos_prey.Y, pos_prey.X, this.GetColor());
            }
        }
        public int GetEnergy()
        {
            return Energy;
        }

        public override Point GetPos()
        {
            return pos;
        }

        public bool CheckPlace()
        {
            //string str = "";
            int temp_count = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    //str += localmap[j, i] + " ";
                    if (i == 1 && j == 1) continue;
                    if (localmap[i,j] != 0)
                        temp_count++;
                }
                //str += "\n";
            }
            //MessageBox.Show(str);
            return temp_count < 8 ? true : false;
        }
        public void SetLocalMap(int x, int y)
        {
            localmap[0, 0] = Form1.map[(y - 1 + Form1.count_obj) % Form1.count_obj, (x - 1 + Form1.count_obj) % Form1.count_obj];
            localmap[0, 1] = Form1.map[(y - 1 + Form1.count_obj) % Form1.count_obj, (x + Form1.count_obj) % Form1.count_obj];
            localmap[0, 2] = Form1.map[(y - 1 + Form1.count_obj) % Form1.count_obj, (x + 1 + Form1.count_obj) % Form1.count_obj];
            localmap[1, 0] = Form1.map[(y + Form1.count_obj) % Form1.count_obj, (x - 1 + Form1.count_obj) % Form1.count_obj];
            localmap[1, 1] = Form1.map[(y + Form1.count_obj) % Form1.count_obj, (x + Form1.count_obj) % Form1.count_obj];
            localmap[1, 2] = Form1.map[(y + Form1.count_obj) % Form1.count_obj, (x + 1 + Form1.count_obj) % Form1.count_obj];
            localmap[2, 0] = Form1.map[(y + 1 + Form1.count_obj) % Form1.count_obj, (x - 1 + Form1.count_obj) % Form1.count_obj];
            localmap[2, 1] = Form1.map[(y + 1 + Form1.count_obj) % Form1.count_obj, (x + Form1.count_obj) % Form1.count_obj];
            localmap[2, 2] = Form1.map[(y + 1 + Form1.count_obj) % Form1.count_obj, (x + 1 + Form1.count_obj) % Form1.count_obj];
        }

        /* проверка на наличие жизни и реализация смерти */
    }
}
