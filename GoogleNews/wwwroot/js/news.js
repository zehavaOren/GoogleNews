// JavaScript code to handle click event on title links
document.addEventListener("DOMContentLoaded", function () {

    var headlineList = document.getElementById("headlineList");
    //Added a click event to each clickable title
    headlineList.addEventListener("click", function (event) {
        if (event.target && event.target.nodeName == "LI") {
            // Remove the 'selected' class from all list items
            var listItems = headlineList.getElementsByTagName("li");
            for (var i = 0; i < listItems.length; i++) {
                listItems[i].classList.remove("selected");
            }

            // Add the 'selected' class to the clicked list item
            event.target.classList.add("selected");

            var title = event.target.dataset.title;
            var description = event.target.dataset.description;
            var link = event.target.dataset.link;

            // Display description and link
            document.getElementById("postTitle").textContent = title;
            document.getElementById("postContent").innerHTML = "<p>" + description + "</p><a href='" + link + "'>Read more</a>";
        }
    });
});
