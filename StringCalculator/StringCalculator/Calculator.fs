namespace StringCalculator
open System;

module Calculator =
    exception NegativeNumber of string;
    let private predefinedDelimiters = [ ","; "\n" ]

    let private extractDelimiter (delimiterAndNumbers: string): string =
        let beforeDelimiter = delimiterAndNumbers.IndexOf(']') - 1
        delimiterAndNumbers.[3..beforeDelimiter]

    let private extractParts (delimiterAndNumbers: string): string [] =
         let customDelimiter = extractDelimiter delimiterAndNumbers
         let afterDelimiter = delimiterAndNumbers.IndexOf(']') + 1
         delimiterAndNumbers.[afterDelimiter..] .Split(List.toArray (predefinedDelimiters @ [ customDelimiter ]), StringSplitOptions.RemoveEmptyEntries)

    let private mapNumber (potentialNumber: string): int =
        match potentialNumber with
        | str when str.StartsWith("-") -> raise (NegativeNumber("Negatives not allowed"))
        | str -> str |> int

    let private collectResult (numbers: string []): int =
        numbers |> Seq.map mapNumber |> Seq.filter (fun x -> x < 1000) |> Seq.sum

    let sum (numbers: string): int =
        match numbers with
        | "" -> 0
        | str when str.StartsWith("//") -> extractParts str |> collectResult
        | str -> str.Split(List.toArray predefinedDelimiters, StringSplitOptions.RemoveEmptyEntries) |> collectResult
