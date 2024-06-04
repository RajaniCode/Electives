delete from Loans
delete from Customers
delete from Interest
delete from Agents
delete from Ratings
delete from Regions
delete from KeyGenerator

insert into KeyGenerator (incrementer) values (1)

insert into Ratings (FirstName, LastName, Rating) values ('Bill', 'Gates', 'good')
insert into Ratings (FirstName, LastName, Rating) values ('Steve', 'Ballmer', 'poor')

insert into Regions (RegionID, State) values ('middle','Kansas')
insert into Regions (RegionID, State) values ('middle','Missouri')
insert into Regions (RegionID, State) values ('middle','Ohio')
insert into Regions (RegionID, State) values ('northeast','NewHampshire')
insert into Regions (RegionID, State) values ('northeast','Maine')
insert into Regions (RegionID, State) values ('northeast','Massachusetts')
insert into Regions (RegionID, State) values ('northwest','Idaho')
insert into Regions (RegionID, State) values ('northwest','Washington')
insert into Regions (RegionID, State) values ('northwest','Oregon')
insert into Regions (RegionID, State) values ('southeast','South Carolina')
insert into Regions (RegionID, State) values ('southeast','North Carolina')
insert into Regions (RegionID, State) values ('southeast','Florida')
insert into Regions (RegionID, State) values ('southeast','Georgia')
insert into Regions (RegionID, State) values ('southwest','Arizona')
insert into Regions (RegionID, State) values ('southwest','California')
insert into Regions (RegionID, State) values ('southwest','Nevada')
insert into Regions (RegionID, State) values ('other','Other')

insert into Interest (Rating, InterestRate) values ('good', 0.05)
insert into Interest (Rating, InterestRate) values ('normal', 0.085)
insert into Interest (Rating, InterestRate) values ('poor', 0.20)

insert into Agents (AgentID, FirstName, LastName, RegionID) values ('blank','nobody','nobody','nowhere')
insert into Agents (AgentID, FirstName, LastName, RegionID) values ('Agnt1','Agent','Elsewhere','other')
insert into Agents (AgentID, FirstName, LastName, RegionID) values ('Agnt2','Northy','Easter','northeast')
insert into Agents (AgentID, FirstName, LastName, RegionID) values ('Agnt3','Northy','Westy','northwest')
insert into Agents (AgentID, FirstName, LastName, RegionID) values ('Agnt4','Southy','Easter','southeast')
insert into Agents (AgentID, FirstName, LastName, RegionID) values ('Agnt5','Southy','Westy','southwest')
insert into Agents (AgentID, FirstName, LastName, RegionID) values ('Agnt6','Mel','Middleton','middle')
