import { fireEvent, render, screen } from '@testing-library/react';
import userEvent from '@testing-library/user-event'
import Login from '../components/Login/Login'


describe('Test the Login component', () => {
  test('render Login component', () => {
    render(<Login />);
    const passwordElement = screen.getByLabelText('Password');
    expect(passwordElement).toBeInTheDocument();
  });

  test('pass valid email to test email input', () => {
    render(<Login />);
    const testEmail = 'test@mail.com';

    const emailInput = screen.getByTestId('email-input');
    const submit = screen.getByText('Login');

    userEvent.type(emailInput, testEmail);
    fireEvent.click(submit);

    expect(emailInput).toBeValid();
  });

  test('pass empty string to test email input', () => {
    render(<Login />);
    const testEmail = '';

    const emailInput = screen.getByTestId('email-input');
    const submit = screen.getByText('Login');

    userEvent.type(emailInput, testEmail);
    fireEvent.click(submit);

    expect(emailInput).toBeInvalid();
  });

  test('pass email without "@" to test email input', () => {
    render(<Login />);
    const testEmail = 'thisshouldnotwork';

    const emailInput = screen.getByTestId('email-input');
    const submit = screen.getByText('Login');

    userEvent.type(emailInput, testEmail);
    fireEvent.click(submit);

    expect(emailInput).toBeInvalid();
  });

  test('pass email that is too long to test email input', () => {
    render(<Login />);
    const testEmail = '11111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111@gmail.com';

    const emailInput = screen.getByTestId('email-input');
    const submit = screen.getByText('Login');

    userEvent.type(emailInput, testEmail);
    fireEvent.click(submit);

    expect(emailInput).toBeInvalid();
  });

  test('pass valid password to test password input', () => {
    render(<Login />);
    const testPassword = 'thisis8char';

    const passwordInput = screen.getByTestId('password-input');
    const submit = screen.getByText('Login');

    userEvent.type(passwordInput, testPassword);
    fireEvent.click(submit);

    expect(passwordInput).toBeValid();
  });

  test('pass empty string to test password input', () => {
    render(<Login />);
    const testPassword = '';

    const passwordInput = screen.getByTestId('password-input');
    const submit = screen.getByText('Login');

    userEvent.type(passwordInput, testPassword);
    fireEvent.click(submit);

    expect(passwordInput).toBeInvalid();
  });

  // FIXME: This test does not work, not sure why
  test('pass password that is too short to test password input', () => {
    render(<Login />);
    const testPassword = 'short';

    const passwordInput = screen.getByTestId('password-input');
    const submit = screen.getByText('Login');

    userEvent.type(passwordInput, testPassword);
    fireEvent.click(submit);

    expect(passwordInput).toBeInvalid();
  });

  // FIXME: This test does not work, not sure why
  test('pass password that is too long to test password input', () => {
    render(<Login />);
    const testPassword = '11111111111111111111111111111111111111111111111111111111111111';

    const passwordInput = screen.getByTestId('password-input');
    const submit = screen.getByText('Login');

    userEvent.type(passwordInput, testPassword);
    fireEvent.click(submit);

    expect(passwordInput).toBeInvalid();
  });
})
