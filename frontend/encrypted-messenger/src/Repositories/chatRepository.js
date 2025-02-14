import axios from "axios"
const getUserChats = async () => {
    try{
        const token = localStorage.getItem("token")
        console.log(token)
        const response = await axios.get('https://localhost:7211/api/chat', {
            headers: {
              Authorization: `Bearer ${token}` 
            }
          });
        if (response.status == 200){
            return response.data
        }
        else{
            console.log("Ошибка")
        }
    }catch(error){
        console.log(error)
    }
}

const createChat = async (chatName, publicKey, chatMembers) => {
    try {
        const token = localStorage.getItem("token"); 
        const createChatDto = {
            ChatName: chatName,
            PublicKey: publicKey,
            ChatMembers: chatMembers
        };
        
        const response = await axios.post(
            'https://localhost:7211/api/chat/create', 
            createChatDto, 
            {
                headers: {
                    Authorization: `Bearer ${token}`, 
                    'Content-Type': 'application/json' 
                }
            }
        );

        console.log("Чат успешно создан:", response.data); 
        return response.data; 
    } catch (error) {
        console.error("Ошибка при создании чата:", error);
        throw error; 
    }
};

export {getUserChats, createChat}