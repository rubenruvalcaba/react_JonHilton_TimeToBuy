import React from "react";
import { CardElement, injectStripe } from "react-stripe-elements";
import { Button } from "reactstrap";
import './CheckoutForm.css';

class CheckoutForm extends React.Component {
    submit = async (e) => {
        let { token } = await this.props.stripe.createToken({ name: 'Name' });
        if (this.props.onPaymentMethodChanged)
            this.props.onPaymentMethodChanged(token);        
    }
    render() {
        return (<div className="checkout">
            <h4>Payment details</h4>
            <CardElement style={{ base: { fontSize: '18px' } }} />
            <Button color='primary' onClick={this.submit}>Place Order</Button>
        </div>
        );
    }

}

export default injectStripe(CheckoutForm);