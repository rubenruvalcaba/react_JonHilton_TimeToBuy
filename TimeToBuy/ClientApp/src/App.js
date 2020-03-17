import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { Counter } from './components/Counter';

import './custom.css'
import ProductDetail from './components/Products/ProductDetail';
import Cart from './components/Cart/Cart';
import CheckoutPage from './components/Checkout/CheckoutPage';
import { Button } from "reactstrap";
import Callback from "./components/Callback";

export default class App extends Component {
    static displayName = App.name;

    render() {
        return (
            <Route path="/*" component={({ ...others }) =>
                <Layout auth={this.props.auth}>
                    <Route exact path='/' component={Home} />
                    <Route path='/counter' component={Counter} />
                    <Route path='/fetch-data' component={FetchData} />
                    <Route path='/product/:id' component={ProductDetail} />
                    <Route path='/cart' component={Cart} />
                    <Route path='/callback' component={({ ...others }) =>
                        <Callback auth={this.props.auth} {...others} />
                    } />
                    <Route path='/checkout' component={({ ...others }) =>
                        <SecureCheckout auth={this.props.auth} {...others}>
                            <CheckoutPage auth={this.props.auth} {...others} />
                        </SecureCheckout>
                    } />
                </Layout>
            } />
        );
    }
}

export class SecureCheckout extends Component {
    state = { authenticated: false };

    async componentDidMount() {
        const isLoggedIn = await this.props.auth.isAuthenticated();
        this.setState({ authenticated: isLoggedIn });
    }

    handleLogin = async () => {
        await this.props.auth.loginWithRedirect();
    }

    render() {
        return (
            this.state.authenticated
                ? this.props.children
                : <div>
                    <p>Please register or log in to complete your order</p>
                    <Button color="primary" onClick={this.handleLogin}>Login or sign up</Button>
                </div>
        );
    }
}