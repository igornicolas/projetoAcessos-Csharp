create database projAcessos

use projAcessos
create table ambientes(
	id int primary key,
	nome varchar(255)
)

create table usuarios(
	id int primary key,
	nome varchar(255),
)

create table usuarios_ambientes(
	idAmbiente int foreign key references ambientes(id),
	idUsuarios int foreign key references usuarios(id)
)


create table registroLog(
		id int primary key identity(1, 1),
		dtAcesso DateTime,
		idUsuarios int foreign key references usuarios(id),
		idAmbiente int foreign key references ambientes(id),
		tpAcesso bit
)


select * from ambientes
select * from usuarios

select * from usuarios_ambientes
select * from registroLog



insert into ambientes values (1, 'sala');
insert into ambientes values (2, 'suite principal');


insert into usuarios values (1, 'lorrane')
insert into usuarios values (2, 'igor')

insert into usuarios_ambientes values (1, 1)
insert into usuarios_ambientes values (1, 2)

insert into registroLog values (Getdate(), 1, 1, 1)

select * from ambientes

drop table registroLog
drop table usuarios
drop table usuarios_ambientes
drop table ambientes

