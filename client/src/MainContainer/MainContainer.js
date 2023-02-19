import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import { useState } from "react";
import Button from "react-bootstrap/Button";
import {useNavigate} from "react-router-dom";

export default function MainContainer() {

    let navigate = useNavigate();
    const LoginRoute = () =>{
        let path = '/main';
        navigate(path);
    }

    return <div>Hello there</div>
}
