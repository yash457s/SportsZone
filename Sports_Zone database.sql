create database Sports_Zone_Db

use Sports_Zone_Db
                                                   
create table Product(
ProId nvarchar(10),
ProName nvarchar(50) not null,
ProDescription nvarchar(200),
ProPrice money check(ProPrice>0),
Stock int check (Stock>0 or Stock=0),
primary key("ProId")
);

create table Categories(
CatId nvarchar(10),
CatName nvarchar(50) not null,
ProId nvarchar(10),
catDescription nvarchar(200) not null,
primary key ("CatId"),
foreign key ("ProId") references Product("ProId")
);





Create table Account_Details(
AccName nvarchar(50) primary key not null,
AccPassword nvarchar(20) not null,
AccPhone nvarchar(10) not null check (AccPhone like '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]' and len(AccPhone)=10),
AccAddress nvarchar(50) not null,
AccEmail nvarchar(50) not null unique
)

create table Orders_Details(
OrderId nvarchar(10),
CusId varchar(20),
OrderDate DateTime ,
ShippedDate DateTime not null,
ShipName varchar(20) not null,
ShipAddress varchar(20) not null,
ShipCity varchar(30) not null,
ShipPostalCode varchar(30) not null,
primary key ("OrderId"),
Foreign key ("CusId") References Customer_info ("CusId")
);


create table Payment(
Payment_Id nvarchar(10),
CusId varchar(20),
Amount money not null,
Payment_Date DateTime not null,
primary key ("Payment_Id"),
foreign key("CusId") references Customer_info("CusId")
)


create table Sports_Info
(
SpoId nvarchar(10),
SpoName nvarchar(50) not null, 
SpoCategory nvarchar(50) not null, 
SpoGears nvarchar(50) not null,
SpoDescription nvarchar(200) not null,
primary key ("SpoId")
)
create table Admin(
AdmId nvarchar(10),
AdmName nvarchar(50) not null,
AdmEmail nvarchar(20) not null,
AdmPassword nvarchar(20) not null,
primary key ("AdmId")
)
---------------------------------------------------------------------------------------------------------------------------------------------------
insert into Admin values(AdmId='A23B4',AdmName='')
---------------------------------------------------------------------------------------------------------------------------------------------------
Create table Cart(
CarId nvarchar(10),
ProId nvarchar(10),
CusId varchar(20),
Quantity nvarchar(10) check (Quantity>0) not null,
primary key ("CarId"),
foreign key("CusId") references Customer_info("CusId"),
foreign Key ("ProId") references Product(ProId)
)


CREATE TABLE Users(
    userId VARCHAR(20) PRIMARY KEY,
    password VARCHAR(20) ,
    first_name VARCHAR(20) ,
    last_name VARCHAR(20),
    email VARCHAR(50) 
);


CREATE TABLE User_Addresses(
    username VARCHAR(20),
    address VARCHAR(100),
    PRIMARY KEY (username, address),

    FOREIGN KEY(username) REFERENCES Users  
);
CREATE TABLE User_mobile_numbers(
    username VARCHAR(20),
    mobile_number VARCHAR(10) check (mobile_number like '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]' and len(mobile_number)=10),
    PRIMARY KEY (username, mobile_number),

    FOREIGN KEY(username) REFERENCES Users  ON DELETE CASCADE ON UPDATE CASCADE
);


Create table Customer_info(
CusId varchar(20) ,
First_Name varchar(20) ,
Last_Name varchar(20) ,
Phone varchar(10) ,
Email varchar(50)  ,
Address varchar(100) ,
primary key("CusId"),
foreign key("CusId") references Users("UserId")
)

Create table Invoice(
InvId nvarchar(10),
CusId varchar(20),
[Date] datetime,
ProId nvarchar(10),
Quantity int check(Quantity>0)
primary key ("InvId"),
foreign key ("CusId") references Customer_info("CusId"),
foreign Key ("ProId") references Product(ProId)
)
create table Feedback(
CusId varchar(20) primary key,
ProId nvarchar(10),
Comment nvarchar(300),
[Date] datetime,
foreign key ("CusId") references Customer_info("CusId"),
foreign Key ("ProId") references Product(ProId)
)
---------------------------------------------------------------------------------------------------------------------------------------------------
                                  - -------------------------Admin----------------------------------------
---------------------------------------------------------------------------------------------------------------------------------------------------
Create Procedure Insert_Product
@ProId nvarchar(10),
@ProName nvarchar(50),
@ProDescription nvarchar(200),
@ProPrice money,
@Stock int
AS
BEGIN
SET NOCOUNT ON;
INSERT INTO Product(ProName,ProId,ProPrice,ProDescription,Stock)
Values(@ProName,@ProId,@ProPrice,@ProDescription,@Stock)
END
------------------------------------------------------------------------------------------------------------------------------------------
exec Insert_Product @ProId='A12B3',@ProName='Golf stick',@ProDescription='Use to play Golf and  made of metal',@ProPrice=2000,@Stock=25
select * from Product
exec Insert_Product @ProId='A12B4',@ProName='Golf ball',@ProDescription='Use to play Golf ',@ProPrice=200,@Stock=1000
exec Insert_Product @ProId='B12C7',@ProName='Cricket Helmet',@ProDescription='Protective Gear for Cicket to guard Head and face of Batsman ',@ProPrice=200,@Stock=900


