[<AutoOpen>]
module rec Npm.Exports

open Fable.Core

type Npm.Types.IExports with
    [<Import("default", "qs")>]
    member __.qs with get () : Types.Qs.IExports = jsNative