Google News Reader - Web Application with RSS Feed and AJAX

This project implements a web application that displays news topics from the Google News RSS feed. Clicking on a topic retrieves the full post details (title, body, and link) using AJAX.

Features:

    Caches RSS feed data in HttpCache for improved performance.
    Renders news topics using a Repeater control for efficient data binding.
    Implements dynamic content fetching for post details using AJAX.
    Prioritizes clean and readable code through:
        Meaningful comments (adhering to Coding Standards where applicable)
        Separation of concerns (UI and DAL)
        External CSS and JavaScript files
        Semantic HTML

Project Structure:

    UI (aspx files): Contains the user interface code for displaying news topics and handling user interactions.
    DAL (C# class files): Encapsulates data access logic, including fetching and caching the RSS feed data.
    CSS: Styles the application's visual appearance.
    JavaScript: Implements AJAX functionality for retrieving post details.

Running the Application:

    Clone this repository.
    Ensure you have the required development environment (e.g., Visual Studio .NET).
    Open the solution file (.sln) and build the project.
    Run the application to view the news feed.

Technology Stack:

    ASP.NET Web Forms
    C#
    HTML5
    CSS
    JavaScript (AJAX)
