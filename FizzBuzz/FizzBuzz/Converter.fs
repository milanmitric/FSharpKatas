namespace FizzBuzz
open System

module Converter = 
    
    let private (|Fizz|_|) (number: int) =
        match number with
        | _ when number % 3 = 0 || (number |> string).Contains("3") -> Some Fizz
        | _ -> None

    let private (|Buzz|_|) (number: int) = 
        match number with
        | _ when number % 5 = 0 || (number |> string).Contains("5") -> Some Buzz
        | _ -> None

    let doConvert (number: int) : string =
        match number with
        | _ when number < 1 || number > 100 -> raise (ArgumentException("Value outside of range(1..100): " + number.ToString()))
        | Fizz & Buzz -> "FizzBuzz"
        | Fizz -> "Fizz"
        | Buzz -> "Buzz"
        | _ -> number |> string