$(function () {

    accountsList = new accountSet();

    accountsList.fetch({ data: { page: "no" } });

    var app = new WelcomeView({ model: accountsList });
    app.render();
});