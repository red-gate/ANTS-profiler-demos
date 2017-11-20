# MagicBooks (BookSearch)

In this lab we’ll profile a .NET application to investigate performance problems with its database access.

## Walkthrough
1. Open **ANTS Performance Profiler**, and choose **“New profiling session”**. Select to profile a **.NET executable**, and browse to `\MagicBooks\BookSearch.exe`. Ensure that **“Enable SQL query profiling”** is ticked, then click **“Start profiling”**.

2. In the launched **Book Search** sample app, run a search for the pre-filled ISBN. Notice in ANTS that **CPU usage** spikes while Entity Framework is initialised.

  Search for this ISBN a couple more times. The searches are still slow, but because Entity Framework is already initialised, they are a little faster and there is no CPU spike.

3. To investigate the slowness, click **“Start live bookmark”** in the top-right of ANTS – this marks out a period of time. Search for the ISBN again, then click **“Stop live bookmark”**, to see what code and data access ran during this time period.

4. Select any method in the call tree to see line-level timings for that method’s code. Notice that you can also see a slow query, along with the code that caused it to run. Click the yellow **“SQL”** icon to view details for the query.

5. Click a yellow **“PLAN”** button to view the execution plan for this query. It may help to minimize the query window, to free up space for the plan. We’re warned about an implicit conversion for the ISBN column, which is forcing a **Table Scan** instead of an **Index Seek**, ruining the query’s performance.

  Expanding the query window again, we can see why. The `@p__linq__0` parameter was submitted as `NVarChar`, while the ISBN column is `VarChar`. SQL Server can’t safely convert the `NVarChar` parameter to `VarChar`, so the entire ISBN column has to be converted.

## Solution
Entity Framework chooses `NVarChar` by default because strings are represented as Unicode in .NET. The fix is easy - you can tell Entity Framework to use a specific data type with a single line of code, but this is typical of the sort of performance problem ANTS can help identify where an application’s out-of-the-box database access behaviour can be problematic.
