import axios from "axios"
import Cookies from "js-cookie"
const getUserChats = async () => {
    try{
        const token = localStorage.getItem("token")
        console.log(token)
        const response = await axios.get('https://localhost:7211/api/chat', {
            headers: {
              Authorization: `Bearer ${token}`  // Включаем токен в заголовок
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

export {getUserChats}