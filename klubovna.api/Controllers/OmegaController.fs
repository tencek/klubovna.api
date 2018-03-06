namespace klubovna.api.Controllers

open Microsoft.AspNetCore.Mvc

[<Route("api/[controller]")>]
type OmegaController () =
    inherit Controller()

    [<HttpPost("heartbeat")>]
    member this.Post([<FromBody>] token:string) =
        new OkResult()
