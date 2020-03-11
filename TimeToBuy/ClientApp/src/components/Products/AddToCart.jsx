import React, { Component } from "react";
import Axios from "axios";

export default class AddToCart extends React.Component {
    async addToCart() {

        const sessionId = localStorage.sessionId;
        const result =  await Axios.post('/api/cart', {
            productId: this.props.productId,
            sessionId: sessionId
        });  
        localStorage.sessionId = result.data.sessionId;

    }

    render() {
        return (
            <button className="btn btn-primary" onClick={() => this.addToCart()}>Add to cart</button>
        );
    }  
}