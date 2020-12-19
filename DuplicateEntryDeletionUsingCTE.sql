create table Employees (id varchar(30),name varchar(30));


insert into Employees values('1','Venkey');

insert into Employees values('1','Venkey');

insert into Employees values('1','Venkey');

insert into Employees values('2','Rajesh');

insert into Employees values('2','Rajesh');

select * from Employees;

delete from Employees;


with EmployeeCTE as
(
select * , Row_Number() over(Partition by id order by id) as RowNumber from Employees 
)
Delete from EmployeeCTE where RowNumber>1;