/// <reference path="/backbone.js" />
/// <reference path="/jquery-1.7.1.js" />
/// <reference path="/underscore.js" />
/// <reference path="/Skill.js" />

$(function () {

    // Our overall **AppView** is the top-level piece of UI.
    WelcomeView = Backbone.View.extend({

        // Instead of generating a new element, bind to the existing skeleton of
        // the App already present in the HTML.
        el: $("#app"),

        events: {
            "click #addAccount": "addAccount"
        },

        addAccount: function () {
            var account = {
                id: 0,
                name: this.newAccountName.val(),
                category: this.newAccountCategory.val(),
                balance: this.newAccountBalance.val()
            };

            accountsList.create(account);

            this.newAccountName.val('');
            this.newAccountCategory.val('');
            this.newAccountBalance.val('');
        },

        initialize: function () {
            this.newAccountName = this.$("#accountName");
            this.newAccountCategory = this.$("#accountCategory");
            this.newAccountBalance = this.$("#accountAmmount");

            this.listenTo(this.model, 'change', this.render);
            this.listenTo(this.model, 'add', this.render);
        },

        render: function () {
            $("#accountsList").html("");
            if (this.model.length) {
                for (var i = 0; i < this.model.length; i++) {
                    var view = new AccountVeiw({ model: this.model.at(i) });
                    $("#accountsList").append(view.render().el);
                }
            }
        }
    });
});