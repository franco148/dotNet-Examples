# ENTITY FRAMEWORK
#### Repository Pattern:
- Mediates between the domain and data mapping layers, acting like an in-memory collection of domain objects.

##### Benefits
- Minimizes duplicate query logic

###### Example:
Imagine in a few different places in our application we need to get the first five top selling courses in a given category without the repository pattern will end up duplicating this query logic over and over in different places in situations like the following.

```c#
var topSellingCourses = context.Courses
.Where(c => c.IsPublic && c.IsApproved)
.OrderByDescending(c => c.Sales)
.Take(10);
```

In previous situations, We can encapsulate this logic in a repository and simply call a method like get top selling courses.

```c#
var courses = repository.GetTopSellingCourses(category, count);
```

- Decouples your application from persistence frameworks
- Promotes testability
- A repository should not have the semantics of your database.

How we are going to save the changes?

#### Unit of Work pattern:
- Maintain a list of objects affected by a business transaction and coordinates the writting out of changes.

###### Clean architecture
An architecture should be independent of frameworks.



