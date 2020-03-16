import React from "react";
import { Form, FormGroup, Label, Col, Input } from "reactstrap";

export class Address extends React.Component {
    state = { line1: "", line2: "", city: "", state: "" };

    handleChange(newState) {
        this.setState(newState, () => {
            if (this.props.onChange)
                this.props.onChange(this.state);
        });

    }

    render() {
        return (
            <Form>
                <FormGroup row>
                    <Label for="line1" sm={2}>Line 1</Label>
                    <Col sm={10}>
                        <Input type="text"
                            value={this.state.line1}
                            onChange={event => this.handleChange({ line1: event.target.value })}
                            id="line1"
                            placeHolder="Line 1" />
                    </Col>
                </FormGroup>
                <FormGroup row>
                    <Label for="line2" sm={2}>Line 2</Label>
                    <Col sm={10}>
                        <Input type="text"
                            value={this.state.line2}
                            onChange={event => this.handleChange({ line2: event.target.value })}
                            id="line2"
                            placeHolder="Line 2" />
                    </Col>
                </FormGroup>
                <FormGroup row>
                    <Label for="city" sm={2}>City</Label>
                    <Col sm={10}>
                        <Input type="text"
                            value={this.state.city}
                            onChange={event => this.handleChange({ city: event.target.value })}
                            id="city"
                            placeHolder="City" />
                    </Col>
                </FormGroup>
                <FormGroup row>
                    <Label for="state" sm={2}>State</Label>
                    <Col sm={10}>
                        <Input type="text"
                            value={this.state.state}
                            onChange={event => this.handleChange({ state: event.target.value })}
                            id="state"
                            placeHolder="State" />
                    </Col>
                </FormGroup>
            </Form>);
    }
}