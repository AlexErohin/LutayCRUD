import React, { Component } from 'react';

export class Admin extends Component {
    displayName = Admin.name

    constructor(props) {
        super(props);
        this.state = {
            users: [],
            login: "",
            password: "",
            colorFilter: 0,
            drinkFilter: 0
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

    static flagsToColors(flag) {
        let result = "";
        result += (flag & 1) == 1 ? "Синий; " : "";
        result += (flag & 2) == 2 ? "Желтый; " : "";
        result += (flag & 4) == 4 ? "Красный; " : "";

        return result;
    }

    static flagsToDrinks(flag) {
        let result = "";
        result += (flag & 1) == 1 ? "Чай; " : "";
        result += (flag & 2) == 2 ? "Кофе; " : "";
        result += (flag & 4) == 4 ? "Сок; " : "";
        result += (flag & 8) == 8 ? "Вода; " : "";

        return result;
    }
    static formatDate(date) {
        if (!date) {
            return;
        }
        var d = new Date(date),
            month = '' + (d.getMonth() + 1),
            day = '' + d.getDate(),
            year = d.getFullYear();

        if (month.length < 2)
            month = '0' + month;
        if (day.length < 2)
            day = '0' + day;

        return [day, month, year].join('.');
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
            auth = 
                <div>
                    <button onClick={() => this.logout()}>Выйти</button>
                    <table className='table'>
                        <thead>
                            <tr>
                                <th>Имя</th>
                                <th>Фамилия</th>
                                <th>Дата рождения</th>
                                <th>Телефон</th>
                                <th>Цвета</th>
                                <th>Напитки</th>
                            </tr>
                        </thead>
                        <tbody>
                        {this.state.users
                            .filter(user => (user.favoriteColors & this.state.colorFilter) == this.state.colorFilter)
                            .filter(user => (user.favoriteDrinks & this.state.drinkFilter) == this.state.drinkFilter)
                            .map(user =>
                                <tr>
                                    <td>{user.firstName}</td>
                                    <td>{user.lastName}</td>
                                    <td>{Admin.formatDate(user.birthday)}</td>
                                    <td>{user.phoneNumber}</td>
                                    <td>{Admin.flagsToColors(user.favoriteColors)}</td>
                                    <td>{Admin.flagsToDrinks(user.favoriteDrinks)}</td>
                                </tr>
                            )}
                        </tbody>
                    </table>
                    <br />
                    <label>
                        Фильтр цвета
                        <select onChange={(event) => this.setState({ colorFilter: parseInt(event.target.value) })}>

                            <option value="0">Без фильтра</option>
                            <option value="1">Синий</option>
                            <option value="2">Желтый</option>
                            <option value="4">Красный</option>
                        </select>
                    </label>
                    <br />
                    <label>
                        Фильтр напитка
                        <select onChange={(event) => this.setState({ drinkFilter: parseInt(event.target.value) })}>

                            <option value="0">Без фильтра</option>
                            <option value="1">Чай</option>
                            <option value="2">Кофе</option>
                            <option value="4">Сок</option>
                            <option value="8">Вода</option>
                        </select>
                    </label>
                </div>;
        }
        return (
            <div>
                <h1>Страница администратора</h1>
                {auth}
            </div>
        );
    }
}
