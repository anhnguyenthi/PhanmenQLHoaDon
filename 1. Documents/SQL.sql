create database InvoiceManager;
go

use InvoiceManager;
go

create table users(
	id int IDENTITY(1,1) PRIMARY KEY,
	username varchar(100) not null,
	password varchar(100) not null,
	full_name nvarchar(100),
	gender bit,
	phone_number varchar(10),
	address nvarchar(150),
	is_admin bit
);
go

insert into users(username, password, full_name, gender, phone_number, address, id_admin) values('admin', '123456', 'Administrator', 1, '0325485968', '', 1);
go

create table items(
	id int IDENTITY(1,1) PRIMARY KEY,
	name nvarchar(150),
	price float
);
go

create table  invoices(
	id int IDENTITY(1,1) PRIMARY KEY,
	date_value date,
	price float,
	employee_id int foreign key references users(id),
);
go

create table details(
	id int IDENTITY(1,1) PRIMARY KEY,
	invoice_id int foreign key references invoices(id),
	item_id int foreign key references items(id),
	amount int,
);
go

alter table users add is_block bit not null default 'FALSE';
go