# Authentication Example 🚀

This project provides a JWT-based authentication and role-based access control (RBAC) implementation using ASP.NET Core Identity.

## Project Structure 📂

- **Controllers**: Classes containing API endpoints.
- **Data**: Database context and identity management classes.
- **Models**: Data models and DTOs.

## Features ✨

- 🔑 JWT authentication.
- 🛡️ Role-based access control.
- 👥 User and role management.

## Setup 🛠️

1. Clone this repository to your local machine:
    ```sh
    git clone https://github.com/username/Authentication.Example.git
    cd Authentication.Example
    ```

2. Install the necessary dependencies:
    ```sh
    dotnet restore
    ```

3. Configure the database connection string in the `appsettings.json` file:
    ```json
    {
      "ConnectionStrings": {
        "DefaultConnection": "YourConnectionStringHere"
      },
      "JWT": {
        "Issuer": "yourIssuer",
        "Audience": "yourAudience",
        "SigningKey": "yourSigningKey"
      }
    }
    ```

4. Run the database migrations:
    ```sh
    dotnet ef database update
    ```

## Usage ▶️

You can run the project with the following command:
```sh
dotnet run

```

## Role and User Setup 👤

Initial data is created within the `AppDbContext`. The following users and roles will be created on the first run:

- **Users**:
  - Username: `TestModerator`
    - Password: `Test@123`
  - Username: `TestAdministrator`
    - Password: `Test@123`

## API Endpoints 📡

- `POST /api/account/login`: Logs in a user and returns a JWT token.
- `POST /api/account/register`: Registers a new user.
- `GET /api/test`: An example endpoint for moderator authorization.
- `POST /api/test`: An example endpoint for admin authorization and restricted for moderators.
