import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import Signin from "../pages/Signin";

function App() {
  return (
    <Router>
      <Routes>
        <Route path="/login" element={<Signin />} />
      </Routes>
    </Router>
  );
}

export default App;
