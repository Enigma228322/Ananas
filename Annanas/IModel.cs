using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Annanas
{
    interface IModel<T>
    {
        event Action Changed;
        int N { get; set; }
        int M { get; set; }
        int Length { get; }
        int Dim { get; set; }
        MyList<Part<T>> AllParts { get; }
        void Add(T item);
        void Delete(int n);
    }
}
