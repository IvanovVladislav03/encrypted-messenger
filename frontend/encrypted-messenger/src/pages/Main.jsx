import { Box, Flex } from "@chakra-ui/react";
import { useState } from "react";
import UsersList from "./UsersList";
import ChatWindow from "./ChatWindow";

const Main = () => {
  const [selectedUser, setSelectedUser] = useState(null);

  return (
    <Flex height="100vh" width="100%">
      {/* Левая колонка — список пользователей */}
      <Box width="25%" bg="gray.200">
        <UsersList onSelectUser={setSelectedUser} />
      </Box>

      {/* Правая колонка — чат */}
      <Box flex="1" bg="gray.300">
        <ChatWindow selectedUser={selectedUser} />
      </Box>
    </Flex>
  );
};

export default Main;
