import React from "react";
import { CardElement, injectStripe } from "react-stripe-elements";
import { Button } from "reactstrap";
import './CheckoutForm.css';

class CheckoutForm extends React.Component {
    state = { requiredDataValid: false };

    submit = async (e) => {
        if (!this.props.customer.firstName || !this.props.customer.lastName) {
            alert("Type the first and last name");
            return;
        }
        if (!this.props.billingAddress.line1) {
            alert("Type the billing address");
            return;
        }

        const customer = this.props.customer;
        const address = this.props.billingAddress;
        const { token } = await this.props.stripe.createToken({
                                        name: customer.firstName + " " + customer.lastName,
                                        address_line1: address.line1,
                                        address_line2: address.line2,
                                        address_state: address.state
                                    });
        if (this.props.onPaymentMethodChanged)
            this.props.onPaymentMethodChanged(token);

    }

    render() {
        return (
            <div className="checkout">
                <h4>Payment details</h4>
                <CardElement style={{ base: { fontSize: '18px' } }} />
                <Button color='primary'
                    onClick={this.submit}>Place Order</Button>
            </div>
        );
    }

}

export default injectStripe(CheckoutForm);