Entity Framework Query Samples
==============================

This sample demonstrates Entity Framework query capabilities and allows you to run
LINQ to Entities, ObjectQuery and Entity SQL queries against different providers.

It requires Entity Framework V4 which is included in .NET Framework 4.0 
and Visual Studio 2010.

The sample is designed to be extensible and also aid in development of your own 
ADO.NET Data Providers.

INSTALLATION
============
1. 	To create the NorthwindEF database, run the CreateNorthwindEFDB.sql script located in the DB project subfolder. 
	Either open the script in Sql Server Management Studio and run it, or open a command prompt in the DB folder
	and run the following command:

		osql -E -S .\sqlexpress -i CreateNorthwindEFDB.sql -o .\Output.txt

2. Open "Entity Framework Query Samples.sln" solution, compile and run.


RUNNING SAMPLES
===============

There are 2 ways to run samples: interactive mode and batch mode.

To run samples in an interactive mode, compile and run the project without any command-line arguments.
Using the tree on the left hand side, locate the interesting sample and click Run.
You can run samples against different providers, by selecting them from the drop-down
menu.

To run samples in the batch mode, run "SampleQueries.exe /runall /pause". It
will open the console where each sample is executed sequentially and any exceptions
are reported.

You can also pass "/log filename.txt" which will save results of all samples to a file.
To specify different provider, pass "/connectionString cs" where "cs" is the name of the
connection string defined in "SampleQueries.exe.config"

For example:

SampleQueries.exe /log log.txt /connectionString "NorthwindEF (EFOracleProvider)" /runall

DIRECTORY STRUCTURE
===================

  * Dumper - classes that dump results of queries in a textual and tree form
  * Harness - attributes and base classes used for writing samples
  * Runner - runs a series of samples
  * Samples - actual samples annotated with custom attributes
  * Schemas - CSDL, SSDL, MSL and object layer files for Entity Framework
  * Utils - various utilities


BACKENDS
========

The project comes with 6 pre-configured backends:

"NorthwindEF (SQL Server 2000)" - uses SQL Server 2000
"NorthwindEF (SQL Server 2005)" - uses SQL Server 2005
"NorthwindEF (SQL Server 2008)" - uses SQL Server 2008
    SQL Server (connects to local NorthwindEF database on .\SQLEXPRESS)

"NorthwindEF (SQL Server CE 3.5)"
    SQL Server Compact Edition 3.5 (uses 'DB\NorthwindEF.sdf' database file)

"NorthwindEF (EFSampleProvider)"
    Connects to local NorthwindEF database on .\SQLEXPRESS)

"NorthwindEF (EFOracleProvider)"
    Connects to local NorthwindEF database on local Oracle 10g XE instance.

To change the backend configuration and/or add new backends, please modify 
App.config and put required schema files in 'Schemas' directory

In order to install EFSampleProvider, please download it from http://code.msdn.microsoft.com/EFSampleProvider 
and follow instructions in the zip file.

In order to install EFOracleProvider, please download it from http://code.msdn.microsoft.com/EFOracleProvider
and follow instructions in the zip file.
