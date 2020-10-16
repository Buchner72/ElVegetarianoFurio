"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var testing_1 = require("@angular/core/testing");
var category_service_1 = require("./category.service");
describe('CategoryService', function () {
    beforeEach(function () { return testing_1.TestBed.configureTestingModule({}); });
    it('should be created', function () {
        var service = testing_1.TestBed.get(category_service_1.CategoryService);
        expect(service).toBeTruthy();
    });
});
//# sourceMappingURL=category.service.spec.js.map