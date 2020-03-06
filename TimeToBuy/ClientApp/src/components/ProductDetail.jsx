import React, { Component } from "react";
import Rating from "./Rating";
export default class ProductDetail extends Component {

    constructor(props) {
        super(props);
               
        this.state = {name:"Some product name", description:"Some description", price:100, rating:2}
    }

    render() {
        return <div className="row">
            <div className="col-12">
                <div className="media">
                    <img src="https://via.placeholder.com/600" className="mr-3" alt="Product" />
                    <div className="media-body">
                        <h1>{this.props.match.params.id} {this.state.name}</h1>
                        <p>{this.state.description}</p>
                        <p>${this.state.price}</p>
                        <Rating rating={this.state.rating} />
                    </div>
                </div>
            </div>
        </div>
    }
}

