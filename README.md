## adding a Nuget 

while in the solution path 
    dotnet add $PackageFolder package $PackageName 

## adding a reference 

while in the path of the project you want to add the reference to
    dotnet add reference ../Project1.Api/Project1.Api.cspro


# await / async 

- await every task - without wait Exception will aggregated and difficult to read  
- don't use return await, adding await creates an additional context switch 
- do use return await inside try/catch
- never use async void 
- if await can't be used use .GetAwaiter().GetResult <-- some say cause deadlocks 
- consider a fire and forget method for eliminating async void 
- use ConfigureAwait(false) when you don't need to return to the calling thread 
- use ValueTask if you have a return path that does not use await
- never use .wait() or .result()

Link: https://codetraveler.io/ndcoslo-asyncawait/

# More research

stackalloc - for allocating small collections on the stack. For less that 512 bytes

ValueTask<TResult> - when you need to return a hot value in an async 

ArrayPool - trade thruput for reduced memory footprint 

Span<T> - 


