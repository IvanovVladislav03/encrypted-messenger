import axios from "axios";
import { generate } from "./encryptionService";
import { savePrivateKeyToIndexedDB, getPrivateKeyFromIndexedDB } from "./indexedDbService";

const login = async (username, password) => {
  const loginData = {
    username: username,
    password: password,
  };
  try {
    const response = await axios.post(
      "https://localhost:7211/api/auth/login",
      loginData,
      {
        headers: {
          "Content-Type": "application/json",
        },
        withCredentials: true,
      }
    );
    if (response.status == 200){
      localStorage.setItem("token", response.data)
      return { success: true, message: "Успешно!" };
    }
    return {
      success: false,
      message: response.data.message || "Ошибка на сервере.",
    };
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
    const response = await axios.post(
      "https://localhost:7211/api/auth/register",
      registryData,
      {
        headers: {
          "Content-Type": "application/json",
        },
      }
    );

    if (response.status === 200) {
      savePrivateKeyToIndexedDB(username, keypair.privateKey)
        .then(() => console.log("Приватный ключ успешно сохранен"))
        .catch((error) => console.error("Ошибка сохранения ключа:", error));
      return { success: true, message: "Успешно зарегестрирован!" };
    } else {
      return {
        success: false,
        message: response.data.message || "Ошибка на сервере.",
      };
    }
  } catch (error) {
    return {
      success: false,
      message: error.response?.data?.message || "Ошибка при подключении к API.",
    };
  }
};

export { registry };
export { login };
