// define function
let prefix prefixStr baseStr = 
    prefixStr + ", " + baseStr

// execute function
// prefix "Hello" "Phillip"
// prefix "Hello" "phillip"

let names = ["David"; "Maria"; "Alex"]

let prefixWithHello = prefix "Hello"

let exclaim s = 
    s + "!"

// function composition
let bigHello = prefixWithHello >> exclaim

// execute function
let hellos = 
    names
    |> Seq.map (fun x -> printfn "Mapped over %s" x; bigHello x)
    |> Seq.sort
    |> Seq.iter (printfn "%s")
