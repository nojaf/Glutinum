namespace Connect

[<AutoOpen>]
module Ext =

    open Fable.Core

    type Node.Http.IExports with
        [<Emit("$0.createServer($1)")>]
        member __.createServer(_ : Types.CreateServer.Server) : Node.Http.Server = jsNative