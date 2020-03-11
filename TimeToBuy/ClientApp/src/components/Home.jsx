import React, { Component } from 'react';
import ProductList from './Products/ProductList';

export class Home extends Component {
    static displayName = Home.name;

    constructor(props) {
        super(props);
        this.state = {
            products: [{ id: "123", title: "some product", description: "interesting" },
                       { id: "234", title: "other product", description: "fancy" }]
        }
    }    
    render() {
        return (
            <ProductList />           
        );
    }
}
