# Queo.Commons.Checks

[![Build Status](https://dev.azure.com/queo-commons/Commons-OpenSource/_apis/build/status%2FqueoGmbH.csharp-commons.checks?branchName=main)](https://dev.azure.com/queo-commons/Commons-OpenSource/_build/latest?definitionId=2&branchName=main) [![Build Status](https://dev.azure.com/queo-commons/Commons-OpenSource/_apis/build/status%2FqueoGmbH.csharp-commons.checks?branchName=develop)](https://dev.azure.com/queo-commons/Commons-OpenSource/_build/latest?definitionId=2&branchName=develop)

## Description
Queo.Commons.Checks provides methods for checking required conditions.

## How to use it
- Include Nuget-Package (queo.commons.checks)

```csharp
<PackageReference Include="Queo.Commons.Checks" Version="3.0.0" />
```

- Add following code to class or file where you want to use the `Check` class:
```csharp
using Queo.Commons.Checks;
[...]
Require.NotNull(name, nameof(name));
```
