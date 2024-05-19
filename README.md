# Learning CSharp Repo

Hi guys, this is my public learning repository for Csharp. This is not really meant to be an educational tool since I'm new to Csharp myself. This repository serves as documentation of my learnings and notes in my journey to have a good understanding of the language.

In the next sections you will find the syllabus that I have curated after searching around and asking AI to help me find which topics to learn in order to have a good foundational understanding of C#. Below each bullet point I will name the project folder associated with the topic.

I am using .NET SDK v8.0.204 and runtime versions 8.0.4 for both .NETCore and AspNetCore.

## Syntax and Structure

- **Namespace and Using Directives**: Understand how using directives work and why they are essential.
    - Directives/
- **Classes and Methods**: Learn to define classes, methods, and how to call them.
- **Main Method**: Understand the role of the Main method as the entry point of a C# application.

## Data Types and Variables

- **Primitive Types**: Learn about integer, floating-point, boolean, and character types.
- **Variables**: Understand variable declaration and scope.
- **Constants**: Learn how to declare constants and their usage.

## Operators

- **Arithmetic Operators**: Practice arithmetic operations.
- **Comparison Operators**: Learn comparison operators and their uses.
- **Logical Operators**: Understand logical operators for combining conditions.

## Control Structures

- **Conditional Statements:** Learn `if`, `else if`, and `else` for branching logic.
    - **Project:** Write a program that checks if a number is positive, negative, or zero using `if` statements.
- **Loops:**
    - **`for` Loop:** Understand iterating over a known number of times.
        - **Project 1:** Create a program that prints the first 10 natural numbers using a `for` loop.
    - **`while` Loop:** Learn looping until a condition becomes false.
        - **Project 2:** Write a program that reads user input until they enter "exit" using a `while` loop.
    - **`do-while` Loop:** Understand a loop that executes at least once.
        - **Project 3 (Optional):** Write a program that simulates a guessing game where the user has to guess a random number between 1 and 10. Use a `do-while` loop to keep the game running until the user guesses correctly.
- **`switch` Statement:** Learn multi-way branching based on a single value.
    - **Project 4:** Develop a program that takes a day of the week as input (e.g., "Monday") and displays a corresponding message using a `switch` statement (e.g., "Go to work!" for weekdays, "Enjoy the weekend!" for weekends).

## Input and Output

- **Reading Input**: Learn how to read input from the console.
- **Writing Output**: Understand how to display output to the console.

## Arrays and Collections

- **Arrays:** Learn how to declare, initialize, and manipulate arrays.
    - **Project 5:** Write a program that stores student names in an array and then displays them all using a loop.
- **Lists and Other Collections:** Understand the basics of collections like `List`, `Dictionary`, etc.
    - **Project 6 (Optional):** Create a program that uses a `List` to store items in a shopping cart and allows adding, removing, and displaying items.
## Object-Oriented Programming (OOP)

- **Classes and Objects:** Define classes and create objects.
- **Inheritance:** Understand how to create a hierarchical relationship between classes.
    - **Project 7 (Optional):** Design a class hierarchy for shapes (e.g., `Shape`, `Circle`, `Rectangle`) with inheritance and methods to calculate area.
- **Polymorphism:** Learn about overriding methods for behavior based on object type.
    - **Project 8 (Optional):** Extend Project 7 to implement a `Draw` method in each shape class that draws the shape to the console using appropriate symbols (e.g., `*` for stars, `-` for lines).
- **Encapsulation:** Practice hiding fields and providing access through properties.
    - **Project 9 (Optional):** Refactor Project 7 to encapsulate shape properties (e.g., width, height) using private fields and public getter/setter properties.

## Exception Handling

- **Try-Catch-Finally Blocks:** Learn how to handle exceptions gracefully.
	- **Project 10 (Optional):** Write a program that reads a file and displays its contents. Use a `try-catch` block to handle potential exceptions like "File not found".

## File I/O

- Reading and Writing Files: Understand how to perform file operations.

## Projects to Illustrate Learning:

- Project 1: Create a simple calculator that performs addition, subtraction, multiplication, and division.
- Project 2: Develop a program to manage a student database, allowing adding, updating, deleting students, and displaying their details. Using only arrays or lists.
- Project 3: Implement a basic game like tic-tac-toe or guessing numbers.
