# Property Brands
Pre-interview API project.

## Dev Environment Installation Tips
- The projects use the latest .NET Core 2.2 libraries. Make sure you have this installed before loading the solution.
- When the solution loads it will complain about Newtonsoft.Json and RestSharp. Just add the missing packages and you should be good to go.
- Make sure to run the migration in the WeatherDataDal project to create the database.

## Pre-interview project requirements.
- Create an application that will track current weather measurements for a given set of zip codes
- Store the following data at a minimum:
  - Zip code,
  - General weather conditions (e.g. sunny, rainy, etc.),
  - Atmospheric pressure,
  - Temperature (in Fahrenheit),
  - Winds (direction and speed),
  - Humidity,
  - Timestamp (in UTC)

- There is no output requirement for this application, it is data retrieval and storage only
- The application should be able to recover from any errors encountered
- The application should be developed using a TDD approach. 100% code coverage is not required
- The set of zip codes and their respective retrieval frequency should be contained in configuration file
- Use the OpenWeatherMap API for data retrieval (https://openweathermap.org)

## Reasoning Behind Design Decisions
- After looking at the requirements and the Job Description, this looked like a perfect place to implement an Azure Function using a Timer trigger. This would allow the data retrieval to run serverless on Azure and do its work on a timed interval.
- To store the data, I choose to use an Entity Framework Core DAL to handle all the model definitions and CRUD operations. I made use of Code-First to create the database and Model-First for small changes to the tables.

## Things I Learned
- Best practices for unit testing Azure Functions.
- A better in-depth understanding of the Moq Mocking Framework.
