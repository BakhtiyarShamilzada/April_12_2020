create database P507
use P507
create table Users(
	Id int primary key identity,
	Fullname nvarchar(100) not null,
	Email nvarchar(100) not null unique,
	Password nvarchar(250) not null,
	IsAdmin bit default 0 not null,
	IsActivated bit default 0 not null,
	IsDeleted bit default 0 not null
)