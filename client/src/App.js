// Component Imports
import Header from "./Header/Header";
import AuthLandingPage from "./Authentication/AuthLandingPage";
// Style imports
import './App.css';
import { Container } from "react-bootstrap";

import { useState } from 'react';

export default function App() {
    const [isLoggedIn, setIsLoggedIn] = useState(false);

    return (
        <div className="App-Body-Layout">
            <Container fluid>
                <Header isLoggedIn={isLoggedIn} setIsLoggedIn={setIsLoggedIn} />
                <AuthLandingPage isLoggedIn={isLoggedIn} setIsLoggedIn={setIsLoggedIn} />
            </Container>
        </div>
    )
}
