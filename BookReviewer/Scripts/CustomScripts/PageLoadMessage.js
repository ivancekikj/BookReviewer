import showMessage from "./modules/ShowMessage.js";

document.addEventListener('DOMContentLoaded', () => {
    const element = document.querySelector("#page-load-message");
    if (element != null) {
        showMessage(null, element.innerHTML);
        element.parentElement.removeChild(element);
    }
}, false);