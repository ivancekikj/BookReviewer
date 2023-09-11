import addClickEventForRequest from "./modules/ClickEventForRequest.js";

const table = $("#data-table").DataTable();
const callback = element => table.row($(element).parents("tr")).remove().draw();

addClickEventForRequest(
    ".ajax-delete",
    "Are you sure you want to delete the selected entry?",
    "Successfully deleted the selected entry!",
    "Failed to delete the selected entry!",
    callback
);

addClickEventForRequest(
    ".ajax-approve",
    "Are you sure you want to approve the selected entry?",
    "Successfully approved the selected entry!",
    "Failed to approve the selected entry!",
    callback
);
