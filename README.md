<h1 align="center">RAiso</h1>

**RAiso** is a renowned online store that specializes in selling stationery products. With its ever-growing popularity, the management of transaction data has become a challenging task. To address this issue, you have been approached to assist RAiso in effectively managing their database transactions. By implementing robust systems and processes, we aim to streamline the transactional data flow, ensuring smooth and efficient operations. 
As a web developer, you are asked to create a website using ASP.NET for this online shop. You are also required to use Domain Driven Design method to develop the website. Please note that using web service is optional in this project. The required layers are:

•	View
View layer is responsible for showing information to the user and interpreting the user's commands. This layer is the home for all user interfaces in the project.

•	Controller
This layer is responsible to validate all input from the view layer. It also responsible for delegating requests from the user to the lower layer for further processing.

•	Handler
This layer is responsible to handle all business logic required in the application. It will delegates the task to query from the database, including select, insert, update and delete, to the repository layer. Please notes that there can be a single handler that accesses multiple repository.  

•	Repository
Repository layer is responsible for giving access to the database and model layer via its public interfaces to acquiring references to preexisting domain objects. It provides methods to manipulate the object which will encapsulate the actual manipulation operation of data in the database. Repository also provides methods that select objects based on some criteria and return fully instantiated objects or collection of objects whose attribute meets those criteria.

•	Factory
You need to encapsulate all complex object creation in this layer. For example, when the client needs to create an aggregate object (an object that holds a reference to another object), the object factory must provide an interface for creating these objects. It is important to note that an object returned by the factory must in a consistent state.
•	Model
Model layer is responsible for representing concepts in the business or information about the business situation. The model layer is handled using entity framework tool.

