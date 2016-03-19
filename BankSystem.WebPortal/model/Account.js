(function() {
    var accountBackend = Backbone.Model.extend({
        schemaName: "account",
        defaults: function() {
            return {
                id: 0,
                name: null,
                category: null,
                balance: 0
            };
        }
    });

    AccountsCollectionBackend = Backbone.Collection.extend({
        url: "http://localhost:50515/api/accounts/",
        model: accountBackend
    });
});