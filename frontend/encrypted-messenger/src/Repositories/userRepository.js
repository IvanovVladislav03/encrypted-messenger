import axios from "axios";

const GetAllUsers = async () => {
  try {
    const response = await axios.get("https://localhost:7211/api/user");
    const data = response.data;

    if (Array.isArray(data)) {
      data.forEach((user) => {
        console.log(`Username: ${user.username}, PublicKey: ${user.publicKey}`);
      });
      return(data)
    }
  } catch (error) {
    console.error("Ошибка при получении данных:", error);
  }
  
};

export {GetAllUsers}
