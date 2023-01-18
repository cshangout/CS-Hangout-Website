// Constants related to login and register requirements
export const UserConstants = {
    username: {
        length: 40,
        placeholder: "Enter Username"
    },
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
        unauthorizedLogin: "The username or password you have entered is invalid or not recognized. Try again.",
        bothFieldsEmpty: "Username and Password fields are empty. Please enter a username and password.",
        passwordEmpty: "Password field is empty. Please enter a password.",
        usernameEmpty: "Username field is empty. Please enter a username.",
    },
    serverErrorMsg: {
        badRequest: "Bad request. Invalid request.",
        serverDown: "Server error. Server is potentially down or not responding.",
        default: "An error has occurred.",
    },
    registerMsg: {
        userAlreadyRegistered: "Bad request. User is already registered.",
        unauthorizedRegister: "Unauthorized to register account.",
        contactSupport: "Server error received. Contact tech support if they exist.",
    },
    color: {
        success: "success",
        error: "danger",
    }
}