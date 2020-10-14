# DickinsonBros.Redactor

<a href="https://dev.azure.com/marksamdickinson/dickinsonbros/_build/latest?definitionId=37&amp;branchName=master"> <img alt="Azure DevOps builds (branch)" src="https://img.shields.io/azure-devops/build/marksamdickinson/DickinsonBros/37/master"> </a> <a href="https://dev.azure.com/marksamdickinson/dickinsonbros/_build/latest?definitionId=37&amp;branchName=master"> <img alt="Azure DevOps coverage (branch)" src="https://img.shields.io/azure-devops/coverage/marksamdickinson/dickinsonbros/37/master"> </a><a href="https://dev.azure.com/marksamdickinson/DickinsonBros/_release?_a=releases&view=mine&definitionId=18"> <img alt="Azure DevOps releases" src="https://img.shields.io/azure-devops/release/marksamdickinson/b5a46403-83bb-4d18-987f-81b0483ef43e/18/19"> </a><a href="https://www.nuget.org/packages/DickinsonBros.Redactor/"><img src="https://img.shields.io/nuget/v/DickinsonBros.Redactor"></a>

A redactor that can take a json string or an object and return a redacted string in json.

Features
* Configurable properties to redact by name
* Configurable regular expressions to validate against 
* Sperate abstractions library to reduce coupling of packages.

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

var redactorServiceOptions = new RedactorServiceOptions
{
    PropertiesToRedact = new string[] { "Password" },
    RegexValuesToRedact = new string[] { "Bearer" },
};

var options = Options.Create(redactorServiceOptions);

var redactorService = new RedactorService(options);
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
