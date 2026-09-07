# Assignment 7

UWP Windows Store Apps assignment for a SACCO staff management portal.

## Requirements implemented

- Staff login page with email and password fields.
- Empty-field and email-format validation.
- SQL Server authentication through a parameterized query.
- SHA-256 password hashing before database comparison.
- Navigation to the Home Page after successful authentication.
- Logged-in staff name, role, and email displayed on the dashboard.
- UWP TopAppBar with Dashboard, Members, Accounts, and Sign out actions.
- Hub sections for dashboard overview and SACCO information.
- Canvas-based member-growth dashboard chart.
- Dashboard cards for members, savings, and active loans.
- Quick-action buttons and working navigation/dialog events.
- SQL Server database schema included in `Assignment7/Database.sql`.

## SQL Server setup

1. Open `Assignment7/Database.sql` in SQL Server Management Studio.
2. Execute the script to create the `SaccoDB` database and `Staff` table.
3. Add your staff records to the `Staff` table.
4. Store each password as a SHA-256 value in `PasswordHash`.
5. If SQL Server is not running on `localhost`, edit the connection string in `Assignment7/DatabaseService.cs`.

Example for creating a password hash in SQL Server:

```sql
HASHBYTES('SHA2_256', CONVERT(NVARCHAR(4000), N'<your password>'))
```

## Running the application

Open `Assignment7.sln` in Visual Studio on Windows with UWP development tools installed.

Select an available Windows target and run the project. The application starts on the Login Page.

The repository is designed for the Assignment 7 requirements supplied by the course.
