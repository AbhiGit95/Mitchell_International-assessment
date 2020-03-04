/*
@Author - Abhigyan Sinha
@Profession - Masters student in Computer Science at UTD
@Purpose - SQL Code required for backend part of the assessment
@Relation - Car {Id,Year,Make,Model}
@SP in this file = 5 [Have used 4 out of them]
@ Extra things which could have been done - Implementaion of Triggers
*/

use Project

--Schema of Car using Create Statement of T-SQL
create table Cars(Id int Identity(1,1), [Year] int NOT NULL , Make varchar(20) NOT NULL, Model varchar(20) NOT NULL Primary Key(Id));


--Inserting some Test values in Car Table
insert into Cars values(2014,'Honda', 'SXGU')

--Stored Procedure for inserting new records in the relation Car
CREATE PROCEDURE Create_Rec
@Year int,
@Make varchar(20),
@Model varchar(20)
As
SET NOCOUNT ON
Insert into Cars([Year],Make,Model) values (@Year,@Make,@Model);
GO

--Testing the Sp Create_Rec
exec Create_Rec @Year = 2019, @Make = "Audi", @Model = "FGAS";

--SP to Delete Record based on Id
CREATE PROCEDURE Delete_Rec
@ID int
As
SET NOCOUNT ON
Delete from Cars where Id = @ID;
GO

--Testing Delete_Rec
exec Delete_Rec @ID = 2


--SP to update values based on Id

CREATE PROCEDURE Update_Rec
@ID int,
@Year int,
@Make varchar(20),
@Model varchar(20)
AS
SET NOCOUNT ON
Update Cars set 
   [Year] = IsNull(@Year,[Year]),
   Make = IsNull(@Make,Make),
   Model = IsNull(@Model,Model)
   where Id = @ID;
GO

--Testing SP Update_Rec
exec Update_Rec @ID = 2,@Year = null, @Model = "SXGS", @Make = null

--Sp to Select Record by Id
CREATE PROCEDURE Select_Rec
@ID int
AS
SET NOCOUNT ON
select * from Cars where Id = @ID;
GO

--Testing Select_Rec
exec Select_Rec @ID = 1

--SP to select by year,model,make
--This could not be used in advanced search, but still this sp is added in the model
--Initially thought of implementing the advanced search usin this SP.
CREATE PROCEDURE Select_byanything
@year int,
@model varchar(20),
@make varchar (20)
AS
SET NOCOUNT ON
select * from Cars where [YEAR] = @year or model like '%'+@model+'%' or make like '%'+@make+'%'
GO

--Testing the SP Select_byanything
exec Select_byanything @year = 2020, @make = 'a' ,@model = 'a'

