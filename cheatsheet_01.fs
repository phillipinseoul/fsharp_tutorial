// F# Tutorials

// 1. Comments

(*
    This is a block comment.
*)

// This is a line comment.


// 2. Strings

/// Create a string using string concatenation.
let hello = "Hello" + "world"

// Use verbatim strings preceded by "@" -> Avoid escaping control characters.
let verbatimXml = @"<book title=""Paradise Lost"">"

// triple-quoted strings -> don't have to esape ""
let tripleXml = """<book title="Paradise Lost">"""

// backslash strings 
let poem =
    "The lesser world has daubed\n\
    By a colorist of modest skill\n\
    A master limned you in the finest inks\n\
    And with a fresh-cut quill."


// 3. Basic Types & Literals

// uy = unsigned 8-bit integer, L = signed 64-bit integer
let b, i, l = 86uy, 86, 86L

(*
val b : byte = 86uy
val i : int = 86
val l : int64 = 86L
*)

let s, f, d, bi = 4.14F, 4.14, 0.7833M, 9999I

(*
val s : float32 = 4.14f
val f : float = 4.14
val d : decimal = 0.7833M
val bi : System.Numerics.BigInteger = 9999 
*)


// 4. Functions
let negate x = x * -1
let square x = x * x
let print x = printfn "The number is: %d" x

let squareNegateThenPrint x =
    print (negate (square x))


// Pipe operator (|>) & Composition operate (>>)
let ''square, negate, then print'' x =
    x
    |> square
    |> negate
    |> print


let sumOfLengths (xs: string[]) =
    xs
    |> Array.map(fun s -> s.Length)
    |> Array.sum

let squareNegateThenPrint' =
    square >> negate >> print


// Recursive Funtions
let rec fact x =
    if x < 1 then 1
    else x * fact (x - 1)

// Mutually Recursive Function
let rec even x =
    if x = 0 then true
    else odd (x - 1)

and odd x =
    if x = 1 then true
    else even (x - 1)


// 5. Pattern Matching

let rec fib n =
    match n with
    | 0 -> 0
    | 1 -> 1
    | _ -> fib (n - 1) + fib (n - 2)


// "when" -> create filters or guards on patterns
let sign x =
    match x with
    | 0 -> 0
    | x when x < 0 -> -1        // create a filter with "when"
    | x -> 1


// pattern matching can done DIRECTLY on arguments
let fst' (x, _) = x


// pattern matching can done via "function" keyword
let rec fib' = function
    | 0 -> 0
    | 1 -> 1
    | n -> fib' (n - 1) + fib' (n - 2)



// 6. Collections

// Lists
let list1 = [ "a"; "b"]

let list2 = "c" :: list1        // prepending

let list3 = list1 @ list2       // concatenation

// Recursion on list using (::) operator
let rec sum list =
    match list with
    | [] -> 0
    | x :: xs -> x + sum xs


// Arrays
let array1 = [| "a"; "b" |]

let first = array1.[0]


// Sequences
let seq1 =
    seq {
        // "yield" adds one element
        yield 1
        yield 2

        // "yield!" adds a whole subsequence
        yield! [5..10]
    }


// Higher-Order Functions on Collections
// ex) generate list [1; 3; 5; 7; 9] or array [| 1; 3; 5; 7; 9|]
let xs = [1..2..9]      // .. is range operator
let ys = [| for i in 0..4 -> 2 * i + 1 |]
let zs = List.init 5 (fun i -> 2 * i + 1)       // use "init" function

// fold: left to right, foldBack: right to left
let xs' = Array.fold (fun str n ->
            sprintf "%s,%i" str n) "" [| 0..9 |]        

// reduce
let last xs = List.reduce (fun acc x -> x) xs

// map
let ys' = Array.map (fun x -> x * x)[| 0..9 |]

// iter
let _ = List.iter (printfn "%i")[ 0..9 ]


// operations in sequences
let zs' =
    seq {
        for i in 0..9 do
            printfn "Adding %d" i
            yield i
    }


// Tuples & Records
let x = (1, "Hello")

let y = ("one", "two", "three")

let (a', b') = x


// first and second elements of a tuple -> obtained using "fst", "snd", or pattern matching
let c' = fst (1, 2)
let d' = snd (1, 2)

let print' tuple =
    match tuple with
    | (a, b) -> printfn "Pair %A %A" a b


// Records
type Person = { Name: string; Age: int}

let paul = { Name = "Paul"; Age = 28 }

let paulsTwin = { paul with Name = "Jim" }


type Person with
    member x.Info = (x.Name, x.Age)


let isPaul person =
    match person with
    | { Name = "Paul" } -> true
    | _ -> false









