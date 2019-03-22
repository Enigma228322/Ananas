using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Annanas
{
    class Controller<T> : IController<T>
    {
        IModel<T> model;
        public void Add(T item)
        {
            model.Add(item);
        }

        public void AddView(IView<T> view)
        {
            model.Changed += new Action(view.UpdateView);
        }

        public int Length()
        {
            return model.Length;
        }

        public void Remove(int n)
        {
            model.Delete(n);
        }

        public void SetMatrix(int n, int m)
        {
            model.N = n;
            model.M = m;
        }

        public void SetModel(IModel<T> model)
        {
            this.model = model;
        }
    }
}
