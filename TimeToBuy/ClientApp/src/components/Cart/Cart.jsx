import React, { Component } from "react";
import { Link } from "react-router-dom";
import Axios from "axios";
export default class Cart extends Component {
    state = {
        cartItems: []
    };

    async componentDidMount() {
        const sessionId = localStorage.sessionId;
        const result = await Axios.get(`/api/cart?sessionId=${sessionId}`);
        const cart = result.data;
        this.setState({ cartItems: cart.items });
    }

    render() {
        return (
            this.state.cartItems.length === 0 ?
                <div>
                    <span>Your cart is empty</span>
                    <Link to="/" >Clic to add some products</Link>
                </div>
                :
                <table className="table table-striped table-bordered">
                    <thead>
                        <th>Name</th>
                        <th>Qty</th>
                        <th>Price</th>
                        <th>Amount</th>
                    </thead>
                    <tbody>
                        {this.state.cartItems.map(item =>
                            <tr id={item.productId}>
                                <td><Link to={`/product/${item.productId}`}>{item.name}</Link></td>
                                <td>{item.quantity}</td>
                                <td>{item.price}</td>
                                <td>{item.quantity * item.price}</td>
                            </tr>)
                        }
                    </tbody>
                </table>


        );
    }
}