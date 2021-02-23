module rec BodyParser

open System
open Fable.Core
open Node
open Connect

[<Import("*", "body-parser")>]
let bodyParser : BodyParser.IExports = jsNative

type NextHandleFunction = Connect.CreateServer.NextHandleFunction

module BodyParser =

    type [<AllowNullLiteral>] IExports =
        /// <summary>
        /// Returns middleware that only parses json and only looks at requests
        /// where the Content-Type header matches the type option.
        /// </summary>
        abstract json: ?options: OptionsJson -> NextHandleFunction
        /// <summary>
        /// Returns middleware that parses all bodies as a Buffer and only looks at requests
        /// where the Content-Type header matches the type option.
        /// </summary>
        abstract raw: ?options: Options -> NextHandleFunction
        /// <summary>
        /// Returns middleware that parses all bodies as a string and only looks at requests
        /// where the Content-Type header matches the type option.
        /// </summary>
        abstract text: ?options: OptionsText -> NextHandleFunction
        /// <summary>
        /// Returns middleware that only parses urlencoded bodies and only looks at requests
        /// where the Content-Type header matches the type option
        /// </summary>
        abstract urlencoded: ?options: OptionsUrlencoded -> NextHandleFunction

    type [<AllowNullLiteral>] Options =
        /// <summary>
        /// When set to true, then deflated (compressed) bodies will be inflated; when false, deflated bodies are rejected. Defaults to true.
        /// </summary>
        abstract inflate: bool with get, set
        /// <summary>
        /// Controls the maximum request body size. If this is a number,
        /// then the value specifies the number of bytes; if it is a string,
        /// the value is passed to the bytes library for parsing. Defaults to '100kb'.
        /// </summary>
        abstract limit: U2<float, string> with get, set
        /// <summary>
        /// The type option is used to determine what media type the middleware will parse
        /// </summary>
        abstract ``type``: U3<string, ResizeArray<string>, (Http.IncomingMessage -> obj option)> with get, set
        /// <summary>
        /// The verify option, if supplied, is called as verify(req, res, buf, encoding),
        /// where buf is a Buffer of the raw request body and encoding is the encoding of the request.
        /// </summary>
        abstract verify: req: Http.IncomingMessage * res: Http.ServerResponse * buf: Buffer * encoding: string -> unit

    type [<AllowNullLiteral>] OptionsJson =
        inherit Options
        /// <summary>
        /// The reviver option is passed directly to JSON.parse as the second argument.
        /// </summary>
        abstract reviver: key: string * value: obj option -> obj option
        /// <summary>
        /// When set to `true`, will only accept arrays and objects;
        /// when `false` will accept anything JSON.parse accepts. Defaults to `true`.
        /// </summary>
        abstract strict: bool with get, set

    type [<AllowNullLiteral>] OptionsText =
        inherit Options
        /// <summary>
        /// Specify the default character set for the text content if the charset
        /// is not specified in the Content-Type header of the request.
        /// Defaults to `utf-8`.
        /// </summary>
        abstract defaultCharset: string with get, set

    type [<AllowNullLiteral>] OptionsUrlencoded =
        inherit Options
        /// <summary>
        /// The extended option allows to choose between parsing the URL-encoded data
        /// with the querystring library (when `false`) or the qs library (when `true`).
        /// </summary>
        abstract extended: bool with get, set
        /// <summary>
        /// The parameterLimit option controls the maximum number of parameters
        /// that are allowed in the URL-encoded data. If a request contains more parameters than this value,
        /// a 413 will be returned to the client. Defaults to 1000.
        /// </summary>
        abstract parameterLimit: float with get, set