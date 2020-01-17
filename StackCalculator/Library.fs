namespace StackCalculator

module Calculator =
    
    type Stack = StackContents of float list
    
    let push x (StackContents aStack) = StackContents (x::aStack)
    
    let pop (StackContents contents) =
        match contents with
            | [] -> failwith "Stack is empty"
            | top::rest ->
                let newStack = StackContents rest
                (top, newStack)
    
    let binary operation stack  =
        let first, stack' = pop stack
        let seconds, stack'' = pop stack'
        let result = operation first seconds
        push result stack''
        
    let ADD = binary (+)
    let MUL = binary (*)
    let SUB = binary (-)
    let DIV = binary (/)
    
    let unary f stack =
        let first,stack' = pop stack
        let result = f first
        push result stack'
    
    let EMPTY = StackContents []
    let ONE = push 1.0
    let TWO = push 2.0
    let THREE = push 3.0
    let FOUR = push 4.0
    let FIVE = push 5.0
