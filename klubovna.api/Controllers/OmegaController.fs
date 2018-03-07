namespace klubovna.api.Controllers

open Microsoft.AspNetCore.Mvc
open System.Net

[<Route("api/omega")>]
type OmegaController () =
    inherit Controller()

    [<HttpPut("heartbeat")>]
    [<ProducesResponseType(typeof<unit>, 200)>]
    [<ProducesResponseType(401)>]
    member this.Heartbeat([<FromBody>] token:string) : IActionResult =
        match token with
        | "12345" -> new OkResult() :> IActionResult
        | _ -> new UnauthorizedResult() :> IActionResult
