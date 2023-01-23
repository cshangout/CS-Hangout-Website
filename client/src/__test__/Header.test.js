import { render, screen } from '@testing-library/react';
import userEvent from '@testing-library/user-event';
import App from '../App';
import Header from "../Header/Header";

describe('Test the Header component', () => {
    test('render Header component', () => {
        const component = render(<Header />);
        expect(component).toBeInstanceOf(Object)
    })

    // TODO: useNavigate() may be used only in the context of a <Router> component.
    test('when not logged in, login button shows', () => {
        render(<Header />);
        const loginButton = screen.getByTestId('header-login-button-test');

        expect(loginButton).toBeInTheDocument();
    })

    // TODO: useNavigate() may be used only in the context of a <Router> component.
    test('when logged in, logout button shows', () => {
        render(<Header isLoggedIn={true} />);

        const logoutButton = screen.getByTestId('header-logout-button-test');
        expect(logoutButton).toBeInTheDocument();
    })
})