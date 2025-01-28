import {HubConnectionBuilder} from "@microsoft/signalr"


const joinChat = async (userName, chatName) => {
    var connection = new HubConnectionBuilder()
        .withUrl("https://localhost:7211/chat")
        .withAutomaticReconnect()
        .build();
    connection.on("ReceiveMessage", (username, message) =>{
        console.log(username)
        console.log(message)
    })
    try{
        await connection.start()
        await connection.invoke("JoinChat", userName, chatName);

    }catch(error){
        console.log(error);
    }
}

export {joinChat}