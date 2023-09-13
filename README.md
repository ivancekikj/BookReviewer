# Introduction

Book Reviewer is a web application meant for what its very name stands for. It supports 3 types of users: anonymous, normal users and administrators. All 3 types can view the available books and reviews. Normal users can also leave a review on each book and even recommend a new book. As for administrators, they: have the ability to approve recommended books; can manage the information related to books, authors and publishers; and can approve new admins to log in.

# Technologies

The project is coded with a front-end and backed-end part. HTML, CSS, Bootstrap, JavaScript and some jQuery are used in the front-end. Meanwhile, the back-end is coded in ASP.NET MVC and uses a local database (sqlexpress).

# Planning

Prior to coding the project sufficient planning was necessary to determine: the functionalities, the data and the interface layout. A couple of files were produced to help visualize these concepts. The files can be found in the folder "./BookReviewer/ProjectFiles". They are:

- short_description.txt - The project's first description. It was written when the project was first thought of.
- functionalities.jpg - A UML use-case diagram that shows the system's user types and the functionalities they possess.
- models.jpg - A UML class diagram that shows the properties and relations of the models used for the database.
- web_pages.txt - A proposed website hierarchy.
- wireframes.jpg - Basic wireframes for each web page from "web_pages.txt".

Keep in mind that these files were intended to be used as a guide on what to focus on when coding the app. During the coding process some changes were made, descriptions of which can be found in the next section of this documentation.

# Coding process

1. Created project.
2. Created DbModels and ran InitialMigration.
3. Set up authentication system.
4. Added controllers for Books, Authors and Publishers.
5. Created overall design with Bootstrap.
6. Added CRUD operations and views for Authors and Publishers with authorization.
7. Created script for Datatables and Ajax.
8. Enabled all CRUD operations for Books with sufficient role authorization.
9. Added controller for Unapproved Books.
10. Enabled creation and approval of Unapproved Books.
11. Refactored DbModels with seperated Book tables.
12. Refactored Admin Approvals into a separate controller.
13. Added Reviews controller with Create, Edit and Delete operations.
14. Added Read operation for Reviews on specific book.
15. Refactored DbModels by making Book and UnapprovedBook inherit from AbstractBook.
16. Added pagination for Reviews on Book Details action.

# Created by

Ivan Cekikj (211146)
