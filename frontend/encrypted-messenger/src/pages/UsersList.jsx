import { Input } from "@chakra-ui/input";
import { Box, VStack, Text, Button } from "@chakra-ui/react";
import { Card, CardBody } from "@chakra-ui/card";
import { Avatar } from "@chakra-ui/avatar";
import { useEffect, useState } from "react";
import { GetAllUsers } from "../Repositories/userRepository";
import { getUserChats } from "../Repositories/chatRepository";

const UserList = ({ onSelectChat }) => {
  const [search, setSearch] = useState("");
  const [users, setUsers] = useState([]);
  const [chats, setChats] = useState([]);

  useEffect(() => {
    const fetchUsers = async () => {
      try {
        const userList = await GetAllUsers();
        setUsers(userList);
      } catch (error) {
        console.error("Ошибка при получении пользователей:", error);
      }
    };

    const fetchChats = async () => {
      try {
        const chatList = await getUserChats();
        setChats(chatList);
      } catch (error) {
        console.error("Ошибка при получении чатов:", error);
      }
    };

    fetchUsers();
    fetchChats();
  }, []);

  const filteredUsers = users.filter((user) =>
    user.username.toLowerCase().includes(search.toLowerCase())
  );

  const handleSelectUser = (user) => {
    onSelectUser(user);
  };

  const handleSelectChat = (chat) => {
    onSelectChat(chat);
    
  };
  
  
  return (
    <Box className="m-4">
      <Input
        value={search}
        onChange={(e) => setSearch(e.target.value)}
        placeholder="Search here..."
        className="mb-2 w-full rounded-full px-4 py-2 bg-gray-300 text-gray-800 focus:outline-none"
      />

      {/* Список пользователей */}
      <VStack spacing={4} align="stretch" className="bg-gray-300 rounded-lg">
        {filteredUsers.length > 0 && search !== ""
          ? filteredUsers.map((user) => (
              <Card
                key={user.id}
                onClick={() => handleSelectUser(user)}
                className=" hover:bg-gray-200 cursor-pointer rounded-md text-blue-600 font-semibold text-l"
              >
                <CardBody className="items-center flex m-1">
                  <Avatar className="size-10 mr-2" />
                  <Text>{user.username}</Text>
                </CardBody>
              </Card>
            ))
          : search && <Text color="gray.500">Пользователь не найден</Text>}
      </VStack>

      {/* Список чатов */}
      <VStack spacing={4} align="stretch" mt={2}>
        {chats.length > 0 ? (
          chats.map((chat) => (
            <Card
              key={chat.id}
              onClick={() => handleSelectChat(chat)}
              className="hover:bg-gray-100 cursor-pointer hover:rounded-md text-blue-600 font-semibold text-l"
            >
              <CardBody className="items-center flex m-1">
                <Avatar className="size-14 mr-2" />
                <Text>{chat.chatName}</Text>
              </CardBody>
            </Card>
          ))
        ) : (
          <Text color="gray.500">Нет доступных чатов</Text>
        )}
      </VStack>
    </Box>
  );
};

export default UserList;
