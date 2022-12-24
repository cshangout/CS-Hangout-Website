import React from 'react';
import '../Login/Login.js'

export default function Login() {
    return (
        <div className='container h-100 p-3 d-flex justify-content-center align-items-center'>
            <div className='card'>
                <div className='card-body'>
                    <div className='form-group'>
                        <label htmlFor='UsernameInput'>Username: </label>
                        <input
                            name='username'
                            className='form-control'
                            id='UsernameInput'
                            type='email'
                            placeholder='Enter Username'
                            maxLength='40'
                        />
                        <label htmlFor='PasswordInput'>Password: </label>
                        <input
                            name='password'
                            className='form-control'
                            id='PasswordInput'
                            type='password'
                            placeholder='Enter Password'
                            minLength='8'
                            maxLength='24'
                        />
                    </div>
                </div>
            </div>
        </div>
    )
}