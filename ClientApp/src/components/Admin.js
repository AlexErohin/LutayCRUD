import React, { Component } from 'react';

export class Admin extends Component {
    displayName = Admin.name

    constructor(props) {
        super(props);
        this.state = {
            users: [],
            login: "",
            password: ""
        };

        this.handleSubmit = this.handleSubmit.bind(this);
    }
    componentDidMount() {
        if (localStorage.getItem('admin') !== null) {
            this.fetchTable();
        }
    }

    handleSubmit(event) {
        event.preventDefault();
        this.auth(this.state.login, this.state.password);
    }

    auth(login, password) {
        const requestOptions = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ login, password })
        };

        return fetch('api/Admin/Authenticate', requestOptions)
            .then(this.handleResponse)
            .then(admin => {
                if (admin) {
                    admin.authdata = window.btoa(login + ':' + password);
                    localStorage.setItem('admin', JSON.stringify(admin));
                }
                this.forceUpdate();
                this.fetchTable();
                return admin;
            });
    }

    fetchTable() {
        const requestOptions = {
            method: 'GET',
            headers: this.authHeader()
        };

        fetch('api/Admin/GetAllUsers', requestOptions)
            .then(response => response.json())
            .then(data => {
                this.setState({ users: data });
            });
    }

    authHeader() {
        let admin = JSON.parse(localStorage.getItem('admin'));

        if (admin && admin.authdata) {
            return { 'Authorization': 'Simple ' + admin.authdata };
        } else {
            return {};
        }
    }

    logout() {
        localStorage.removeItem('admin');
        this.forceUpdate();
    }

    handleResponse(response) {
        return response.text().then(text => {
            const data = text && JSON.parse(text);
            if (!response.ok) {
                if (response.status === 401) {
                    this.logout();
                }

                const error = (data && data.message) || response.statusText;
                return Promise.reject(error);
            }

            return data;
        });
    }

    static renderUsersTable(users) {
        return (
            <table className='table'>
                <thead>
                    <tr>
                        <th>Имя</th>
                        <th>Фамилия</th>
                    </tr>
                </thead>
                <tbody>
                    {users.map(user =>
                        <tr>
                            <td>{user.firstName}</td>
                            <td>{user.lastName}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let auth;
        if (localStorage.getItem('admin') === null) {
            auth =
                <form onSubmit={this.handleSubmit} visible={localStorage.getItem('admin') === null}>
                    <label>
                        Логин
                    <input name="login" type="text" onChange={(event) => this.setState({ login: event.target.value })} />
                    </label>
                    <label>
                        Пароль
                    <input name="password" type="password" onChange={(event) => this.setState({ password: event.target.value })} />
                    </label>
                    <br />
                    <input type="submit" value="Войти" />
                </form>;
        } else {
            auth = [<button onClick={() => this.logout()}>Выйти</button>, Admin.renderUsersTable(this.state.users)];
        }
        return (
            <div>
                <h1>Страница администратора</h1>
                {auth}
            </div>
        );
    }
}
