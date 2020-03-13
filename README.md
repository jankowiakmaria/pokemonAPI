## Pokemon API
It's a code test writtent in ASP .NET Core 3.1, C#.

## Prerequisites
In order to run the code locally you should have installed:
* appropriate .NET Core version; for the download see [microsoft website](https://dotnet.microsoft.com/download).
* **[optional]** git (to clone the project or you can simply download from the github website).

## Instructions

You could open the solution directly in Visual Studio and run the solution (or tests) from there or you could do it from the command line.

Clone the project:
```sh
$ git clone git@github.com:jankowiakmaria/pokemonAPI.git
```

Build and run (from the project directory):
```sh
$ dotnet build
$ dotnet run --project .\PokemonAPI\PokemonAPI.csproj
```

Run tests:
```sh
$ dotnet test
```

### Future developement
If I wanted to spend more time on this project I would:
* extract and improve exception handler
* add resiliency policies to http clients (retry, circuit breaker)
* add view for displaying the result - at the moment ShakespearePokemon is not used for anything else other than container for data, so I haven't added view, but in general it's a good practice - to make sure the internal representation is not exposed publicly
* improve logging
* introduce E2E tests