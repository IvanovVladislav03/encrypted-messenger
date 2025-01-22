import axios from "axios";
import { generate } from "./encryptionService";

const login = async (username, password) => {
  const loginData = (username, password);
  try {
    const response = axios.post("");
  } catch (error) {
    return {
      success: false,
      message: error.response?.data?.message || "Ошибка при подключении к API.",
    };
  }
};

const registry = async (username, password) => {
  const keypair = await generate();

  const registryData = {
    username: username,
    password: password,
    publicKey: keypair.publicKey,
  };
  try {
    const response = await axios.post("https://localhost:7211/api/auth/register", registryData, {
      headers: {
        "Content-Type": "application/json",
      },
    });

    if (response.status === 200) {
      return { success: true, message: "Успешно зарегестрирован!" };
    } else {
      return { success: false, message: response.data.message || "Ошибка на сервере." };
    }
  } catch (error) {
    return {
      success: false,
      message: error.response?.data?.message || "Ошибка при подключении к API.",
    };
  }
};

export {registry};
export {login};
