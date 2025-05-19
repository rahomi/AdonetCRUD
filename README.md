# ADO.NET CRUD Demo

A simple ASP.NET Core MVC application demonstrating basic **CRUD** operations (Create, Read, Update, Delete) using **ADO.NET** and **SQL Server**.

---

## 🔧 Technologies Used

- ASP.NET Core 9 (MVC)
- ADO.NET
- Microsoft SQL Server
- Visual Studio 2022
- C#
- Razor Views



## 🗂️ Project Structure

AdoNetCrudDemo/
├── Controllers/
│ └── BookController.cs
├── DAL/
│ └── BookDAL.cs
├── Models/
│ └── Book.cs
├── Views/
│ └── Book/
│ ├── Index.cshtml
│ ├── Create.cshtml
│ ├── Edit.cshtml
│ └── Delete.cshtml
├── appsettings.json
└── Program.cs


---

## 🚀 Getting Started

### 1. Clone the Repository

```bash
git clone https://github.com/rahomi/AdonetCRUD.git
cd AdonetCRUD
```
### 2. Update SQL Server Connection String

In `appsettings.json`, set your connection string:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=YOUR_DB_NAME;Trusted_Connection=True;"
}
```
### 3. Run the SQL Script
Create the table used in the project:

CREATE TABLE Books (
  Id INT PRIMARY KEY IDENTITY,
  Title NVARCHAR(100),
  Author NVARCHAR(100),
  Price DECIMAL(10, 2)
);

### 4. Run the Project
Open the solution in Visual Studio 2022 and press F5 to run.

### Features
- View all books (Index)
- Add a new book (Create)
- Edit an existing book (Edit)
- Delete a book (Delete)

📄 License
This project is open-source and available for use without restriction.
