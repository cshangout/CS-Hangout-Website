import { render, screen } from '@testing-library/react';
import userEvent from '@testing-library/user-event'
import Login from '../Login/Login'


describe('Test the Login component', () => {
  test('render Login component', () => {
    render(<Login />);
    const passwordElement = screen.getByLabelText('Password');
    expect(passwordElement).toBeInTheDocument();
  });

  test('pass valid email to test email input', () => {
    render(<Login />);
    const testEmail = 'test@mail.com';
    const validEmail = 'test@mail.com';

    const emailInput = screen.getByPlaceholderText('someone@example.com');
    userEvent.type(emailInput, testEmail);

    expect(emailInput.value).toMatch(validEmail);
  })

  test('pass invalid email to test email input', () => {
    render(<Login />);
    const testEmail = 'test';
    const validEmail = 'test@mail.com';

    const emailInput = screen.getByPlaceholderText('someone@example.com');
    userEvent.type(emailInput, testEmail);

    expect(emailInput.value).not.toMatch(validEmail);
  })
})
