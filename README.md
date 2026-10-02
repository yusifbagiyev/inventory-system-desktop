# Inventory System (desktop)

A Windows desktop application for tracking the IT equipment of a company: every device has an
inventory code, belongs to a category and a department, and every move between departments or
employees is kept as its history. It was built in 2024 for an IT department of a logistics company
and used in production until it was replaced by a web version.

> **Portfolio copy.** Server addresses, credentials and keys were removed from the code before
> publishing; the database connection and the password key now come from `App.config`.

## Screenshots

<!-- Add screenshots to docs/screenshots/ and reference them here, e.g.
![Products](docs/screenshots/products.png) -->

## Features

- **Products** - register IT equipment with inventory code, category, vendor, model, department and
  responsible employee; edit, delete, search.
- **Barcode labels** - Code 128 barcode of the inventory code (ZXing.Net), ready to print on a label.
- **Transfers (routes)** - move a product to another department or employee; every move is stored
  with date and note, so the full history of a device is one search away.
- **Categories and departments** - with head, contact and description of each department.
- **Lost and written-off equipment** - products marked as lost (`*` code prefix) or out of use
  (`#` prefix) get their own lists.
- **Search** - by department or by employee: what is where and who is responsible for it.
- **PDF reports** - export of product, transfer, department and employee lists (iTextSharp).
- **Dashboard** - number of products per category and department (Windows Forms charts).
- **Users and roles** - Admin and User, suspend / enable accounts, one active session per user
  (machine name and IP are recorded), change password.
- **Activity log** - every create, update, delete, sign-in and transfer is written to a log table.
- **Two languages** - English and Russian interface, chosen per user.

## Tech stack

| | |
|---|---|
| Language / runtime | C#, .NET Framework 4.7.2 |
| UI | Windows Forms, Bunifu UI 1.52 |
| Database | Microsoft SQL Server (ADO.NET, `System.Data.SqlClient`) |
| Libraries | iTextSharp 5.5 (PDF), ZXing.Net 0.16 (barcodes), BouncyCastle |
| Deployment | ClickOnce, from a shared network folder |

## Project structure

```
Inventory System/
  Classes/
    AppSettings.cs     connection string and password key from App.config
    Connect.cs         SQL Server connection helper
    Cryptography.cs    AES encryption of stored passwords
    Logger.cs          activity log
  Forms/               one form per screen (Login, Main Menu, Products, Routes, Users, ...)
                       *.ru.resx - Russian translations of each form
  Properties/
  App.config           connection string and settings (placeholders)
database/
  schema.sql           tables used by the application
  sample-data.sql      fictional demo data and two demo users
Pictures/              icons used in the UI
```

## Getting started

Requirements: Windows, Visual Studio 2019 or later (.NET desktop development workload),
SQL Server or SQL Server Express / LocalDB.

1. **Database** - create a database and run the scripts:
   ```sql
   CREATE DATABASE InventoryDb;
   ```
   then run `database/schema.sql` and (optionally) `database/sample-data.sql` in it.
2. **Configuration** - in `Inventory System/App.config` set the `InventoryDb` connection string and
   change `PasswordKey` (16, 24 or 32 characters). The sample users were created with the sample key.
3. **Bunifu UI** - the project references `Bunifu_UI_v1.52.dll`, which is not on NuGet. Put it in
   `lib/` next to the solution (the folder is ignored by git).
4. **Build and run** - open `Inventory System.sln`; NuGet restores the other packages on build.

Demo users (from `sample-data.sql`, with the sample key):

| User | Password | Role |
|---|---|---|
| `admin` | `Demo-Admin-2024` | Admin |
| `operator` | `Demo-User-2024` | User |

## What I would do differently today

This was my first production application; its successor is a web application (ASP.NET Core
modular monolith, PostgreSQL) that replaced it. Looking back at this code:

- **SQL** - several queries are built by string concatenation; they should all be parameterised
  (some already are) to rule out SQL injection.
- **Passwords** - stored AES-encrypted with a fixed IV; passwords should be hashed with a slow,
  salted algorithm (PBKDF2, bcrypt or Argon2) instead of being reversible.
- **Data model** - products refer to their category and department by name, not by key, so a
  rename has to be applied everywhere; foreign keys would keep the data consistent.
- **Configuration** - the original kept the connection string in code; it now lives in
  `App.config`, and a real deployment should keep secrets out of the repository entirely.
- **Structure** - data access lives inside the forms; a separate data layer would make the code
  testable.
