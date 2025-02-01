import { Avatar } from "@chakra-ui/avatar";
import { Card, CardBody } from "@chakra-ui/card";
import { Box, Button, Text } from "@chakra-ui/react";

const ChatWindow = ({ selectedUser }) => {

  return (
    <Box className="">
      <Box className="flex items-center">
        {selectedUser ? (
          <Card className="bg-gray-100 hover:bg-gray-200 cursor-pointer text-blue-600 font-semibold text-l w-full p-2">
            <CardBody className="items-center flex m-1">
              <Avatar className="size-12 mr-2"></Avatar>
              <Text>{selectedUser.username}</Text>
            </CardBody>
          </Card>
        ) : (
          <Text>Выберите пользователя, чтобы начать чат</Text>
        )}
      </Box>
      <Box>

      </Box>
    </Box>
  );
};

export default ChatWindow;
