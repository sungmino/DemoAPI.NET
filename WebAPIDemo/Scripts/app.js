﻿var ViewModel = function () {
    var self = this;
    self.products = ko.observableArray();
    self.error = ko.observable();

    var productsUri = '/api/products/';

    function ajaxHelper(uri, method, data) {
        self.error(''); // Clear error message
        return $.ajax({
            type: method,
            url: uri,
            dataType: 'json',
            contentType: 'application/json',
            data: data ? JSON.stringify(data) : null
        }).fail(function (jqXHR, textStatus, errorThrown) {
            self.error(errorThrown);
        });
    }

    function getAllProducts() {
        ajaxHelper(productsUri, 'GET').done(function (data) {
            self.products(data);
        });
    }

    // Fetch the initial data.
    getAllProducts();

    self.detail = ko.observable();

    self.getProductDetail = function (item) {
        ajaxHelper(productsUri + item.Id, 'GET').done(function (data) {
            self.detail(data);
        });
    }

    self.categories = ko.observableArray();
    self.newProduct= {
        Category: ko.observable(),
        Name: ko.observable(),
        Price: ko.observable(),
    }

    var categoriesUri = '/api/categories/';

    function getCategories() {
        ajaxHelper(categoriesUri, 'GET').done(function (data) {
            self.categories(data);
        });
    }

    self.addProduct = function (formElement) {
        var product = {
            CategoryId: self.newProduct.Category().Id,
            Name: self.newProduct.Name(),
            Price: self.newProduct.Price(),
        };

        ajaxHelper(productsUri, 'POST', product).done(function (item) {
            self.products.push(item);
        });
    }

    getCategories();
};

ko.applyBindings(new ViewModel());