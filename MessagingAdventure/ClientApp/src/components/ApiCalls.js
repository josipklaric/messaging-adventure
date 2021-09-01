import React, { Component } from "react";

export class ApiCalls extends Component {
    static displayName = ApiCalls.name;

    constructor(props) {
        super(props);
        this.state = {
            apiCalls: [],
            loading: true
        }
    }

    componentDidMount(){
        this.populateApiCallsData();
    }

    static renderApiCallsTable(apiCalls){
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Date</th>
                        <th>Endpoint</th>
                        <th>Content</th>
                    </tr>
                </thead>
                <tbody>
                    {apiCalls.map(apiCall =>
                        <tr key={apiCall.date}>
                            <td>{apiCall.date}</td>
                            <td>{apiCall.endpoint}</td>
                            <td>{apiCall.content}</td>
                        </tr>
                    )}
                </tbody>
            </table>
          );
    }

    render() {
        let contents = this.state.loading ? <p><em>Loading...</em></p> : ApiCalls.renderApiCallsTable(this.state.apiCalls);

        return(
            <div>
                <h2 id="apiCallsTable">Api calls</h2>
                { contents }
            </div>
        );
    }

    async populateApiCallsData(){
        const response = await fetch('api/apicalls');
        const data = await response.json();
        this.setState({ apiCalls: data, loading: false });
    }
}