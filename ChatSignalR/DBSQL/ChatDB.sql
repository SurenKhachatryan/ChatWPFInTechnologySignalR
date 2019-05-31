Create DataBase ChatDB;
Go

Use ChatDB
Go

Create Table [User]
(
Id int primary key identity,
FirstName nvarchar not null,
LastName nvarchar not null,
LoginName varchar(50) not null Unique,
Email nvarchar(50) not null Unique,
[Password] varchar not null,
IsEmailVerified bit ,
IsDeleted bit,
IsBlocked bit,
LastUpdateDate Date Not null,
CreationDate Date Not null,
BirthDate Date not null
);

Create Table UserSession 
(
Id int primary key Identity,
UserId int references [User](Id),
Token nvarchar Not Null,
CreationDate Date Not Null,
ModificationDate Date Not Null
);