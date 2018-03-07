namespace klubovna.api.Controllers

open Microsoft.AspNetCore.Mvc
open System.Net

[<Route("api/[controller]")>]
type OmegaController () =
    inherit Controller()

    [<HttpPost("heartbeat")>]
    [<ProducesResponseType(typeof<unit>, 200)>]
    [<ProducesResponseType(401)>]
    member this.Post([<FromBody>] token:string) : IActionResult =
        match token with
        | "12345" -> new OkResult() :> IActionResult
        | _ -> new UnauthorizedResult() :> IActionResult
