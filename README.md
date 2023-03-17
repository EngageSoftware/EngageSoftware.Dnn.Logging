# EngageSoftware.Dnn.Logging

[![GitHub Actions](https://github.com/EngageSoftware/Engage.Dnn.Logging/actions/workflows/ci.yml/badge.svg)](https://github.com/EngageSoftware/Engage.Dnn.Logging/actions) [![NuGet](https://img.shields.io/nuget/v/EngageSoftware.Dnn.Logging)](https://www.nuget.org/packages/Engage.Dnn.Logging) [![MIT License](https://img.shields.io/github/license/EngageSoftware/Engage.Dnn.Logging)](https://github.com/EngageSoftware/Engage.Dnn.Logging/blob/main/LICENSE) 

Reference this project in order to enable dependency injection support for
`ILogger<T>` in your DNN Platform site. This implementation wraps [DNN's
`LoggerSource`](https://docs.dnncommunity.org/api/DotNetNuke.Instrumentation.LoggerSource.html),
which ties into DNN's custom Log4Net implementation by default.
