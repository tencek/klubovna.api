namespace klubovna.api.Controllers

open Microsoft.AspNetCore.Mvc

[<Route("api/presence")>]
type PresenceController () =
    inherit Controller()

    [<HttpGet>]
    member this.Get() =
        false