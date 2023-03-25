-- ============ DATABASE ===============
create database db_blazorwebapicrud_1

use db_blazorwebapicrud_1

-- ============ TABLES ===============
create table Department (
	departmentId int primary key identity(1,1),
	departmentName varchar(50) not null
)

create table Employee(
	employeeId int primary key identity(1,1),
	employeeName varchar(50) not null,
	departmentId int references Department(departmentId) not null,
	salary int not null,
	contractDate date not null
)

-- ============ INSERTS ===============
insert into Department (departmentName) values
('Management'),
('Commerce'),
('Sales'),
('Marketing')

insert into Employee (employeeName, departmentId, salary, contractDate) values
('John Smith', 1, 2000, getdate())