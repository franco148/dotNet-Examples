# ASP NET MVC Concepts

ActionResult: This is like a general object of results. The specific ones would be.

	TYPE						HELPER METHOD
- ViewResult 				- 	View()
- PartialViewResult			-	PartialView()
- ContentResult				- 	Content()					: Simple text
- RedirectResult			-	Redirect()
- RedirectToRouteResult		-	RedirectToAction()
- JsonResult				-	Json()
- FileResult				-	File()
- HttpNotFoundResult		-	HttpNotFound()
- EmptyResult				- 	When action is not going to return any value, like VOID.



Attribute Routes:
- :regex
- :range
- :minlenght
- :maxlenght
- :int
- :float
- :guid


# Package Manager Cmdlets

```

Each package is licensed to you by its owner. Microsoft is not responsible for, nor does it grant any licenses to, third-party packages. Some packages may include dependencies which are governed by additional licenses. Follow the package source (feed) URL to determine any dependencies.

Package Manager Console Host Version 2.12.0.817

Type 'get-help NuGet' to see all available NuGet commands.

PM> enable-migrations
Checking if the context targets an existing database...
Code First Migrations enabled for project MovieShop.
PM> add-migration InitialModel
Scaffolding migration 'InitialModel'.
The Designer Code for this migration file includes a snapshot of your current Code First model. This snapshot is used to calculate the changes to your model when you scaffold the next migration. If you make additional changes to your model that you want to include in this migration, then you can re-scaffold it by running 'Add-Migration InitialModel' again.
PM> add-migration InitialModel -force
Re-scaffolding migration 'InitialModel'.
PM> update-database
Specify the '-Verbose' flag to view the SQL statements being applied to the target database.
Applying explicit migrations: [201712040245355_InitialModel].
Applying explicit migration: 201712040245355_InitialModel.
Running Seed method.
PM> add-migration AddIsSubscribedToCustomer
Scaffolding migration 'AddIsSubscribedToCustomer'.
The Designer Code for this migration file includes a snapshot of your current Code First model. This snapshot is used to calculate the changes to your model when you scaffold the next migration. If you make additional changes to your model that you want to include in this migration, then you can re-scaffold it by running 'Add-Migration AddIsSubscribedToCustomer' again.
PM> Update-Database
Specify the '-Verbose' flag to view the SQL statements being applied to the target database.
Applying explicit migrations: [201712040302513_AddIsSubscribedToCustomer].
Applying explicit migration: 201712040302513_AddIsSubscribedToCustomer.
Running Seed method.
PM> add-migration AddMembershipType
Scaffolding migration 'AddMembershipType'.
The Designer Code for this migration file includes a snapshot of your current Code First model. This snapshot is used to calculate the changes to your model when you scaffold the next migration. If you make additional changes to your model that you want to include in this migration, then you can re-scaffold it by running 'Add-Migration AddMembershipType' again.
PM> Update-Database
Specify the '-Verbose' flag to view the SQL statements being applied to the target database.
Applying explicit migrations: [201712040308124_AddMembershipType].
Applying explicit migration: 201712040308124_AddMembershipType.
Running Seed method.
PM> add-migration PopulateMembershipTypes
Scaffolding migration 'PopulateMembershipTypes'.
The Designer Code for this migration file includes a snapshot of your current Code First model. This snapshot is used to calculate the changes to your model when you scaffold the next migration. If you make additional changes to your model that you want to include in this migration, then you can re-scaffold it by running 'Add-Migration PopulateMembershipTypes' again.
PM> Update-Database
Specify the '-Verbose' flag to view the SQL statements being applied to the target database.
Applying explicit migrations: [201712040310148_PopulateMembershipTypes].
Applying explicit migration: 201712040310148_PopulateMembershipTypes.
Running Seed method.
PM> add-migrations ApplyAnnotationsToCustomerName
add-migrations : The term 'add-migrations' is not recognized as the name of a cmdlet, function, script file, or operable program. Check the spelling of the name, or if a path was included, verify that the path is correct and try again.
At line:1 char:1
+ add-migrations ApplyAnnotationsToCustomerName
+ ~~~~~~~~~~~~~~
    + CategoryInfo          : ObjectNotFound: (add-migrations:String) [], CommandNotFoundException
    + FullyQualifiedErrorId : CommandNotFoundException
 
PM> add-migration ApplyAnnotationsToCustomerName
Scaffolding migration 'ApplyAnnotationsToCustomerName'.
The Designer Code for this migration file includes a snapshot of your current Code First model. This snapshot is used to calculate the changes to your model when you scaffold the next migration. If you make additional changes to your model that you want to include in this migration, then you can re-scaffold it by running 'Add-Migration ApplyAnnotationsToCustomerName' again.
PM> Updata-Database
Updata-Database : The term 'Updata-Database' is not recognized as the name of a cmdlet, function, script file, or operable program. Check the spelling of the name, or if a path was included, verify that the path is correct and try again.
At line:1 char:1
+ Updata-Database
+ ~~~~~~~~~~~~~~~
    + CategoryInfo          : ObjectNotFound: (Updata-Database:String) [], CommandNotFoundException
    + FullyQualifiedErrorId : CommandNotFoundException
 
PM> Update-Database
Specify the '-Verbose' flag to view the SQL statements being applied to the target database.
Applying explicit migrations: [201712040321174_ApplyAnnotationsToCustomerName].
Applying explicit migration: 201712040321174_ApplyAnnotationsToCustomerName.
Running Seed method.
PM> 

```

#Data Annotations
- [Required]
- [StringLength(255)]
- [Range(1, 10)]
- [Compare("OtherProperty")]
- [Phone]
- [EmailAddress]
- [Url]
- [RegularExpression("...")]

#Cross-site Request Forgery (CSRF)
- To ensure that the request comes only from our application form.

# CODE SNIPETS
- prop tab
- mvcaction4 tab
