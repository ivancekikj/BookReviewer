export default function showMessage(title, message) {
    bootbox.alert({
        title: title,
        message: message,
        closeButton: false
    });
}