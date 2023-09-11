export default function showPromptForAction(message, actionCallback) {
    bootbox.confirm({
        message: message,
        closeButton: false,
        title: "Confirm",
        callback: (result) => {
            if (!result)
                return;
            actionCallback();
        }
    });
}