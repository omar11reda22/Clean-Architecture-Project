# clean-architecture
# Applicant Management System
# Overview
The Applicant Management System is a comprehensive application designed to streamline the process of handling applicant data. This system allows users to submit applicant details, including resumes and cover letters, which are then stored on the server and recorded in a database. The project is structured following the principles of Clean Architecture, ensuring a clear separation of concerns and facilitating maintainability and scalability.

# Features
Clean Architecture: The application is built using Clean Architecture principles, ensuring a clear separation between different layers of the application.
File Upload: Allows users to upload resumes and cover letters, which are saved on the server.
CQRS and Mediator Pattern: Utilizes CQRS (Command Query Responsibility Segregation) and the Mediator pattern to manage the application's flow and ensure a clean separation of concerns.
Entity Management: Manages various entities such as applicants, universities, and majors.
Windows Forms Client: Includes a Windows Forms application as the user interface for data entry and submission.
RESTful API: Provides a set of RESTful APIs for interacting with the system programmatically.

# Project Structure
The project is divided into several layers, each with its own responsibility:

1-Domain Layer: Contains the core business logic and entities.
2-Application Layer: Handles application-specific logic, including commands, queries, and handlers.
3-Infrastructure Layer: Manages data access, external services, and file storage.
4-Presentation Layer: Provides the user interface for the application[windosform].
5-Driver Layer: Implements APIs and controllers for handling HTTP requests.

# Getting Started
Prerequisites
.NET Core SDK
SQL Server or any other compatible database
Visual Studio or any other C# compatible IDE


# Installation
1-Clone the Repository: git clone https://github.com/omar11reda22/applicant-management-system.git
2-Navigate to the Project Directory: cd applicant-management-system
3-Build the Project:dotnet build
4-Update the Database:dotnet ef database update
5-Run the Application:dotnet run

# Usage
# Starting the Backend
1-Navigate to the API project directory.
2-Run the backend server using: dotnet run


# Using the Windows Forms Application
1-Open the Presentation project in your IDE.
2-Run the application.
3-Fill in the applicant's details in the form provided.
4-Select the resume and cover letter files.
5-Click the submit button to send the data to the backend.

# API Endpoints
POST /api/Applicant: Adds a new applicant. Requires applicant details and files in the request body.
GET /api/GetData/majors: Retrieves a list of all majors.
GET /api/GetData/universities: Retrieves a list of all universities.

# Contributing
Contributions are welcome! If you have suggestions or improvements, please:

1-Fork the repository.
2-Create a new branch (git checkout -b feature/your-feature-name).
3-Commit your changes (git commit -m 'Add some feature').
4-Push to the branch (git push origin feature/your-feature-name).
5-Open a pull request.

#Flow Chart to project : 
1-UI Layer (Windows Forms)

User interacts with the application.
User inputs data (name, email, message, experience, workplace, major, university, resume file, cover letter file).
2-UI Layer Actions

HTTP GET to fetch majors and universities.
Populate combo boxes with fetched data.
On form submission, create an ApplicantDTO with user input data.
3-API Layer (ASP.NET Core)

Receives HTTP POST request with ApplicantDTO and file uploads.
Controller routes request to the appropriate command handler.
4-Application Layer

Command Handler:
Processes ApplicantDTO.
Validates data.
Interacts with Infrastructure Layer to save data and files.
Queries to retrieve data as needed.
5-Infrastructure Layer

Repository:
Interacts with MyContext to persist data to the database.
FileStorageService:
Handles file uploads, saving the resume and cover letter to the specified location.
6-Domain Layer

Defines the core business entities (e.g., Applicant).
Contains business rules and logic.
7-Data Persistence

MyContext (EF Core context):
Manages database connections.
Maps domain entities to database tables.
8-Response Handling

Application Layer responds to API Layer with success or error messages.
API Layer sends the response back to the UI Layer.
UI Layer updates the user with the result (e.g., success message or error alert).

# Contact
For any questions or further information, feel free to contact the project maintainers.

Thank you for using the Applicant Management System. We hope it serves your needs well!




















