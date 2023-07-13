using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Praktika_1._001
{
    internal class Predator : Creature
    {
        private int HunderLvl = 0;
        private int MaxHunderLvl = 5;
        public Point pos = new Point();
        private bool isalive;
        private Color clr;
        private int[,] localmap = new int[3, 3];

        public Predator(int x, int y, int HunderLvl, int MaxHunderLvl, Color clr) : base(x, y)
        {
            pos.X = x;
            pos.Y = y;
            this.HunderLvl = HunderLvl;
            this.MaxHunderLvl = MaxHunderLvl;
            this.clr = clr;
            isalive = true;
            CorrectXY();
        }

        public void SetPos(Point pos)
        {
            this.pos = pos;
        }

        public override bool isAlive()
        {
            return isalive;
        }

        public void Eat()
        {
            Random rand = new Random();
            HunderLvl -= rand.Next(5, 9);
            if (HunderLvl < 0)
                HunderLvl = 0;
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
        public override void Death()
        {
            isalive = false;
        }

        public override void Birth()
        {
            isalive = true;
            HunderLvl = 2;
        }

        public Point GiveBirth()
        {
            Random rand = new Random();
            Point pos_birth = new Point();
            pos_birth = ChoosePlace(localmap, 0);
            Eat();
            return pos_birth;
        }
        public void IncreaseHunder()
        {
            if (++HunderLvl > MaxHunderLvl)
                Death();
        }
        public override void Movement(int x, int y)
        {
            pos.X += x;
            pos.Y += y;
        }
        public bool CheckPlace()
        {
            int temp_count = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (i == 1 && j == 1) continue;
                    if (localmap[i, j] != 0)
                        temp_count++;
                }
            }
            return temp_count < 8 ? true : false;
        }

        public Point ChoosePlace(int[,] local_map, int num)
        {
            Point point = new Point();
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    if (local_map[i + 1, j + 1] == num && (i != 0 || j != 0))
                    {
                        point = new Point(j, i);
                        return point;
                    }
                }
            }
            return point;
        }
        public int SearchCreatures(int num)
        {
            int temp_count = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (i == 1 && j == 1) continue;
                    if (localmap[i, j] == num)
                        temp_count++;
                }
            }
            return temp_count;
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
        public Color GetColor()
        {
            return clr;
        }
        public override Point GetPos()
        {
            return pos;
        }
        public override void Step()
        {
            Point clear_point = this.GetPos();
            Random rd = new Random();
            int coef = rd.Next(0, 101);
            int coef_form = Form1.coef_predator_born;
            SetLocalMap(GetPos().X, GetPos().Y);
            if (!CheckPlace() || HunderLvl == MaxHunderLvl)
            {
                this.Death();
                Form1.RemoveCreatures(this);
                Form1.Draw(clear_point.Y, clear_point.X, Color.LightGray);
                Form1.map[clear_point.Y, clear_point.X] = 0;
                return;
            }
            if (SearchCreatures(1) != 0 && HunderLvl > 6) /*Проверка места на поедание жартвы*/
            {
                Point tempXY = ChoosePlace(localmap, 1);
                Movement(tempXY.X, tempXY.Y);
                Eat();
                CorrectXY();
                Point EatPoint = this.GetPos();
                SetLocalMap(EatPoint.X, EatPoint.Y);
                if (Form1.GetCreature(EatPoint) is Prey prey)
                {
                    Form1.RemoveCreatures(prey);
                }
                Form1.Draw(clear_point.Y, clear_point.X, Color.LightGray);
                Form1.map[clear_point.Y, clear_point.X] = 0;
                Form1.map[EatPoint.Y, EatPoint.X] = 2;
                Form1.Draw(EatPoint.Y, EatPoint.X, this.GetColor());
                return;
            }
            else if ((SearchCreatures(1) > SearchCreatures(2)) && CheckPlace() &&
            coef > coef_form && MaxHunderLvl - HunderLvl > 9) /*Проверка места на рождаемость*/
            {
                HunderLvl +=7;

                Point temp_pred = this.GetPos();
                SetLocalMap(temp_pred.X, temp_pred.Y);
                Point BirthPoint = this.GiveBirth();
                temp_pred.X += BirthPoint.X;
                temp_pred.Y += BirthPoint.Y;
                Predator pred = new Predator(temp_pred.X, temp_pred.Y, random.Next(0, 3), random.Next(10, 12), 
                                    Form1.SetColor(2));
                Form1.creatures.Add(pred);
                temp_pred = pred.GetPos();
                Form1.Draw(temp_pred.Y, temp_pred.X, pred.GetColor());
                Form1.map[temp_pred.Y, temp_pred.X] = 2;
                return;
            }
            else /*Просто ходьба*/
            {
                Random rand = new Random();
                int tempX, tempY;
                do
                {
                    tempX = rand.Next(-1, 2);
                    tempY = rand.Next(-1, 2);
                } while (localmap[tempY + 1, tempX + 1] != 0);
                Movement(tempX, tempY);
                IncreaseHunder();

                CorrectXY();
                Point pos_predator = this.GetPos();
                Form1.Draw(clear_point.Y, clear_point.X, Color.LightGray);
                Form1.map[clear_point.Y, clear_point.X] = 0;
                Form1.map[pos_predator.Y, pos_predator.X] = 2;
                Form1.Draw(pos_predator.Y, pos_predator.X, this.GetColor());
                return;
            }
        }
    }
}
