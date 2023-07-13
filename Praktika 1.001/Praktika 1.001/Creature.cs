using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praktika_1._001
{
    public abstract class Creature
    {
        protected readonly Random random = new Random();

        public Point pos { get; set; }

        public Creature(int x, int y)
        {
            pos = new Point(x,y); 
        }

        public abstract void Movement(int x, int y);
        public abstract void Death();
        public abstract Point GetPos();
        public abstract void Birth();
        public abstract void Step();
        public abstract bool isAlive();
    }
}
