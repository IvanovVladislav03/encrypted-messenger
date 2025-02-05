import { Avatar } from "@chakra-ui/avatar";
import { Card, CardBody } from "@chakra-ui/card";
import { InputGroup, InputRightElement } from "@chakra-ui/input";
import { Box, Button, Input, Text } from "@chakra-ui/react";
import { useChat } from "../../hooks/useChat";
import { useEffect, useState } from "react";
import { useUser } from "../../UserContext";

const ChatWindow = ({ selectedChat }) => {
  const { joinChat, sendMessage, messages } = useChat();
  const [message, setMessage] = useState("");
  const { user } = useUser();

  useEffect(() => {
    if (selectedChat) {
      joinChat(selectedChat.id, user.userId, user.username);
    }
  }, [selectedChat]);

  const handleJoinChat = () => {
    joinChat(selectedChat.id, user.userId, user.username);
  };

  const handleSendMessage = () => {
    sendMessage(message);
    console.log(messages);

    setMessage("");
  };
  return (
    <Box className="relative h-screen p-4">
      <Box className="flex items-center mb-4">
        {selectedChat ? (
          <Card className="bg-gray-100 cursor-pointer text-blue-600 font-semibold text-l w-full p-2">
            <CardBody className="items-center flex m-1">
              <Avatar className="size-12 mr-2" />
              <Text>{selectedChat.chatName}</Text>
            </CardBody>
          </Card>
        ) : (
          <Text>Выберите чат</Text>
        )}
      </Box>
      <Box className="flex flex-col overflow-auto max-h-[75%] mb-4">
        {messages.map((msg, index) => (
          <Box
            key={index}
            className={`w-1/3 rounded-lg px-2 pb-2 mb-2 ${
              msg.username === user.username
                ? "bg-blue-700 rounded-br-none ml-auto"
                : "bg-red-700 rounded-bl-none"
            }`}
          >
            <Text className="top-1 mb-1 text-white font-semibold">
              {msg.username}
            </Text>
            <Text className="text-white">{msg.messageContent}</Text>
          </Box>
        ))}
      </Box>

      <Box className="absolute bottom-0 left-0 w-full p-2">
        <InputGroup className="">
          <Input
            className="p-2 border-solid border-2 border-gray-600 text-gray-600"
            value={message}
            onChange={(e) => setMessage(e.target.value)}
          />
          <InputRightElement className="">
            <Button
              className="right-0 bg-gray-600 text-white rounded-r-md p-2"
              onClick={handleSendMessage}
            >
              Отправить
            </Button>
          </InputRightElement>
        </InputGroup>
      </Box>
    </Box>
  );
};

export default ChatWindow;
