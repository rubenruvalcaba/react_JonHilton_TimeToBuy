import React, { Component } from "react";
import Axios from "axios";
export default function RemoveFromCart(props) {

    async function handleRemove(event) {

        await Axios.delete(`/api/cart/${localStorage.sessionId}/lines/${props.itemId}`);
        props.onItemRemoved();

    }

    return (<button className="btn btn-danger"
        onClick={handleRemove}>Remove</button>);

}