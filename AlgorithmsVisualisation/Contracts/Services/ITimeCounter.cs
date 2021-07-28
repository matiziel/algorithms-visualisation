using System;

namespace Contracts.Services {
    public interface ITimeCounter {
        (TimeSpan, TResult) Time<TResult>(Func<TResult> func);
    }
}