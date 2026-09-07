# Assignment 7

UWP C# and XAML Windows Store Apps assignment for the Kampala Community SACCO staff management portal.

## Assignment requirements implemented

- UWP Login Page with email and password controls.
- Empty-field and email-format validation.
- SQL Server staff authentication using a parameterized query.
- SHA-256 password hashing before database comparison.
- Navigation from Login Page to Home Page after successful authentication.
- Logged-in staff name, role, and email shown on the Home Page.
- UWP TopAppBar and CommandBar navigation.
- Hub sections for Overview, Member Services, Loan Services, Reports, and SACCO Information.
- Canvas-based dashboard graphics and activity visualisation.
- Working service, report, navigation, and logout button events.
- Logout confirmation followed by navigation back to the Login Page.
- SQL Server database and seeded staff roles in `Assignment7/Database.sql`.
- Required UWP package visual assets included under `Assignment7/Assets`.

## Visual design

The interface stays within native UWP XAML. The design uses Swiss-style alignment and typography, Bauhaus geometric shapes and primary accents, and UWP EntranceThemeTransition motion. The page structure remains close to the assignment screenshots, including the centred staff login panel, dark SACCO header, dashboard overview, service columns, reports, and SACCO information.

## SQL Server setup

1. Open `Assignment7/Database.sql` in SQL Server Management Studio.
2. Execute the full script. It creates the `SaccoDB` database and `dbo.Staff` table if they do not exist.
3. The script also inserts the assignment test users if their email addresses are not already present.
4. If SQL Server is not running on `localhost`, update the connection string in `Assignment7/DatabaseService.cs`.

## Test login credentials

| Role | Email | Password |
| --- | --- | --- |
| Manager | `manager@unitysacco.ug` | `Manager@123` |
| Member Services Officer | `members@unitysacco.ug` | `Members@123` |
| Loan Officer | `loans@unitysacco.ug` | `Loans@123` |
| Accountant | `accountant@unitysacco.ug` | `Accounts@123` |

Passwords are stored in SQL Server as SHA-256 hashes and are compared with the hash produced by `DatabaseService.cs`.

## Running in Visual Studio

Open `Assignment7.sln` on Windows in Visual Studio with Universal Windows Platform development tools and the Windows 10/11 SDK installed.

Restore NuGet packages, run `Assignment7/Database.sql` in SQL Server Management Studio, confirm the SQL Server connection string, then select the UWP project and run it. The application starts on the Login Page.
