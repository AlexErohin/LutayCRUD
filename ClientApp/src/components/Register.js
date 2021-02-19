import React, { Component } from 'react';

export class Register extends Component {
    displayName = Register.name
    constructor(props) {
        super(props);
        this.state = {
            user: { firstName: "", lastName: "", birthday: undefined, phoneNumber: "", favoriteColors: 0, favoriteDrinks: 0, },
            isInvalid: true,
        };
        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleSubmit(event) {
        event.preventDefault();
        const requestOptions = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(this.state.user)
        };
        fetch('api/User/Register', requestOptions)
            .then(response => response.json())
            .then(alert('Зарегистрирован ' + this.state.user.firstName));
    }

    handleChange(event) {
        const target = event.target;
        const name = target.name;
        this.setState(prevState => {
            let user = Object.assign({}, prevState.user);
            user[name] = target.value;
            return { user };
        });
        this.handleValidation();
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
                            onChange={this.handleChange} />
                    </label>
                    <br/>
                    <label>
                        Фамилия*
                        <input
                            name="lastName"
                            type="text"
                            size="30"
                            placeholder="Фамилия"
                            value={this.state.user.lastName}
                            onChange={this.handleChange} />
                    </label>
                    <br />
                    <label>
                        Дата рождения
                        <input
                            name="birthday"
                            type="date"
                            size="30"
                            value={this.state.user.birthday}
                            onChange={this.handleChange} />
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
                            onChange={this.handleChange} />
                    </label>
                    <br />
                    <label>
                        Вопрос 1: Какой цвет вам больше нравится?
                        <select
                            name="favoriteColors"
                            multiple={true}
                            value={this.state.user.favoriteColors}
                            onChange={this.handleChange}>
                            <option value="1">Синий</option>
                            <option value="2">Желтый</option>
                            <option value="4">Красный</option>
                        </select>
                    </label>
                    <br />
                    <label>
                        Вопрос 2: Какой напиток вы предпочитаете?
                        <select
                            name="favoriteDrinks"
                            multiple={true}
                            value={this.state.user.favoriteDrinks}
                            onChange={this.handleChange}>
                            <option value="1">Чай</option>
                            <option value="2">Кофе</option>
                            <option value="4">Сок</option>
                            <option value="8">Вода</option>
                        </select>
                    </label>
                    <br />
                    <input type="submit" disabled={this.state.isInvalid} value="Подтвердить" />
                </form>
            </div>
        );
    }
}
