using System;
using System.Linq;

namespace Application.Service
{
    public interface IService<TRequest, TResponse>
    {
        public TResponse execute (TRequest request);
    }
}