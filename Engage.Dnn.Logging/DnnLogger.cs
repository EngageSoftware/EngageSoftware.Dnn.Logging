// <copyright file="DnnLogger.cs" company="Engage">
// Engage.Dnn.Logging
// Copyright (c) 2023
// </copyright>
namespace Engage.Dnn.Logging;

/// <summary>An <see cref="ILogger"/> implementation which wraps DNN's <see cref="ILog"/>.</summary>
public sealed class DnnLogger : ILogger
{
    private readonly ILog log;

    /// <summary>Initializes a new instance of the <see cref="DnnLogger"/> class.</summary>
    /// <param name="log">The DNN <see cref="ILog"/> instance to wrap.</param>
    public DnnLogger(ILog log)
    {
        this.log = log;
    }

    /// <inheritdoc />
    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {
        if (formatter == null)
        {
            throw new ArgumentNullException(nameof(formatter));
        }

        switch (logLevel)
        {
            case LogLevel.Trace:
                LogWithLevel(this.log.Trace, eventId, state, exception, formatter);
                return;
            case LogLevel.Debug:
                LogWithLevel(this.log.Debug, eventId, state, exception, formatter);
                return;
            case LogLevel.Information:
                LogWithLevel(this.log.Info, eventId, state, exception, formatter);
                return;
            case LogLevel.Warning:
                LogWithLevel(this.log.Warn, eventId, state, exception, formatter);
                return;
            case LogLevel.Error:
                LogWithLevel(this.log.Error, eventId, state, exception, formatter);
                return;
            case LogLevel.Critical:
                LogWithLevel(this.log.Fatal, eventId, state, exception, formatter);
                return;
            case LogLevel.None:
                return;
            default:
                throw new ArgumentOutOfRangeException(nameof(logLevel), logLevel, FormattableString.Invariant($"Unexpected log level: {logLevel}"));
        }

        static void LogWithLevel(
            Action<object, Exception?> logException,
            EventId eventId,
            TState state,
            Exception? exception,
            Func<TState, Exception?, string> formatter)
        {
            logException($"[{eventId}] {formatter(state, exception)}", exception);
        }
    }

    /// <inheritdoc />
    public bool IsEnabled(LogLevel logLevel)
    {
        return logLevel switch
        {
            LogLevel.None => false,
            LogLevel.Critical => this.log.IsFatalEnabled,
            LogLevel.Error => this.log.IsErrorEnabled,
            LogLevel.Warning => this.log.IsWarnEnabled,
            LogLevel.Information => this.log.IsInfoEnabled,
            LogLevel.Debug => this.log.IsDebugEnabled,
            LogLevel.Trace => this.log.IsTraceEnabled,
            _ => throw new ArgumentOutOfRangeException(nameof(logLevel), logLevel, FormattableString.Invariant($"Unexpected log level: {logLevel}")),
        };
    }

    /// <inheritdoc />
    public IDisposable BeginScope<TState>(TState state)
        where TState : notnull
    {
        this.log.InfoFormat(CultureInfo.InvariantCulture, "[BeginScope] {0}", state);
        return new ScopeDisposable(() => this.log.InfoFormat(CultureInfo.InvariantCulture, "[EndScope] {0}", state));
    }

    private sealed class ScopeDisposable : IDisposable
    {
        private readonly Action onDispose;

        public ScopeDisposable(Action onDispose)
        {
            this.onDispose = onDispose;
        }

        public void Dispose()
        {
            this.onDispose();
        }
    }
}
