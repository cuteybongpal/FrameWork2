using System.Threading.Tasks;
using UnityEngine;

public interface ILogger
{
    public Task Log<T>(IRequest<T> request, string message);

    public Task Error<T>(IRequest<T> request, string message);
}
