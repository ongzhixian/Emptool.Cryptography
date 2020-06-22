<#
 .Synopsis
  Run .NET Core tests

 .Description
  Run .NET Core test using dotnet test runner.

 .Example
   # Start HTTP server to host web site using default settings
   .\Start-Test.ps1

 .Notes
  The default command runs with minimal verbosity.
  It maybe more useful to run:
  
    dotnet test --logger "console;verbosity=normal" .\Emptool.Loggers.Tests\
  
  Other levels of verbosity:

    Diagnostic  -- level 4
    Detailed    -- level 3
    Normal      -- level 2
    Minimal     -- level 1
    Quiet       -- level 0

  To log test results to a file:

    dotnet test --logger trx --results-directory ./results .\Emptool.Loggers.Tests\

  To log test results to a file using TRX format:

    dotnet test --logger "trx;verbosity=detailed" --results-directory ./results .\Emptool.Loggers.Tests\

  To log test results to a file using TRX format using custom file name:

    dotnet test --logger "trx;verbosity=detailed;LogFileName=results.trx" --results-directory ./results .\Emptool.Loggers.Tests\

  Note: For the options pertaining to logging test results, the specified results-directory is found inside the test project.
#>

# Run test with minimal (default) verbosity
dotnet test .\Emptool.Cryptography.Tests\

# Run test with normal verbosity
# dotnet test --logger "console;verbosity=normal" .\Emptool.Loggers.Tests\

# Run test and log (minimal) results to specified folder in test project using TRX format
# dotnet test --logger trx --results-directory ./results .\Emptool.Loggers.Tests\

# Run test and log detailed results to specified folder in test project using TRX format
# dotnet test --logger "trx;verbosity=detailed" --results-directory ./results .\Emptool.Loggers.Tests\

# Run test and log detailed results to specified folder in test project using TRX format using specific filename
# dotnet test --logger "trx;verbosity=detailed;LogFileName=results.trx" --results-directory ./results .\Emptool.Loggers.Tests\
