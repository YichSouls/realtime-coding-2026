# Station Registry Service

C# · Collections · OOP · CRUD · Easy–Medium

## 1. Background

You're building a small in-memory registry for railway stations.

Each station has a unique code, a name, and a city. Your task is to implement a service that can register, remove, and search stations.

No database, no HTTP API, no external libraries.

## 2. Data model

Create a `Station` class with these properties:

| Property | Type     | Example          |
| -------- | -------- | ---------------- |
| `Code`   | `string` | `"PAR01"`        |
| `Name`   | `string` | `"Gare du Nord"` |
| `City`   | `string` | `"Paris"`        |

Also create a `StationSummary` record containing `Code` and `Name`.

## 3. Service requirements

Create a class called `StationRegistry` implementing the following interface:

```
public interface IStationRegistry
{
    bool AddStation(Station station);

    bool RemoveStation(string code);

    Station? FindByCode(string code);

    List<Station> FindByCity(string city);

    List<StationSummary> GetAllSummaries();

    string[] GetAllCities();
}
```

The registry must initially contain these three stations:

| Code  | Name         | City  |
| ----- | ------------ | ----- |
| PAR01 | Gare du Nord | Paris |
| PAR02 | Gare de Lyon | Paris |
| LYO01 | Part-Dieu    | Lyon  |

### Functional rules

1. AddStation — Add a station. Return `false` if its code already exists; otherwise `true`.
2. RemoveStation — Remove a station by code. Return `true` if found and removed; otherwise `false`.
3. FindByCode — Return the matching station, or `null` if not found.
4. FindByCity — Return all stations in the requested city.
5. GetAllSummaries — Return a list of `StationSummary`, sorted alphabetically by station name.
6. GetAllCities — Return an array of unique city names, sorted alphabetically.

For this exercise, all comparisons of codes and cities must be case-insensitive. The registry must not expose its internal collection directly.

You can assume station objects and their properties are non-null and valid, but you should handle empty search results.

## 4. Acceptance tests

Your implementation should satisfy these examples:

| Operation                                      | Expected result               |
| ---------------------------------------------- | ----------------------------- |
| `AddStation("PAR03", "Montparnasse", "Paris")` | `true`                        |
| Add another station with code `"par03"`        | `false`                       |
| `FindByCode("par01")`                          | Gare du Nord                  |
| `FindByCity("PARIS")`                          | 3 stations after adding PAR03 |
| `RemoveStation("lyo01")`                       | `true`                        |
| Remove `"lyo01"` again                         | `false`                       |
| `GetAllCities()` after removal                 | `["Paris"]`                   |
| `GetAllSummaries()`                            | Sorted by `Name`              |

## 5. Interview rules

Your checklist

0/4

No Copilot or AI code generation

Write and initialize the collections yourself

Compile and run your implementation

Test at least one duplicate and one missing station

Start when you're ready.

Start coding

你可以直接使用：

```
dotnet new console -n StationRegistryExercise
cd StationRegistryExercise
dotnet run
```

提交方式： 把你的完整 C# 代码贴过来，并告诉我实际用了多少分钟、有没有编译通过。

我会按照以下权重给你打分：正确性 40%、C# 语法与集合使用 30%、边界条件 20%、代码可读性 10%，总分 100。

现在开始。我不会提前给出答案。
