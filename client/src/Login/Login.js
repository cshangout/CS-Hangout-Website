import React, { useState, useEffect } from 'react';
import './Login.js'
import Card from 'react-bootstrap/Card';
import Form from 'react-bootstrap/Form';
import Container from 'react-bootstrap/Container';
import Button from 'react-bootstrap/Button';
import CardGroup from 'react-bootstrap/CardGroup';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import { LoginConstants, ToastConstants } from "../__helpers__/Constants";
import Toast from '../Toast/Toast';


// FIXME: Review formating of extra columns
export default function Login() {
    const [show, setShow] = useState(false);
    const [color, setColor] = useState(null);
    const [message, setMessage] = useState(null);
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');

    const [loginInfoValid, setLoginInfoValid] = useState(false);
    const [usernameValid, setUsernameValid] = useState(false);
    const [passwordValid, setPasswordValid] = useState(false);

    const handleSubmit = (e) => {
        const form = e.currentTarget;
        e.preventDefault();

        let tempVarToActAsSuccessfulRequest = false;
        let responseCode = 401;

        const checkValid = () => {
            if (tempVarToActAsSuccessfulRequest) {
                console.log("Route to homepage")
            }
            else {
                e.stopPropagation();
                handleErrors(responseCode);
            }
        }
        checkValid();
    }

    const onEmailChange = (e) => {
        setEmail(e.target.value);
    }

    const onPasswordChange = (e) => {
        setPassword(e.target.value);
    }

    const validateEmailInput = () => {
        if (email.length < 40 && email.includes('@')) {
            setUsernameValid(true);
        }
        else {
            setUsernameValid(false);
        }
    }

    const validatePasswordInput = () => {
        if (password.length >= 8 && password.length < 24) {
            setPasswordValid(true);
        }
        else {
            setPasswordValid(false);
        }
    }

    const isFormValid = () => {
        if (usernameValid && passwordValid) {
            setLoginInfoValid(true);
        }
        else {
            setLoginInfoValid(false);
        }
    }

    useEffect(() => {
        validateEmailInput()
        validatePasswordInput()
        isFormValid()
    }, [usernameValid, passwordValid, email, password])

    const handleErrors = (responseCode) => {
        switch (responseCode) {
            case 401: 
                setColor(ToastConstants.color.error);
                setMessage(ToastConstants.loginErrorMsg.unauthorizedLogin);
                setShow(true);
                break;
            default:
                console.log("Unhandled error code");
        }
    }

    return (
        <div>
            {show ? <Toast
                onClose={() => setShow(false)}
                show={show}
                delay={3000}
                autohide={true}
                color={color}
                message={message} /> : null}
            <Container fluid>
                <Row>
                    <Col />
                    <Col>
                        <CardGroup>
                            <Card style={{ width: '18rem' }}>
                                <Card.Body>
                                    <Form
                                        noValidate
                                        onSubmit={handleSubmit}
                                        data-testid='login-form-validity-test'>
                                        <Form.Group className='mb-3'>
                                            <Form.Label htmlFor='email'>Email Address</Form.Label>
                                            <Form.Control
                                                type='email'
                                                placeholder={LoginConstants.email.placeholder}
                                                maxLength={40} id='email'
                                                required data-testid='login-form-email-input'
                                                onChange={(e) => onEmailChange(e)} />
                                            <Form.Control.Feedback
                                                type='invalid'
                                                data-testid='email-err-msg'
                                            >Please enter a valid email.
                                            </Form.Control.Feedback>
                                        </Form.Group>
                                        <Form.Group className='mb-3'>
                                            <Form.Label htmlFor='password'>Password</Form.Label>
                                            <Form.Control
                                                type='password'
                                                placeholder='Enter Password'
                                                minLength={LoginConstants.password.minLength}
                                                maxLength={LoginConstants.password.maxLength}
                                                id='password'
                                                required
                                                data-testid='login-form-password-input'
                                                onChange={(e) => onPasswordChange(e)} />
                                            <Form.Control.Feedback
                                                type='invalid'
                                                data-testid='password-err-msg'
                                            >Please enter a password with a minimum of 8 chars.
                                            </Form.Control.Feedback>
                                        </Form.Group>
                                        <Button onSubmit={handleSubmit} variant="primary" type="submit" disabled={!loginInfoValid}>
                                            Login
                                        </Button>
                                    </Form>
                                </Card.Body>
                            </Card>
                        </CardGroup>
                    </Col>
                    <Col />
                </Row>
            </Container>
        </div>
    )
}