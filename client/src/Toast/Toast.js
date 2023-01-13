import React from "react";
import Toast from 'react-bootstrap/Toast';
import ToastContainer from 'react-bootstrap/ToastContainer';

/**
 * Toast component takes the props: 
 * @param color
 * @param message
 * @param show
 * @param autohide
 * @param delay
 * @param onClose
*/
export default function ToastAlertComponent({ color, message, show, autohide, delay, onClose }) {
    return (
        <ToastContainer position ='top-center'>
            <Toast bg={color} data-testid='does-toast-render' show={show} 
            autohide={autohide} delay={delay} onClose={onClose}>
                <Toast.Body>{message}</Toast.Body>
            </Toast>
        </ToastContainer>
    )
}