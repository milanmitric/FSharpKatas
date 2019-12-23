namespace StringCalculatorTests

module StringCalculatorTests = 

    open Xunit
    open StringCalculator

    [<Fact>]
    let ``Empty string returns zero`` () =
        Assert.Equal(0, Calculator.Sum(""))

    [<Fact>]
    let ``Single number returned`` () =
        Assert.Equal(1, Calculator.Sum("1"))

    [<Fact>]
    let ``Sum of two numbers`` () =
        Assert.Equal(3, Calculator.Sum("1,2"))

    [<Fact>]
    let ``Sum of three numbers`` () =
        Assert.Equal(6, Calculator.Sum("1,2,3"))

    [<Fact>]
    let ``Sum of three numbers with newline separator`` () =
        Assert.Equal(6, Calculator.Sum("1\n2\n3"))

    [<Fact>]
    let ``Sum of three numbers with newline and coma separator`` () =
        Assert.Equal(6, Calculator.Sum("1\n2,3"))

