import React from "react";
import Axios from "axios";

export default class MyOrders extends React.Component {
    //TODO: Restrict to logged users
    //TODO: Load orders from the user
    state = { orders: [] };

    async componentDidMount() {

        const bearerToken = await this.props.auth.getTokenSilently();

        const response = await Axios.get('/api/orders',
            {
                headers: { 'Authorization': `bearer ${bearerToken}` }
            });
        this.setState({ orders: response.data });

    }

    render() {
        return (
            <div>
                <h1>My Orders</h1>
                <table className="table table-striped table-bordered">
                    <thead>
                        <th>Order Id</th>
                    </thead>
                    <tbody>
                        {this.state.orders.map(order =>
                            <tr key={order.id}>
                                <td>{order.id}</td>
                            </tr>
                        )}
                    </tbody>
                </table>
            </div>
        );
    }
}