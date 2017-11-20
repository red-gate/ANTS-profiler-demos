# PdfConverter
PdfConverter is a small desktop app which opens a pdf file and converts its pages to a series of images. You can use it to learn how unmanaged profiling works in **ANTS Memory Profiler**.

## How to profile

1. Start profiling the application from the `\App\` folder with **unmanaged mode switched on**.
2. **Take a baseline snapshot**
3. In the app, click **Load Pdf File** and load the first PDF sample provided in `\Example Pdfs\` directory.
4. After a small delay, the PDF appears in the app. You can flick through the pages to preview it.
5. Notice there is large increase in memory usage visible in **ANTS Memory Profiler** (up to 1 GB).
6. In order to further investigate the matter, **take a snapshot**.
7. Open second PDF.
8. We expect the large amount of memory associated with opening the previous PDF to reduce in size, since it is no longer being used for anything. To make sure that is the case, **take another memory snapshot**.
9. Change the baseline to snapshot 1.
10. Observe that area of memory in the bottom left shows almost everything as unmanaged memory.
11. In the unmanaged module breakdown in the bottom right, you can see that most memory is being used by the **MuPdf module**. This is important information especially in a larger application when the problem isn’t as obvious.
12. We need to understand what’s holding on to this memory. Switch to the **class list**.
13. Ordering by .NET size, nothing of much is of interest, but we can now also look at unmanaged size, to see how much unmanaged memory a .NET class is responsible for holding onto, so sort by unmanaged size.
14. The biggest is the MuPdf class, which accounts for a large amount of used memory. We wouldn’t have spotted this class without unmanaged profiling.
15. We want to investigate why this is still taking up so much memory even after we started looking at a different PDF, so we’ll get a list of instances using the **instance list**.
16. Expand into one of the instances which has non-zero unmanaged memory, to show why they’re not taking up much .NET memory – they basically have a few properties and a pointer to an unmanaged object. But why is it still in memory?
17. View the **instance retention graph** for this instance, which shows it’s being held on the finalizer queue.
18. Open the solution from the `\Source\` folder in Visual Studio. Browse to the **MuPDF project**, then `MuPDF.cs` -> `MuPDF`, and double click on the finalizer, `~MuPDF`, to open it. Be careful not to scroll down too far as this shows the fixed implementation

## The problem
In opened finalizer method, the first block of code is responsible for cleaning up the unmanaged resources. Following it there is logging to a logging framework from within the finalizer.

.NET only has one finalizer thread, so if it gets blocked, .NET is unable to carry on finalizing objects. It’s likely that our logging framework is blocking this finalizer thread, hence why none of the objects are being cleaned up properly.

## The solution
There are few solutions to a memory problem above. We could either look at the logging framework to make sure it isn’t able to block **or** just don’t log anything from the finalizer.

However, the best solution would be to implement the `IDisposable` pattern so the issue can’t happen in the first place. A sample implementation is provided as a commented code in `MuPDF.cs` file, right after faulty `~MuPDF` finalizer.
