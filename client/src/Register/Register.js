import { Container } from "react-bootstrap"
import { UserConstants, ToastConstants } from "../__helpers__/Constants"
import React, { useState, useEffect } from 'react';
import Form from 'react-bootstrap/Form';
import Button from 'react-bootstrap/Button';
import Card from 'react-bootstrap/Card';
import CardGroup from 'react-bootstrap/CardGroup';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import Toast from '../Toast/Toast';

// FIXME: Review formating of extra columns
export default function Register() {
    const [show, setShow] = useState(false);
    const [color, setColor] = useState(null);
    const [message, setMessage] = useState(null);
    const [username, setUsername] = useState('');
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [checkPassword, setCheckPassword] = useState('')

    const [registerInfoValid, setRegisterInfoValid] = useState(false);
    const [emailValid, setEmailValid] = useState(false);
    const [usernameValid, setUsernameValid] = useState(false);
    const [passwordValid, setPasswordValid] = useState(false);

    const handleSubmit = async (e) => {
        const form = e.currentTarget;
        e.preventDefault();

        const requestOptions = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({
                Username: username,
                Email: email,
                Password: password
            })
        };

        fetch('https://localhost:5001/api/auth/register', requestOptions)
            .then(function (response) {
                console.log("Status Code: " + response.status);
                if (!response.ok) {
                    handleErrors(response.status);
                }
                else {
                    console.log("Submission successful!");
                    return response.json();
                }
            })
            .then(data => console.log(data));
    }

    const onEmailChange = (e) => {
        setEmail(e.target.value);
    }

    const onUsernameChange = (e) => {
        setUsername(e.target.value);
    }

    const onPasswordChange = (e) => {
        setPassword(e.target.value);
    }

    const onCheckPasswordChange = (e) => {
        setCheckPassword(e.target.value);
    }

    const validateUsernameInput = () => {
        if (username.length < 40) {
            setUsernameValid(true);
        }
        else {
            setUsernameValid(false);
        }
    }

    const validateEmailInput = () => {
        if (email.length < 40 && email.includes('@')) {
            setEmailValid(true);
        }
        else {
            setEmailValid(false);
        }
    }

    const validatePasswordInput = () => {
        if (password.length >= 8 && password.length < 24 && password === checkPassword) {
            setPasswordValid(true);
        }
        else {
            setPasswordValid(false);
        }
    }

    const isFormValid = () => {
        if (usernameValid && emailValid && passwordValid) {
            setRegisterInfoValid(true);
        }
        else {
            setRegisterInfoValid(false);
        }
    }

    useEffect(() => {
        validateUsernameInput()
        validateEmailInput()
        validatePasswordInput()
        isFormValid()
    }, [usernameValid, emailValid, passwordValid, username, email, password, checkPassword])

    const handleErrors = (responseCode) => {
        switch (responseCode) {
            case 400:
                setColor(ToastConstants.color.error);
                setMessage(ToastConstants.registerMsg.userAlreadyRegistered);
                setShow(true);
                break;
            case 401:
                setColor(ToastConstants.color.error);
                setMessage(ToastConstants.registerMsg.unauthorizedRegister);
                setShow(true);
                break;
            case 500:
                setColor(ToastConstants.color.error);
                setMessage(ToastConstants.registerMsg.contactSupport);
                setShow(true);
                break;
            default:
                setColor(ToastConstants.color.error);
                setMessage("Unhandled error code");
                setShow(true);
                break;
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
            <Container fluid className="p-5">
                <Row>
                    <Col />
                    <Col>
                        <CardGroup>
                            <Card style={{ width: '18rem' }}>
                                <Card.Body>
                                    <Card.Title className="text-center">Register Form</Card.Title>
                                    <Form
                                        noValidate
                                        onSubmit={handleSubmit}
                                        data-testid='register-form-validity-test'>
                                        <Form.Group className='mb-3'>
                                            <Form.Label htmlFor='username'>Username</Form.Label>
                                            <Form.Control
                                                type='text'
                                                placeholder={UserConstants.username.placeholder}
                                                maxLength={40} id='username'
                                                required data-testid='register-form-username-input'
                                                onChange={(e) => onUsernameChange(e)} />
                                            <Form.Control.Feedback
                                                type='invalid'
                                                data-testid='username-err-msg'
                                            >Please enter a valid email.
                                            </Form.Control.Feedback>
                                            <Form.Label htmlFor='email'>Email Address</Form.Label>
                                            <Form.Control
                                                type='email'
                                                placeholder={UserConstants.email.placeholder}
                                                maxLength={40} id='email'
                                                required data-testid='register-form-email-input'
                                                onChange={(e) => onEmailChange(e)} />
                                            <Form.Control.Feedback
                                                type='invalid'
                                                data-testid='email-err-msg'
                                            >Please enter a valid email.
                                            </Form.Control.Feedback>
                                            <Form.Label htmlFor='password'>Password</Form.Label>
                                            <Form.Control
                                                type='password'
                                                placeholder='Enter Password'
                                                minLength={UserConstants.password.minLength}
                                                maxLength={UserConstants.password.maxLength}
                                                id='password'
                                                required
                                                data-testid='register-form-password-input'
                                                onChange={(e) => onPasswordChange(e)} />
                                            <Form.Control.Feedback
                                                type='invalid'
                                                data-testid='password-err-msg'
                                            >Please enter a password with a minimum of 8 chars.
                                            </Form.Control.Feedback>
                                            <Form.Label htmlFor='checkPassword'>Retype Password</Form.Label>
                                            <Form.Control
                                                type='password'
                                                placeholder='Enter Password Again'
                                                minLength={UserConstants.password.minLength}
                                                maxLength={UserConstants.password.maxLength}
                                                id='checkPassword'
                                                required
                                                data-testid='register-form-check-password-input'
                                                onChange={(e) => onCheckPasswordChange(e)} />
                                            <Form.Control.Feedback
                                                type='invalid'
                                                data-testid='check-password-err-msg'
                                            >Please make sure your password is the same!
                                            </Form.Control.Feedback>
                                        </Form.Group>
                                        <Button variant="primary" type="submit" disabled={!registerInfoValid}>
                                            Register
                                        </Button>
                                    </Form>
                                </Card.Body>
                            </Card>
                        </CardGroup>
                    </Col>
                    <Col>
                    </Col>
                </Row>
            </Container>
        </div>
    )
}