namespace rec Mime.Types

// Exported from: https://github.com/DefinitelyTyped/DefinitelyTyped/blob/0893371fea43bfdf1777b6d835424961ba0d1dbb/types/mime/index.d.ts

open System
open Fable.Core
open Fable.Core.JS

type [<AllowNullLiteral>] IExports =
    abstract Mime: MimeStatic
    abstract getType: path: string -> string option
    abstract getExtension: mime: string -> string option
    abstract define: mimes: TypeMap * ?force: bool -> unit

type [<AllowNullLiteral>] Mime =
    abstract getType: path: string -> string option
    abstract getExtension: mime: string -> string option
    abstract define: mimes: TypeMap * ?force: bool -> unit

type [<AllowNullLiteral>] MimeStatic =
    [<EmitConstructor>] abstract Create: mimes: TypeMap -> Mime

type [<AllowNullLiteral>] TypeMap =
    [<EmitIndexer>] abstract Item: key: string -> ResizeArray<string> with get, set