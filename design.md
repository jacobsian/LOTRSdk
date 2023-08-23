This is a simple SDK designed to support communications with the LOTR API.

Public components include:
- Extension method to load the SDK into the system for use.
- Service classes which drive the communication to the underlying APIs
- Strongly typed models for consumption by SDK consumers


```mermaid
classDiagram
    class Movie{
      +String Id
      +String Name
      +int RuntimeInMinutes
      +decimal BudgetInMillions
      +decimal BoxOfficeRevenueInMillions
      +int AcademyAwardNominations
      +int AcademyAwardWins
      +decimal RottenTomatoesScore
    }
    class Quote{
        +String Id
        +String Dialog
        +String Movie
        +String Character
    }
    class QuoteList{
        +List~Quote~ Docs
    }    
    class MovieList{
        +List~Quote~ Docs
    }
    class MovieService{
        -HttpClient _httpClient
        -ILogger~MovieService~ _logger
        +GetMovieAsync() Task~IList~Movie~~
    } 
    class QuoteService{
        -HttpClient _httpClient
        -ILogger~QuoteService~ _logger
        +GetQuoteAsync() Task~IList~Movie~~
        +GetMovieQuotes() Task~IList~Movie~~
    } 

    class SDKExtensions{
        +AddLOTR()$ IServiceCollection
    }

    note for MovieList "Internal class supports deserialization"
    note for QuoteList "Internal class supports deserialization"

    Movie --o MovieList
    Quote --o QuoteList
    QuoteList -- QuoteService
    MovieList -- MovieService


   

```
