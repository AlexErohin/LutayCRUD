import React, { Component } from 'react';
import DatePicker from "react-datepicker";
import moment from 'moment'

import "react-datepicker/dist/react-datepicker.css";

export class Register extends Component {
    displayName = Register.name
    constructor(props) {
        super(props);
        this.state = {
            user: { firstName: "", lastName: "", birthday: moment(), phoneNumber: "", favoriteColors: [], favoriteDrinks: [], },
            isInvalid: true,
        };
        this.handleInputChange = this.handleInputChange.bind(this);
        this.handleSelectChange = this.handleSelectChange.bind(this);
        this.handleBirthdayChange = this.handleBirthdayChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleSubmit(event) {
        event.preventDefault();
        let user = Object.assign({}, this.state.user);
        user.favoriteColors = user.favoriteColors.reduce((x, v, i, a) => x + parseInt(v, 10), 0);
        user.favoriteDrinks = user.favoriteDrinks.reduce((x, v, i, a) => x + parseInt(v, 10), 0);
        const requestOptions = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(user)
        };
        fetch('api/User/Register', requestOptions)
            .then(response => {
                if (response.ok) {
                    alert("Успешно зарегистрирован");
                } else {
                    alert("Ошибка регистрации");
                }
            });
    }

    handleInputChange(event) {
        const target = event.target;
        const name = target.name;
        this.setState(prevState => {
            let user = Object.assign({}, prevState.user);
            user[name] = target.value;
            return { user };
        }, () => {
            this.handleValidation();
        });
    }

    handleBirthdayChange(date) {
        this.setState(prevState => {
            let user = Object.assign({}, prevState.user);
            user.birthday = moment(date);
            return { user };
        });
    }

    handleSelectChange(event) {
        const target = event.target;
        const name = target.name;
        this.setState(prevState => {
            let user = Object.assign({}, prevState.user);
            user[name] = Array.from(target.selectedOptions, option => option.value);
            return { user };
        });
    }
    handleValidation() {
        let invalid = true;
        if (this.state.user.firstName.length > 0 && this.state.user.lastName.length > 0 && !!this.state.user.phoneNumber.match(/^(\+[0-9]+)$/)) {
            invalid = false;
        }
        this.setState({ isInvalid: invalid });
    }

    render() {
        return (
            <div>
                <h1>Регистрация</h1>
                <p>Заполнение полей с * обязательно</p>
                <form onSubmit={this.handleSubmit}>
                    <label>
                        Имя*
                        <input
                            name="firstName"
                            type="text"
                            size="30"
                            placeholder="Имя"
                            value={this.state.user.firstName}
                            onChange={this.handleInputChange} />
                    </label>
                    <br />
                    <label>
                        Фамилия*
                        <input
                            name="lastName"
                            type="text"
                            size="30"
                            placeholder="Фамилия"
                            value={this.state.user.lastName}
                            onChange={this.handleInputChange} />
                    </label>
                    <br />
                    <label>
                        Дата рождения
                        <DatePicker
                            dateFormat="DD.MM.yyyy"
                            selected={this.state.user.birthday}
                            onChange={this.handleBirthdayChange} />
                    </label>
                    <br />
                    <label>
                        Телефон*
                        <input
                            name="phoneNumber"
                            type="text"
                            size="30"
                            placeholder="+0000000"
                            value={this.state.user.phoneNumber}
                            onChange={this.handleInputChange} />
                    </label>
                    <br />
                    <label>
                        Вопрос 1: Какой цвет вам больше нравится?
                    <br />
                        <select
                            name="favoriteColors"
                            multiple={true}
                            value={this.state.user.favoriteColors}
                            onChange={this.handleSelectChange}>
                            <option value="1">Синий</option>
                            <option value="2">Желтый</option>
                            <option value="4">Красный</option>
                        </select>
                    </label>
                    <br />
                    <label>
                        Вопрос 2: Какой напиток вы предпочитаете?
                    <br />
                        <select
                            name="favoriteDrinks"
                            multiple={true}
                            value={this.state.user.favoriteDrinks}
                            onChange={this.handleSelectChange}>
                            <option value="1">Чай</option>
                            <option value="2">Кофе</option>
                            <option value="4">Сок</option>
                            <option value="8">Вода</option>
                        </select>
                    </label>
                    <br />
                    <input type="submit" disabled={this.state.isInvalid} value="Зарегистрировать" />
                </form>
            </div>
        );
    }
}
