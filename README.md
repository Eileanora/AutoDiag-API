# AutoDiag

## Introduction

This project was done as a graduation project for the Faculty of Engineering, Suez Canal University.
AutoDiag-API is the backend part of a project that aims to make automotive vehicle diagnostics easier and more efficient.

## What is AutoDiag?

Automotive systems maintenance methods improved over the years, it originally depended on 
manual inspections and periodic maintenance. With technology revolution, it improved in 
the direction of automatic diagnosis in order to save time, money and effort. Existing 
systems focus solely on the diagnosis process and do not provide accompanying services, 
either before or after the diagnosis, limiting the range of possibilities and reducing 
preventive maintenance.

Our project aims to improve existing methods, by providing a broad range of services, and
relying less on the human factor, making the already-existing diagnosis process more efficient, less error prone, and less time consuming.


Our final product is a hardware system and AI Model, supported by web and mobile applications, 
providing an easy-to-use user interface to access all diagnosis information anytime and anywhere.

## Technologies
- ASP.NET Core 8.0
- EF Core
- SQL Server
- Postman and Swagger


## Libraries
- FluentValidation
- Newtonsoft.Json
- Asp.Versioning.Mvc
- Microsoft.IdentityModel.JsonWebTokens (JWT)
- MqttNet


## Documentation
- [API Documentation](https://documenter.getpostman.com/view/31899910/2sA3JFB53V)

## API Endpoints and their functionalities

### CarSystem Endpoints
| Endpoint                 | Method  | Functionality                            |
|--------------------------|---------|------------------------------------------|
| /api/v1/car-systems      | GET     | Get all car systems                      |
| /api/v1/car-systems/{id} | GET     | Get a car system by id                   |
| /api/v1/car-systems      | POST    | Add a new car system                     |
| /api/v1/car-systems/{id} | PATCH   | Update a car system                      |
| /api/v1/car-systems/{id} | DELETE  | Delete a car system                      |
| /api/v1/car-systems      | OPTIONS | Get allowed HTTP methods for car systems |


### CarSystem Collection Endpoints
| Endpoint                                      | Method | Functionality                                |
|-----------------------------------------------|--------|----------------------------------------------|
| /api/v1/carsystemcollections/({carSystemIds}) | GET    | Get a collection of car systems by their IDs |
| /api/v1/carsystemcollections                  | Post   | Create a new collection of car systems       |



### Sensor Endpoints
| Endpoint                                             | Method   | Functionality                                      |
|------------------------------------------------------|----------|----------------------------------------------------|
| /api/v1/car-systems/{carSystemId}/sensors            | GET      | Get all sensors belonging to a specific car system |
| /api/v1/car-systems/{carSystemId}/sensors/{sensorId} | GET      | Get a sensor by id                                 |
| /api/v1/car-systems/{carSystemId}/sensors            | POST     | Add a new sensor                                   |
| /api/v1/car-systems/{carSystemId}/sensors/{sensorId} | PATCH    | Update a sensor                                    |
| /api/v1/car-systems/{carSystemId}/sensors/{sensorId} | DELETE   | Delete a sensor                                    |
| /api/v1/car-systems//sensors/                        | OPTIONS  | Get allowed HTTP methods for sensors               |

### Reading Endpoints
| Endpoint                                                     | Method | Functionality                         |
|--------------------------------------------------------------|--------|---------------------------------------|
| /api/v1/car-systems/{carSystemId}/sensors/{sensorId}/reading | GET    | Get all readings of a specific sensor |


### Fault Endpoints
| Endpoint       | Method | Functionality  |
|----------------|--------|----------------|
| /api/v1/faults | GET    | Get all faults |


### User Endpoints
| Endpoint                    | Method | Functionality            |
|-----------------------------|--------|--------------------------|
| /api/account/register       | POST   | Register a new user      |
| /api/account/login          | POST   | Log in a user            |
| /api/account/changepassword | POST   | Change a user's password |


## Features
- RESTful APIs for a maintainable and scalable backend.
- User Authentication ensuring that only authorized users can access the data of a vehicle.
- Real-time monitoring of vehicle sensors data.
- Vehicle Diagnostics using integration with embedded system.
- Remaining useful life prediction for sensors using integration with AI model.
- Admin Panel to manage sensors and vehicles data more efficiently allowing CRUD operations.
