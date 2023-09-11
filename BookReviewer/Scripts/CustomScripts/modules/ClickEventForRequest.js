import showMessage from "./ShowMessage.js";
import showPromptForAction from "./ShowPromptForAction.js";

export default function addClickEventForRequest(selector, promptMessage, successMessage, errorMessage, callback) {
    document.querySelectorAll(selector)
        .forEach(element => {
            element.addEventListener("click", () => {
                makeRequestWithDialog(element.getAttribute("url"), promptMessage, successMessage, errorMessage, () => callback(element));
            });
        });
}

function makeRequestWithDialog(url, promptMessage, successMessage, errorMessage, successCallback) {
    showPromptForAction(promptMessage, () => {
        makeRequest(url)
            .then(
                json => {
                    if (json.isSuccessful) {
                        successCallback();
                        showMessage("Success", successMessage);
                    } else {
                        showMessage("Failure", errorMessage);
                    }
                },
                () => showMessage("Failure", errorMessage)
            );
    });
}

async function makeRequest(url) {
    const request = await fetch(url, {
        method: "POST",
    });
    const result = await request.json();
    return result;
}