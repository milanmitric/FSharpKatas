namespace StringCalculatorTests

module StringCalculatorTests =

    open Xunit
    open FsUnit.Xunit
    open StringCalculator

    [<Fact>]
    let ``Empty string returns zero``() =
        Calculator.sum ("") |> should equal 0

    [<Fact>]
    let ``Single number returned``() =
        Calculator.sum ("1") |> should equal 1

    [<Fact>]
    let ``Sum of two numbers``() =
        Calculator.sum ("1,2") |> should equal 3

    [<Fact>]
    let ``Sum of three numbers``() =
         Calculator.sum ("1,2,3") |> should equal 6

    [<Fact>]
    let ``Sum of three numbers with newline separator``() =
        Calculator.sum ("1\n2\n3") |> should equal 6

    [<Fact>]
    let ``Sum of three numbers with newline and coma separator``() =
        Calculator.sum ("1\n2,3") |> should equal 6

    [<Fact>]
    let ``Custom delimiter``() =
        Calculator.sum ("//[;]\n1;2") |> should equal 3

    [<Fact>]
    let ``Negative numbers not allowed``() =
        (fun () -> Calculator.sum ("-1,2") |> ignore) |> should throw typeof<Calculator.NegativeNumber>

    [<Fact>]
    let ``Numbers over 1000 are ignored``() =
        Calculator.sum ("1,2, 1001,3") |> should equal 6

    [<Fact>]
    let ``Delimiter with multiple characters``() =
        Calculator.sum ("//[****]\n11****22****33") |> should equal 66

