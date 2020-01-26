namespace CommandLineArguments
open Microsoft.VisualBasic
open System

module Parser =

    let OrderByName = "N"
    let OrderBySize = "S"
    type CommandLineOptions = {
        verbose: bool;
        subdirectories: bool;
        orderby: string;
    }

    let noOptions = { verbose = false; subdirectories = false; orderby = "" }

    let rec private  parseInternal (optionsSoFar: CommandLineOptions) (input: string list) : CommandLineOptions =
        match input with
        | [] -> optionsSoFar
        | "/V"::rest ->
            let newOptions = { optionsSoFar with verbose = true}
            parseInternal newOptions rest
        | x::rest ->
            eprintf "Unrecognized switch %s" x
            parseInternal optionsSoFar rest

    let parse (input: string) =
        let appWithArgs = input.Split(" ") |> Array.toList 
        match appWithArgs with
        | [] -> noOptions
        | app::args -> parseInternal noOptions args
