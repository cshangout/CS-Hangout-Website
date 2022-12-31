import renderer from 'react-test-renderer'
import AuthLandingPage from "./AuthLandingPage";

it('AuthLandingPage Renders Login Component', () => {
    const component = renderer.create(
        <AuthLandingPage />
    );

    expect(component).toBeInstanceOf(Object)
})