---------------------------------------------------------------------------------------------------------------------------------------------
                            
------------------------------------------------------------------------------------------------------------------------------------------------
Create Procedure Insert_Categories
@ProId nvarchar(10),
@CatName nvarchar(50),
@CatId nvarchar(10),
@CatDescription nvarchar(200)
AS
BEGIN
SET NOCOUNT ON;
INSERT INTO Categories(CatId, CatName, ProId, CatDescription)
Values(@CatId,@CatName,@ProId,@CatDescription)
END

Create Procedure Insert_Sports_Info
@SpoId nvarchar(10),
@SpoName nvarchar(50),
@SpoDescription nvarchar(200),
@SpoGears nvarchar(50),
@SpoCategory nvarchar(50)
AS
BEGIN
SET NOCOUNT ON;
INSERT INTO Sports_Info(SpoId,SpoName,SpoCategory,SpoDescription,SpoGears)
Values(@SpoId,@SpoName,@SpoCategory,@SpoDescription,@SpoGears)
END

Create Procedure Update_Customer_information
@CusId nvarchar(10),
@First_Name nvarchar(50),
@Last_Name nvarchar(50),
@Phone nvarchar(10),
@Email  nvarchar(50),
@Address nvarchar(100)

AS
BEGIN
UPDATE Customer_info
SET 
First_Name=@First_Name,
Last_Name=@Last_Name,
Phone=@Phone,
Email=@Email,
Address=@Address

WHERE
CusId=@CusId
END

Create Procedure Update_Product
@ProId nvarchar(10),
@ProName nvarchar(50),
@ProDescription nvarchar(200),
@ProPrice money,
@Stock int
AS
BEGIN
UPDATE Product
SET 
ProPrice=@ProPrice,
Stock=@Stock,
ProDescription=@ProDescription
WHERE
ProId=@ProId
END


----------------------------------------------------------------------------------------------------------------------------------------
                                             ------unregu=istered User------------
.............................................................................................................................................

CREATE PROCEDURE customerRegister
@userId VARCHAR(20),@first_name VARCHAR(20), @last_name VARCHAR(20),@password VARCHAR(20), @email
VARCHAR(50)
AS
BEGIN
INSERT INTO Users VALUES 
(@userId, @password, @first_name, @last_name, @email)
INSERT INTO Customer_info(CusId,First_Name,Last_Name,Email) VALUES 
(@UserId,@first_name,@last_name,@Email)
END
------------------------------------------------------------------------------------------------------------------------------------------------
exec customerRegister @userId='A123',@first_name='yash', @last_name='shivhare' , @password='A7415434573@z',@email='yashshivhare911119@gmail.com';
exec customerRegister @userId='A112',@first_name='Udit', @last_name='Gupta' , @password='ABCD@123',@email='Udit_Kumar@gmail.com';
exec customerRegister @userId='A118',@first_name='Deepak', @last_name='singh' , @password='qwe3445',@email='Deepak_singh@gmail.com';
select *from Users
select *from Customer_info
--------------------------------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE addMobile
@username VARCHAR(20), @mobile_number VARCHAR(20)
AS
BEGIN
INSERT INTO User_mobile_numbers 
VALUES (@username, @mobile_number)
Update Customer_info
set
Phone=@mobile_number
where CusId=@username
END
----------------------------------------------------------------------------------------------------------------------------------------------------
exec addMobile @username='A123' ,@mobile_number='7987791856'
----------------------------------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE addAddress
@username VARCHAR(20), @address VARCHAR(100)
AS
BEGIN
INSERT INTO User_Addresses 
VALUES (@username, @address)
Update Customer_info
set
Address=@address
where CusId=@username
END

Create Procedure Login_pro
@UserId varchar(20),
@Password varchar(20)
As
Begin
declare  @status int , @type int 
if exists(select * from Users where @UserId=UserId and @Password=Password)
set @status=1
else
set @status=0
set @type=-1
select @status
End

If @status=1
Begin
If exists(select * from Customer_info where @UserId=CusId)
set @type=1
Else If exists(select * from Admin where @userId=AdmId)
set @type=2
Else
Set @type=0
select @type
End

---------------------------------------------------------------------------------------------------------------------------------------------------
exec Login_pro @UserId='A123' ,@Password='A7415434573@z'
exec Login_pro @UserId='A112' ,@Password='ABCD@12'
----------------------------------------------------------------------------------------------------------------------------------------------
                                            -----------Customer----------------
----------------------------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE searchbyname
 @text NVARCHAR(50)
 AS
 BEGIN
 SELECT *
 FROM Product
 WHERE Product.ProName LIKE '%' + @text + '%'
 END
 ----------------------------------------------------------------------------------------------------------------------------------------------------
 exec searchbyname @text='tennis racket'
 exec searchbyname @text='cricket helmet'
 ----------------------------------------------------------------------------------------------------------------------------------------------------
