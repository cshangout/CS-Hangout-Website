import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import {useState} from "react";
import Button from "react-bootstrap/Button";
import {useNavigate} from "react-router-dom";

export default function Header() {

    const [loggedIn, setLoggedIn] = useState(false);

    let navigate = useNavigate();
    //callable constant for onClick function to direct user to register route
    const registerRoute = () =>{
        let path = '/register';
        navigate(path);
    }

    return (
        <Navbar bg="light" expand="lg">
            <Container>
                <Navbar.Brand href="#home">CS Hangout</Navbar.Brand>
                <Navbar.Collapse className="justify-content-end">
                    {/*if logged in, following displays in header*/}
                    {loggedIn ?
                        <Nav>
                            <Nav.Link href="#home">I am a link! Click me!</Nav.Link>
                            <Button variant="outline-primary">Log out</Button>
                        </Nav>
                         // if not logged in, this displays
                         :
                        <Nav>
                            <Nav.Link href="#home">I am a link! Click me!</Nav.Link>
                            <Button variant="outline-primary" onClick={registerRoute}>Register</Button>
                            <Button variant="outline-primary">Login</Button>
                        </Nav>
                    }
                </Navbar.Collapse>
            </Container>
        </Navbar>
    );
}

