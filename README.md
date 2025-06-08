# KoperasiTenteraProject

KoperasiTenteraProject is a backend API service designed to support customer registration for a cooperative (Koperasi) system. Built with ASP.NET Core Web API, it offers endpoints for user registration, OTP validation, and secure PIN setup. This service is a fundamental part of a larger React Full Stack learning initiative.

---

## 🔗 Live API Documentation (Swagger)
The API follows the OpenAPI 3.0.1 specification. You can explore the endpoints using the Swagger file provided in the repository.

---

## 📬 Postman API Collection
You can test the API endpoints using the Postman collection below:

🔗 [Postman Workspace](https://www.postman.com/workspace/Learning_React_Full_Stack~6ec35727-44c8-48bf-b46d-0eee40522284/collection/40262803-8a765c2a-fe35-4fa8-8598-e65f83a84301?action=share&creator=40262803)

---

## 🚀 Features

- **User Registration**
- **OTP Sending to Mobile**
- **OTP Validation**
- **PIN Setup**
- **Retrieve All Registrations**
- **Fetch Individual Registration by IC Number**
- **Test Endpoint for Connectivity**

---

## 📌 API Endpoints

### POST `/api/Registration/register`
Registers a new customer using the following fields:
- `customerName`
- `icNumber`
- `mobileNumber`
- `email`

### GET `/api/Registration/all`
Returns a list of all registered users.

### GET `/api/Registration/{icnumber}`
Returns the registration data for a user with a specific IC number.

### POST `/api/Registration/sendotp`
Sends an OTP to the user's mobile number.

### POST `/api/Registration/validateotp`
Validates the OTP sent to the user.

### POST `/api/Registration/setpin`
Sets a PIN for the user after OTP verification.

### GET `/api/Registration/test`
Returns a success message to verify API connectivity.

---

## 🧰 Technologies Used

- ASP.NET Core Web API
- Swagger / OpenAPI 3.0.1
- Postman

---

## 🗃️ Project Structure

KoperasiTenteraProject/
│
├── Controllers/
├── DAL/
├── DomainModels/
├── DTOs/
├── Services/
├── swagger.json # Swagger API specification
└── README.md # Project documentation (this file)


---

## 📎 How to Run

1. Clone the repository:
   git clone https://github.com/HumayunKabirRubel/KoperasiTenteraProject.git
   cd KoperasiTenteraProject

2. Open in Visual Studio or use the .NET CLI:
   dotnet build
   dotnet run

3. Navigate to https://localhost:{port}/swagger to access the Swagger UI.

📞 Contact
Created by Humayun Kabir Rubel
Feel free to contribute, open issues, or suggest improvements.

📄 License
This project is licensed under the MIT License.




