module Tests.Express.App.Core

open Npm
open Mocha

let tests () =
    describe "app" (fun _ ->

        itAsync "should inherit from event emitter" (fun d ->
            let app = Express.e.express()

            app.on("foo", fun _ -> d()) |> ignore
            app.emit("foo") |> ignore
        )

        itAsync "should be callable" (fun d ->
            request(Express.e.express())
                .get("/")
                .expect(
                    404,
                    fun err _ -> d err
                )
                |> ignore
        )

    )
