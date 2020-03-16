import React, { Component } from "react";
import Rating from "../Rating";
import Axios from "axios";
import AddToCart from "../Cart/AddToCart";

export default class ProductDetail extends Component {

    constructor(props) {
        super(props);
               
        this.state = {};
    }

    async componentDidMount() {
        var result = await Axios(`/api/product/${this.props.match.params.id}`);
        this.setState(result.data);
    }

    render() {
        return <div className="row">
            <div className="col-12">
                <div className="media">
                    <img src="https://via.placeholder.com/600" className="mr-3" alt="Product" />
                    <div className="media-body">
                        <h1>{this.state.id} {this.state.name}</h1>
                        <p>{this.state.description}</p>
                        <p>${this.state.price}</p>
                        <Rating rating={this.state.rating} />
                        <AddToCart productId={this.state.id}/>
                    </div>
                </div>
            </div>
        </div>
    }
}

