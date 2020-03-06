import React, { Component } from "react";
import ProductCard from "./ProductCard";
export default class ProductList extends Component {

    constructor(props) {
        super(props);
        this.state = {
            products: [{ id: "123", title: "some product", description: "interesting" },
            { id: "234", title: "other product", description: "fancy" }]
        }
    }

    render() {
       
        return (<div className="row">
            {this.state.products.map(product =>
                <div key={product.id} className="col-4">
                    <ProductCard id={product.id} title={product.title} description={product.description} />
                </div>)}

        </div>);
    }

}