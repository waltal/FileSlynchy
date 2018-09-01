# FileSlynchy
FileSlynchy for Windows provides a variety of tools for keeping multiple file directory trees synchronized.

FileSlynchy is a Windows Forms application in .NET C# code.  It was created with Visual Studio 2017.

There are a number of popular utilities to perform directory and file differencing.  These tools generally do not provide 
syncronization support.  FileSlychy is an expansion and rewrite of Walt Lounsbery's original utility to provide file 
and directory synchronization between two directories.  In the two directory case, one directory tree was designated the
master directory, the other was the target directory.  One-way synchronization options were easy to provide in this situtation.

FileSlynchy provides tools for comparing and synchronizing multiple directory trees.  It goes beyond that, defining projects that
do multiple comparison sets.  A primary example of usage in software would be six application projects, two producing library code that is
shared among the other four projects.  FileSlynchy can compare that code in the repository of the original shared library, 
and the shared code in the repositories of the four applications.  That would be a single difference comparison with five directory trees.

The other library repository could have a separate comparison with its directory tree and the shared files in the other four applications.
The FileSlynchy project would then contain two comparisons with different directory sets, providing easy access to analyze and 
synchronize all the related software.  FileSlynchy is not limited in the number of comparison sets.

In this very complex scenario, a coder could work on one application with the two shared code libraries in its repository, find bugs in the 
shared code, fix that up in the repo of the application, then use FileSlynchy to back the changes into the shared code library repos.  
Then FileSlynchy could be used to publish the updated code to the three other application repos.
This preserves the integrity of the library repos and the applications sharing the repo.

There are other scenarios where multi-way file synchronization is helpful, this is basically a relatable example.  FileSlynchy still 
requires good judgement in these sorts of situations, they are complex by nature.  However, information is presented to help make the
best decisions.  Analysis and sychronization operations are fast and allow the coder to focus on improving code with lower error rates.
