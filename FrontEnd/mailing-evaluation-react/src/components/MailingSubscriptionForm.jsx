import React, { Component, Fragment } from 'react';

export class MailingSubscriptionForm extends Component {

    constructor(props){
        super(props);
        this.state = {lastName:'', firstName:'', email:'', showModal:false};

        this.handleInputChange = this.handleInputChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleInputChange(e) {
        const target = e.target;
        const name = target.name;
        this.setState({
            [name]: target.value
        });
    }

    handleSubmit(e){
        fetch("http://localhost:52705/api/mailing/AddSubscriber", {
            "method": "POST",
            "headers": {
                "content-type": "application/json",
                "accept": "application/json"
            },
            "body": JSON.stringify({
                lastName: this.state.lastName,
                firstName: this.state.firstName,
                email: this.state.email
            })
        })
        .then(response => response.json())
        .then(response => {
            console.log(response)
        })
        .catch(err => {
            console.log(err);
        });

        e.preventDefault();
    }

    render() {
        return (
            <Fragment>
                <form onSubmit={this.handleSubmit}>
                    <label>
                        Last Name:
                        <input name="lastName" type="text" value={this.state.lastName} onChange={this.handleInputChange} />
                    </label>
                    <label>
                        First Name:
                        <input name="firstName" type="text" value={this.state.firstName} onChange={this.handleInputChange} />
                    </label>
                    <label>
                        Email:
                        <input name="email" type="email" value={this.state.email} onChange={this.handleInputChange} />
                    </label>
                    <input type="submit" value="Subscribe!" />
                </form>
            </Fragment>
        )
    }
}