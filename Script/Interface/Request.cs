using UnityEngine;

public interface IRequest<T>
{
    public T Request { get; set; }
}
public enum RequestType
{

}