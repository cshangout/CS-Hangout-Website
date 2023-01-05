import React from "react";
import Toast from 'react-bootstrap/Toast';
import ToastContainer from 'react-bootstrap/ToastContainer';

/*
 * Toast component takes the props: 
 * @param {color}
 * @param {message}
*/


export default function ToastEl({ color, message }) {

    

    return (
        <ToastContainer position ='top-center'>
            <Toast bg={color} data-testid='does-toast-render'>
                <Toast.Body>{message}</Toast.Body>
            </Toast>
        </ToastContainer>
    )
}