using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Annanas
{
    interface IView<T>
    {
        void SetModel(IModel<T> model);
        void UpdateView();
    }
}
