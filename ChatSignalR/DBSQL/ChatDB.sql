Create DataBase ChatDB;
Go

Use ChatDB
Go

Create Table [Role]
(
Id int identity primary key,
[Name] nvarchar(100) Unique not null
);

Create table [Permission]
(
Id int identity Primary key,
[Name] nvarchar(200) not null Unique,
[Description] nvarchar null,
[Action] nvarchar not null
);

Create Table RolePermission
(
Id int identity Primary Key,
RoleId int references [Role](Id) on Delete Cascade not null,
PermissionId int references [Permission](Id) on Delete Cascade not null
);

Create table Error
(
Id int identity Primary key,
[Key] nvarchar(200) Unique not null,
[Translation] nvarchar(max) not null
)

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
BirthDate Date not null,
RoleId int references [Role](Id) on Delete Cascade null
);

Create Table UserSession 
(
Id int primary key Identity,
Token nvarchar Not Null,
CreationDate Date Not Null,
ModificationDate Date Not Null,
UserId int references [User](Id) on Delete Cascade
);

Create Table AppSettings
(
Id int identity Primary Key,
[Name] nvarchar(200) Unique not null,
[Value] nvarchar(max) not null
);