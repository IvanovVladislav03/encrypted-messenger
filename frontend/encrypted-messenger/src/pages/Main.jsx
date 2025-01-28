import { Input } from "@chakra-ui/input";
import { Box, VStack, Text } from "@chakra-ui/react";
import { Card, CardBody } from "@chakra-ui/card";
import { Avatar } from "@chakra-ui/avatar";
import { useEffect, useState } from "react";
import { GetAllUsers } from "../Repositories/userRepository";
import { joinChat } from "../services/chatService";

const Main = () => {
  const [search, setSearch] = useState("");
  const [selectedUser, setSelectedUser] = useState(null);
  const [users, setUsers] = useState([]);

  useEffect(() => {
    const fetchUsers = async () => {
      try {
        const userList = await GetAllUsers(); 
        setUsers(userList); 
      } catch (error) {
        console.error("Ошибка при получении пользователей:", error);
      }
    };

    fetchUsers();
  }, []); 

  // Фильтрация пользователей по поисковому запросу
  const filteredUsers = users.filter((user) =>
    user.username.toLowerCase().includes(search.toLowerCase()) 
  );

  const handleSelectUser = async (user) => {
    console.log(user)
    await joinChat(user.username, "testChat")
    setSelectedUser(user);
    setSearch(user.username); 
  };

  return (
    <Box className="items-center bg-gray-300 h-screen w-1/4 p-5">
      <Input
        value={search}
        onChange={(e) => setSearch(e.target.value)}
        placeholder="Search here..."
        className="mb-2 w-full rounded-full px-4 py-2 bg-gray-200 text-gray-800 focus:outline-none"
      />

      <VStack spacing={4} align="stretch">
        {filteredUsers.length > 0 && search!==""
          ? filteredUsers.map((user) => (
              <Card
                onClick={() => handleSelectUser(user)}
                className="bg-gray-100 hover:bg-gray-200 cursor-pointer rounded-md text-blue-600 font-semibold text-l"
              >
                <CardBody className="items-center flex m-1">
                  <Avatar className="size-10 mr-2"></Avatar>
                  <Text>{user.username}</Text>
                </CardBody>
              </Card>
            ))
          : search && <Text color="gray.500">Пользователь не найден</Text>}
      </VStack>
    </Box>
  );
};

export default Main;
