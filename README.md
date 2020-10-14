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

[Sample Runner](https://github.com/msdickinson/DickinsonBros.Redactor/tree/master/DickinsonBros.Redactor.Runner)
