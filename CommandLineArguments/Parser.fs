namespace CommandLineArguments

module Parser =

    type OrderByOption = | OrderBySize | OrderByName
    type SubdirectoryOption = | IncludeSubdirectories | ExcludeSubdirectories
    type VerboseOption = | VerboseOutput | TerseOutput

    type CommandLineOptions = {
        verbose: VerboseOption;
        subdirectories: SubdirectoryOption;
        orderby: OrderByOption
        }

    type ParseMode = | TopLevel | OrderBy

    type FoldState = {
        options: CommandLineOptions;
        parseMode: ParseMode;
        }

    let defaultOptions = {
            verbose = TerseOutput;
            subdirectories = ExcludeSubdirectories;
            orderby = OrderByName
            }

    // parse the top-level arguments
    // return a new FoldState
    let parseTopLevel arg optionsSoFar =
        match arg with

        // match verbose flag
        | "/V" ->
            let newOptionsSoFar = { optionsSoFar with verbose = VerboseOutput }
            { options = newOptionsSoFar; parseMode = TopLevel }

        // match subdirectories flag
        | "/S" ->
            let newOptionsSoFar = { optionsSoFar with subdirectories = IncludeSubdirectories }
            { options = newOptionsSoFar; parseMode = TopLevel }

        // match sort order flag
        | "/O" ->
            { options = optionsSoFar; parseMode = OrderBy }

        // handle unrecognized option and keep looping
        | x ->
            printfn "Option '%s' is unrecognized" x
            { options = optionsSoFar; parseMode = TopLevel }

    // parse the orderBy arguments
    // return a new FoldState
    let parseOrderBy arg optionsSoFar =
        match arg with
        | "S" ->
            let newOptionsSoFar = { optionsSoFar with orderby = OrderBySize }
            { options = newOptionsSoFar; parseMode = TopLevel }
        | "N" ->
            let newOptionsSoFar = { optionsSoFar with orderby = OrderByName }
            { options = newOptionsSoFar; parseMode = TopLevel }
        // handle unrecognized option and keep looping
        | _ ->
            printfn "OrderBy needs a second argument"
            { options = optionsSoFar; parseMode = TopLevel }

    // create a helper fold function
    let foldFunction state element =
        match state with
        | { options = optionsSoFar; parseMode = TopLevel } ->
            // return new state
            parseTopLevel element optionsSoFar

        | { options = optionsSoFar; parseMode = OrderBy } ->
            // return new state
            parseOrderBy element optionsSoFar

    // create the "public" parse function
    let parseCommandLine (commandLineArgs: string) =

        let initialFoldState =
            { options = defaultOptions; parseMode = TopLevel }

        let appWithArgs = commandLineArgs.Split(" ") |> Array.toList
        match appWithArgs with
        | [] -> defaultOptions
        | app :: args ->
            let resultState = args |> List.fold foldFunction initialFoldState
            resultState.options
