# _Change Maker_

#### _A C# web application for a salon , 18-October-2019_

#### By _**Jason Huels**_

## Description

_A C# web application for a salon that allows the owner to add/edit/remove stylists/clients from a mysql database._

## Specifications

| Behavior | Input | Output|
|:------|:---------:|:------:|

## Setup/Installation Requirements_

* _Clone this repository_
* _Using MySQL:_
    * _CREATE DATABASE jason_huels;_
    * _USE jason_huels;_
    * _CREATE TABLE stylists (stylistID int(11) NOT NULL AUTO_INCREMENT PRIMARY KEY, name VARCHAR(255), specialty VARCHAR(255));_
    * _CREATE TABLE clients (clientID int(11) NOT NULL AUTO_INCREMENT PRIMARY KEY, name VARCHAR(255), stylistID int(11) DEFAULT '0');_
* _Navigate to the directory_
* _Run "dotnet run" command to open application in the command console_

## Known Bugs

* N/A

## Support and contact details

_jasonhuels@yahoo.com_

## Technologies Used

_C#, ASP.NET, MySQL, Entity_

### License

*open source*

Copyright (c) 2019 **_Jason Huels_**