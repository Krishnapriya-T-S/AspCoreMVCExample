create procedure [dbo].[sp_login]
@eid int,
@ena varchar(50)
as
begin
select count (Emp_Id) from EMP_Tab where emp_Id=@eid and Emp_Name=@ena
end

create procedure [dbo].[sp_selectProfile]
@id int
as
begin
select * from [dbo].[EMP_Tab] where Emp_Id=@id
end

create procedure [dbo].[sp_updateProfile]
@eid int,
@esal varchar(20),
@eaddr varchar(150)
as
begin
update [dbo].[EMP_Tab] set [Emp_Salary]=@esal, [Emp_Address]=@eaddr where [Emp_Id]=@eid
end

create procedure [dbo].[sp_selectAll]
as
begin
select * from [dbo].[EMP_Tab]
end