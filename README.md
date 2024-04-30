
# C# Dotnet core application to store Food & Drug Administration data to in-memory database

Welcome to the **C# Dotnet core application to store Food & Drug Administration data to in-memory database** assessment test! In this assessment, you will be given task to fetch the data from the url and store it in the in-memory by following the best coding practices, good project structure, applying SOLID principles, and writing test case.

## Getting Started

### Prerequisites

##### 1. Visual Studio any version or Visual Studio Code
##### 2. Microsoft .NET Core 6 
##### 3. Install required nuget package to perform this task  

Link for .Net 6 download (https://dotnet.microsoft.com/download)

## Getting Started

To begin the assessment, follow these steps:

### Steps to run

- Restore packages
- Build the whole solution
- In Solution Explorer, make sure that CodingAssessment is selected as the Startup Project
- In Visual Studio, press "Control + F5" or Run the program using command line

## Assessment Tasks

This application is fetching the data from the "openFDA" api ([https://api.fda.gov/food/enforcement.json?limit=10](https://api.fda.gov/food/enforcement.json?limit=10)). 

 1. You need to store the data in the in-memory database. Note: You can store 50 to 500 data as per your choice.
 2. After storing data to the memory, create an api to return the json list of the data stored in the memory. This api should have pagination.
 3. Write unit test case for all the controllers and methods and try to achieve maximum code coverage. 
 4. Optimize the code, follow best coding practices, maintain good project structure, applying SOLID principles.

We will measure below points while reviewing of your code:

1. **Code Quality**: Review the existing codebase and identify areas for improvement in terms of code quality, readability, project structuring and maintainability. Apply coding standards, conventions, and best practices to enhance the overall quality of the code. 

2. **SOLID Principles**: Apply SOLID principles (Single Responsibility, Open/Closed, Liskov Substitution, Interface Segregation, Dependency Inversion) to refactor the codebase where necessary. Ensure that each component and module adheres to these principles to promote better design and extensibility.

3. **Test Coverage**: Write test case using a testing framework such as NUnit or XUnit to test critical components, functions, and endpoints of the application. Cover both positive and negative test cases to ensure robustness and reliability.

4.   **Error handling and logging:**  Implement proper error handling and logging mechanisms to capture and handle database-related errors. Catch and handle exceptions during database operations, and log relevant information for troubleshooting and auditing purposes.

5. **Task achievement**: We will measure the level of task completed within given criteria.

## Submission Guidelines

Once you have completed the tasks, submit your solution by sending mail within 24 hours. Include a detailed description of the changes made, rationale behind your decisions, and any challenges faced during the process.

## Feedback and Support

If you have any questions, concerns, or need assistance during the assessment, feel free to reach out to us.