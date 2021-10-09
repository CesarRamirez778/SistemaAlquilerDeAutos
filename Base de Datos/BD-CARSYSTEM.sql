use master	

Create DataBases CarSystem

use  CarSystem

-- TABLES

Create table Users(
UserID INT identity(1,1) primary Key,
LoginName nvarchar(100) unique not null,
Password Nvarchar (100) not null,
FirstName nvarchar(100) not null,
LastName nvarchar (100) not null,
Position nvarchar(100) not null,
Email nvarchar (150) not null
)

Insert into Users values ('cesar.ramirez778','nomercy778','Cesar','Ramirez','Soporte','ramirezcesar653@gmail.com')
Insert into Users values ('empleado','123','Empleado','empleado','empleado','empleado@gmail.com')
Insert into Users values ('admin','123','Admin','admin','Administrador','administrator@gmail.com')



Declare @user nvarchar(100)='admin'
Declare @pass nvarchar(100) ='123'

select*from Users where LoginName=@user and Password=@pass

