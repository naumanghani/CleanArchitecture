# Technologies
* .Net 5.0
* EF Core 5
* MediatR with CQRS Pattern
* AutoMapper
* FluentValidation
* NUnit, FluentAssertions and Moq 
* AsoNetCore.MVC.Versioning
* Swagger
* SQL Server

# How to run this project
* Open the project in Visual Sutdio 2019
* Change connection string (DefaultConnection) in appsetting.json file for AMPOL.API project.
* Open Package Manager Console from Top Menu bar Tools > Nuget Package Manager > Package Manager Console.
* Run 'update-database' command in inside Package Manager Console it will create a new database sqldb-ampol-test and seed the data provided in specification document (pdf).
* Press F5 to build and run and it will bring swagger UI and expose a POST API and two GET APIs 

## DiscountCalculator POST: /api/v1/DiscountController
This API will calculate discounts and points earned by a shoper in a specific invoice.

## Product GET: /api/v1/Product
This API will return the of products with their discount promotions.

## PointsPromotion GET: /api/v1/PointsPromotion
This API will get all the Promotions to earn points.

## Validations on DiscountCalculator API
* CustomerId should not be empty
* TransationDate should be a valid date
* Bastket should have atleast one product
* ProductId should not be empty
* ProductId should already exist in database

## Unit Tests
* For ProductId in basket
* Calculate Points Earned
* Calculate Total Discount
