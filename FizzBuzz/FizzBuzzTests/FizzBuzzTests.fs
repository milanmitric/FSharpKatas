namespace FizzBuzzTests

module FizzBuzzTests = 

    open Xunit
    open FizzBuzz

    [<Fact>]
    let ``1 is number`` () =
        Assert.Equal("1", Converter.doConvert(1))

    [<Fact>]
    let ``3 is Fizz`` () =
        Assert.Equal("Fizz", Converter.doConvert(3))

    [<Fact>]
    let ``6 is Fizz`` () =
        Assert.Equal("Fizz", Converter.doConvert(6))

    [<Fact>]
    let ``5 is Buzz`` () =
        Assert.Equal("Buzz", Converter.doConvert(5))

    [<Fact>]
    let ``10 is Buzz`` () = 
        Assert.Equal("Buzz", Converter.doConvert(10))

    [<Fact>]
    let ``Exception is thrown when value is over 100`` () =
        Assert.Throws<Converter.InvalidInputExcepetion>(fun () -> Converter.doConvert(101) |> ignore)

    [<Fact>]
    let ``Exception is thrown when value is 0`` () =
        Assert.Throws<Converter.InvalidInputExcepetion>(fun () -> Converter.doConvert(0) |> ignore)

    [<Fact>]
    let ``Exception is thrown when value is negative`` () =
       Assert.Throws<Converter.InvalidInputExcepetion>(fun () -> Converter.doConvert(-1) |> ignore)