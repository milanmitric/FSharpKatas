namespace StackCalculatorTests

module StackCalculatorTests =

    open FsUnit
    open FsUnit.Xunit
    open Xunit
    open StackCalculator

    let readItems (stack: Calculator.Stack) =
        let (Calculator.StackContents content) = stack
        content

    [<Fact>]
    let ``Initialize stack``() =
       Calculator.StackContents([ 1.0; 2.0; 3.0; 4.0 ]) |> readItems |> should equal [ 1.0; 2.0; 3.0; 4.0 ]

    [<Fact>]
    let ``Push to stack``() =
       Calculator.StackContents [ 1.0; 2.0; 3.0 ] |> Calculator.push 4.0 |> readItems |> should equal [ 4.0; 1.0; 2.0; 3.0; ]

    [<Fact>]
    let ``Push multiple items to stack``() =
        Calculator.EMPTY |> Calculator.THREE |> Calculator.FIVE |> Calculator.FIVE
        |> readItems |> should equal [ 5.0; 5.0; 3.0 ]

    [<Fact>]
    let ``Pop from stack``() =
        let (top, newStack) = Calculator.EMPTY |> Calculator.ONE |> Calculator.ONE |> Calculator.pop
        top |> should equal 1.0
        newStack |> readItems |> should equal [ 1.0 ]

    [<Fact>]
    let ``Pop on empty stack fails``() =
        (fun () -> Calculator.EMPTY |> Calculator.pop |> ignore) |> shouldFail

    [<Fact>]
    let ``Top on stack`` () =
        let (top, stack)  = Calculator.EMPTY |> Calculator.ONE |> Calculator.THREE |> Calculator.top
        top |> should equal 3.0
        stack |>  should equal [3.0; 1.0;]
        
    [<Fact>]
    let ``Duplicate top number on stack`` () =
        Calculator.EMPTY |> Calculator.FIVE |> Calculator.TWO |> Calculator.duplicate |>
        readItems |> should equal [2.0; 2.0; 5.0]
        
    [<Fact>]
    let ``Swap two top numbers on stack`` () =
        Calculator.EMPTY |> Calculator.FIVE |> Calculator.THREE |> Calculator.swap |>
        readItems |> should equal [5.0; 3.0]
        
    [<Fact>]
    let ``Add two top numbers on stack``() =
        Calculator.EMPTY |> Calculator.ONE |> Calculator.TWO |> Calculator.THREE |>
        Calculator.ADD |> readItems |> should equal [ 5.0; 1.0 ]

    [<Fact>]
    let ``Multiply two top numbers on stack``() =
        Calculator.EMPTY |> Calculator.ONE |> Calculator.TWO |> Calculator.THREE |>
        Calculator.MUL |> readItems |> should equal [ 6.0; 1.0 ]

    [<Fact>]
    let ``Subtract two top numbers on stack``() =
        Calculator.EMPTY |> Calculator.ONE |> Calculator.TWO |> Calculator.THREE |>
        Calculator.SUB |> readItems |> should equal [ 1.0; 1.0 ]

    [<Fact>]
    let ``Divide two top numbers on stack``() =
        Calculator.EMPTY |> Calculator.ONE |> Calculator.TWO |> Calculator.FOUR |>
        Calculator.DIV |> readItems |> should equal [ 2.0; 1.0 ]
    
    [<Fact>]
    let ``Negate top number on stack`` () =
        Calculator.EMPTY |> Calculator.ONE |> Calculator.NEG |> readItems |> should equal [-1.0]
    
    [<Fact>]
    let ``Sqrt top number on  stack`` () =
        Calculator.EMPTY |> Calculator.push 9.0 |> Calculator.SQRT |> readItems |> should equal [3.0]

    [<Fact>]
    let ``Pow top number on stack`` () =
        Calculator.EMPTY |> Calculator.TWO |> Calculator.POW |> readItems |> should equal [4.0]