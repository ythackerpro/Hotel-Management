use master 
go
alter database myHotel set single_user with rollback immediate


DROP database myHotel

create database myHotel
go
use myHotel
go
--use table myHotel-ROOM



create table rooms(
roomid int Identity(1,1) primary key,
roomNo varchar(250) not null unique,
roomType varchar(250) not null,
bed int not null,
price bigint not null,
booked varchar(50) default 'NO'
);

create table customer(
cid int Identity(1,1) primary key,
cname varchar(250) not null,
mobile bigint not null,
nationality varchar(250) not null,
gender varchar(50) not null,
dob varchar(50) not null,
idproof varchar(250) not null,
--address varchar(350) not null,
checkin varchar(250) not null,
checkout varchar(250),
chekout varchar(250) not null default 'NO',
roomid int not null,
foreign key (roomid) references rooms(roomid)

);

create table employee(
eid int identity(1,1) primary key,
ename varchar(250) not null,
mobile bigint not null,
gender varchar(50) not null,
emailid varchar(120) not null,
username varchar(150) not null,
pass varchar(150) not null
type nvarchar(150) not null,
);

