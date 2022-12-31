import React from 'react';
import '../Login/Login.js'
import Card from 'react-bootstrap/Card';
import Form from 'react-bootstrap/Form';
import Container from 'react-bootstrap/Container';
import Button from 'react-bootstrap/Button';
import CardGroup from 'react-bootstrap/CardGroup';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';


// FIXME: Review formating of extra columns
export default function Login() {
    return (
        <Container fluid>
            <Row>
                <Col />
                <Col>
                    <CardGroup>
                        <Card style={{ width: '18rem' }}>
                            <Card.Body>
                                <Form>
                                    <Form.Group className='mb-3' controlId='user'>
                                        <Form.Label htmlFor='email'>Email Address</Form.Label>
                                        <Form.Control type='email' placeholder='someone@example.com' maxLength={40} id='email' />
                                        <Form.Label htmlFor='password'>Password</Form.Label>
                                        <Form.Control type='password' placeholder='Enter Password' minLength={8} maxLength={24} id='password' />
                                        <Button variant="primary" type="submit">
                                            Submit
                                        </Button>
                                    </Form.Group>
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