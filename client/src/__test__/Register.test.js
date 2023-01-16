import { render, screen } from '@testing-library/react';
import userEvent from '@testing-library/user-event';
import Register from '../Register/Register';

describe('Test the Register component', () => {
    test('render Register component', () => {
      render(<Register />);
      const passwordElement = screen.getByLabelText('Password');
      expect(passwordElement).toBeInTheDocument();
    });

    test('pass empty string to test username input', () => {
        render(<Register />);
        const testUsername = '';
        const isValid = screen.getByTestId('register-form-validity-test');
    
        const usernameInput = screen.getByTestId('register-form-username-input');
        const submit = screen.getByText('Register');
    
        userEvent.type(usernameInput, testUsername);
        userEvent.click(submit);
    
        expect(isValid).toBeInvalid();
      });

    test('pass username that is too long to test username input', () => {
        render(<Register />);
        const testUsername = '11111111111111111111111111111111111111111111111111';
        const isValid = screen.getByTestId('register-form-validity-test');
    
        const usernameInput = screen.getByTestId('register-form-username-input');
        const submit = screen.getByText('Register');
    
        userEvent.type(usernameInput, testUsername);
        userEvent.click(submit);
    
        expect(isValid).toBeInvalid();
      });

    test('pass empty string to test email input', () => {
        render(<Register />);
        const testEmail = '';
        const isValid = screen.getByTestId('register-form-validity-test');
    
        const emailInput = screen.getByTestId('register-form-email-input');
        const submit = screen.getByText('Register');
    
        userEvent.type(emailInput, testEmail);
        userEvent.click(submit);
    
        expect(isValid).toBeInvalid();
      });

      test('pass email without "@" to test email input', () => {
        render(<Register />);
        const testEmail = 'thisshouldnotwork';
        const isValid = screen.getByTestId('register-form-validity-test');
    
        const emailInput = screen.getByTestId('register-form-email-input');
        const submit = screen.getByText('Register');
    
        userEvent.type(emailInput, testEmail);
        userEvent.click(submit);
    
        expect(isValid).toBeInvalid();
      });

      test('pass email that is too long to test email input', () => {
        render(<Register />);
        const testEmail = '11111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111@gmail.com';
    
        const emailInput = screen.getByTestId('register-form-email-input');
        const submit = screen.getByText('Register');
        const isValid = screen.getByTestId('register-form-validity-test');
    
        userEvent.type(emailInput, testEmail);
        userEvent.click(submit);
    
        expect(isValid).toBeInvalid();
      });

      test('pass empty string to test password input', () => {
        render(<Register />);
        const testPassword = '';
    
        const passwordInput = screen.getByTestId('register-form-password-input');
        const submit = screen.getByText('Register');
        const isValid = screen.getByTestId('register-form-validity-test');
    
        userEvent.type(passwordInput, testPassword);
        userEvent.click(submit);
    
        expect(isValid).toBeInvalid();
      });

      test('pass password that is too short to test password input', () => {
        render(<Register />);
        const testPassword = 'short';
    
        const passwordInput = screen.getByTestId('register-form-password-input');
        const submit = screen.getByText('Register');
        const isValid = screen.getByTestId('register-form-validity-test');
    
        userEvent.type(passwordInput, testPassword);
        userEvent.click(submit);
    
        expect(isValid).toBeInvalid();
      });

      test('pass password that is too long to test password input', () => {
        render(<Register />);
        const testPassword = '11111111111111111111111111111111111111111111111111111111111111';
    
        const passwordInput = screen.getByTestId('register-form-password-input');
        const submit = screen.getByText('Register');
        const isValid = screen.getByTestId('register-form-validity-test');
    
        userEvent.type(passwordInput, testPassword);
        userEvent.click(submit);
    
        expect(isValid).toBeInvalid();
      });

      test('pass not matching passwords', () => {
        render(<Register />);
        const testPassword = 'passwordOne';
        const testCheckPassword = 'passwordTwo';
    
        const passwordInput = screen.getByTestId('register-form-password-input');
        const checkPasswordInput = screen.getByTestId('register-form-check-password-input');
        const submit = screen.getByText('Register');
        const isValid = screen.getByTestId('register-form-validity-test');
    
        userEvent.type(passwordInput, testPassword);
        userEvent.type(checkPasswordInput, testCheckPassword);
        userEvent.click(submit);
    
        expect(isValid).toBeInvalid();
      });

      test('pass valid username, email, password to test correct form submission', () => {
        render(<Register />);
        const testUsername = 'testusername'
        const testEmail = 'test@mail.com';
        const testPassword = 'thisis8char';
        const isValid = screen.getByTestId('register-form-validity-test');
    
        const usernameInput = screen.getByTestId('register-form-username-input');
        const emailInput = screen.getByTestId('register-form-email-input');
        const passwordInput = screen.getByTestId('register-form-password-input');
        const checkPasswordInput = screen.getByTestId('register-form-check-password-input');
        const submit = screen.getByText('Register');
    
        userEvent.type(usernameInput, testUsername);
        userEvent.type(emailInput, testEmail);
        userEvent.type(passwordInput, testPassword);
        userEvent.type(checkPasswordInput, testPassword);
        userEvent.click(submit);
    
        expect(isValid).toBeValid();
      });
})