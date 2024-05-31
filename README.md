# Repository Pattern

This repository serves as a template for setting up and creating a folder and class structure for Entity Framework Core using the Repository Pattern in Visual Studio. It is designed to help you quickly scaffold a new project with a clean architecture.

## Description

The Repository Pattern is a popular design pattern that abstracts data access logic and provides a more testable and maintainable codebase. This template provides a basic implementation of the pattern, facilitating the development of applications with Entity Framework Core.

## Project Structure

The project structure created by this template is organized as follows:

```plaintext
RepositoryPattern/
├── Abstraction/
│   ├── IDto.cs
│   ├── IEntity.cs
├── Dto/
│   ├── DummyDto.cs
├── Models/
│   ├── DummyModel.cs
├── QueryBuilders/
│   ├── Abstraction/
│   │   ├──  IQueryBuilder.cs
│   │   ├──  QueryBuilder.cs
│   ├── DummyQueryBuilder.cs
├── Repositories/
│   ├── Abstraction/
│   │   ├──  IDummyRepository.cs
│   │   ├──  IQueryableRepository.cs
│   │   ├──  IRepositoryBase.cs
│   ├── Base/
│   │   ├──  QueryableRepository.cs
│   │   ├──  RepositoryBase.cs
│   ├── DummyRepository.cs
├── CustomDbContext.cs
├── Initializer.cs

```
## Installation

To install this template, follow these steps:

1. **Download the ZIP file:**
   Download the template as a ZIP file from the Release Assets on GitHub.

2. **Move the file to the template folder:**
   Save the ZIP file to `%USERPROFILE%\Documents\Visual Studio\Templates\ProjectTemplates`.

3. **Run Visual Studio:**
   Run or restart Visual Studio to load the new template. You should now see the "Repository Pattern" template available when creating a new project.

## Usage

Once the template is installed, you can use it to create a new project in Visual Studio by selecting the "Repository Pattern" template from the list of available templates.

1. Open Visual Studio and select "Create a new project".
2. Search for "Repository Pattern" in the list of project templates.
3. Select the template and follow the prompts to configure your new project.

## License

This project is licensed under a free license, and anyone is free to use it.