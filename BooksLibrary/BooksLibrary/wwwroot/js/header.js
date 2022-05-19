var img = document.createElement("img");
img.src = "/Images/books.jpg";
img.setAttribute("style", "margin-top: 10px;width: 1600;height: 100;margin-bottom: 10px");

var div = document.getElementById("x");
div.appendChild(img);
div.setAttribute("style", "text-align:center");