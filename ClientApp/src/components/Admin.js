import React, { Component } from 'react';

export class Admin extends Component {
  displayName = Admin.name

  constructor(props) {
    super(props);
    this.state = { users: [], loading: true };

    fetch('api/User/GetAll')
      .then(response => response.json())
      .then(data => {
        this.setState({ users: data, loading: false });
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
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
        : Admin.renderUsersTable(this.state.users);

    return (
      <div>
        <h1>Страница администратора</h1>
        <button>Обновить</button>
        {contents}
      </div>
    );
  }
}
