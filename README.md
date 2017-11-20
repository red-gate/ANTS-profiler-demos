# ANTS Demos
This collection of demos highlights common .NET performance and memory problems. All these demos should be rebuilt on the machine where they will be profiled.

## TicketDesk
This MVC app experiences around a dozen performance and memory issues, which can be identified with ANTS Performance Profiler and ANTS Memory Profiler. There are also a couple of rendering performance issues, which can identified with the Chrome dev tools or with Glimpse.

| Issue | Feature | How to surface |
|-----|-----|-----|
|Slow startup due to multiple sql queries|APP sql profiling<br />APP timeline|Log in and view any ticket page (eg `/TicketCenter`)|
|Unnecessary repeated SQL queries due to lazy loading in EF|APP sql profiling|Log in and view any ticket page (eg `/TicketCenter`)|
|Slow web requests|APP web req profiling<br />APP viewing header information|Refresh homepage with 1 second (`/`)|
|Unnecessary web requests due to inefficient API use|APP web req profiling<br />APP call tree filtering<br />APP integrated decompilation|View Live Support page (`/Home/LiveHelp`)|
|Misuse of string concatenation|APP line-level timing<br />APP call tree filtering|Log in and search for 'imported'|
|Leaked dynamic assemblies|AMP loaded assemblies info|Run load against `/Home/Status` using tinyget .bat file|
|Multiple view engines loaded|Glimpse view tab|View about page|
|No time delay for ajax autocomplete|Glimpse hud ajax count|Create new ticket and type in tag field|
|Slow corner rendering for large search results|Glimpse hud time split<br />Chrome dev tools rendering analysis|Log in and search for 'imported'|
|Compression not enabled|Page Speed Test|Run against any page|

See Demos/TicketDesk/README.md for more complete instructions.

## LibraryManager
This WinForms app may be preferable to the TicketDesk MVC site for those working with desktop applications.

| Issue | Feature | How to surface |
|-----|-----|-----|
|Slow startup due to initializing EF|APP call tree filtering<br />APP timeline|Start the app, select initial CPU spike|
|EF n+1 lazy loading|APP sql profiling<br />APP line-level timings|Search for members in London with loan filtering ticked|
|Slow loading of user details|APP web request profiling|Select any member in search results|
|Slow searching due to rendering|APP call tree filtering|Search for books called Monster|
|Slow searching due to missing index|APP execution plan view|Advanced search for books called Monster by John|

See /Demos/LibraryManager/README.md for more complete instructions.

## Other demos
#### Bouncing Ball
Basic introduction to ANTS Performance Profiler, showing the value of line level timings to identify an O(n^2) algorithm.
#### Async File Access
Show APP's Async code profiling while copying a directory of files asynchronously. *There is no performance issue in this application.*
#### Query Bee
A WinForms event handler leak, keeping a form containing database strings in memory.
#### Pattern Generator
The same event handler leak as QueryBee, but with no need to connect to a database.
#### Colorizer
A WinForms event handler leak per QueryBee and Pattern Generator, but which leaks unmanaged images. This can be used to understand how to profile unmanaged memory usage using ANTS Memory Profiler.
#### Pdf Converter
Shows ANTS Memory Profiler's unmanaged profiling when an unmanaged pdf generation library doesn't get cleaned up properly because of a blocked finalizer.
#### Dynamic Assemblies
A demonstration of AMP's 'loaded assemblies' functionality.
