create table OldTable( id varchar(30),name varchar(30));

insert into OldTable values('1','Venkey');

insert into OldTable values('1','Venkey');

insert into OldTable values('1','Venkey');

insert into OldTable values('2','Rajesh');

insert into OldTable values('2','Rajesh');

select * from OldTable;


create table NewTable( id varchar(30),name varchar(30));



insert into NewTable select Distinct * From OldTable;

select * from NewTable;


delete from OldTable;


insert into OldTable select * from NewTable;




