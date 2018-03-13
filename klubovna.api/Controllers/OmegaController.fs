namespace klubovna.api.Controllers

open Microsoft.AspNetCore.Mvc
open System.Net
open klubovna.api.HeartBeatProcessor

[<Route("api/omega")>]
type OmegaController () =
    inherit Controller()

    [<HttpPut("heartbeat")>]
    [<ProducesResponseType(typeof<unit>, 200)>]
    [<ProducesResponseType(401)>]
    member this.Heartbeat([<FromBody>] token:string) : IActionResult =
        match token with
        | "12345" -> 
            let _reply = heartBeatAgent.PostAndReply (fun replyChannel -> (HeartBeat, replyChannel))
            new OkResult() :> IActionResult
        | _ -> new UnauthorizedResult() :> IActionResult
