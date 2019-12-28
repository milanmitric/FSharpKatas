namespace FizzBuzz
open System

module Converter = 
    let doConvert (number: int) : string =
        match number with
        | _ when number < 1 || number > 100 -> raise (ArgumentException("Value outside of range(1..100): " + number.ToString()))
        | _ when number % 3 = 0 -> "Fizz"
        | _ when number % 5 = 0 -> "Buzz"
        | _ -> number |> string
