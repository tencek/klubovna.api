module klubovna.api.HeartBeatProcessor

open System

type HeartBeatInterval = {tsBegin:DateTime ; tsEnd:DateTime}
type HeartBeatIntervals = HeartBeatInterval list
type MessageType = HeartBeat | GetIntervals
type Message = MessageType * AsyncReplyChannel<HeartBeatIntervals>

let heartBeatAgent = MailboxProcessor<Message>.Start(fun inbox-> 

    // the message processing function
    let rec messageLoop heartBeatIntervals = async{
        
        // read a message
        let! (msg, replyChannel) = inbox.Receive()

        // log
        printfn "Message is: %A" msg

        let newHeartBeatIntervals = 
            match msg with
            | HeartBeat -> 
                let newHeartBeatIntervals = 
                    match heartBeatIntervals with
                    | [] -> {tsBegin = DateTime.Now ; tsEnd = DateTime.Now} |>  List.singleton
                    | head::tail -> 
                        let diff:TimeSpan = (DateTime.Now - head.tsEnd)
                        if diff.TotalSeconds > 300.0 then
                            {tsBegin = DateTime.Now ; tsEnd = DateTime.Now} :: heartBeatIntervals
                        else
                            {tsBegin = head.tsBegin ; tsEnd = DateTime.Now} :: tail
                replyChannel.Reply newHeartBeatIntervals
                newHeartBeatIntervals
            | GetIntervals ->
                replyChannel.Reply heartBeatIntervals
                heartBeatIntervals

        // loop to top
        return! messageLoop newHeartBeatIntervals
    }

    // start the loop 
    messageLoop List.Empty
    )