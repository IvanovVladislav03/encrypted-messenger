import { useState, useEffect } from "react";
import { HubConnectionBuilder, HubConnectionState } from "@microsoft/signalr";
import axios from "axios";

export const useChat = () => {
  const [connection, setConnection] = useState(null);
  const [messages, setMessages] = useState([]);

  useEffect(() => {
    return () => {
      if (connection) {
        connection.stop();
      }
    };
  }, [connection]);

  const fetchMessages = async (chatId) => {
    try {
      const response = await axios.get(`https://localhost:7211/api/chat/${chatId}`);
      setMessages(response.data.messages); // Ожидается массив объектов сообщений
    } catch (error) {
      console.error("Ошибка загрузки сообщений:", error);
    }
  };

  const joinChat = async (chatId, userId, username) => {
    const newConnection = new HubConnectionBuilder()
      .withUrl("https://localhost:7211/chat")
      .withAutomaticReconnect()
      .build();

    newConnection.on("ReceiveMessage", (message) => {
      setMessages((prevMessages) => [...prevMessages, message]);
    });

    try {
      await newConnection.start();
      await newConnection.invoke("JoinChat", { chatId, userId, username });
      setConnection(newConnection);

      await fetchMessages(chatId);
    } catch (error) {
      console.error("Ошибка подключения:", error);
    }
  };

  const sendMessage = async (message) => {
    if (connection && connection.state === HubConnectionState.Connected) {
      try {
        await connection.invoke("SendMessage", message);
      } catch (error) {
        console.error("Ошибка отправки сообщения:", error);
      }
    } else {
      console.error("Соединение не установлено");
    }
  };

  return { joinChat, sendMessage, messages };
};
