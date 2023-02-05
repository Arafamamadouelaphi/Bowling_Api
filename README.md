[![Build Status](https://codefirst.iut.uca.fr/api/badges/victor_perez.ngounou/BowlingScoreApp/status.svg)](https://codefirst.iut.uca.fr/victor_perez.ngounou/BowlingScoreApp)  
[![Quality Gate Status](https://codefirst.iut.uca.fr/sonar/api/project_badges/measure?project=BowlingScoreApp&metric=alert_status&token=d89d41f6a247037395d41fe6f40f53a402943bd9)](https://codefirst.iut.uca.fr/sonar/dashboard?id=BowlingScoreApp)
[![Bugs](https://codefirst.iut.uca.fr/sonar/api/project_badges/measure?project=BowlingScoreApp&metric=bugs&token=d89d41f6a247037395d41fe6f40f53a402943bd9)](https://codefirst.iut.uca.fr/sonar/dashboard?id=BowlingScoreApp)
[![Code Smells](https://codefirst.iut.uca.fr/sonar/api/project_badges/measure?project=BowlingScoreApp&metric=code_smells&token=d89d41f6a247037395d41fe6f40f53a402943bd9)](https://codefirst.iut.uca.fr/sonar/dashboard?id=BowlingScoreApp)
[![Coverage](https://codefirst.iut.uca.fr/sonar/api/project_badges/measure?project=BowlingScoreApp&metric=coverage&token=d89d41f6a247037395d41fe6f40f53a402943bd9)](https://codefirst.iut.uca.fr/sonar/dashboard?id=BowlingScoreApp)  
[![Duplicated Lines (%)](https://codefirst.iut.uca.fr/sonar/api/project_badges/measure?project=BowlingScoreApp&metric=duplicated_lines_density&token=d89d41f6a247037395d41fe6f40f53a402943bd9)](https://codefirst.iut.uca.fr/sonar/dashboard?id=BowlingScoreApp)
[![Lines of Code](https://codefirst.iut.uca.fr/sonar/api/project_badges/measure?project=BowlingScoreApp&metric=ncloc&token=d89d41f6a247037395d41fe6f40f53a402943bd9)](https://codefirst.iut.uca.fr/sonar/dashboard?id=BowlingScoreApp)
[![Maintainability Rating](https://codefirst.iut.uca.fr/sonar/api/project_badges/measure?project=BowlingScoreApp&metric=sqale_rating&token=d89d41f6a247037395d41fe6f40f53a402943bd9)](https://codefirst.iut.uca.fr/sonar/dashboard?id=BowlingScoreApp)
[![Reliability Rating](https://codefirst.iut.uca.fr/sonar/api/project_badges/measure?project=BowlingScoreApp&metric=reliability_rating&token=d89d41f6a247037395d41fe6f40f53a402943bd9)](https://codefirst.iut.uca.fr/sonar/dashboard?id=BowlingScoreApp)  
[![Security Rating](https://codefirst.iut.uca.fr/sonar/api/project_badges/measure?project=BowlingScoreApp&metric=security_rating&token=d89d41f6a247037395d41fe6f40f53a402943bd9)](https://codefirst.iut.uca.fr/sonar/dashboard?id=BowlingScoreApp)
[![Technical Debt](https://codefirst.iut.uca.fr/sonar/api/project_badges/measure?project=BowlingScoreApp&metric=sqale_index&token=d89d41f6a247037395d41fe6f40f53a402943bd9)](https://codefirst.iut.uca.fr/sonar/dashboard?id=BowlingScoreApp)
[![Vulnerabilities](https://codefirst.iut.uca.fr/sonar/api/project_badges/measure?project=BowlingScoreApp&metric=vulnerabilities&token=d89d41f6a247037395d41fe6f40f53a402943bd9)](https://codefirst.iut.uca.fr/sonar/dashboard?id=BowlingScoreApp)  
 
 
# Bowling Score API


<img src="Documentation/doc_images/bowling-157933.png" height=40/>   

## Description

Cette API fournit des services pour gérer les scores d'un jeu de bowling.
Elle permet de créer des joueurs, des parties et de gérer les scores de chaque joueur pour chaque partie.
Elle permet également de consulter les scores de chaque joueur pour chaque partie.
Le projet est développé en C# avec le framework .NET Core 6.0.
la documentation de l'API est disponible à l'adresse suivante : https://codefirst.iut.uca.fr/swagger/index.html
et est constituée de 2 API (API RestFull et GraphQL) qui qui sont manager par une API Gateway.


## Installation

### Requirements

* C# 10.0
* .NET Core 6.0
* Visual Studio 2022
* Entity Framework Core 6.0
* SQLite 3.36.0
* xUnit 2.4.1

### Clone

Clone this repo to your local machine using 'https://codefirst.iut.uca.fr/git/victor_perez.ngounou/ApiBowlingProject.git'

* [Git](https://git-scm.com) - Download and Install Git.
* [Visual Studio](https://visualstudio.microsoft.com/fr/) - Download and Install Visual Studio.
* [SQLite](https://www.sqlite.org/index.html) - Download and Install SQLite.
* [xUnit](https://xunit.net/) - Download and Install xUnit.
* [Entity Framework Core](https://docs.microsoft.com/fr-fr/ef/core/) - Download and Install Entity Framework Core.

### Install Entity Framework Core Tools

```shell
$ dotnet tool install --global dotnet-ef
```

### Setup

* Ouvrir le projet dans Visual Studio.
* Configurer l'exécution de l'application en mode "Multiple startup projects" et sélectionner les projets suivants :
    * BowlingApi
    * Bowling Api Gateway
    * GraphQL Project
* Build le projet.
* L'application est prête à être utilisée.

## Usage

* Open the solution in Visual Studio 2022
* Build the solution
* Run the application

## Contributeurs

* [Victor Perez NGOUNOU](https://codefirst.iut.uca.fr/git/victor_perez.ngounou)
* [Mamadou Elaphi ARAFA](https://codefirst.iut.uca.fr/git/mamadou_elaphi.arafa)


## Support

Contactez-moi à l'un des endroits suivants !

* Website at <a href="https://codefirst.iut.uca.fr/git/victor_perez.ngounou" target="_blank">`https://codefirst.iut.uca.fr/git/victor_perez.ngounou`</a>
* Email at <a href="mailto:victor_perez.ngounou@etu.uca.fr" target="_blank">`victor_perez.ngounou@etu.uca.fr`</a>

## License

[![License](https://codefirst.iut.uca.fr/sonar/api/project_badges/measure?project=BowlingScoreApp&metric=license&token=d89d41f6a247037395d41fe6f40f53a402943bd9)](https://codefirst.iut.uca.fr/sonar/dashboard?id=BowlingScoreApp)

- **[MIT license](http://opensource.org/licenses/mit-license.php)**