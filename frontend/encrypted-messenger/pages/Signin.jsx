import { FormControl, FormLabel } from "@chakra-ui/form-control";
import { AddIcon, ChevronDownIcon, LockIcon, SmallAddIcon, StarIcon } from "@chakra-ui/icons";
import { InputRightElement, InputGroup } from "@chakra-ui/input";
import {
  Box,
  Button,
  Heading,
  Icon,
  Input,
  Link,
  Text,
  VStack,
} from "@chakra-ui/react";

const Signin = () => {
  return (
    <Box className="flex items-center justify-center min-h-screen">
      <Box className="shadow-lg bg-white p-4 rounded-md w-96">
        <Box className="flex justify-center items-center my-4">
          <StarIcon w={8} h={8} color="blue.500" />
        </Box>
        <Heading className="text-2xl text-gray-900 mb-1 text-center font-semibold">
          Welcome!
        </Heading>
        <Heading className="text-sm text-gray-600 mb-6 text-center">
          Sign in to your account
        </Heading>
        <Box className="flex flex-col items-start">
          <VStack spacing={4} align="stretch" className="w-full mb-4">
            <FormControl>
              <FormLabel className="text-black">Login</FormLabel>
              <InputGroup>
                <Input className="text-black border-b-2 border-solid" />
                <InputRightElement className="items-center flex h-full mx-2">
                  <AddIcon w={4} h={4} color="gray.400" />
                </InputRightElement>
              </InputGroup>
            </FormControl>
            <FormControl>
              <FormLabel className="text-black">Password</FormLabel>
              <InputGroup>
                <Input className="text-black border-b-2 border-solid" />
                <InputRightElement className="items-center flex h-full mx-2">
                  <LockIcon w={4} h={4} color="gray.400" />
                </InputRightElement>
              </InputGroup>
            </FormControl>
          </VStack>
          <Text className="text-black">
            Don't have an account yet?{" "}
            <Link color="teal.500" href="/register">
              Sign Up
            </Link>
          </Text>
          <Button className="bg-blue-600 rounded-md text-white px-6 py-2 mt-4">
            Login
          </Button>
        </Box>
      </Box>
    </Box>
  );
};

export default Signin;
