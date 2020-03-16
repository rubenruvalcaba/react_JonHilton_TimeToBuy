import React from "react";
import { CustomerDetails } from "./CustomerDetails";
import { Address } from "./Address";
import { Form, FormGroup, Label, Input } from "reactstrap";
import { StripeProvider, Elements } from "react-stripe-elements";
import CheckoutForm from "./CheckoutForm";
import Axios from "axios";

export class Checkout extends React.Component {

    state = { customer: {}, billingAddress: {}, deliveryAddress: {}, deliverToBillingAddress: true };

    toggleDeliverToBillingAddress = () => {
        this.setState({ deliverToBillingAddress: !this.state.deliverToBillingAddress });
    }

     handlePaymentMethodChanged = async (token) => {
        if (token) {
            this.setState({ paymentToken: token });
            await Axios.post('/api/checkout', {
                ...this.state,
                paymentToken: token.id,
                sessionId: localStorage.sessionId
            });
        }
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

            <StripeProvider apiKey='pk_test_3oR8xfHONoFCRi3WA1H9OTj700kU9nTPsb'>
                <Elements>
                    <CheckoutForm
                        customer={this.state.customer}
                        billingAddress={this.state.billingAddress}
                        onPaymentMethodChanged={this.handlePaymentMethodChanged} />
                </Elements>
            </StripeProvider>

        </div>);
    }
}