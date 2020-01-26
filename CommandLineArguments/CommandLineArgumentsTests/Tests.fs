module Tests

open CommandLineArguments

open FsUnit.Xunit
open Xunit
open Parser

[<Fact>]
let ``Parse verbose flag`` () =
    "MyApp /V" |> parse |> should equal {noOptions with verbose = true }
    
