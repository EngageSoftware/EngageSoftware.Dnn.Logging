// <copyright file="DnnLoggerProvider.cs" company="Engage">
// Engage.Dnn.Logging
// Copyright (c) 2023
// </copyright>
namespace Engage.Dnn.Logging;

/// <summary>An <see cref="ILoggerProvider" /> implementation using DNN's <see cref="LoggerSource"/>.</summary>
public sealed class DnnLoggerProvider : ILoggerProvider
{
    /// <inheritdoc />
    public ILogger CreateLogger(string categoryName)
    {
        return new DnnLogger(LoggerSource.Instance.GetLogger(categoryName));
    }

    /// <inheritdoc />
    public void Dispose()
    {
    }
}