The following is the Entity Relationship Diagram for RAiso’s Database:
![image](https://github.com/kyl464/psd-lab-project/assets/74804053/e9fbb903-7de6-440b-8419-c904549a3a99)
<p align="center">Figure 1. Entity Relationship Diagram of RAiso’s Database</p>

There are three types of user's roles in this website: Admin, Customer, and Guest (non-logged-in user). Below are the minimum pages you need to create for each role:

•	Admin
- View Stationeries
-	Insert Stationery
-	Update Stationery
-	Delete Stationery
-	Update Profile
-	View Transactions Report

•	Customer
-	View Stationeries
-	Order Stationeries
-	View Carts
-	Update Carts
-	Delete Carts
-	Update Profile
-	View Transactions History
-	View Transaction Detail

•	Guest
-	Login
-	Register
-	View Stationeries
The descriptions for each page are as follows

2.	Login
This page is the landing page of the website where the user will attempt to log in to the website. This page is only accessible to guests. 
The following table shows the existing fields in the login form and validations for each field:
![image](https://github.com/kyl464/psd-lab-project/assets/74804053/e0408c1f-f97e-4ae6-9d9c-48e5c3110228)
If the user entered an incorrect username or password, then an error message will be shown corresponding to the validation triggering it. The login page will also have a remember me checkbox. The remember me checkbox will save your login information by implementing a cookie which also has an expired time if a user had checked it so that the next time the user attempts another login, it will log the user in automatically.

3.	Register
This page allows guests to register themselves as RAiso customer. Validate this page is only accessible to guests. Display an error message if the user inputs invalid personal data. The following table shows the existing fields on this page and the validation for each field:
![image](https://github.com/kyl464/psd-lab-project/assets/74804053/6e592572-39e2-4369-94c1-7cd81233f3a6)

5.	Navigation Bar
Provide a navigation bar to make it easier for user to navigate between pages:
•	If no user is logged-in:
•	Home: Redirect user to the homepage
•	Login: Redirect user to the login page
•	Register: Redirect user to the register page
•	If the current user is a customer:
•	Home: Redirect user to the homepage
•	Cart: Redirect user to the carts page
•	Transaction: Redirect user to the transactions page
•	Update Profile: Redirect user to update profile page
•	Logout: Logs out the user from the website and destroys all cookie variables
•	If the current user is an admin:
•	Home: Redirect user to the homepage
•	Transaction: Redirect user to transaction report page
•	Update Profile: Redirect user to update profile page
•	Logout: Logs out the user from the website and destroys all cookie variables

6.	Home
This page allows user to see all RAiso’s stationeries. This page allows user to redirect into Stationery’s Detail Page if user click the card. This page allows admin to insert, update and delete the Stationery. In this page, there is an Insert Stationery button. If admin click Insert Stationery button, then it will redirect them to Insert Stationery page.
Each stationery in the lists have ‘Update’ and ‘Delete’ buttons:
-	If Admin click Delete button, delete selected Stationery.
-	If Admin click Update button, it will redirect them to Update Stationery page and the selected Stationery ID will be passed using the URL’s query string parameter. 

6.	Stationery Detail
This page is accessible for all users. If user click the Stationery card in homepage, redirect user to this details page. This page displays the stationery name, stationery price. There is also a “Add to Cart” button. Validate the button to only appear if the user’s login as Customer. Customer could fill the quantity number before adding the item to cart.
The following table shows existing fields in the page and the validation for each field:
![image](https://github.com/kyl464/psd-lab-project/assets/74804053/f1a012e8-16a1-4bd2-94c4-a04e75b6c6e7)

7.	Insert Stationery
This page is only accessible for admin. This page allows an admin to insert a new stationery into the database, this page can be access when admin clicks Insert Stationery button in Home Page. Display an error message if the admin inputted invalid data. When admin has inputted all of the fields correctly and pressed the Insert Button, the inputted stationery information will be added and saved into the database. The following table shows existing fields on this page and the validation for each field:
![image](https://github.com/kyl464/psd-lab-project/assets/74804053/0e893103-248e-48a9-a934-9e10c66c60be)

8.	Update Stationery
This page is only accessible for admin. This page allows an admin to update an existing stationery in the database. The administrator will be redirected to this page when they clicked the Update Button provided in the Home Page. All the to-be-updated stationery’s current data will be shown in this page and the administrator can change those data before submitting it again by pressing the Update Button. The stationery’s data will be fetched from the database by using the stationery’s ID provided from the URL’s query string parameter. When the admin has inputted all the fields correctly and pressed the Update Button, the stationery’s information in the database will be updated. Display an error message if the admin inputted invalid data. 
The following table shows existing fields in the page and the validation for each field:
![image](https://github.com/kyl464/psd-lab-project/assets/74804053/310e3c9f-52fb-44f3-94af-6d85c2c85040)

9.	Cart Page
This page is accessible only for customers. The customer will be redirected to this page when they clicked the Cart Button provided at the Navigation Bar. This page displays all stationeries that have been added into customer’s shopping cart. Display cart information such as stationery’s name, stationery’s price and stationery’s quantity. There are three buttons in this page, Update button for each stationery on cart, Remove button for each stationery on cart and Checkout button. If customers click Update button, then redirect customer to Update Cart page, if customers click Remove button, then remove selected stationery from the cart, and if customers click Checkout button, then all shopping cart data will be deleted and insert current transaction data into customer’s transaction history, then redirect user to home page.

10.	Update Cart
This page is accessible only for customers. Customers can access it by clicking the "Update Cart" button in the Cart page. On this page, will be shown stationery’s name, stationery’s price, and a textfield for user to update the quantity of stationery that they want to buy.
The following table shows existing fields in the page and the validation for each field:
![image](https://github.com/kyl464/psd-lab-project/assets/74804053/47746b83-cba8-4b67-b66c-4f178f24012e)

11.	Transaction History
This page is only accessible for customers to show customer’s transaction history. The information of transaction that must be shown are transaction id, transaction date, customer’s name, and transaction detail button to redirect user to Transaction Detail page.

12.	Transaction Detail
This page is only accessible for customers to show customer’s transaction details. The information of transaction that must be shown are stationery’s name, stationery’s price, and quantity bought.

13.	Transaction Report
This page is accessible only for the admin. The administrator will be redirected to this page when they clicked the Transactions Button provided at the Navigation Bar. This page will display the report transactions data using Crystal Report. The report will have to show the header transaction information such as transaction id, user id, transaction date and Grand Total value, also the details such as transaction id, stationery name, quantity, stationery price, and Sub Total value.

14.	Update Profile
This page allows the user to change their profile information. The user will be redirected to this page when they clicked the Update Profile Button provided at Navigation Bar. Display an error message if the user inputted invalid data. All of the to-be-updated profile's current data will be shown on this page and the user can change those data before submitting it again by pressing the Update Button. When the user has inputted all of the fields correctly and pressed the Update Button, the user’s information in the database will be updated. 
The following table shows existing fields in the page and the validation for each field:
![image](https://github.com/kyl464/psd-lab-project/assets/74804053/ae040f58-040b-43e2-b932-bb3be6163cee)


