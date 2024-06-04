Create procedure Get_Title1(@price float ,@pubdate datetime)
As
set nocount on
select Title, type, price, notes, pubdate from titles
where price<=@price and pubdate<=@pubdate
go
Create procedure Get_Title2(@sqlstring varchar(2000))
As
set nocount on
create table #temp
(title_id char(6),title varchar(80),type char(12),
pub_id char(4),price money,advance money,
royalty int,ytd_sale int, notes varchar(200), pubdate datetime)
insert into #temp
exec(@sqlstring)
select * from #temp
drop table #temp
go