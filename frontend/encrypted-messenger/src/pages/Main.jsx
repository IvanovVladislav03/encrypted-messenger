import { Box, Flex } from "@chakra-ui/react";
import { useState } from "react";
import UsersList from "./UsersList";
import ChatWindow from "./ChatWindow";

const Main = () => {
  const [selectedChat, setSelectedChat] = useState(null);

  return (
    <Flex height="100vh" width="100%">
      {/* Левая колонка — список пользователей */}
      <Box className="w-1/4 bg-gray-200">
        <UsersList onSelectChat={setSelectedChat} />
      </Box>

      {/* Правая колонка — чат */}
      <Box className="flex-1 bg-gray-300">
        <ChatWindow selectedChat={selectedChat} />
      </Box>
    </Flex>
  );
};

export default Main;
