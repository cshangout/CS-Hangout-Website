// Constants related to login requirements
export const LoginConstants = {
    email: {
        length: 40,
        placeholder: "someone@example.com"
    },
    password: {
        minLength: 8,
        maxLength: 24
    }
}

// Constants related to toast alerts
export const ToastConstants = {
    loginErrorMsg: {
        bothFieldsFilled: "The username or password you have entered is invalid or not recognized. Try again.",
        bothFieldsEmpty: "Username and Password fields are empty. Please enter a username and password.",
        passwordEmpty: "Password field is empty. Please enter a password.",
        usernameEmpty: "Username field is empty. Please enter a username.",
    },
    color: {
        error: "danger",
    }
}