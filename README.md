# Inventory System (desktop)

My first inventory application, written in 2024 for the IT department I work in. It is a Windows
Forms app on SQL Server: each piece of IT equipment has an inventory code, a category and a
department, and every time a device moves to another department or person it is recorded, so you can
see where it has been.

We used it until it was replaced by a web version - first as
[microservices](https://github.com/yusifbagiyev/Inventory-Management-Microservices), then rewritten as
the [modular monolith](https://github.com/yusifbagiyev/Inventory-Management-Modular-Monolith) we use
now.

Before publishing I took the server address, password and encryption key out of the code; they are
read from `App.config` now.

## What it does

- add, edit and search products (inventory code, category, vendor, model, department, employee);
- print a Code 128 barcode of the inventory code for the label (ZXing.Net);
- move a product to another department or employee, with the date and a note; the history of every
  device is kept;
- categories and departments (with the head of department and contacts);
- separate lists for lost products (code starting with `*`) and written-off ones (`#`);
- search by department or by employee;
- PDF reports of products, transfers and search results (iTextSharp);
- a small dashboard with the number of products per category and department;
- Admin and User accounts, suspending users, one active session per user, password change;
- a log of every change, sign-in and transfer;
- English and Russian interface, chosen per user.

Built with C# and .NET Framework 4.7.2, Windows Forms with Bunifu UI 1.52, SQL Server through
ADO.NET. It was installed on the users' computers with ClickOnce from a shared network folder.

## Project structure

```
Inventory System/
  Classes/        connection, password encryption, logging, settings from App.config
  Forms/          one form per screen (Login, Main Menu, Products, Routes, Users, ...);
                  *.ru.resx files hold the Russian texts
  App.config      connection string and settings
database/
  schema.sql      the tables the app uses
  sample-data.sql demo data and two demo users
Pictures/         icons
```

## Running it

You need Windows, Visual Studio 2019 or newer and SQL Server (Express or LocalDB is enough).

1. Create a database (`CREATE DATABASE InventoryDb;`) and run `database/schema.sql` in it, and
   `database/sample-data.sql` if you want demo data.
2. Set the `InventoryDb` connection string in `Inventory System/App.config` and change `PasswordKey`
   (16, 24 or 32 characters). The demo users were created with the key that is in the file.
3. Bunifu UI is not on NuGet: put `Bunifu_UI_v1.52.dll` into a `lib` folder next to the solution.
4. Open `Inventory System.sln` and run it; the other packages are restored by NuGet.

Demo users from `sample-data.sql`: `admin` / `Demo-Admin-2024` (Admin) and `operator` /
`Demo-User-2024` (User).

## Looking back

This was the first application I wrote that people actually used every day, and some of it I would
write differently now:

- some SQL queries are put together by string concatenation; they should all use parameters (some
  already do);
- passwords are encrypted with AES and a fixed IV, which means they can be decrypted; they should
  be hashed (PBKDF2, bcrypt or Argon2) instead;
- products point to their category and department by name instead of by key, so a rename has to be
  done everywhere;
- the database code sits inside the forms; a separate data layer would make it easier to test and
  change.
