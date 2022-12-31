// Component Imports
import Header from "./components/Header/Header";
import AuthLandingPage from "./components/Authentication/AuthLandingPage";

// Style imports
import './App.css';
export default function App() {
  return (
    <div className="App-Body-Layout">
      <Header />
      <AuthLandingPage />
    </div>
  )
}
