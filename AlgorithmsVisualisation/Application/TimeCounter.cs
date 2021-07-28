using System;
using System.Diagnostics;
using Contracts.Services;

namespace Application {
    public class TimeCounter : ITimeCounter {
        public (TimeSpan, TResult) Time<TResult>(Func<TResult> func) {
            Stopwatch stopwatch = Stopwatch.StartNew();
            var result = func();
            stopwatch.Stop();
            return (stopwatch.Elapsed, result);
        }
    }
}