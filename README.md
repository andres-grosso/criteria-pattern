# Criteria Pattern Implementation

## Introduction
This project demonstrates the **Criteria Pattern**, a structural design pattern used to filter objects based on multiple criteria while maintaining flexibility and reusability. It allows the creation of dynamic filtering rules without modifying the core business logic.

## Features
- **Encapsulation of Filtering Logic**: Filters are implemented as separate classes, making them reusable and easy to maintain.
- **Combinable Criteria**: Criteria can be combined using logical operators (AND, OR, NOT).
- **Factory-Based Criteria Creation**: The `CriteriaFactory` centralizes the creation of filtering rules.
- **Fluent Interface for Criteria Composition**: Enhances readability and usability.

## Technologies Used
- C# (.NET)
- LINQ for filtering operations
- Object-oriented principles (Encapsulation, Composition, Factory Pattern)

## Project Structure
```
/ConsoleTest
│── Program.cs         # Entry point of the application
│── CriteriaFactory.cs # Factory to create filtering criteria
│── CriterioMasculinos.cs  # Filters male individuals
│── CriterioFemeninos.cs   # Filters female individuals
│── CriterioSolteros.cs    # Filters single individuals
│── CriterioExtranjeros.cs # Filters foreign individuals
│── Common/              # Common utilities and data structures
```

## How It Works
### Creating Individual Criteria
Each criterion implements the `ICriteria<Person>` interface and applies a specific filter:
```csharp
public class MaleCriteria : ICriteria<Person> {
    public List<Person> MeetCriteria(List<Person> entities) {
        return entities.Where(p => p.Gender == Gender.Male).ToList();
    }
}
```

### Combining Criteria
You can combine multiple criteria using logical operations:
```csharp
ICriteria<Person> male = new MaleCriteria();
ICriteria<Person> foreigner = new ForeignerCriteria();
ICriteria<Person> foreignMales = male.And(foreigner);
```

### Using the Factory for Criteria Selection
Instead of manually instantiating criteria, use `CriteriaFactory` to generate the required filter dynamically:
```csharp
ICriteria<Person> criteria = CriteriaFactory.GetCriteria(CriteriaTypeEnum.ForeignMaleSingle);
List<Person> filteredPeople = criteria.MeetCriteria(personList);
```

## Running the Application
1. Clone this repository.
2. Open the project in Visual Studio or any .NET-compatible IDE.
3. Run the `Program.cs` file.
4. Follow the console output to see different filtering criteria in action.

## Example Output
```
NOW DISPLAYING FOREIGN, MALE, AND SINGLE INDIVIDUALS:
- John Doe (Male, Foreigner, Single)
- Alex Smith (Male, Foreigner, Single)

NOW DISPLAYING FOREIGN AND MALE INDIVIDUALS:
- John Doe (Male, Foreigner)
- Alex Smith (Male, Foreigner)
- Michael Lee (Male, Foreigner)
```

## License
This project is released under the [MIT License](LICENSE).

## Author
Developed by Andrés Grosso in 2010. Feel free to contribute or suggest improvements!

---
🚀 *Happy Coding!*
