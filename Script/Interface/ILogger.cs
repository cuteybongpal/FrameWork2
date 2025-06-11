using System.Threading.Tasks;
using UnityEngine;

public interface ILogger : IMiddleWare
{
    public Task Log(string message);

    public Task Error(string message);
}
