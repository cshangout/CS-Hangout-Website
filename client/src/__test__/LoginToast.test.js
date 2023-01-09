import { render, screen } from '@testing-library/react';
import userEvent from '@testing-library/user-event';
import Login from '../Login/Login';
import { ToastConstants } from '../__helpers__/Constants';

// TODO: Work on mocking these tests
describe('Test the Toast component within the Login component', () => {
  test('toast component is hidden', () => {
    render(<Login />);
    const toastElement = screen.queryByRole('alert');
    expect(toastElement).toBeNull();
  });

  test('toast component shows on error', () => {
    render(<Login />);
    const testEmail = '';

    const emailInput = screen.getByTestId('login-form-email-input');
    const submit = screen.getByText('Login');

    userEvent.type(emailInput, testEmail);
    userEvent.click(submit);

    const toastElement = screen.getByRole('alert');
    expect(toastElement).toBeInTheDocument();
  });

  test('toast component shows correct message with empty username field', () => {
    render(<Login />);
    const testEmail = '';
    const testPassword = 'thisis8char';

    const emailInput = screen.getByTestId('login-form-email-input');
    const passwordInput = screen.getByTestId('login-form-password-input');
    const submit = screen.getByText('Login');

    userEvent.type(emailInput, testEmail);
    userEvent.type(passwordInput, testPassword);
    userEvent.click(submit);

    const toastMessage = screen.queryByText(ToastConstants.loginErrorMsg.usernameEmpty);
    expect(toastMessage.innerHTML).toBe(ToastConstants.loginErrorMsg.usernameEmpty);
  });

  test('toast component shows correct message with empty password field', () => {
    render(<Login />);
    const testEmail = 'test@email.com';
    const testPassword = '';

    const emailInput = screen.getByTestId('login-form-email-input');
    const passwordInput = screen.getByTestId('login-form-password-input');
    const submit = screen.getByText('Login');

    userEvent.type(emailInput, testEmail);
    userEvent.type(passwordInput, testPassword);
    userEvent.click(submit);

    const toastMessage = screen.queryByText(ToastConstants.loginErrorMsg.passwordEmpty);
    expect(toastMessage.innerHTML).toBe(ToastConstants.loginErrorMsg.passwordEmpty);
  });

  test('toast component shows correct message with both fields empty', () => {
    render(<Login />);
    const testEmail = '';
    const testPassword = '';

    const emailInput = screen.getByTestId('login-form-email-input');
    const passwordInput = screen.getByTestId('login-form-password-input');
    const submit = screen.getByText('Login');

    userEvent.type(emailInput, testEmail);
    userEvent.type(passwordInput, testPassword);
    userEvent.click(submit);

    const toastMessage = screen.queryByText(ToastConstants.loginErrorMsg.bothFieldsEmpty);
    expect(toastMessage.innerHTML).toBe(ToastConstants.loginErrorMsg.bothFieldsEmpty);
  });

  test('toast component shows correct message with both fields filled', () => {
    render(<Login />);
    const testEmail = 'test@mail.com';
    const testPassword = 'thisis8char';

    const emailInput = screen.getByTestId('login-form-email-input');
    const passwordInput = screen.getByTestId('login-form-password-input');
    const submit = screen.getByText('Login');

    userEvent.type(emailInput, testEmail);
    userEvent.type(passwordInput, testPassword);
    userEvent.click(submit);

    const toastMessage = screen.queryByText(ToastConstants.loginErrorMsg.unauthorizedLogin);
    expect(toastMessage.innerHTML).toBe(ToastConstants.loginErrorMsg.unauthorizedLogin);
  });

})