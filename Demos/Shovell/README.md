# Shovell
Shovell is an example ASP.net (C#) application, which can be used to demonstrate ANTS Profiler.

## Summary
It implements a news website, where users can add articles and comments. Anyone can vote that the article is interesting, which makes it appear higher up the page.

It contains two ways to display a page of articles:
+ A naive way that reads all the articles from the database, then orders them in C#.
+ An efficient way that uses an advanced SQL query to do the ordering in the database.

## Prerequisites
+ Visual Studio / Visual Web Developer (tested on VS2005)
+ MS Access (tested on Access 2003)
+ ANTS Profiler (tested on v4.1)

## To use
+ In solution navigate to **Shovell demo** => **Shovell**
+ In `web.config`, change the `slowMode` setting to either `True` or `False`, to get either the naive or efficient display method
+ Start debugging or choose **Profile Performance** from the **ANTS 4** menu to run the website

**Note**: The login information is defined in `.\App_Data\MembershipUsers.xml`

## To run the client
There is also an ASP.NET web service, and a basic client to submit new articles.
+ The website needs to be running on port 80. Choose the project in the solution explorer, and in the Properties change **Use dynamic ports** to `false` and **Port number** to `80`.
+ Ensure the website is running (this means leaving VS open).
+ Open a second instance of VS, and open and run the **WSClient** project.
