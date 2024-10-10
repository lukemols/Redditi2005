# Redditi2005

This application elaborates .txt files that contains tax refunds data.

Data should be with a similar structure:
```/* Sample data: 
* [0]             [1]             [2]        [3]            [4]         [5]            [6]         [7]   [8]
* SURNAME NAME    1929-07-16      RC         52210        9.476       2.153             0           0    UNICOPF
* 
* [0]             [1]             [2]                       [3]         [4]            [5]         [6]   [7]
* SURNAME NAME    1981-11-29      RH                     91.056      30.902             0           0    UNICOPF
* 
* [0]             [1]                                       [2]         [3]            [4]         [5]   [6]
* SURNAME NAME    1943-05-05                                  0           0             0           0    CUD
*/
```

After elaboration, data is inserted in a SQLite DB file.

You can download a SQLite browser [here](https://sqlitebrowser.org/), or use your preferred application.

This application uses [SQLite-net by Praeclarum](https://github.com/praeclarum/sqlite-net).

No personal data is included in this folder. You need to use your own files.

## Requirements
This application is build with Visual Studio CE 2022 and [.NET Framework 6.0](https://dotnet.microsoft.com/it-it/download/dotnet/6.0).

You can download the application without needing to compile it under [Releases tab](https://github.com/lukemols/Redditi2005/releases).

## Output Database
Output database will be found in a folder called "output" inside the root application folder.
