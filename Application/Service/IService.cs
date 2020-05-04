using System;
using System.Linq;

using System.Threading.Tasks;

namespace Application.Service
{
    public interface IService<TRequest, TResponse>
    {
        public TResponse execute (TRequest request);
    }
}