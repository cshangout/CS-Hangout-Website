import React, { useState } from 'react';
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
    const [validated, setValidated] = useState(false);

    const handleSubmit = (e) => {
        const form = e.currentTarget;

        if (form.checkValidity() === false) {
            e.preventDefault();
            e.stopPropagation();
            handleErrors();
        }

        setValidated(true);
    }

    // FIXME: Get toast component to render
    function handleErrors() {
        let username = document.getElementById('email').value;
        let password = document.getElementById('password').value;
        if (username === '' && password) {
            console.log(ToastConstants.loginErrorMsg.usernameEmpty); 
        }
        if (password === '' && username) {
            console.log(ToastConstants.loginErrorMsg.passwordEmpty);
        }
        if (password === '' && username === ''){
            console.log(ToastConstants.loginErrorMsg.bothFieldsEmpty);
        }
        if (password && username) {
            console.log(ToastConstants.loginErrorMsg.bothFieldsFilled);
        }
    }

    return (
        <Container fluid>
            <Row>
                <Col />
                <Col>
                    <CardGroup>
                        <Card style={{ width: '18rem' }}>
                            <Card.Body>
                                <Form
                                    noValidate
                                    validated={validated}
                                    onSubmit={handleSubmit}
                                    data-testid='login-form-validity-test'>
                                    {/* FIXME: Change hardcoded code: placeholder, maxLength */}
                                    <Form.Group className='mb-3'>
                                        <Form.Label htmlFor='email'>Email Address</Form.Label>
                                        <Form.Control
                                            type='email'
                                            placeholder={LoginConstants.email.placeholder}
                                            maxLength={40} id='email'
                                            required data-testid='login-form-email-input' />
                                        <Form.Control.Feedback
                                            type='invalid'
                                            data-testid='email-err-msg'
                                        >Please enter a valid email.
                                        </Form.Control.Feedback>
                                    </Form.Group>
                                    {/* FIXME: Change hardcoded code: placeholder, minLength, maxLength */}
                                    <Form.Group className='mb-3'>
                                        <Form.Label htmlFor='password'>Password</Form.Label>
                                        <Form.Control
                                            type='password'
                                            placeholder='Enter Password'
                                            minLength={LoginConstants.password.minLength}
                                            maxLength={LoginConstants.password.maxLength}
                                            id='password'
                                            required
                                            data-testid='login-form-password-input' />
                                        <Form.Control.Feedback
                                            type='invalid'
                                            data-testid='password-err-msg'
                                        >Please enter a password with a minimum of 8 chars.
                                        </Form.Control.Feedback>
                                    </Form.Group>
                                    <Button variant="primary" type="submit">
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
    )
}