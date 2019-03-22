using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Annanas
{
    class Model<T> : IModel<T>
    {
        MyList<Part<T>> list = new MyList<Part<T>>();

        public int Dim { get; set; }

        
        public int N { get; set; }
        public int M { get; set; }

        public event Action Changed;

        public int Length { get => list.Length; }

        public MyList<Part<T>> AllParts => list;

        public void Add(T item)
        {
            Part<T> part = new Part<T>(item, 100 , 100,Length + 1);
            if (Length != 0)
                part = new Part<T>(item, list.Last.Pos.X + 20, list.Last.Pos.Y, Length + 1);
            list.Add(part);
            if (Changed != null) Changed();
        }

        public void Delete(int n)
        {
            list.Remove(n);
            if (Changed != null) Changed();
        }
        
    }
}

