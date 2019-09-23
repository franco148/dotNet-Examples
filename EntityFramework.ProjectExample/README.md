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

##### Implementation
- Create IRepository, so it has methods like ADD, REMOVE, GET, and FIND again here we are not going to have UPDATE or SAVE. 
```json
IRepository

Add()
Remove()
Get(id)
Find(predicate)
```
Next we are going to implement this interface in a class called ```Repository```. Inside this repository we are going to have a DB Context, a generic context. So what we can see here, it is completely generic. It is nothing to do with our application, we can reuse this interface and the concrete implementation of it in any applications. In context of our application we're going to have a repository for each entity.

So for a course entity we are going to have an interface called ```ICourseRepository```, in this interface we are going to define any operations specific to courses that are not in our generic repository. For example methods like ```GetTopSellingCourses```, ```GetCoursesWithAuthors``` or another method which uses eager loading to load the courses and their answers.

So there is one of the key things here, anything to do with eager loading or explicit loading is data access concern, your application code, your businesss logic should not care how this is done. This is the implementation details that should happen inside a repository.

Your business logic layer, your services simply tell the repository give me courses and their authors, and the repository works out how it should be done.

Here ```ICourseRepository``` just declares the contract, so we need to implement it in a class like ```CourseRepository```. So in our implementation ```CourseRepository``` derives from our generic repository because a lot of our data access code is similar but it also additionally implements of ```ICourseRepository``` Interface. So it is going to have implementations for these two methods you see on the right side.


How we are going to save the changes?

#### Unit of Work pattern:
- Maintain a list of objects affected by a business transaction and coordinates the writting out of changes.

###### Clean architecture
An architecture should be independent of frameworks.

##### Implementation

