import React from "react";

export default class OrderSummary extends React.Component {
    state = { itemCount: 1, total: 99.99 };

    render() {
        return (<div>
            <h3>Your order </h3>
            {this.state.itemCount} Items <br />
            Sub Total: ${this.state.total} <br/>
        </div> );
    }
}