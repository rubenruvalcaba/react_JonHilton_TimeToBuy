import React from "react";
import { Button } from "reactstrap";

export default class LogInOut extends React.Component {
    state = { authenticated: false };

    async componentDidMount() {
        const isLoggedIn = await this.props.auth.isAuthenticated();
        this.setState({ authenticated: isLoggedIn });
    }

    handleLogIn = async () => {
        await this.props.auth.loginWithRedirect();
    }

    handleLogOff = async () => {
        await this.props.auth.logout();
        this.setState({ authenticated: true });
    }

    render() {
        return (
            this.state.authenticated
                ? <Button color="primary" onClick={this.handleLogOff}>Log off</Button>
                : <Button color="primary" onClick={this.handleLogIn}>Log in</Button>
        );
    }
}