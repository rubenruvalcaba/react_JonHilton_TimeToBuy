import React, { Component } from "react";
import { Link } from "react-router-dom";
import Axios from "axios";
import RemoveFromCart from "./RemoveFromCart";
import { Row, Col } from "reactstrap";
export default class Cart extends Component {
    state = {
        cartItems: []
    };

    async componentDidMount() {
        await this.getCart();
    }

    async getCart() {
        const result = await Axios.get(`/api/cart/${localStorage.sessionId}`);
        const cart = result.data;
        this.setState({ cartItems: cart.items });
    }

    async handleItemRemoved() {
        await this.getCart();
    }

    render() {
        return (
            this.state.cartItems.length === 0 ?
                <div>
                    <span>Your cart is empty</span>
                    <Link to="/" >Clic to add some products</Link>
                </div>
                :
                <div>
                    <Row className="clearfix" style={{ padding: '.5rem' }}>
                        <Col>
                            <Link to="/checkout" className="btn btn-primary float-right">Checkout</Link>
                        </Col>
                    </Row>
                    <Row>
                        <table className="table table-striped table-bordered">
                            <thead>
                                <th>Name</th>
                                <th>Qty</th>
                                <th>Price</th>
                                <th>Amount</th>
                                <th />
                            </thead>
                            <tbody>
                                {this.state.cartItems.map(item =>
                                    <tr id={item.productId}>
                                        <td><Link to={`/product/${item.productId}`}>{item.name}</Link></td>
                                        <td>{item.quantity}</td>
                                        <td>{item.price}</td>
                                        <td>{item.quantity * item.price}</td>
                                        <td><RemoveFromCart
                                            itemId={item.id}
                                            onItemRemoved={() => this.handleItemRemoved()} /></td>
                                    </tr>)
                                }
                            </tbody>
                        </table>
                    </Row>
                </div>

        );
    }
}