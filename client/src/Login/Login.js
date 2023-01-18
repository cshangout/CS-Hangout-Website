import React, { useState, useEffect } from 'react';
import './Login.js'
import Card from 'react-bootstrap/Card';
import Form from 'react-bootstrap/Form';
import Container from 'react-bootstrap/Container';
import Button from 'react-bootstrap/Button';
import CardGroup from 'react-bootstrap/CardGroup';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import { UserConstants, ToastConstants } from "../__helpers__/Constants";
import Toast from '../Toast/Toast';


// FIXME: Review formating of extra columns
export default function Login() {
    const [showToast, setShowToast] = useState(false);
    const [color, setColor] = useState(null);
    const [message, setMessage] = useState(null);
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');

    const [loginInfoValid, setLoginInfoValid] = useState(false);
    const [usernameValid, setUsernameValid] = useState(false);
    const [passwordValid, setPasswordValid] = useState(false);

    const URL = process.env.REACT_APP_BACKEND_API_ENDPOINT;

    const handleSubmit = async (e) => {
        const form = e.currentTarget;
        e.preventDefault();

        const requestOptions = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json'},
            body: JSON.stringify({
                Email: email,
                Password: password
            })
        };

        fetch(`${URL}/api/auth`, requestOptions)
            .then((response) => {
                console.log("Status Code: " + response.status);
                if (!response.ok) {
                    handleErrors(response.status);
                }
                else {
                    console.log("Route to next page!");
                    return response.json();
                }
            })
            .then(data => console.log(data));
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
            case 400:
                setColor(ToastConstants.color.error);
                setMessage(ToastConstants.serverErrorMsg.badRequest);
                setShowToast(true);
                break;
            case 401:
                setColor(ToastConstants.color.error);
                setMessage(ToastConstants.loginErrorMsg.unauthorizedLogin);
                setShowToast(true);
                break;
            case 500:
                setColor(ToastConstants.color.error);
                setMessage(ToastConstants.serverErrorMsg.serverDown);
                setShowToast(true);
                break;
            default:
                setColor(ToastConstants.color.error);
                setMessage("Unhandled error code");
                setShowToast(true);
                break;
        }
    }

    return (
        <div>
            {showToast ? <Toast
                onClose={() => setShowToast(false)}
                showToast={showToast}
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
                                                placeholder={UserConstants.email.placeholder}
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
                                                minLength={UserConstants.password.minLength}
                                                maxLength={UserConstants.password.maxLength}
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
                                        <Button variant="primary" type="submit" disabled={!loginInfoValid}>
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
