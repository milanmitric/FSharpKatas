module Tests

open CommandLineArguments

open FsUnit.Xunit
open Xunit
open Parser

let flagsOrderByName = {verbose = VerboseOutput; subdirectories = IncludeSubdirectories; orderby = OrderByName}
let flagsOrderBySize = {verbose = VerboseOutput; subdirectories = IncludeSubdirectories; orderby = OrderBySize}
[<Fact>]
let ``Parse verbose flag``() =
    "MyApp /V" |> parseCommandLine |> should equal { defaultOptions with verbose = VerboseOutput }

[<Fact>]
let ``Parse subdirectories flag``() =
    "MyApp /S" |> parseCommandLine |> should equal { defaultOptions with subdirectories = IncludeSubdirectories }

[<Fact>]
let ``Parse order by name``() =
    "MyApp /O N" |> parseCommandLine |> should equal { defaultOptions with orderby = OrderByName }

[<Fact>]
let ``Parse order by size``() =
    "MyApp /O S" |> parseCommandLine |> should equal { defaultOptions with orderby = OrderBySize }
    
[<Fact>]
let ``Parse order by invalid switch``() =
    "MyApp /O a" |> parseCommandLine |> should equal defaultOptions

[<Fact>]
let ``Parse flags with order by name`` () =
    "MyApp /V /S /O N" |> parseCommandLine |> should equal flagsOrderByName
    
[<Fact>]
let ``Parse flags with order by size`` () =
    "MyApp /V /S /O S" |> parseCommandLine |> should equal flagsOrderBySize