# DickinsonBros.Redactor

A redactor that can take a json string or an object and return a redacted string in json.

Features
* Configurable properties to redact by name
* Configurable regular expressions to validate against 
* Sperate abstractions library to reduce coupling of packages.

<a href="https://dev.azure.com/marksamdickinson/DickinsonBros/_build?definitionScope=%5CDickinsonBros.Redactor">Builds</a>

<h2>Example Usage</h2>

```C#

var input =
@"{
  ""Password"": ""password""
}";
Console.WriteLine($"Raw Json: \r\n {input}");
Console.WriteLine($"Redacted Json: \r\n { redactorService.Redact(input)}");

```

```
Raw Json:
{
  "Password": "password"
}
Redacted Json:
{
  "Password": "***REDACTED***"
}
```

Example Runner Included in folder "DickinsonBros.Redactor.Runner"

<h2>Setup</h2>

<h3>Add Nuget References</h3>

    https://www.nuget.org/packages/DickinsonBros.Redactor/
    https://www.nuget.org/packages/DickinsonBros.Redactor.Abstractions

<h3>Create Instance</h3>

```C#    
using DickinsonBros.Redactor;

...

var redactorService = new RedactorService()
```

<h3>Create Instance (With Dependency Injection)</h3>

<h4>Add appsettings.json File With Contents</h4>

 ```json  
{
  "RedactorServiceOptions": {
    "PropertiesToRedact": [
      "Password"
    ],
    "RegexValuesToRedact": []
  }
}
 ```    
 
<h4>Code</h4>

```C#        
using DickinsonBros.Redactor.Abstractions;
using DickinsonBros.Redactor.Extensions;

...  

var services = new ServiceCollection();   

//Configure Options
var builder = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", false)

var configuration = builder.Build();
serviceCollection.AddOptions();
serviceCollection.Configure<RedactorServiceOptions>(_configuration.GetSection(nameof(RedactorServiceOptions)));

//Add Service
serviceCollection.AddRedactorService();

//Build Service Provider 
using (var provider = services.BuildServiceProvider())
{
   var redactorService = provider.GetRequiredService<IRedactorService>();
}
```    
