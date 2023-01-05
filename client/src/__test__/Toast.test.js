import { render, screen } from '@testing-library/react';
import Toast from '../Toast/Toast';

describe('Test the Toast component', () => {
    test('render Toast component', () => {
        render(<Toast/ >);
        const toastElement = screen.getByTestId('does-toast-render');
        expect(toastElement).toBeInTheDocument();
    })

    // FIXME: Figure out how to test color prop
    test('pass color to test color prop', () => {
        const testColor = 'danger';
        render(<Toast color = {testColor} />);
        const toastElement = screen.getByTestId('does-toast-render');
        expect(toastElement.className).toBe(testColor);
    })

    test('pass message to test message prop' , () => {
        const testMsg = 'Test Message';
        render(<Toast message = {testMsg} />);
        const toastElement = screen.getByText(testMsg);
        expect(toastElement.innerHTML).toBe(testMsg);
    })
})