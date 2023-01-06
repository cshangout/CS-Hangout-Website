import { render, screen } from '@testing-library/react';
import AuthLandingPage from "../Authentication/AuthLandingPage";

describe('Test the AuthLandingPage component', () => {
    test('render AuthLandingPage component', () => {
        const component = render(<AuthLandingPage/ >);
        expect(component).toBeInstanceOf(Object)
    })
})