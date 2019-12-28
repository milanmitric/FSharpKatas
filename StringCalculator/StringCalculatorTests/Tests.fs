namespace StringCalculatorTests

module StringCalculatorTests = 

    open Xunit
    open StringCalculator

    [<Fact>]
    let ``Empty string returns zero`` () =
        Assert.Equal(0, Calculator.sum(""))

    [<Fact>]
    let ``Single number returned`` () =
        Assert.Equal(1, Calculator.sum("1"))

    [<Fact>]
    let ``Sum of two numbers`` () =
        Assert.Equal(3, Calculator.sum("1,2"))

    [<Fact>]
    let ``Sum of three numbers`` () =
        Assert.Equal(6, Calculator.sum("1,2,3"))

    [<Fact>]
    let ``Sum of three numbers with newline separator`` () =
        Assert.Equal(6, Calculator.sum("1\n2\n3"))

    [<Fact>]
    let ``Sum of three numbers with newline and coma separator`` () =
        Assert.Equal(6, Calculator.sum("1\n2,3"))

    [<Fact>]
    let ``Custom delimiter`` () =
        Assert.Equal(3, Calculator.sum("//[;]\n1;2"))

    [<Fact>]
    let ``Negative numbers not allowed`` () =
        Assert.Throws<Calculator.NegativeNumber>(fun () -> Calculator.sum("-1,2") |> ignore)

    [<Fact>]
    let ``Numbers over 1000 are ignored`` () =
        Assert.Equal(6, Calculator.sum("1,2, 1001,3"))

    [<Fact>]
    let ``Delimiter with multiple characters`` () =
        Assert.Equal(66, Calculator.sum("//[****]\n11****22****33"))

