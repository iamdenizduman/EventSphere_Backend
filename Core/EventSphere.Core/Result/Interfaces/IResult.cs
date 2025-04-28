using EventSphere.Core.Enums;

namespace EventSphere.Core.Result.Interfaces
{
    public interface IResult
    {
        ResultStatus ResultStatus { get; }
        string Message { get;  }
        Exception? Exception { get; }
    }
}
