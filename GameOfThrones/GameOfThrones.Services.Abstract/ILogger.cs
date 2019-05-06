using System;

namespace GameOfThrones.Services.Abstract
{
    public interface ILogger
    {
        void LogError(Exception exception);
        void LogMessage(string text);
    }
}
