import React, { Component } from "react";
import Axios from "axios";

export default class AddToCart extends React.Component {
    async addToCart() {
        const id = this.props.productId;
        await Axios.post('/api/cart', { productId: id });        
    }

    render() {
        return (
            <button className="btn btn-primary" onClick={() => this.addToCart()}>Add to cart</button>
        );
    }  
}