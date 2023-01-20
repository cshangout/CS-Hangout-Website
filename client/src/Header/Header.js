import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import { useState } from "react";
import Button from "react-bootstrap/Button";

export default function Header({ isLoggedIn, setIsLoggedIn }) {
    const onClick = () => {
        setIsLoggedIn(isLoggedIn = false);
    }

    return (
        <Navbar bg="light" expand="lg">
            <Container>
                <Navbar.Brand href="#home">CS Hangout</Navbar.Brand>
                <Navbar.Collapse className="justify-content-end">
                    {isLoggedIn ?
                        <Nav>
                            <Nav.Link href="#home">I am a link! Click me!</Nav.Link>
                            <Button onClick={onClick} data-testid="header-logout-button-test" variant="outline-primary">Log out</Button>
                        </Nav>
                        :
                        <Nav>
                            <Nav.Link href="#home">I am a link! Click me!</Nav.Link>
                            <Button variant="outline-primary" data-testid="header-login-button-test" >Login</Button>
                        </Nav>
                    }
                </Navbar.Collapse>
            </Container>
        </Navbar>
    );
}

