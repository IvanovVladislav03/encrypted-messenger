import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import Signin from "./pages/Signin";
import Signup from "./pages/Signup";
import Main from "./pages/Main";
import { UserProvider } from "../UserContext";


function App() {
  return (
    <UserProvider>
    <Router>
      <Routes>
        <Route path="/login" element={<Signin />} />
        <Route path="/register" element={<Signup />} />
        <Route path="/main" element={<Main />} />
      </Routes>
    </Router>
    </UserProvider>
  );
}

export default App;
