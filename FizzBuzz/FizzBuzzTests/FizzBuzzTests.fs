namespace FizzBuzzTests

module FizzBuzzTests = 

    open System
    open Xunit
    open FizzBuzz
    open FsUnit.Xunit

    [<Fact>]
    let ``1 is number`` () =
        Converter.doConvert(1) |> should equal "1"

    [<Fact>]
    let ``3 is Fizz`` () =
        Converter.doConvert(3) |> should equal "Fizz"

    [<Fact>]
    let ``6 is Fizz`` () =
        Converter.doConvert(6) |> should equal "Fizz"

    [<Fact>]
    let ``5 is Buzz`` () =
        Converter.doConvert(5) |> should equal "Buzz"

    [<Fact>]
    let ``10 is Buzz`` () = 
        Converter.doConvert(10) |> should equal "Buzz"

    [<Fact>]
    let ``Exception is thrown when value is over 100`` () =
        (fun () -> Converter.doConvert(101) |> ignore) |> should throw typeof<ArgumentException>

    [<Fact>]
    let ``Exception is thrown when value is 0`` () =
        (fun () -> Converter.doConvert(0) |> ignore) |> should throw typeof<ArgumentException>

    [<Fact>]
    let ``Exception is thrown when value is negative`` () =
       (fun () -> Converter.doConvert(-1) |> ignore) |> should throw typeof<ArgumentException>