import React from "react";
import { CustomerDetails } from "./CustomerDetails";
import { Address } from "./Address";
import { Form, FormGroup, Label, Input } from "reactstrap";

export class Checkout extends React.Component {

    state = { customer: {}, billingAddress: {}, deliveryAddress: {}, deliverToBillingAddress: true };

    toggleDeliverToBillingAddress = () => {
        this.setState({ deliverToBillingAddress: !this.state.deliverToBillingAddress });
    }

    render() {
        return (<div>
            <h4>Your Details</h4>
            <CustomerDetails onChange={newDetails => this.setState({ customer: newDetails })} />
            <h4>Billing Address</h4>
            <Address onChange={(newAddress) => this.setState({ billingAddress: newAddress })} />

            <Form>
                <FormGroup check>
                    <Label check>
                        <Input type="checkbox" checked={this.state.deliverToBillingAddress}
                            onChange={this.toggleDeliverToBillingAddress} /> Deliver to billing address?
                    </Label>
                </FormGroup>
            </Form>
            {!this.state.deliverToBillingAddress && <div>
                <h4>Delivery Address</h4>
                <Address onChange={(newAddress) => this.setState({ deliveryAddress: newAddress })} />
            </div>
            }

        </div>);
    }
}