﻿namespace EventSphere.Core.Result.Interfaces
{
    public interface IDataResult<out T> : IResult
    {
        T Data { get; }
    }
}
