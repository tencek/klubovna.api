namespace klubovna.api.Controllers

open Microsoft.AspNetCore.Mvc
open klubovna.api.HeartBeatProcessor
open System

[<Route("api/presence")>]
type PresenceController () =
    inherit Controller()

    [<HttpGet>]
    [<ProducesResponseType(typeof<bool>, 200)>]
    member this.Get() =
        match heartBeatAgent.PostAndReply (fun replyChannel -> (GetIntervals, replyChannel)) with
        | [] -> false
        | head::_tail ->
            let diff:TimeSpan = (DateTime.Now - head.tsEnd)
            diff.TotalSeconds <= 300.0

    [<HttpGet("history")>]
    [<ProducesResponseType(typeof<HeartBeatIntervals>, 200)>]
    member this.GetHistory() =
        heartBeatAgent.PostAndReply (fun replyChannel -> (GetIntervals, replyChannel))