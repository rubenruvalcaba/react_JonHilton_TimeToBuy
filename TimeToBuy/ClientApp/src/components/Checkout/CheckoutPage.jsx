import React, { Component } from "react";
import { Row, Col } from "reactstrap";
import OrderSummary from "./OrderSummary";
import { Checkout } from "./Checkout";

export default class CheckoutPage extends Component {
    render() {
        return (<Row>
            <Col md={8}>
                <Checkout auth={this.props.auth} {...this.props}/>
            </Col>
            <Col md={4}>
                <OrderSummary />
            </Col>
        </Row>);
    }
}