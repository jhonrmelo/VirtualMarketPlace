$(document).ready(() => {
    masksApplication();
});

const masksApplication = () => {

    $('.money').mask('000.000.000.000.000,00', { reverse: true });
}