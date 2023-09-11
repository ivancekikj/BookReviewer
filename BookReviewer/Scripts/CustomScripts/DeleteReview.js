import showPromptForAction from "./modules/ShowPromptForAction.js";

document.querySelector("#btn-delete-review")
    .addEventListener("click", () => showPromptForAction(
        "Are you sure you want to delete your review of the current book?",
        () => document.querySelector("#delete-review").submit()
    ));