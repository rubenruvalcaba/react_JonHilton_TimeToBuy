import React, { Component, Fragment } from "react";
import Axios from "axios";

export default class AddToCart extends React.Component {
    state = {
        showNotification: false,
        quantity: 1
    };


    async addToCart(event) {
        event.preventDefault();

        // Builds the request
        let request = {
            productId: this.props.productId,
            quantity: this.state.quantity
        };
        const sessionId = localStorage.sessionId;
        if (sessionId) {
            request.sessionId = sessionId;
        }

        // Calls the webAPI
        const result = await Axios.post('/api/cart', request);

        // Takes the session id from the API
        localStorage.sessionId = result.data.sessionId;

        // Shows the notification
        this.setState({ showNotification: true, quantity: 1 })
        setTimeout(() => { this.setState({ showNotification: false }) }, 2000);

    }

    quantityChanged(event) {
        const quantity = parseInt(event.target.value, 10);
        this.setState({ quantity: quantity });
    }

    render() {
        return <form onSubmit={(event) => { this.addToCart(event) }}>
            <div>

                <input type="number"
                    className="form-control col-sm-2 mr-2"
                    value={this.state.quantity}
                    onChange={(event) => this.quantityChanged(event)}
                    required />
                <button className="btn btn-primary form-control col-sm-3"
                    type="submit"
                    disabled={this.state.showNotification}
                >Add to cart</button>

                {this.state.showNotification &&
                    <span className="alert alert-primary">Item added to your cart</span>}

            </div>
        </form>;

    }
}