import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import {useState} from "react";
import Button from "react-bootstrap/Button";

export default function Header() {

    const [loggedIn, setLoggedIn] = useState(false);

    return (
        <Navbar bg="light" expand="lg">
            <Container>
                <Navbar.Brand href="#home">CS Hangout</Navbar.Brand>
                <Navbar.Collapse className="justify-content-end">
                    {loggedIn ?
                        <Nav>
                            <Nav.Link href="#home">I am a link! Click me!</Nav.Link>
                            <Button variant="outline-primary">Log out</Button>
                        </Nav>
                         :
                        <Nav>
                            <Nav.Link href="#home">I am a link! Click me!</Nav.Link>
                            <Button variant="outline-primary">Login</Button>
                        </Nav>
                    }
                </Navbar.Collapse>
            </Container>
        </Navbar>
    );
}

