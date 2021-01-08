

// Discriminated Unions
type Tree<'T> =
    | Node of Tree<'T> * 'T * Tree<'T>
    | Leaf

let rec depth = function
    | Node(l, _, r) -> 1 + max (depth 1) (depth r)
    | Leaf -> 0


// built-in discriminated unions for error handling
let optionPatternMatch input =
    match input with
    | Some i -> printfn "input is an int=%d" i
    | None -> printfn "input is missing"


// single-case discriminated union -> create type-safe abstractions
// with pattern matching support
type Orderid = Order of string

let orderId = Order "12"        // create a DU value
let (Order id) = orderId        // use pattern matching to deconstruct single-case DU


// Exceptions

// failwith
let divideFailwith x y =
    if y = 0 then
        failwith "Divisor cannot be zero."
    else x / y

// try/with
let divide x y =
    try
        Some (x / y)
    with :? System.DivideByZeroException ->
        printfn "Division by zero!"
        None

// try/finally
// execute clean-up code EVEN IF a block of code throws an exception
exception InnerError of string
exception OuterError of string

let handleErrors x y =
    try
        try
            if x = y then raise (InnerError("inner"))
            else raise (OuterError("outer"))
        with InnerError(str) ->
            printfn "Error1 %s" str
    finally         // this code is ALWAYS executed
        printfn "Always print this."



// Classes & Inheritance

// define class "Vector"
type Vector(x: float, y: float) = 
    let mag = sqrt(x * x + y * y)   // local let bindings
    member this.X = x               // properties
    member this.Y = y               
    member this.Mag = mag
    member this.Scale(s) =          // methods
        Vector(x * s, y * s)
    static member (+) (a: Vector, b: Vector) =      // static members
        Vector(a.X + b.X, a.Y + b.Y)


// call a base class from a derived one
type Animal() =
    member __.Rest() = ()

type Dog() =            // base class: Animal
    inherit Animal()
    member __.Run() = 
        base.Rest()

// upcasting by :> operator
let dog = Dog()
let animal = dog :> Animal

// dynamic downcasting by :?>
let shouldBeADog = animal :?> Dog



// Interfaces & Object Expressions

// declare IVector interface
type IVector = 
    abstract Scale : float -> IVector

// implement IVector in Vector'
type Vector'(x, y) = 
    interface IVector with
        member __.Scale(s) = 
            Vector'(x * s, y * s) :> IVector        // upcasting by :>
        member __.X = x
        member __.Y = y


// implement interface by using Object Expressions
type ICustomer =            // declare ICustomer interface
    abstract Name : string
    abstract Age : int
 
let createCustomer name age = 
    { new ICustomer with
        member __.Name = name
        member __.Age = age }




// Active Patterns

// COMPLETE active patterns -> pattern can be parsed/detected dynamically
let (|Even|Odd|) i =
    if i % 2 = 0 then Even
    else Odd

let testNumber i = 
    match i with
    | Even -> printfn "%d is even" i
    | Odd -> printfn "%d is odd" i


// PARAMETERIZED active patterns
let 



