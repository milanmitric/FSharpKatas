namespace StringCalculator
open System;

module Calculator =
    let private (|SingleDigit|MultipleDigit|Empty|) (input: string) =
        if input.Contains(",") then MultipleDigit
        elif input <> "" then SingleDigit
        else Empty

    let Sum (numbers: string) : int =
        match numbers with
        | SingleDigit -> numbers |> int
        | MultipleDigit -> numbers.Split(",") |> Seq.map Int32.Parse |> Seq.sum
        | _ -> 0