**Overview**

This document covers brief overview of the following .NET Core runtime libraries features.

1. Application Host
1. Dependency Injection
1. Application configuration
1. Logging

This document explores these concepts with reference to Console application. In ASP.NET Core, web application specific features are configured on top of basic setup. Microsoft has implemented and provided these core features via NuGet Packages (Microsoft.Extensions.\*).
 # Application host

A *host* is an object that encapsulates an app's resources and lifetime functionality, such as:

- Dependency injection (DI)
- Logging
- Configuration
- App shutdown

To add hosting feature in a console app

1. Add [Microsoft.Extensions.Hosting](https://www.nuget.org/packages/Microsoft.Extensions.Hosting) NuGet package.
1. Add below code in the Main method

![Graphical user interface, text, application Description automatically generated](5ff5e3a9-304b-4902-8a67-8dc4020fbbb4.001.png)

Host.CreateDefaultBuilder() call creates default host builder which

- Loads configuration from the environment variables, appsettings.json, appsettings.{Environment}.json etc.
- Adds logging provider: Console, Debug, EventSource, EventLog
- Register framework provided services into DI container – logging, configuration etc

[Reference documentation](https://docs.microsoft.com/en-gb/dotnet/core/extensions/generic-host)
# Dependency Injection

Dependency injection in .NET is a first-class citizen, along with configuration, logging. Dependency (services) are registered using ConfigureServices method of the host builder object. Objects will be created and injected by DI container via Constructor of the class. Alternative object can be requested using GetRequiredService method. This default feature could replace third-party DI containers eg. Ninject, Unity, StructureMap etc

[Reference documentation](https://docs.microsoft.com/en-gb/dotnet/core/extensions/dependency-injection)
# Application configuration
The default host builder provides configuration for the app. Default configuration service will read the app configuration data from key-value pairs using various configuration sources such as settings file appsettings.json, environment variables (OS level) etc.

Configuration providers that are added later override previous key settings. For example, if SomeKey is set in both appsettings.json and the environment, the environment value is used. Using the default configuration providers, the Command-line configuration provider overrides all other providers.

The default provider as their order is:

1. appsettings.json using the JSON configuration provider.
1. appsettings.Environment.json using the JSON configuration provider. For example, appsettings.Production.json and appsettings.Development.json.
1. App secrets when the app runs in the Development environment.
1. Environment variables using the Environment Variables configuration provider.
1. Command-line arguments using the Command-line configuration provider.

In .NET core, appsetttings.json file will replaces the app.config and web.config files.
Confiuguration values can be read using IConfiguration object from DI.

[Reference documentation](https://docs.microsoft.com/en-gb/dotnet/core/extensions/configuration)
# Logging

.NET supports a logging API that works with a variety of built-in and third-party logging providers. The default host builder configures the logging services and built-in logging providers.
Logging providers are the target where log information will go/persisted such as console screen, debug window, event viewer, text file)

To create logs, use an ILogger<TCategoryName> object from DI.
Logging configuration is commonly provided by the Logging section of the appsettings.json file.

1. Log Level configuration example configuration

![Graphical user interface, text, application Description automatically generated](5ff5e3a9-304b-4902-8a67-8dc4020fbbb4.002.png)

1. Log Level + Logging Provider example configuration

![Text Description automatically generated](5ff5e3a9-304b-4902-8a67-8dc4020fbbb4.003.png)

Microsoft Extensions includes the following built-in logging providers:

- Console
- Debug
- EventSource
- EventLog

Custom Formatting can be used to structure or add more information in the log content such as timestamp etc.
[Reference documentation](https://docs.microsoft.com/en-gb/dotnet/core/extensions/logging)
