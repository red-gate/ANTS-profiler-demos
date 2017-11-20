use ticketdesk

update dbo.aspnet_membership set isapproved = 1, islockedout = 0

update dbo.aspnet_Membership set comment = LEFT(email, CHARINDEX('@', email) - 1)

UPDATE dbo.aspnet_users SET username = mem.comment FROM dbo.aspnet_Membership as [mem] WHERE dbo.aspnet_users.userid = mem.userid

update dbo.aspnet_users set loweredusername = lower(username)

truncate table dbo.aspnet_usersinroles

insert into aspnet_usersinroles(userid, roleid) select us.userid, (select roleid from dbo.aspnet_roles where rolename='ticketsubmitters') from dbo.aspnet_users us

insert into aspnet_usersinroles(userid, roleid) select us.userid, (select roleid from dbo.aspnet_roles where rolename='helpdesk') from dbo.aspnet_users us where username in ('neil', 'terrance', 'lynette', 'esther', 'joshua', 'aaron')

insert into aspnet_usersinroles(userid, roleid) select us.userid, (select roleid from dbo.aspnet_roles where rolename='administrators') from dbo.aspnet_users us where username in ('aaron')

update dbo.ticketcomments set ishtml = 0

update dbo.tickets set ishtml = 0

update dbo.tickets set taglist = 'imported' where ticketid in (select ticketid from dbo.tickettags where tagname = 'imported')