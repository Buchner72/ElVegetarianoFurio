"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var testing_1 = require("@angular/core/testing");
var dish_service_1 = require("./dish.service");
describe('DishService', function () {
    beforeEach(function () { return testing_1.TestBed.configureTestingModule({}); });
    it('should be created', function () {
        var service = testing_1.TestBed.get(dish_service_1.DishService);
        expect(service).toBeTruthy();
    });
});
//# sourceMappingURL=dish.service.spec.js.map