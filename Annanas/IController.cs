using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Annanas
{
    interface IController<T>
    {
        void Add(T item);
        void Remove(int n);
        void SetModel(IModel<T> model);
        void AddView(IView<T> view);
        int Length();
        void SetMatrix(int n, int m);
    }
}
