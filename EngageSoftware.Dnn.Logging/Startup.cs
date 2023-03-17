// <copyright file="Startup.cs" company="Engage">
// EngageSoftware.Dnn.Logging
// Copyright (c) 2023
// </copyright>
namespace EngageSoftware.Dnn.Logging;

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
