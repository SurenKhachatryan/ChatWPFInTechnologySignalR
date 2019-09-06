Create DataBase ChatDB;
Go

Use ChatDB
Go

Create Table [Role]
(
Id int identity primary key,
[Name] nvarchar(255) Unique not null
);

Create table [Permission]
(
Id int identity Primary key,
[Name] nvarchar(255) not null Unique,
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
Id int Primary key,
[Key] nvarchar(255) Unique not null,
[Translation] nvarchar(max) not null
)

Create Table [User]
(
Id int primary key identity,
FirstName nvarchar(255) not null,
LastName nvarchar(255) not null,
LoginName varchar(255) not null Unique,
Email nvarchar(255) not null Unique,
[Password] varchar(1000) not null,
IsEmailVerified bit ,
IsDeleted bit,
IsBlocked bit,
LastUpdateDate DATETIME2 Not null,
CreationDate DATETIME2 Not null,
BirthDate DATETIME2 not null,
RoleId int references [Role](Id) on Delete Cascade null
);

Create Table UserSession 
(
Id int primary key Identity,
Token nvarchar(255) Not Null,
CreationDate DATETIME2 Not Null,
ModificationDate DATETIME2 Not Null,
UserId int references [User](Id) on Delete Cascade
);

Create Table AppSettings
(
Id int identity Primary Key,
[Name] nvarchar(255) Unique not null,
[Value] nvarchar(max) not null
);

Insert into Error Values 
(1 , 'GeneralError' , '{"ru":"Общая ошибка","en":"General Error"}'),
(2 , 'UserAlreadyExists' , '{"ru":"Пользователь уже существует","en":"User Already Exists"}'),
(3 , 'UserNotFound' , '{"ru":"Пользователь не найден","en":"User Not Found"}'),
(4 , 'UserWithThatEmailAlreadyExists' , '{"ru":"Пользователь с таким электронной почты уже существует","en":"User With That Email Already Exists"}'),
(5 , 'UserIsBlocked' , '{"ru":"Пользователь заблокирован","en":"User Is Blocked"}'),
(6 , 'UserIsDeleted' , '{"ru":"Пользователь удален","en":"User Is Deleted"}'),
(7 , 'UserHasNotBeenVerified' , '{"ru":"Пользователь не подтвердил e-mail","en":"User Has Not Been Verified"}'),
(8 , 'IncorrectPasswordOrUsername' , '{"ru":"Неверный пароль или имя пользователя","en":"Incorrect Password Or Username"}'),
(9 , 'UnAuthorized' , '{"ru":"Неразрешенный","en":"UnAuthorized"}'),
(10 , 'SessionExpired' , '{"ru":"Сессия истекла","en":"Session Expired"}')