// <copyright file="Startup.cs" company="Engage">
// Engage.Dnn.Logging
// Copyright (c) 2023
// </copyright>
namespace Engage.Dnn.Logging;

/// <summary>Configures the Dependency Injection container to be able to resolve <see cref="ILogger{T}"/> instances.</summary>
[PublicAPI]
public class Startup : IDnnStartup
{
    /// <inheritdoc />
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddLogging(builder => { builder.ClearProviders().AddProvider(new DnnLoggerProvider()); });
    }
}
