using System.Threading.Tasks;
using UnityEngine;

public interface IMiddleWare
{
    public Task Invoke<T>(IRequest<T> request);
}
