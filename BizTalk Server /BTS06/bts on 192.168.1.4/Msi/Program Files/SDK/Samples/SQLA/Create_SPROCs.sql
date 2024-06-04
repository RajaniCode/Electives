if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_CreateKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_CreateKey]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_Get_Agent_and_Interest]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_Get_Agent_and_Interest]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_Get_Customer_Rating]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_Get_Customer_Rating]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_Monitor_for_New_Customers]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_Monitor_for_New_Customers]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_Reset_Loans]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_Reset_Loans]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_Save_Loan_info]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_Save_Loan_info]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_monitor_for_Loan_to_Assign]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_monitor_for_Loan_to_Assign]
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

CREATE PROCEDURE  SP_CreateKey @Prefix as nvarchar(10), @RetVal  nvarchar(10)  OUTPUT
AS

/* internal procedure, simply generate a unique key (nvarchar(10)) */
declare @Value int

update KeyGenerator set @Value = incrementer = incrementer + 1
SELECT @RetVal = @Prefix + Convert( nvarchar, @Value)
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

CREATE PROCEDURE SP_Get_Agent_and_Interest @State as nvarchar(50), @Rating as nvarchar(10) AS

/* first determine the region from the state */
declare @RegionID as nvarchar(10)
select @RegionID = RegionID from Regions where State = @State

/* if not found, use the 'other' regionID */
if @RegionID = null
   set @RegionID = 'other'

/* Get the Agent from the Region */
declare @AgentID as nvarchar(10)
select @AgentID = AgentID from Agents where RegionID = @RegionID

/* Get the Interest Rate using the Interest table */
declare @InterestRate as real
select @InterestRate = InterestRate from Interest where Rating = @Rating

/* return the information */
select @AgentID as AgentID, @InterestRate as InterestRate for xml raw
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

CREATE PROCEDURE SP_Get_Customer_Rating @FirstName as nvarchar(50), @LastName as nvarchar(50) AS
/* a real life rating system would probably be using Business rules or at least a full address for the customer
   this is simplified for the sample */
declare @Rating as nvarchar(10)
select @Rating = Rating from Ratings where FirstName = @FirstName and LastName = @LastName

/* if the user is not in the Ratings table, give then a default Rating */
if @Rating = Null 
   set @Rating = 'normal'

/* note xmldata is only needed during the SQL Adapter wizard schema generation */
select @Rating as Rating for xml raw
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

CREATE PROCEDURE SP_Monitor_for_New_Customers AS
/* we want just one of the newly created customers (Rating is new) */
declare @CustomerID as nvarchar(10)
select top 1 @CustomerID = CustomerID from Customers where Rating = 'new' 

/* critical race protection, if a new customer is found, we change the Rating from new to in-use
   this prevents from accidentally resubmitting this same row again if the orchestration takes too 
   long 
*/
if @CustomerID != null 
  begin 
     update Customers Set Rating = 'in-use' where CustomerID = @CustomerID
     /* found new customer is returned  */
     select * from Customers where CustomerID = @CustomerID for xml auto
   end
else 
    /* no new customer, return an empty set */
    select * from Customers where 1 = 0 for xml auto
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

CREATE PROCEDURE SP_Reset_Loans AS
DELETE from Loans
DELETE from Customers

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

CREATE PROCEDURE SP_Save_Loan_info  
   @FirstName as nvarchar(50), 
   @LastName as nvarchar(50),
   @Street as nvarchar(50),
   @City as nvarchar(50),
   @State as nvarchar(50),
   @Amount as nvarchar(50)
 AS

/* first find out if the customer has already been put in the database */
declare @ExistingCustomerID as nvarchar(10)
Select @ExistingCustomerID = CustomerID from Customers where 
       FirstName = @FirstName  and LastName = @LastName

/* if the customer is not in the table, we create a new record for him/her */
if @ExistingCustomerID = null 
  BEGIN 
      exec SP_CreateKey 'cust', @ExistingCustomerID output
      insert into Customers (CustomerID, FirstName, LastName, StreetAddress, City, State)
         values (@ExistingCustomerID, @FirstName, @LastName, @Street, @City, @State)
    END

/* Now we can store the new loan record using the CustomerID */
declare @NewLoanID as nvarchar(10)
exec SP_CreateKey 'loan', @NewLoanID output
insert into Loans (LoanID, CustomerID, RequestAmt)
   values (@NewLoanID, @ExistingCustomerID, Convert(money, @Amount))

/* Finally we return the Loans row we created 
    remember xmldata only needed when deriving schema for the adapter */
select * from Loans where LoanID = @NewLoanID for xml auto
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

CREATE PROCEDURE SP_monitor_for_Loan_to_Assign AS
/* we want just one of the newly created Loans that has a Customer that has been rated */
declare @LoanID as nvarchar(10)
select top 1 @LoanID = Loans.LoanID from Loans,Customers 
      where Loans.CustomerID = Customers.CustomerID  
                and Loans.Status = 'new'
                and not ( Customers.Rating = 'new'
                         or Customers.Rating = 'in-use')

/* critical race protection, if a new loan is found, we change the Status from new to in-use
   this prevents from accidentally resubmitting this same row again if the orchestration takes too 
   long 
*/
if @LoanID != null 
  begin 
     update Loans Set Status = 'in-use' where LoanID = @LoanID

     /* found new loan is returned  */
     select * from Customers,Loans 
         where Customers.CustomerID = Loans.CustomerID
            and Loans.LoanID = @LoanID for xml auto
   end
else 
    /* no new loans, return an empty set */
    select * from Customers,Loans where 1 = 0 for xml auto
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
