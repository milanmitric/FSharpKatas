namespace StringCalculator
open System;

module Calculator =
    let private delimiters = [|','; '\n'|]

    let Sum (numbers: string) : int =
        match numbers with
        | "" -> 0
        | _ -> numbers.Split(delimiters) |> Seq.map int |> Seq.sum