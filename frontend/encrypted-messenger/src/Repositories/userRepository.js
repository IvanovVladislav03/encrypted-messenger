import axios from "axios";

const GetAllUsers = async () => {
  try {
    const response = await axios.get("https://localhost:7211/api/user");
    const data = response.data;

    if (Array.isArray(data)) {
      return(data)
    }
  } catch (error) {
    console.error("Ошибка при получении данных:", error);
  }
  
};

export {GetAllUsers}
