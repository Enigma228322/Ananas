using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Annanas
{
    class PanelView : Panel, IView<T>
    {
        IModel<T> model;
        public void SetModel(IModel<T> model)
        {
            this.model = model;
        }

        public void UpdateView()
        {
            Invalidate();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (model == null) return;
            Graphics g = e.Graphics;
            int n = model.N;
            int m = model.M;
            Elements[,] a = new Elements[m, n];
            int k = 0;
            int x = -70, y = 0;
            int w = 50, h = 50;
            int dist_betw = 20;

            int dir = 1;
            int l = 0, r = 0, u = 0, d = 0;
            while (k < n * m)
            {
                if (dir > 4) dir = 1;
                if (dir == 1)// слева на право
                {
                    for (int j = l; j < n - r; j++)
                    {
                        x = x + w + dist_betw;
                        Elements element = new Elements(k, x, y);
                        a[u, j] = element;
                        k++;
                    }
                    u++;
                }

                if (dir == 2)// сверху вниз
                {
                    for (int i = u; i < m - d; i++)
                    {
                        y = y + h + dist_betw;
                        Elements element = new Elements(k, x, y);
                        a[i, n - 1 - r] = element;
                        k++;
                    }
                    r++;
                }

                if (dir == 3)// справа на лево
                {
                    for (int j = n - 1 - r; j >= l; j--)
                    {
                        x = x - w - dist_betw;
                        Elements element = new Elements(k, x, y);
                        a[m - 1 - d, j] = element;
                        k++;
                    }
                    d++;
                }

                if (dir == 4)// снизу вверх
                {
                    for (int i = m - 1 - d; i >= u; i--)
                    {
                        y = y - h - dist_betw;
                        Elements element = new Elements(k, x, y);
                        a[i, l] = element;
                        k++;
                    }
                    l++;
                }
                dir++;

            }
            foreach (var el in model.AllParts)
            {
                for(int i1 = 0; i1 < m; i1++)
                {
                    for (int j1 = 0; j1 < n; j1++)
                    {
                        if(el.Count == a[i1,j1].k) g.DrawRectangle(Pens.Black, a[i1,j1].X, a[i1, j1].Y, el.W, el.H);
                    }
                }
            }
        }


    }
}

struct Elements
{
    public Elements(int k, int x, int y)
    {
        this.k = k;
        this.X = x;
        this.Y = y;
    }
    public int k;
    public int X, Y;
}
