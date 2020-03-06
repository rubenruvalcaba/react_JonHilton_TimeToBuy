import React, { Component } from "react";
import { Link } from "react-router-dom";

export default function ProductCard(props) {
    return (
        <div className="card product-card">
            <div className="card-body">
                <h5 className="card-title">{props.title}</h5>
                <p className="card-text">{props.description}</p>
                <Link to={`/product/${props.id}`}>View</Link>
            </div>
        </div>);
}