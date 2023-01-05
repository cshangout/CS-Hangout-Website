import { render, screen } from '@testing-library/react';
import userEvent from '@testing-library/user-event';
import Login from '../Login/Login';


describe('Test the Login component', () => {
  test('render Login component', () => {
    render(<Login />);
    const passwordElement = screen.getByLabelText('Password');
    expect(passwordElement).toBeInTheDocument();
  });

  test('pass empty string to test email input', () => {
    render(<Login />);
    const testEmail = '';
    const isValid = screen.getByTestId('login-form-validity-test');

    const emailInput = screen.getByTestId('login-form-email-input');
    const submit = screen.getByText('Login');

    userEvent.type(emailInput, testEmail);
    userEvent.click(submit);

    expect(isValid).toBeInvalid();
  });

  test('pass email without "@" to test email input', () => {
    render(<Login />);
    const testEmail = 'thisshouldnotwork';
    const isValid = screen.getByTestId('login-form-validity-test');

    const emailInput = screen.getByTestId('login-form-email-input');
    const submit = screen.getByText('Login');

    userEvent.type(emailInput, testEmail);
    userEvent.click(submit);

    expect(isValid).toBeInvalid();
  });

  test('pass email that is too long to test email input', () => {
    render(<Login />);
    const testEmail = '11111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111@gmail.com';

    const emailInput = screen.getByTestId('login-form-email-input');
    const submit = screen.getByText('Login');
    const isValid = screen.getByTestId('login-form-validity-test');

    userEvent.type(emailInput, testEmail);
    userEvent.click(submit);

    expect(isValid).toBeInvalid();
  });

  test('pass empty string to test password input', () => {
    render(<Login />);
    const testPassword = '';

    const passwordInput = screen.getByTestId('login-form-password-input');
    const submit = screen.getByText('Login');
    const isValid = screen.getByTestId('login-form-validity-test');

    userEvent.type(passwordInput, testPassword);
    userEvent.click(submit);

    expect(isValid).toBeInvalid();
  });

  test('pass password that is too short to test password input', () => {
    render(<Login />);
    const testPassword = 'short';

    const passwordInput = screen.getByTestId('login-form-password-input');
    const submit = screen.getByText('Login');
    const isValid = screen.getByTestId('login-form-validity-test');

    userEvent.type(passwordInput, testPassword);
    userEvent.click(submit);

    expect(isValid).toBeInvalid();
  });

  test('pass password that is too long to test password input', () => {
    render(<Login />);
    const testPassword = '11111111111111111111111111111111111111111111111111111111111111';

    const passwordInput = screen.getByTestId('login-form-password-input');
    const submit = screen.getByText('Login');
    const isValid = screen.getByTestId('login-form-validity-test');

    userEvent.type(passwordInput, testPassword);
    userEvent.click(submit);

    expect(isValid).toBeInvalid();
  });

  test('pass valid email and password to test email and password input', () => {
    render(<Login />);
    const testEmail = 'test@mail.com';
    const testPassword = 'thisis8char';
    const isValid = screen.getByTestId('login-form-validity-test');

    const emailInput = screen.getByTestId('login-form-email-input');
    const passwordInput = screen.getByTestId('login-form-password-input');
    const submit = screen.getByText('Login');

    userEvent.type(emailInput, testEmail);
    userEvent.type(passwordInput, testPassword);
    userEvent.click(submit);

    expect(isValid).toBeValid();
  });
})
