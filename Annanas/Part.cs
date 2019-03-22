using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Annanas
{
    class Part <T>
    {
        public Part(T item, int x, int y, int cnt)
        {
            Data = item;
            Point p = new Point();
            p.X = x;
            p.Y = y;
            Pos = p;
            Count = cnt;
        }
        int w = 50;
        int h = 50;

        public Point Pos { get; set; }
        public int W { get => w; }
        public int H { get => h; }
        public T Data { get; set; }
        public int Count { get; set; }
    }
}

struct Point
{
    public int X { get; set; }
    public int Y { get; set; }
}