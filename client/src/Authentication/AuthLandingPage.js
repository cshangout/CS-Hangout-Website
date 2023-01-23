import Login from '../Login/Login';

export default function AuthLandingPage({ isLoggedIn, setIsLoggedIn }) {
    return (
        <Login isLoggedIn={isLoggedIn} setIsLoggedIn={setIsLoggedIn}/>
    )
}