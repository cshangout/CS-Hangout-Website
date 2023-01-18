// Component Imports
import Header from "./Header/Header";
import AuthLandingPage from "./Authentication/AuthLandingPage";
// Style imports
import './App.css';
import {Container} from "react-bootstrap";
export default function App() {
  return (
      <div className="App-Body-Layout">
          <Container fluid>
              <Header />
              <AuthLandingPage />
          </Container>
      </div>
  )
}
