(self["webpackChunkgamestore_ui_app"] = self["webpackChunkgamestore_ui_app"] || []).push([["main"],{

/***/ 8255:
/*!*******************************************************!*\
  !*** ./$_lazy_route_resources/ lazy namespace object ***!
  \*******************************************************/
/***/ ((module) => {

function webpackEmptyAsyncContext(req) {
	// Here Promise.resolve().then() is used instead of new Promise() to prevent
	// uncaught exception popping up in devtools
	return Promise.resolve().then(() => {
		var e = new Error("Cannot find module '" + req + "'");
		e.code = 'MODULE_NOT_FOUND';
		throw e;
	});
}
webpackEmptyAsyncContext.keys = () => ([]);
webpackEmptyAsyncContext.resolve = webpackEmptyAsyncContext;
webpackEmptyAsyncContext.id = 8255;
module.exports = webpackEmptyAsyncContext;

/***/ }),

/***/ 158:
/*!***************************************!*\
  !*** ./src/app/app-routing.module.ts ***!
  \***************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "AppRoutingModule": () => (/* binding */ AppRoutingModule)
/* harmony export */ });
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/router */ 1258);
/* harmony import */ var _configuration_routes_resolver__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./configuration/routes-resolver */ 1629);
/* harmony import */ var _pages_main_page_main_page_component__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./pages/main-page/main-page.component */ 6728);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/core */ 2316);





const routes = [
    {
        path: '',
        pathMatch: 'full',
        component: _pages_main_page_main_page_component__WEBPACK_IMPORTED_MODULE_1__.MainPageComponent,
    },
    {
        path: '**',
        redirectTo: '',
    },
];
class AppRoutingModule {
    constructor(router) {
        (0,_configuration_routes_resolver__WEBPACK_IMPORTED_MODULE_0__.resolveRoutesAsync)().then((routes) => routes.forEach((x) => router.config.splice(1, 0, x)));
    }
}
AppRoutingModule.ɵfac = function AppRoutingModule_Factory(t) { return new (t || AppRoutingModule)(_angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵinject"](_angular_router__WEBPACK_IMPORTED_MODULE_3__.Router)); };
AppRoutingModule.ɵmod = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵdefineNgModule"]({ type: AppRoutingModule });
AppRoutingModule.ɵinj = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵdefineInjector"]({ imports: [[_angular_router__WEBPACK_IMPORTED_MODULE_3__.RouterModule.forRoot(routes, { anchorScrolling: 'enabled' })], _angular_router__WEBPACK_IMPORTED_MODULE_3__.RouterModule] });
(function () { (typeof ngJitMode === "undefined" || ngJitMode) && _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵsetNgModuleScope"](AppRoutingModule, { imports: [_angular_router__WEBPACK_IMPORTED_MODULE_3__.RouterModule], exports: [_angular_router__WEBPACK_IMPORTED_MODULE_3__.RouterModule] }); })();


/***/ }),

/***/ 5041:
/*!**********************************!*\
  !*** ./src/app/app.component.ts ***!
  \**********************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "AppComponent": () => (/* binding */ AppComponent)
/* harmony export */ });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var _componetns_header_component_header_component__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./componetns/header-component/header.component */ 2058);
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/router */ 1258);



class AppComponent {
    constructor() {
        this.title = 'gamestore-ui-app';
    }
}
AppComponent.ɵfac = function AppComponent_Factory(t) { return new (t || AppComponent)(); };
AppComponent.ɵcmp = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵdefineComponent"]({ type: AppComponent, selectors: [["app-root"]], decls: 3, vars: 0, consts: [[1, "page-wrapper"]], template: function AppComponent_Template(rf, ctx) { if (rf & 1) {
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵelement"](0, "gamestore-header");
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵelementStart"](1, "div", 0);
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵelement"](2, "router-outlet");
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵelementEnd"]();
    } }, directives: [_componetns_header_component_header_component__WEBPACK_IMPORTED_MODULE_0__.HeaderComponent, _angular_router__WEBPACK_IMPORTED_MODULE_2__.RouterOutlet], styles: [".page-wrapper[_ngcontent-%COMP%] {\n  padding: 15px;\n  box-sizing: border-box;\n}\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbImFwcC5jb21wb25lbnQuc2NzcyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiQUFBQTtFQUNJLGFBQUE7RUFDQSxzQkFBQTtBQUNKIiwiZmlsZSI6ImFwcC5jb21wb25lbnQuc2NzcyIsInNvdXJjZXNDb250ZW50IjpbIi5wYWdlLXdyYXBwZXIge1xyXG4gICAgcGFkZGluZzogMTVweDtcclxuICAgIGJveC1zaXppbmc6IGJvcmRlci1ib3g7XHJcbn0iXX0= */"] });


/***/ }),

/***/ 6747:
/*!*******************************!*\
  !*** ./src/app/app.module.ts ***!
  \*******************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "AppModule": () => (/* binding */ AppModule)
/* harmony export */ });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_27__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var _angular_platform_browser__WEBPACK_IMPORTED_MODULE_29__ = __webpack_require__(/*! @angular/platform-browser */ 1570);
/* harmony import */ var _app_routing_module__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./app-routing.module */ 158);
/* harmony import */ var _app_component__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./app.component */ 5041);
/* harmony import */ var _angular_platform_browser_animations__WEBPACK_IMPORTED_MODULE_30__ = __webpack_require__(/*! @angular/platform-browser/animations */ 718);
/* harmony import */ var _componetns_header_component_header_component__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./componetns/header-component/header.component */ 2058);
/* harmony import */ var _pages_main_page_main_page_module__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./pages/main-page/main-page.module */ 2287);
/* harmony import */ var _configuration_configuration_resolver__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ./configuration/configuration-resolver */ 5482);
/* harmony import */ var ngx_toastr__WEBPACK_IMPORTED_MODULE_31__ = __webpack_require__(/*! ngx-toastr */ 3315);
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_28__ = __webpack_require__(/*! @angular/common/http */ 3882);
/* harmony import */ var _configuration_http_interceptor__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ./configuration/http-interceptor */ 433);
/* harmony import */ var _configuration_error_handler__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ./configuration/error-handler */ 381);
/* harmony import */ var _pages_games_page_games_page_module__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! ./pages/games-page/games-page.module */ 564);
/* harmony import */ var _pages_game_page_game_page_module__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! ./pages/game-page/game-page.module */ 7389);
/* harmony import */ var _pages_update_game_page_update_game_page_module__WEBPACK_IMPORTED_MODULE_9__ = __webpack_require__(/*! ./pages/update-game-page/update-game-page.module */ 640);
/* harmony import */ var _pages_delete_game_page_delete_game_page_module__WEBPACK_IMPORTED_MODULE_10__ = __webpack_require__(/*! ./pages/delete-game-page/delete-game-page.module */ 4811);
/* harmony import */ var _angular_material_button__WEBPACK_IMPORTED_MODULE_32__ = __webpack_require__(/*! @angular/material/button */ 781);
/* harmony import */ var _pages_genre_page_genre_page_module__WEBPACK_IMPORTED_MODULE_11__ = __webpack_require__(/*! ./pages/genre-page/genre-page.module */ 4108);
/* harmony import */ var _pages_genres_page_genres_page_module__WEBPACK_IMPORTED_MODULE_12__ = __webpack_require__(/*! ./pages/genres-page/genres-page.module */ 7204);
/* harmony import */ var _pages_update_genre_page_update_genre_page_module__WEBPACK_IMPORTED_MODULE_13__ = __webpack_require__(/*! ./pages/update-genre-page/update-genre-page.module */ 159);
/* harmony import */ var _pages_delete_genre_page_delete_genre_page_module__WEBPACK_IMPORTED_MODULE_14__ = __webpack_require__(/*! ./pages/delete-genre-page/delete-genre-page.module */ 5432);
/* harmony import */ var _pages_platforms_page_platforms_page_module__WEBPACK_IMPORTED_MODULE_15__ = __webpack_require__(/*! ./pages/platforms-page/platforms-page.module */ 3952);
/* harmony import */ var _pages_platform_page_platform_page_module__WEBPACK_IMPORTED_MODULE_16__ = __webpack_require__(/*! ./pages/platform-page/platform-page.module */ 7351);
/* harmony import */ var _pages_update_platform_page_update_platform_page_module__WEBPACK_IMPORTED_MODULE_17__ = __webpack_require__(/*! ./pages/update-platform-page/update-platform-page.module */ 4231);
/* harmony import */ var _pages_delete_patform_page_delete_platform_page_module__WEBPACK_IMPORTED_MODULE_18__ = __webpack_require__(/*! ./pages/delete-patform-page/delete-platform-page.module */ 5883);
/* harmony import */ var _pages_delete_publisher_page_delete_publisher_page_module__WEBPACK_IMPORTED_MODULE_19__ = __webpack_require__(/*! ./pages/delete-publisher-page/delete-publisher-page.module */ 491);
/* harmony import */ var _pages_update_publisher_page_update_publisher_page_module__WEBPACK_IMPORTED_MODULE_20__ = __webpack_require__(/*! ./pages/update-publisher-page/update-publisher-page.module */ 97);
/* harmony import */ var _pages_publisher_page_publisher_page_module__WEBPACK_IMPORTED_MODULE_21__ = __webpack_require__(/*! ./pages/publisher-page/publisher-page.module */ 5640);
/* harmony import */ var _pages_publishers_page_publishers_page_module__WEBPACK_IMPORTED_MODULE_22__ = __webpack_require__(/*! ./pages/publishers-page/publishers-page.module */ 9596);
/* harmony import */ var _pages_orders_page_orders_page_module__WEBPACK_IMPORTED_MODULE_23__ = __webpack_require__(/*! ./pages/orders-page/orders-page.module */ 5529);
/* harmony import */ var _pages_order_page_order_page_module__WEBPACK_IMPORTED_MODULE_24__ = __webpack_require__(/*! ./pages/order-page/order-page.module */ 7235);
/* harmony import */ var _pages_basket_page_basket_page_module__WEBPACK_IMPORTED_MODULE_25__ = __webpack_require__(/*! ./pages/basket-page/basket-page.module */ 6323);
/* harmony import */ var _pages_make_order_page_make_order_page_module__WEBPACK_IMPORTED_MODULE_26__ = __webpack_require__(/*! ./pages/make-order-page/make-order-page.module */ 893);



































class AppModule {
}
AppModule.ɵfac = function AppModule_Factory(t) { return new (t || AppModule)(); };
AppModule.ɵmod = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_27__["ɵɵdefineNgModule"]({ type: AppModule, bootstrap: [_app_component__WEBPACK_IMPORTED_MODULE_1__.AppComponent] });
AppModule.ɵinj = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_27__["ɵɵdefineInjector"]({ providers: [
        {
            provide: _angular_core__WEBPACK_IMPORTED_MODULE_27__.APP_INITIALIZER,
            useFactory: () => _configuration_configuration_resolver__WEBPACK_IMPORTED_MODULE_4__.resolveConfigurations,
            multi: true,
        },
        {
            provide: _angular_common_http__WEBPACK_IMPORTED_MODULE_28__.HTTP_INTERCEPTORS,
            useClass: _configuration_http_interceptor__WEBPACK_IMPORTED_MODULE_5__.GlobalHttpInterceptorService,
            multi: true,
        },
        { provide: _angular_core__WEBPACK_IMPORTED_MODULE_27__.ErrorHandler, useClass: _configuration_error_handler__WEBPACK_IMPORTED_MODULE_6__.GlobalErrorHandlerService },
    ], imports: [[
            _pages_main_page_main_page_module__WEBPACK_IMPORTED_MODULE_3__.MainPageModule,
            _angular_platform_browser__WEBPACK_IMPORTED_MODULE_29__.BrowserModule,
            _app_routing_module__WEBPACK_IMPORTED_MODULE_0__.AppRoutingModule,
            _angular_platform_browser_animations__WEBPACK_IMPORTED_MODULE_30__.BrowserAnimationsModule,
            ngx_toastr__WEBPACK_IMPORTED_MODULE_31__.ToastrModule.forRoot(),
            _angular_common_http__WEBPACK_IMPORTED_MODULE_28__.HttpClientModule,
            _pages_games_page_games_page_module__WEBPACK_IMPORTED_MODULE_7__.GamesPageModule,
            _pages_game_page_game_page_module__WEBPACK_IMPORTED_MODULE_8__.GamePageModule,
            _pages_update_game_page_update_game_page_module__WEBPACK_IMPORTED_MODULE_9__.UpdateGamePageModule,
            _pages_delete_game_page_delete_game_page_module__WEBPACK_IMPORTED_MODULE_10__.DeleteGamePageModule,
            _angular_material_button__WEBPACK_IMPORTED_MODULE_32__.MatButtonModule,
            _pages_genre_page_genre_page_module__WEBPACK_IMPORTED_MODULE_11__.GenrePageModule,
            _pages_genres_page_genres_page_module__WEBPACK_IMPORTED_MODULE_12__.GenresPageModule,
            _pages_update_genre_page_update_genre_page_module__WEBPACK_IMPORTED_MODULE_13__.UpdateGenrePageModule,
            _pages_delete_genre_page_delete_genre_page_module__WEBPACK_IMPORTED_MODULE_14__.DeleteGenrePageModule,
            _pages_platforms_page_platforms_page_module__WEBPACK_IMPORTED_MODULE_15__.PlatformsPageModule,
            _pages_platform_page_platform_page_module__WEBPACK_IMPORTED_MODULE_16__.PlatformPageModule,
            _pages_update_platform_page_update_platform_page_module__WEBPACK_IMPORTED_MODULE_17__.UpdatePlatformPageModule,
            _pages_delete_patform_page_delete_platform_page_module__WEBPACK_IMPORTED_MODULE_18__.DeletePlatformPageModule,
            _pages_delete_publisher_page_delete_publisher_page_module__WEBPACK_IMPORTED_MODULE_19__.DeletePublisherPageModule,
            _pages_update_publisher_page_update_publisher_page_module__WEBPACK_IMPORTED_MODULE_20__.UpdatePublisherPageModule,
            _pages_publisher_page_publisher_page_module__WEBPACK_IMPORTED_MODULE_21__.PublisherPageModule,
            _pages_publishers_page_publishers_page_module__WEBPACK_IMPORTED_MODULE_22__.PublishersPageModule,
            _pages_orders_page_orders_page_module__WEBPACK_IMPORTED_MODULE_23__.OrdersPageModule,
            _pages_order_page_order_page_module__WEBPACK_IMPORTED_MODULE_24__.OrderPageModule,
            _pages_basket_page_basket_page_module__WEBPACK_IMPORTED_MODULE_25__.BasketPageModule,
            _pages_make_order_page_make_order_page_module__WEBPACK_IMPORTED_MODULE_26__.MakeOrderPageModule,
        ]] });
(function () { (typeof ngJitMode === "undefined" || ngJitMode) && _angular_core__WEBPACK_IMPORTED_MODULE_27__["ɵɵsetNgModuleScope"](AppModule, { declarations: [_app_component__WEBPACK_IMPORTED_MODULE_1__.AppComponent, _componetns_header_component_header_component__WEBPACK_IMPORTED_MODULE_2__.HeaderComponent], imports: [_pages_main_page_main_page_module__WEBPACK_IMPORTED_MODULE_3__.MainPageModule,
        _angular_platform_browser__WEBPACK_IMPORTED_MODULE_29__.BrowserModule,
        _app_routing_module__WEBPACK_IMPORTED_MODULE_0__.AppRoutingModule,
        _angular_platform_browser_animations__WEBPACK_IMPORTED_MODULE_30__.BrowserAnimationsModule, ngx_toastr__WEBPACK_IMPORTED_MODULE_31__.ToastrModule, _angular_common_http__WEBPACK_IMPORTED_MODULE_28__.HttpClientModule,
        _pages_games_page_games_page_module__WEBPACK_IMPORTED_MODULE_7__.GamesPageModule,
        _pages_game_page_game_page_module__WEBPACK_IMPORTED_MODULE_8__.GamePageModule,
        _pages_update_game_page_update_game_page_module__WEBPACK_IMPORTED_MODULE_9__.UpdateGamePageModule,
        _pages_delete_game_page_delete_game_page_module__WEBPACK_IMPORTED_MODULE_10__.DeleteGamePageModule,
        _angular_material_button__WEBPACK_IMPORTED_MODULE_32__.MatButtonModule,
        _pages_genre_page_genre_page_module__WEBPACK_IMPORTED_MODULE_11__.GenrePageModule,
        _pages_genres_page_genres_page_module__WEBPACK_IMPORTED_MODULE_12__.GenresPageModule,
        _pages_update_genre_page_update_genre_page_module__WEBPACK_IMPORTED_MODULE_13__.UpdateGenrePageModule,
        _pages_delete_genre_page_delete_genre_page_module__WEBPACK_IMPORTED_MODULE_14__.DeleteGenrePageModule,
        _pages_platforms_page_platforms_page_module__WEBPACK_IMPORTED_MODULE_15__.PlatformsPageModule,
        _pages_platform_page_platform_page_module__WEBPACK_IMPORTED_MODULE_16__.PlatformPageModule,
        _pages_update_platform_page_update_platform_page_module__WEBPACK_IMPORTED_MODULE_17__.UpdatePlatformPageModule,
        _pages_delete_patform_page_delete_platform_page_module__WEBPACK_IMPORTED_MODULE_18__.DeletePlatformPageModule,
        _pages_delete_publisher_page_delete_publisher_page_module__WEBPACK_IMPORTED_MODULE_19__.DeletePublisherPageModule,
        _pages_update_publisher_page_update_publisher_page_module__WEBPACK_IMPORTED_MODULE_20__.UpdatePublisherPageModule,
        _pages_publisher_page_publisher_page_module__WEBPACK_IMPORTED_MODULE_21__.PublisherPageModule,
        _pages_publishers_page_publishers_page_module__WEBPACK_IMPORTED_MODULE_22__.PublishersPageModule,
        _pages_orders_page_orders_page_module__WEBPACK_IMPORTED_MODULE_23__.OrdersPageModule,
        _pages_order_page_order_page_module__WEBPACK_IMPORTED_MODULE_24__.OrderPageModule,
        _pages_basket_page_basket_page_module__WEBPACK_IMPORTED_MODULE_25__.BasketPageModule,
        _pages_make_order_page_make_order_page_module__WEBPACK_IMPORTED_MODULE_26__.MakeOrderPageModule] }); })();


/***/ }),

/***/ 2844:
/*!**********************************************!*\
  !*** ./src/app/componetns/base.component.ts ***!
  \**********************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "BaseComponent": () => (/* binding */ BaseComponent)
/* harmony export */ });
/* harmony import */ var rxjs_operators__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! rxjs/operators */ 3927);
/* harmony import */ var _configuration_page_routes__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ../configuration/page-routes */ 5075);
/* harmony import */ var _configuration_routes_resolver__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../configuration/routes-resolver */ 1629);
/* harmony import */ var _locals_en_labels__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../locals/en-labels */ 2219);




class BaseComponent {
    constructor() {
        this.links = _configuration_routes_resolver__WEBPACK_IMPORTED_MODULE_1__.links;
        this.pageRoutes = _configuration_page_routes__WEBPACK_IMPORTED_MODULE_0__.PageRoutes;
        this.enLabels = new _locals_en_labels__WEBPACK_IMPORTED_MODULE_2__.EnLabels();
    }
    get labels() {
        return this.enLabels;
    }
    getRouteParam(route, name) {
        return route.params.pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_3__.map)((params) => { var _a; return (_a = params[name]) === null || _a === void 0 ? void 0 : _a.toString(); }));
    }
}


/***/ }),

/***/ 5583:
/*!*************************************************************************************!*\
  !*** ./src/app/componetns/checkboxes-input-component/checkboxes-input.component.ts ***!
  \*************************************************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "CheckboxesInputComponent": () => (/* binding */ CheckboxesInputComponent)
/* harmony export */ });
/* harmony import */ var _base_component__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ../base.component */ 2844);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/common */ 4364);
/* harmony import */ var _angular_material_checkbox__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/material/checkbox */ 4058);
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/forms */ 1707);





function CheckboxesInputComponent_div_1_Template(rf, ctx) { if (rf & 1) {
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵelementStart"](0, "div");
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵtext"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵelementEnd"]();
} if (rf & 2) {
    const ctx_r0 = _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵnextContext"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵtextInterpolate"](ctx_r0.name);
} }
function CheckboxesInputComponent_div_2_span_2_Template(rf, ctx) { if (rf & 1) {
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵelementStart"](0, "span");
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵtext"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵelementEnd"]();
} if (rf & 2) {
    const i_r3 = _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵnextContext"]().index;
    const ctx_r4 = _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵnextContext"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵtextInterpolate"](ctx_r4.getItem(i_r3));
} }
function CheckboxesInputComponent_div_2_Template(rf, ctx) { if (rf & 1) {
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵelementStart"](0, "div", 3);
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵelement"](1, "mat-checkbox", 4);
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵtemplate"](2, CheckboxesInputComponent_div_2_span_2_Template, 2, 1, "span", 1);
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵelementEnd"]();
} if (rf & 2) {
    const control_r2 = ctx.$implicit;
    const i_r3 = ctx.index;
    const ctx_r1 = _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵnextContext"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵproperty"]("formControl", control_r2);
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵproperty"]("ngIf", !!ctx_r1.getItem(i_r3));
} }
class CheckboxesInputComponent extends _base_component__WEBPACK_IMPORTED_MODULE_0__.BaseComponent {
    constructor() {
        super(...arguments);
        this.name = '';
    }
    getItem(index) {
        return this.items[index];
    }
}
CheckboxesInputComponent.ɵfac = /*@__PURE__*/ function () { let ɵCheckboxesInputComponent_BaseFactory; return function CheckboxesInputComponent_Factory(t) { return (ɵCheckboxesInputComponent_BaseFactory || (ɵCheckboxesInputComponent_BaseFactory = _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵgetInheritedFactory"](CheckboxesInputComponent)))(t || CheckboxesInputComponent); }; }();
CheckboxesInputComponent.ɵcmp = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵdefineComponent"]({ type: CheckboxesInputComponent, selectors: [["gamestore-checkboxes-input"]], inputs: { controls: "controls", items: "items", name: "name" }, features: [_angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵInheritDefinitionFeature"]], decls: 3, vars: 2, consts: [[1, "checkboxes-input-wrapper"], [4, "ngIf"], ["class", "checkbox-container", 4, "ngFor", "ngForOf"], [1, "checkbox-container"], [3, "formControl"]], template: function CheckboxesInputComponent_Template(rf, ctx) { if (rf & 1) {
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵelementStart"](0, "div", 0);
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵtemplate"](1, CheckboxesInputComponent_div_1_Template, 2, 1, "div", 1);
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵtemplate"](2, CheckboxesInputComponent_div_2_Template, 3, 2, "div", 2);
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵelementEnd"]();
    } if (rf & 2) {
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵadvance"](1);
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵproperty"]("ngIf", !!(ctx.name == null ? null : ctx.name.length));
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵadvance"](1);
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵproperty"]("ngForOf", ctx.controls);
    } }, directives: [_angular_common__WEBPACK_IMPORTED_MODULE_2__.NgIf, _angular_common__WEBPACK_IMPORTED_MODULE_2__.NgForOf, _angular_material_checkbox__WEBPACK_IMPORTED_MODULE_3__.MatCheckbox, _angular_forms__WEBPACK_IMPORTED_MODULE_4__.NgControlStatus, _angular_forms__WEBPACK_IMPORTED_MODULE_4__.FormControlDirective], styles: [".checkboxes-input-wrapper[_ngcontent-%COMP%] {\n  padding-top: 5px;\n  padding-bottom: 5px;\n}\n.checkboxes-input-wrapper[_ngcontent-%COMP%]   .checkbox-container[_ngcontent-%COMP%] {\n  margin-bottom: 7px;\n}\n.checkboxes-input-wrapper[_ngcontent-%COMP%]   .checkbox-container[_ngcontent-%COMP%]   span[_ngcontent-%COMP%] {\n  padding-left: 10px;\n  top: 2px;\n  position: relative;\n}\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbImNoZWNrYm94ZXMtaW5wdXQuY29tcG9uZW50LnNjc3MiXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IkFBQUE7RUFDSSxnQkFBQTtFQUNBLG1CQUFBO0FBQ0o7QUFDSTtFQUNJLGtCQUFBO0FBQ1I7QUFDUTtFQUNJLGtCQUFBO0VBQ0EsUUFBQTtFQUNBLGtCQUFBO0FBQ1oiLCJmaWxlIjoiY2hlY2tib3hlcy1pbnB1dC5jb21wb25lbnQuc2NzcyIsInNvdXJjZXNDb250ZW50IjpbIi5jaGVja2JveGVzLWlucHV0LXdyYXBwZXIge1xyXG4gICAgcGFkZGluZy10b3A6IDVweDtcclxuICAgIHBhZGRpbmctYm90dG9tOiA1cHg7XHJcblxyXG4gICAgLmNoZWNrYm94LWNvbnRhaW5lciB7XHJcbiAgICAgICAgbWFyZ2luLWJvdHRvbTogN3B4O1xyXG5cclxuICAgICAgICBzcGFuIHtcclxuICAgICAgICAgICAgcGFkZGluZy1sZWZ0OiAxMHB4O1xyXG4gICAgICAgICAgICB0b3A6IDJweDtcclxuICAgICAgICAgICAgcG9zaXRpb246IHJlbGF0aXZlO1xyXG4gICAgICAgIH1cclxuICAgIH1cclxuXHJcbn0iXX0= */"] });


/***/ }),

/***/ 1951:
/*!********************************************************!*\
  !*** ./src/app/componetns/common-components.module.ts ***!
  \********************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "CommonComponentsModule": () => (/* binding */ CommonComponentsModule)
/* harmony export */ });
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_15__ = __webpack_require__(/*! @angular/common */ 4364);
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_16__ = __webpack_require__(/*! @angular/forms */ 1707);
/* harmony import */ var _app_routing_module__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ../app-routing.module */ 158);
/* harmony import */ var _delete_wrapper_component_delete_wrapper_component__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./delete-wrapper-component/delete-wrapper.component */ 2303);
/* harmony import */ var _form_component_form_component__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./form-component/form.component */ 8205);
/* harmony import */ var _info_component_info_component__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./info-component/info.component */ 4130);
/* harmony import */ var _info_wrapper_component_info_wrapper_component__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ./info-wrapper-component/info-wrapper.component */ 7990);
/* harmony import */ var _list_component_list_component__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ./list-component/list.component */ 9860);
/* harmony import */ var _list_item_component_list_item_component__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ./list-item-component/list-item.component */ 2439);
/* harmony import */ var _text_input_component_text_input_component__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! ./text-input-component/text-input.component */ 2082);
/* harmony import */ var _angular_material_dialog__WEBPACK_IMPORTED_MODULE_17__ = __webpack_require__(/*! @angular/material/dialog */ 2213);
/* harmony import */ var _angular_material_progress_spinner__WEBPACK_IMPORTED_MODULE_18__ = __webpack_require__(/*! @angular/material/progress-spinner */ 181);
/* harmony import */ var _angular_material_button__WEBPACK_IMPORTED_MODULE_19__ = __webpack_require__(/*! @angular/material/button */ 781);
/* harmony import */ var _angular_material_radio__WEBPACK_IMPORTED_MODULE_25__ = __webpack_require__(/*! @angular/material/radio */ 5644);
/* harmony import */ var _loader_component_loader_component__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! ./loader-component/loader.component */ 7001);
/* harmony import */ var _angular_material_input__WEBPACK_IMPORTED_MODULE_20__ = __webpack_require__(/*! @angular/material/input */ 4742);
/* harmony import */ var _angular_material_checkbox__WEBPACK_IMPORTED_MODULE_24__ = __webpack_require__(/*! @angular/material/checkbox */ 4058);
/* harmony import */ var _angular_material_icon__WEBPACK_IMPORTED_MODULE_22__ = __webpack_require__(/*! @angular/material/icon */ 2529);
/* harmony import */ var _angular_material_list__WEBPACK_IMPORTED_MODULE_21__ = __webpack_require__(/*! @angular/material/list */ 8417);
/* harmony import */ var _angular_material_select__WEBPACK_IMPORTED_MODULE_23__ = __webpack_require__(/*! @angular/material/select */ 7007);
/* harmony import */ var _textarea_input_component_textarea_input_component__WEBPACK_IMPORTED_MODULE_9__ = __webpack_require__(/*! ./textarea-input-component/textarea-input.component */ 3281);
/* harmony import */ var _selector_input_component_selector_input_component__WEBPACK_IMPORTED_MODULE_10__ = __webpack_require__(/*! ./selector-input-component/selector-input.component */ 9260);
/* harmony import */ var _checkboxes_input_component_checkboxes_input_component__WEBPACK_IMPORTED_MODULE_11__ = __webpack_require__(/*! ./checkboxes-input-component/checkboxes-input.component */ 5583);
/* harmony import */ var _number_input_component_number_input_component__WEBPACK_IMPORTED_MODULE_12__ = __webpack_require__(/*! ./number-input-component/number-input.component */ 9567);
/* harmony import */ var _radio_input_component_radio_input_component__WEBPACK_IMPORTED_MODULE_13__ = __webpack_require__(/*! ./radio-input-component/radio-input.component */ 5962);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_14__ = __webpack_require__(/*! @angular/core */ 2316);


























class CommonComponentsModule {
}
CommonComponentsModule.ɵfac = function CommonComponentsModule_Factory(t) { return new (t || CommonComponentsModule)(); };
CommonComponentsModule.ɵmod = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_14__["ɵɵdefineNgModule"]({ type: CommonComponentsModule });
CommonComponentsModule.ɵinj = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_14__["ɵɵdefineInjector"]({ imports: [[
            _angular_common__WEBPACK_IMPORTED_MODULE_15__.CommonModule,
            _app_routing_module__WEBPACK_IMPORTED_MODULE_0__.AppRoutingModule,
            _angular_forms__WEBPACK_IMPORTED_MODULE_16__.ReactiveFormsModule,
            _angular_material_dialog__WEBPACK_IMPORTED_MODULE_17__.MatDialogModule,
            _angular_material_progress_spinner__WEBPACK_IMPORTED_MODULE_18__.MatProgressSpinnerModule,
            _angular_material_button__WEBPACK_IMPORTED_MODULE_19__.MatButtonModule,
            _angular_material_input__WEBPACK_IMPORTED_MODULE_20__.MatInputModule,
            _angular_material_list__WEBPACK_IMPORTED_MODULE_21__.MatListModule,
            _angular_material_icon__WEBPACK_IMPORTED_MODULE_22__.MatIconModule,
            _angular_material_select__WEBPACK_IMPORTED_MODULE_23__.MatSelectModule,
            _angular_material_checkbox__WEBPACK_IMPORTED_MODULE_24__.MatCheckboxModule,
            _angular_material_radio__WEBPACK_IMPORTED_MODULE_25__.MatRadioModule
        ]] });
(function () { (typeof ngJitMode === "undefined" || ngJitMode) && _angular_core__WEBPACK_IMPORTED_MODULE_14__["ɵɵsetNgModuleScope"](CommonComponentsModule, { declarations: [_list_item_component_list_item_component__WEBPACK_IMPORTED_MODULE_6__.ListItemComponent,
        _list_component_list_component__WEBPACK_IMPORTED_MODULE_5__.ListComponent,
        _info_wrapper_component_info_wrapper_component__WEBPACK_IMPORTED_MODULE_4__.InfoWrapperComponent,
        _info_component_info_component__WEBPACK_IMPORTED_MODULE_3__.InfoComponent,
        _form_component_form_component__WEBPACK_IMPORTED_MODULE_2__.FormComponent,
        _text_input_component_text_input_component__WEBPACK_IMPORTED_MODULE_7__.TextInputComponent,
        _delete_wrapper_component_delete_wrapper_component__WEBPACK_IMPORTED_MODULE_1__.DeleteWrapperComponent,
        _loader_component_loader_component__WEBPACK_IMPORTED_MODULE_8__.LoaderComponent,
        _textarea_input_component_textarea_input_component__WEBPACK_IMPORTED_MODULE_9__.TextareaInputComponent,
        _selector_input_component_selector_input_component__WEBPACK_IMPORTED_MODULE_10__.SelectorInputComponent,
        _checkboxes_input_component_checkboxes_input_component__WEBPACK_IMPORTED_MODULE_11__.CheckboxesInputComponent,
        _number_input_component_number_input_component__WEBPACK_IMPORTED_MODULE_12__.NumberInputComponent,
        _radio_input_component_radio_input_component__WEBPACK_IMPORTED_MODULE_13__.RadioInputComponent], imports: [_angular_common__WEBPACK_IMPORTED_MODULE_15__.CommonModule,
        _app_routing_module__WEBPACK_IMPORTED_MODULE_0__.AppRoutingModule,
        _angular_forms__WEBPACK_IMPORTED_MODULE_16__.ReactiveFormsModule,
        _angular_material_dialog__WEBPACK_IMPORTED_MODULE_17__.MatDialogModule,
        _angular_material_progress_spinner__WEBPACK_IMPORTED_MODULE_18__.MatProgressSpinnerModule,
        _angular_material_button__WEBPACK_IMPORTED_MODULE_19__.MatButtonModule,
        _angular_material_input__WEBPACK_IMPORTED_MODULE_20__.MatInputModule,
        _angular_material_list__WEBPACK_IMPORTED_MODULE_21__.MatListModule,
        _angular_material_icon__WEBPACK_IMPORTED_MODULE_22__.MatIconModule,
        _angular_material_select__WEBPACK_IMPORTED_MODULE_23__.MatSelectModule,
        _angular_material_checkbox__WEBPACK_IMPORTED_MODULE_24__.MatCheckboxModule,
        _angular_material_radio__WEBPACK_IMPORTED_MODULE_25__.MatRadioModule], exports: [_list_item_component_list_item_component__WEBPACK_IMPORTED_MODULE_6__.ListItemComponent,
        _list_component_list_component__WEBPACK_IMPORTED_MODULE_5__.ListComponent,
        _info_wrapper_component_info_wrapper_component__WEBPACK_IMPORTED_MODULE_4__.InfoWrapperComponent,
        _info_component_info_component__WEBPACK_IMPORTED_MODULE_3__.InfoComponent,
        _form_component_form_component__WEBPACK_IMPORTED_MODULE_2__.FormComponent,
        _text_input_component_text_input_component__WEBPACK_IMPORTED_MODULE_7__.TextInputComponent,
        _textarea_input_component_textarea_input_component__WEBPACK_IMPORTED_MODULE_9__.TextareaInputComponent,
        _delete_wrapper_component_delete_wrapper_component__WEBPACK_IMPORTED_MODULE_1__.DeleteWrapperComponent,
        _selector_input_component_selector_input_component__WEBPACK_IMPORTED_MODULE_10__.SelectorInputComponent,
        _checkboxes_input_component_checkboxes_input_component__WEBPACK_IMPORTED_MODULE_11__.CheckboxesInputComponent,
        _number_input_component_number_input_component__WEBPACK_IMPORTED_MODULE_12__.NumberInputComponent,
        _radio_input_component_radio_input_component__WEBPACK_IMPORTED_MODULE_13__.RadioInputComponent] }); })();


/***/ }),

/***/ 2303:
/*!*********************************************************************************!*\
  !*** ./src/app/componetns/delete-wrapper-component/delete-wrapper.component.ts ***!
  \*********************************************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "DeleteWrapperComponent": () => (/* binding */ DeleteWrapperComponent)
/* harmony export */ });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var _base_component__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ../base.component */ 2844);
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/common */ 4364);
/* harmony import */ var _angular_material_button__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/material/button */ 781);
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/router */ 1258);






function DeleteWrapperComponent_h3_3_Template(rf, ctx) { if (rf & 1) {
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵelementStart"](0, "h3");
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵtext"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵelementEnd"]();
} if (rf & 2) {
    const ctx_r0 = _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵnextContext"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵtextInterpolate"](ctx_r0.name);
} }
function DeleteWrapperComponent_h3_4_Template(rf, ctx) { if (rf & 1) {
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵelementStart"](0, "h3");
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵelementStart"](1, "a", 2);
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵtext"](2);
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵelementEnd"]();
} if (rf & 2) {
    const ctx_r1 = _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵnextContext"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵpropertyInterpolate"]("routerLink", ctx_r1.pageLink);
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵtextInterpolate"](ctx_r1.name);
} }
const _c0 = ["*"];
class DeleteWrapperComponent extends _base_component__WEBPACK_IMPORTED_MODULE_0__.BaseComponent {
    constructor() {
        super(...arguments);
        this.delete = new _angular_core__WEBPACK_IMPORTED_MODULE_1__.EventEmitter();
    }
}
DeleteWrapperComponent.ɵfac = /*@__PURE__*/ function () { let ɵDeleteWrapperComponent_BaseFactory; return function DeleteWrapperComponent_Factory(t) { return (ɵDeleteWrapperComponent_BaseFactory || (ɵDeleteWrapperComponent_BaseFactory = _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵgetInheritedFactory"](DeleteWrapperComponent)))(t || DeleteWrapperComponent); }; }();
DeleteWrapperComponent.ɵcmp = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵdefineComponent"]({ type: DeleteWrapperComponent, selectors: [["gamestore-delete-wrapper"]], inputs: { name: "name", pageLink: "pageLink" }, outputs: { delete: "delete" }, features: [_angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵInheritDefinitionFeature"]], ngContentSelectors: _c0, decls: 10, vars: 4, consts: [[4, "ngIf"], ["mat-raised-button", "", "color", "warn", 3, "click"], ["mat-button", "", 3, "routerLink"]], template: function DeleteWrapperComponent_Template(rf, ctx) { if (rf & 1) {
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵprojectionDef"]();
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵelementStart"](0, "article");
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵelementStart"](1, "p");
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵtext"](2);
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵelementEnd"]();
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵtemplate"](3, DeleteWrapperComponent_h3_3_Template, 2, 1, "h3", 0);
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵtemplate"](4, DeleteWrapperComponent_h3_4_Template, 3, 2, "h3", 0);
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵelementStart"](5, "div");
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵprojection"](6);
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵelementEnd"]();
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵelementStart"](7, "div");
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵelementStart"](8, "button", 1);
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵlistener"]("click", function DeleteWrapperComponent_Template_button_click_8_listener() { return ctx.delete.emit(); });
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵtext"](9);
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵelementEnd"]();
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵelementEnd"]();
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵelementEnd"]();
    } if (rf & 2) {
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵadvance"](2);
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵtextInterpolate"](ctx.labels.deleteMessage);
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵadvance"](1);
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵproperty"]("ngIf", !(ctx.pageLink == null ? null : ctx.pageLink.length));
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵadvance"](1);
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵproperty"]("ngIf", !!(ctx.pageLink == null ? null : ctx.pageLink.length));
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵadvance"](5);
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵtextInterpolate1"](" ", ctx.labels.deleteButtonLabel, " ");
    } }, directives: [_angular_common__WEBPACK_IMPORTED_MODULE_2__.NgIf, _angular_material_button__WEBPACK_IMPORTED_MODULE_3__.MatButton, _angular_material_button__WEBPACK_IMPORTED_MODULE_3__.MatAnchor, _angular_router__WEBPACK_IMPORTED_MODULE_4__.RouterLinkWithHref], styles: ["h3[_ngcontent-%COMP%] {\n  font-weight: 500;\n}\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbImRlbGV0ZS13cmFwcGVyLmNvbXBvbmVudC5zY3NzIl0sIm5hbWVzIjpbXSwibWFwcGluZ3MiOiJBQUFBO0VBQ0ksZ0JBQUE7QUFDSiIsImZpbGUiOiJkZWxldGUtd3JhcHBlci5jb21wb25lbnQuc2NzcyIsInNvdXJjZXNDb250ZW50IjpbImgze1xyXG4gICAgZm9udC13ZWlnaHQ6IDUwMDtcclxufSJdfQ== */"] });


/***/ }),

/***/ 8205:
/*!*************************************************************!*\
  !*** ./src/app/componetns/form-component/form.component.ts ***!
  \*************************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "FormComponent": () => (/* binding */ FormComponent)
/* harmony export */ });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var _base_component__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ../base.component */ 2844);
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/forms */ 1707);
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/common */ 4364);
/* harmony import */ var _angular_material_button__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/material/button */ 781);
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/router */ 1258);







function FormComponent_input_1_Template(rf, ctx) { if (rf & 1) {
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵelement"](0, "input", 5);
} if (rf & 2) {
    const ctx_r0 = _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵnextContext"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵpropertyInterpolate"]("formControlName", ctx_r0.idName);
} }
function FormComponent_a_7_Template(rf, ctx) { if (rf & 1) {
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵelementStart"](0, "a", 6);
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵtext"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵelementEnd"]();
} if (rf & 2) {
    const ctx_r1 = _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵnextContext"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵpropertyInterpolate"]("routerLink", ctx_r1.pageLink);
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵtextInterpolate1"](" ", ctx_r1.labels.toPageLabel, " ");
} }
const _c0 = ["*"];
class FormComponent extends _base_component__WEBPACK_IMPORTED_MODULE_0__.BaseComponent {
    constructor() {
        super(...arguments);
        this.save = new _angular_core__WEBPACK_IMPORTED_MODULE_1__.EventEmitter();
    }
}
FormComponent.ɵfac = /*@__PURE__*/ function () { let ɵFormComponent_BaseFactory; return function FormComponent_Factory(t) { return (ɵFormComponent_BaseFactory || (ɵFormComponent_BaseFactory = _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵgetInheritedFactory"](FormComponent)))(t || FormComponent); }; }();
FormComponent.ɵcmp = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵdefineComponent"]({ type: FormComponent, selectors: [["gamestore-form"]], inputs: { idName: "idName", pageLink: "pageLink", form: "form" }, outputs: { save: "save" }, features: [_angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵInheritDefinitionFeature"]], ngContentSelectors: _c0, decls: 8, vars: 5, consts: [[3, "formGroup"], ["type", "hidden", 3, "formControlName", 4, "ngIf"], [1, "buttons-container"], ["type", "button", "mat-raised-button", "", "color", "primary", 3, "disabled", "click"], ["mat-button", "", 3, "routerLink", 4, "ngIf"], ["type", "hidden", 3, "formControlName"], ["mat-button", "", 3, "routerLink"]], template: function FormComponent_Template(rf, ctx) { if (rf & 1) {
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵprojectionDef"]();
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵelementStart"](0, "form", 0);
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵtemplate"](1, FormComponent_input_1_Template, 1, 1, "input", 1);
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵelementStart"](2, "div");
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵprojection"](3);
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵelementEnd"]();
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵelementStart"](4, "div", 2);
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵelementStart"](5, "button", 3);
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵlistener"]("click", function FormComponent_Template_button_click_5_listener() { return ctx.save.emit(); });
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵtext"](6);
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵelementEnd"]();
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵtemplate"](7, FormComponent_a_7_Template, 2, 2, "a", 4);
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵelementEnd"]();
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵelementEnd"]();
    } if (rf & 2) {
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵproperty"]("formGroup", ctx.form);
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵadvance"](1);
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵproperty"]("ngIf", !!(ctx.idName == null ? null : ctx.idName.length));
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵadvance"](4);
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵproperty"]("disabled", ctx.form.invalid);
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵadvance"](1);
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵtextInterpolate1"](" ", ctx.labels.saveButtonLabel, " ");
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵadvance"](1);
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵproperty"]("ngIf", !!(ctx.pageLink == null ? null : ctx.pageLink.length));
    } }, directives: [_angular_forms__WEBPACK_IMPORTED_MODULE_2__["ɵNgNoValidate"], _angular_forms__WEBPACK_IMPORTED_MODULE_2__.NgControlStatusGroup, _angular_forms__WEBPACK_IMPORTED_MODULE_2__.FormGroupDirective, _angular_common__WEBPACK_IMPORTED_MODULE_3__.NgIf, _angular_material_button__WEBPACK_IMPORTED_MODULE_4__.MatButton, _angular_forms__WEBPACK_IMPORTED_MODULE_2__.DefaultValueAccessor, _angular_forms__WEBPACK_IMPORTED_MODULE_2__.NgControlStatus, _angular_forms__WEBPACK_IMPORTED_MODULE_2__.FormControlName, _angular_material_button__WEBPACK_IMPORTED_MODULE_4__.MatAnchor, _angular_router__WEBPACK_IMPORTED_MODULE_5__.RouterLinkWithHref], styles: [".buttons-container[_ngcontent-%COMP%] {\n  margin-top: 15px;\n}\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbImZvcm0uY29tcG9uZW50LnNjc3MiXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IkFBQUE7RUFDSSxnQkFBQTtBQUNKIiwiZmlsZSI6ImZvcm0uY29tcG9uZW50LnNjc3MiLCJzb3VyY2VzQ29udGVudCI6WyIuYnV0dG9ucy1jb250YWluZXJ7XHJcbiAgICBtYXJnaW4tdG9wOiAxNXB4O1xyXG59Il19 */"] });


/***/ }),

/***/ 2058:
/*!*****************************************************************!*\
  !*** ./src/app/componetns/header-component/header.component.ts ***!
  \*****************************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "HeaderComponent": () => (/* binding */ HeaderComponent)
/* harmony export */ });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! tslib */ 3786);
/* harmony import */ var _ngneat_until_destroy__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @ngneat/until-destroy */ 9758);
/* harmony import */ var src_app_configuration_shared_info__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! src/app/configuration/shared-info */ 2614);
/* harmony import */ var _base_component__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../base.component */ 2844);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/router */ 1258);
/* harmony import */ var _angular_material_button__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/material/button */ 781);
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! @angular/common */ 4364);








function HeaderComponent_span_4_Template(rf, ctx) { if (rf & 1) {
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](0, "span");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtext"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
} if (rf & 2) {
    const ctx_r0 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵnextContext"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtextInterpolate2"]("", ctx_r0.labels.totalGamesLabel, ": ", ctx_r0.gameCount, "");
} }
let HeaderComponent = class HeaderComponent extends _base_component__WEBPACK_IMPORTED_MODULE_1__.BaseComponent {
    constructor() {
        super(...arguments);
        this.gameCount = null;
    }
    ngOnInit() {
        src_app_configuration_shared_info__WEBPACK_IMPORTED_MODULE_0__.gameCountSubject.pipe((0,_ngneat_until_destroy__WEBPACK_IMPORTED_MODULE_3__.untilDestroyed)(this))
            .subscribe((x) => (this.gameCount = x));
    }
};
HeaderComponent.ɵfac = /*@__PURE__*/ function () { let ɵHeaderComponent_BaseFactory; return function HeaderComponent_Factory(t) { return (ɵHeaderComponent_BaseFactory || (ɵHeaderComponent_BaseFactory = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵgetInheritedFactory"](HeaderComponent)))(t || HeaderComponent); }; }();
HeaderComponent.ɵcmp = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵdefineComponent"]({ type: HeaderComponent, selectors: [["gamestore-header"]], features: [_angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵInheritDefinitionFeature"]], decls: 7, vars: 3, consts: [["routerLink", "", "mat-button", "", 1, "logo"], [1, "header-right"], [4, "ngIf"], ["mat-button", "", 1, "basket", 3, "routerLink"]], template: function HeaderComponent_Template(rf, ctx) { if (rf & 1) {
        _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](0, "header");
        _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](1, "a", 0);
        _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtext"](2, "GameStore");
        _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
        _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](3, "div", 1);
        _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtemplate"](4, HeaderComponent_span_4_Template, 2, 2, "span", 2);
        _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](5, "a", 3);
        _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtext"](6);
        _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
        _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
        _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
    } if (rf & 2) {
        _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](4);
        _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵproperty"]("ngIf", !!(ctx.gameCount == null ? null : ctx.gameCount.length));
        _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](1);
        _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵpropertyInterpolate"]("routerLink", ctx.links.get(ctx.pageRoutes.Basket));
        _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](1);
        _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtextInterpolate"](ctx.labels.basketMenuItem);
    } }, directives: [_angular_router__WEBPACK_IMPORTED_MODULE_4__.RouterLinkWithHref, _angular_material_button__WEBPACK_IMPORTED_MODULE_5__.MatAnchor, _angular_common__WEBPACK_IMPORTED_MODULE_6__.NgIf], styles: ["header[_ngcontent-%COMP%] {\n  padding: 15px 25px;\n  box-sizing: border-box;\n  position: relative;\n}\nheader[_ngcontent-%COMP%]   .logo[_ngcontent-%COMP%] {\n  font-size: 30px;\n}\nheader[_ngcontent-%COMP%]   .header-right[_ngcontent-%COMP%] {\n  display: inline;\n  position: absolute;\n  right: 30px;\n  top: 25%;\n}\nheader[_ngcontent-%COMP%]   .header-right[_ngcontent-%COMP%]   .basket[_ngcontent-%COMP%] {\n  position: relative;\n  font-size: 22px;\n  margin-left: 15px;\n}\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbImhlYWRlci5jb21wb25lbnQuc2NzcyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiQUFBQTtFQUNJLGtCQUFBO0VBQ0Esc0JBQUE7RUFDQSxrQkFBQTtBQUNKO0FBQ0k7RUFDSSxlQUFBO0FBQ1I7QUFFSTtFQUNJLGVBQUE7RUFDQSxrQkFBQTtFQUNBLFdBQUE7RUFDQSxRQUFBO0FBQVI7QUFFUTtFQUNJLGtCQUFBO0VBQ0EsZUFBQTtFQUNBLGlCQUFBO0FBQVoiLCJmaWxlIjoiaGVhZGVyLmNvbXBvbmVudC5zY3NzIiwic291cmNlc0NvbnRlbnQiOlsiaGVhZGVyIHtcclxuICAgIHBhZGRpbmc6IDE1cHggMjVweDtcclxuICAgIGJveC1zaXppbmc6IGJvcmRlci1ib3g7XHJcbiAgICBwb3NpdGlvbjogcmVsYXRpdmU7XHJcblxyXG4gICAgLmxvZ28ge1xyXG4gICAgICAgIGZvbnQtc2l6ZTogMzBweDtcclxuICAgIH1cclxuXHJcbiAgICAuaGVhZGVyLXJpZ2h0IHtcclxuICAgICAgICBkaXNwbGF5OiBpbmxpbmU7XHJcbiAgICAgICAgcG9zaXRpb246IGFic29sdXRlO1xyXG4gICAgICAgIHJpZ2h0OiAzMHB4O1xyXG4gICAgICAgIHRvcDogMjUlO1xyXG4gICAgICAgIFxyXG4gICAgICAgIC5iYXNrZXQge1xyXG4gICAgICAgICAgICBwb3NpdGlvbjogcmVsYXRpdmU7XHJcbiAgICAgICAgICAgIGZvbnQtc2l6ZTogMjJweDtcclxuICAgICAgICAgICAgbWFyZ2luLWxlZnQ6IDE1cHg7XHJcbiAgICAgICAgfVxyXG4gICAgfVxyXG59Il19 */"] });
HeaderComponent = (0,tslib__WEBPACK_IMPORTED_MODULE_7__.__decorate)([
    (0,_ngneat_until_destroy__WEBPACK_IMPORTED_MODULE_3__.UntilDestroy)()
], HeaderComponent);



/***/ }),

/***/ 4130:
/*!*************************************************************!*\
  !*** ./src/app/componetns/info-component/info.component.ts ***!
  \*************************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "InfoComponent": () => (/* binding */ InfoComponent)
/* harmony export */ });
/* harmony import */ var _base_component__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ../base.component */ 2844);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/common */ 4364);
/* harmony import */ var _angular_material_button__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/material/button */ 781);
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/router */ 1258);
/* harmony import */ var _list_component_list_component__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../list-component/list.component */ 9860);






function InfoComponent_ng_container_2_a_4_Template(rf, ctx) { if (rf & 1) {
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](0, "a", 4);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtext"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
} if (rf & 2) {
    const info_r1 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵnextContext"]().$implicit;
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵpropertyInterpolate"]("routerLink", info_r1.pageLink);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtextInterpolate1"](" ", info_r1.value, " ");
} }
function InfoComponent_ng_container_2_span_5_Template(rf, ctx) { if (rf & 1) {
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](0, "span");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtext"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
} if (rf & 2) {
    const info_r1 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵnextContext"]().$implicit;
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtextInterpolate1"](" ", info_r1.value, " ");
} }
function InfoComponent_ng_container_2_gamestore_list_6_Template(rf, ctx) { if (rf & 1) {
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelement"](0, "gamestore-list", 5);
} if (rf & 2) {
    const info_r1 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵnextContext"]().$implicit;
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵproperty"]("listItems", info_r1.nestedValues);
} }
function InfoComponent_ng_container_2_Template(rf, ctx) { if (rf & 1) {
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementContainerStart"](0);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](1, "dt");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtext"](2);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](3, "dd");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtemplate"](4, InfoComponent_ng_container_2_a_4_Template, 2, 2, "a", 1);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtemplate"](5, InfoComponent_ng_container_2_span_5_Template, 2, 1, "span", 2);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtemplate"](6, InfoComponent_ng_container_2_gamestore_list_6_Template, 1, 1, "gamestore-list", 3);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementContainerEnd"]();
} if (rf & 2) {
    const info_r1 = ctx.$implicit;
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](2);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtextInterpolate"](info_r1.name);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](2);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵproperty"]("ngIf", !!(info_r1.pageLink == null ? null : info_r1.pageLink.length));
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵproperty"]("ngIf", !(info_r1.pageLink == null ? null : info_r1.pageLink.length));
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵproperty"]("ngIf", !!(info_r1 == null ? null : info_r1.nestedValues == null ? null : info_r1.nestedValues.length));
} }
class InfoComponent extends _base_component__WEBPACK_IMPORTED_MODULE_0__.BaseComponent {
    constructor() {
        super(...arguments);
        this.infoList = [];
    }
}
InfoComponent.ɵfac = /*@__PURE__*/ function () { let ɵInfoComponent_BaseFactory; return function InfoComponent_Factory(t) { return (ɵInfoComponent_BaseFactory || (ɵInfoComponent_BaseFactory = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵgetInheritedFactory"](InfoComponent)))(t || InfoComponent); }; }();
InfoComponent.ɵcmp = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵdefineComponent"]({ type: InfoComponent, selectors: [["gamestore-info"]], inputs: { infoList: "infoList" }, features: [_angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵInheritDefinitionFeature"]], decls: 3, vars: 1, consts: [[4, "ngFor", "ngForOf"], ["mat-button", "", 3, "routerLink", 4, "ngIf"], [4, "ngIf"], [3, "listItems", 4, "ngIf"], ["mat-button", "", 3, "routerLink"], [3, "listItems"]], template: function InfoComponent_Template(rf, ctx) { if (rf & 1) {
        _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](0, "div");
        _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](1, "dl");
        _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtemplate"](2, InfoComponent_ng_container_2_Template, 7, 4, "ng-container", 0);
        _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
        _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
    } if (rf & 2) {
        _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](2);
        _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵproperty"]("ngForOf", ctx.infoList);
    } }, directives: [_angular_common__WEBPACK_IMPORTED_MODULE_3__.NgForOf, _angular_common__WEBPACK_IMPORTED_MODULE_3__.NgIf, _angular_material_button__WEBPACK_IMPORTED_MODULE_4__.MatAnchor, _angular_router__WEBPACK_IMPORTED_MODULE_5__.RouterLinkWithHref, _list_component_list_component__WEBPACK_IMPORTED_MODULE_1__.ListComponent], styles: ["dl[_ngcontent-%COMP%]   dt[_ngcontent-%COMP%] {\n  font-size: 15px;\n  font-weight: 500;\n  margin-top: 5px;\n  margin-bottom: 3px;\n}\ndl[_ngcontent-%COMP%]   dd[_ngcontent-%COMP%] {\n  padding-left: 15px;\n  margin-bottom: 5px;\n  box-sizing: border-box;\n}\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbImluZm8uY29tcG9uZW50LnNjc3MiXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IkFBQ0k7RUFDSSxlQUFBO0VBQ0EsZ0JBQUE7RUFDQSxlQUFBO0VBQ0Esa0JBQUE7QUFBUjtBQUdJO0VBQ0ksa0JBQUE7RUFDQSxrQkFBQTtFQUNBLHNCQUFBO0FBRFIiLCJmaWxlIjoiaW5mby5jb21wb25lbnQuc2NzcyIsInNvdXJjZXNDb250ZW50IjpbImRse1xyXG4gICAgZHR7XHJcbiAgICAgICAgZm9udC1zaXplOiAxNXB4O1xyXG4gICAgICAgIGZvbnQtd2VpZ2h0OiA1MDA7XHJcbiAgICAgICAgbWFyZ2luLXRvcDogNXB4O1xyXG4gICAgICAgIG1hcmdpbi1ib3R0b206IDNweDtcclxuICAgIH1cclxuICAgIFxyXG4gICAgZGQge1xyXG4gICAgICAgIHBhZGRpbmctbGVmdDogMTVweDtcclxuICAgICAgICBtYXJnaW4tYm90dG9tOiA1cHg7XHJcbiAgICAgICAgYm94LXNpemluZzogYm9yZGVyLWJveDtcclxuICAgIH1cclxufSJdfQ== */"] });


/***/ }),

/***/ 7990:
/*!*****************************************************************************!*\
  !*** ./src/app/componetns/info-wrapper-component/info-wrapper.component.ts ***!
  \*****************************************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "InfoWrapperComponent": () => (/* binding */ InfoWrapperComponent)
/* harmony export */ });
/* harmony import */ var _base_component__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ../base.component */ 2844);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/common */ 4364);
/* harmony import */ var _angular_material_button__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/material/button */ 781);
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/router */ 1258);





function InfoWrapperComponent_div_1_a_1_Template(rf, ctx) { if (rf & 1) {
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵelementStart"](0, "a", 4);
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵtext"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵelementEnd"]();
} if (rf & 2) {
    const ctx_r1 = _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵnextContext"](2);
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵpropertyInterpolate"]("routerLink", ctx_r1.addLink);
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵtextInterpolate"](ctx_r1.labels.addNewButtonLabel);
} }
function InfoWrapperComponent_div_1_a_2_Template(rf, ctx) { if (rf & 1) {
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵelementStart"](0, "a", 4);
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵtext"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵelementEnd"]();
} if (rf & 2) {
    const ctx_r2 = _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵnextContext"](2);
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵpropertyInterpolate"]("routerLink", ctx_r2.deleteLink);
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵtextInterpolate"](ctx_r2.labels.deleteButtonLabel);
} }
function InfoWrapperComponent_div_1_a_3_Template(rf, ctx) { if (rf & 1) {
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵelementStart"](0, "a", 4);
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵtext"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵelementEnd"]();
} if (rf & 2) {
    const ctx_r3 = _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵnextContext"](2);
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵpropertyInterpolate"]("routerLink", ctx_r3.updateLink);
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵtextInterpolate"](ctx_r3.labels.updateButtonLabel);
} }
function InfoWrapperComponent_div_1_Template(rf, ctx) { if (rf & 1) {
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵelementStart"](0, "div", 2);
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵtemplate"](1, InfoWrapperComponent_div_1_a_1_Template, 2, 2, "a", 3);
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵtemplate"](2, InfoWrapperComponent_div_1_a_2_Template, 2, 2, "a", 3);
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵtemplate"](3, InfoWrapperComponent_div_1_a_3_Template, 2, 2, "a", 3);
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵelementEnd"]();
} if (rf & 2) {
    const ctx_r0 = _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵnextContext"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵproperty"]("ngIf", !!(ctx_r0.addLink == null ? null : ctx_r0.addLink.length));
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵproperty"]("ngIf", !!(ctx_r0.deleteLink == null ? null : ctx_r0.deleteLink.length));
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵproperty"]("ngIf", !!(ctx_r0.updateLink == null ? null : ctx_r0.updateLink.length));
} }
const _c0 = ["*"];
class InfoWrapperComponent extends _base_component__WEBPACK_IMPORTED_MODULE_0__.BaseComponent {
}
InfoWrapperComponent.ɵfac = /*@__PURE__*/ function () { let ɵInfoWrapperComponent_BaseFactory; return function InfoWrapperComponent_Factory(t) { return (ɵInfoWrapperComponent_BaseFactory || (ɵInfoWrapperComponent_BaseFactory = _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵgetInheritedFactory"](InfoWrapperComponent)))(t || InfoWrapperComponent); }; }();
InfoWrapperComponent.ɵcmp = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵdefineComponent"]({ type: InfoWrapperComponent, selectors: [["gamestore-info-wrapper"]], inputs: { addLink: "addLink", deleteLink: "deleteLink", updateLink: "updateLink" }, features: [_angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵInheritDefinitionFeature"]], ngContentSelectors: _c0, decls: 4, vars: 1, consts: [[1, "info-container"], ["class", "controls-container", 4, "ngIf"], [1, "controls-container"], ["mat-stroked-button", "", "color", "accent", 3, "routerLink", 4, "ngIf"], ["mat-stroked-button", "", "color", "accent", 3, "routerLink"]], template: function InfoWrapperComponent_Template(rf, ctx) { if (rf & 1) {
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵprojectionDef"]();
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵelementStart"](0, "article", 0);
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵtemplate"](1, InfoWrapperComponent_div_1_Template, 4, 3, "div", 1);
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵelementStart"](2, "div");
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵprojection"](3);
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵelementEnd"]();
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵelementEnd"]();
    } if (rf & 2) {
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵadvance"](1);
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵproperty"]("ngIf", !!(ctx.addLink == null ? null : ctx.addLink.length) || !!(ctx.deleteLink == null ? null : ctx.deleteLink.length) || !!(ctx.updateLink == null ? null : ctx.updateLink.length));
    } }, directives: [_angular_common__WEBPACK_IMPORTED_MODULE_2__.NgIf, _angular_material_button__WEBPACK_IMPORTED_MODULE_3__.MatAnchor, _angular_router__WEBPACK_IMPORTED_MODULE_4__.RouterLinkWithHref], styles: [".info-container[_ngcontent-%COMP%] {\n  margin-bottom: 20px;\n}\n.info-container[_ngcontent-%COMP%]   .controls-container[_ngcontent-%COMP%] {\n  margin-bottom: 20px;\n}\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbImluZm8td3JhcHBlci5jb21wb25lbnQuc2NzcyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiQUFBQTtFQUNJLG1CQUFBO0FBQ0o7QUFBSTtFQUNJLG1CQUFBO0FBRVIiLCJmaWxlIjoiaW5mby13cmFwcGVyLmNvbXBvbmVudC5zY3NzIiwic291cmNlc0NvbnRlbnQiOlsiLmluZm8tY29udGFpbmVyIHtcclxuICAgIG1hcmdpbi1ib3R0b206IDIwcHg7XHJcbiAgICAuY29udHJvbHMtY29udGFpbmVyIHtcclxuICAgICAgICBtYXJnaW4tYm90dG9tOiAyMHB4O1xyXG4gICAgfVxyXG59Il19 */"] });


/***/ }),

/***/ 9860:
/*!*************************************************************!*\
  !*** ./src/app/componetns/list-component/list.component.ts ***!
  \*************************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "ListComponent": () => (/* binding */ ListComponent)
/* harmony export */ });
/* harmony import */ var _base_component__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ../base.component */ 2844);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/common */ 4364);
/* harmony import */ var _angular_material_list__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/material/list */ 8417);
/* harmony import */ var _angular_material_button__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/material/button */ 781);
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! @angular/router */ 1258);
/* harmony import */ var _list_item_component_list_item_component__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../list-item-component/list-item.component */ 2439);







function ListComponent_div_1_Template(rf, ctx) { if (rf & 1) {
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](0, "div", 2);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](1, "a", 3);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtext"](2);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
} if (rf & 2) {
    const ctx_r0 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵnextContext"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵpropertyInterpolate"]("routerLink", ctx_r0.addLink);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtextInterpolate"](ctx_r0.labels.addNewButtonLabel);
} }
function ListComponent_gamestore_list_item_3_Template(rf, ctx) { if (rf & 1) {
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelement"](0, "gamestore-list-item", 4);
} if (rf & 2) {
    const item_r2 = ctx.$implicit;
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵproperty"]("item", item_r2);
} }
class ListComponent extends _base_component__WEBPACK_IMPORTED_MODULE_0__.BaseComponent {
    constructor() {
        super(...arguments);
        this.listItems = [];
    }
}
ListComponent.ɵfac = /*@__PURE__*/ function () { let ɵListComponent_BaseFactory; return function ListComponent_Factory(t) { return (ɵListComponent_BaseFactory || (ɵListComponent_BaseFactory = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵgetInheritedFactory"](ListComponent)))(t || ListComponent); }; }();
ListComponent.ɵcmp = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵdefineComponent"]({ type: ListComponent, selectors: [["gamestore-list"]], inputs: { addLink: "addLink", listItems: "listItems" }, features: [_angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵInheritDefinitionFeature"]], decls: 4, vars: 2, consts: [["class", "add-container", 4, "ngIf"], [3, "item", 4, "ngFor", "ngForOf"], [1, "add-container"], ["mat-stroked-button", "", "color", "accent", 3, "routerLink"], [3, "item"]], template: function ListComponent_Template(rf, ctx) { if (rf & 1) {
        _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](0, "div");
        _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtemplate"](1, ListComponent_div_1_Template, 3, 2, "div", 0);
        _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](2, "mat-list");
        _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtemplate"](3, ListComponent_gamestore_list_item_3_Template, 1, 1, "gamestore-list-item", 1);
        _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
        _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
    } if (rf & 2) {
        _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](1);
        _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵproperty"]("ngIf", !!(ctx.addLink == null ? null : ctx.addLink.length));
        _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](2);
        _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵproperty"]("ngForOf", ctx.listItems);
    } }, directives: [_angular_common__WEBPACK_IMPORTED_MODULE_3__.NgIf, _angular_material_list__WEBPACK_IMPORTED_MODULE_4__.MatList, _angular_common__WEBPACK_IMPORTED_MODULE_3__.NgForOf, _angular_material_button__WEBPACK_IMPORTED_MODULE_5__.MatAnchor, _angular_router__WEBPACK_IMPORTED_MODULE_6__.RouterLinkWithHref, _list_item_component_list_item_component__WEBPACK_IMPORTED_MODULE_1__.ListItemComponent], styles: [".add-container[_ngcontent-%COMP%] {\n  margin-bottom: 10px;\n}\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbImxpc3QuY29tcG9uZW50LnNjc3MiXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IkFBQUE7RUFDSSxtQkFBQTtBQUNKIiwiZmlsZSI6Imxpc3QuY29tcG9uZW50LnNjc3MiLCJzb3VyY2VzQ29udGVudCI6WyIuYWRkLWNvbnRhaW5lciB7XHJcbiAgICBtYXJnaW4tYm90dG9tOiAxMHB4O1xyXG59Il19 */"] });


/***/ }),

/***/ 2439:
/*!***********************************************************************!*\
  !*** ./src/app/componetns/list-item-component/list-item.component.ts ***!
  \***********************************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "ListItemComponent": () => (/* binding */ ListItemComponent)
/* harmony export */ });
/* harmony import */ var _base_component__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ../base.component */ 2844);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var _angular_material_list__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/material/list */ 8417);
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/common */ 4364);
/* harmony import */ var _angular_material_button__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/material/button */ 781);
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/router */ 1258);






function ListItemComponent_a_1_Template(rf, ctx) { if (rf & 1) {
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵelementStart"](0, "a", 4);
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵtext"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵelementEnd"]();
} if (rf & 2) {
    const ctx_r0 = _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵnextContext"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵpropertyInterpolate"]("routerLink", ctx_r0.item.pageLink);
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵtextInterpolate1"](" ", ctx_r0.item.title, " ");
} }
function ListItemComponent_span_2_Template(rf, ctx) { if (rf & 1) {
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵelementStart"](0, "span");
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵtext"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵelementEnd"]();
} if (rf & 2) {
    const ctx_r1 = _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵnextContext"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵtextInterpolate"](ctx_r1.item.title);
} }
function ListItemComponent_a_3_Template(rf, ctx) { if (rf & 1) {
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵelementStart"](0, "a", 5);
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵtext"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵelementEnd"]();
} if (rf & 2) {
    const ctx_r2 = _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵnextContext"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵpropertyInterpolate"]("routerLink", ctx_r2.item.updateLink);
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵtextInterpolate1"](" ", ctx_r2.labels.updateButtonLabel, " ");
} }
function ListItemComponent_a_4_Template(rf, ctx) { if (rf & 1) {
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵelementStart"](0, "a", 5);
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵtext"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵelementEnd"]();
} if (rf & 2) {
    const ctx_r3 = _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵnextContext"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵpropertyInterpolate"]("routerLink", ctx_r3.item.deleteLink);
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵtextInterpolate1"](" ", ctx_r3.labels.deleteButtonLabel, " ");
} }
class ListItemComponent extends _base_component__WEBPACK_IMPORTED_MODULE_0__.BaseComponent {
}
ListItemComponent.ɵfac = /*@__PURE__*/ function () { let ɵListItemComponent_BaseFactory; return function ListItemComponent_Factory(t) { return (ɵListItemComponent_BaseFactory || (ɵListItemComponent_BaseFactory = _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵgetInheritedFactory"](ListItemComponent)))(t || ListItemComponent); }; }();
ListItemComponent.ɵcmp = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵdefineComponent"]({ type: ListItemComponent, selectors: [["gamestore-list-item"]], inputs: { item: "item" }, features: [_angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵInheritDefinitionFeature"]], decls: 5, vars: 4, consts: [[1, "list-item-container"], ["mat-button", "", "color", "acient", 3, "routerLink", 4, "ngIf"], [4, "ngIf"], ["mat-stroked-button", "", "color", "accent", 3, "routerLink", 4, "ngIf"], ["mat-button", "", "color", "acient", 3, "routerLink"], ["mat-stroked-button", "", "color", "accent", 3, "routerLink"]], template: function ListItemComponent_Template(rf, ctx) { if (rf & 1) {
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵelementStart"](0, "mat-list-item", 0);
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵtemplate"](1, ListItemComponent_a_1_Template, 2, 2, "a", 1);
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵtemplate"](2, ListItemComponent_span_2_Template, 2, 1, "span", 2);
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵtemplate"](3, ListItemComponent_a_3_Template, 2, 2, "a", 3);
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵtemplate"](4, ListItemComponent_a_4_Template, 2, 2, "a", 3);
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵelementEnd"]();
    } if (rf & 2) {
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵadvance"](1);
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵproperty"]("ngIf", !!(ctx.item.pageLink == null ? null : ctx.item.pageLink.length));
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵadvance"](1);
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵproperty"]("ngIf", !(ctx.item.pageLink == null ? null : ctx.item.pageLink.length));
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵadvance"](1);
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵproperty"]("ngIf", !!(ctx.item.updateLink == null ? null : ctx.item.updateLink.length));
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵadvance"](1);
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵproperty"]("ngIf", !!(ctx.item.deleteLink == null ? null : ctx.item.deleteLink.length));
    } }, directives: [_angular_material_list__WEBPACK_IMPORTED_MODULE_2__.MatListItem, _angular_common__WEBPACK_IMPORTED_MODULE_3__.NgIf, _angular_material_button__WEBPACK_IMPORTED_MODULE_4__.MatAnchor, _angular_router__WEBPACK_IMPORTED_MODULE_5__.RouterLinkWithHref], styles: ["span[_ngcontent-%COMP%] {\n  display: inline-block;\n  padding: 10px;\n}\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbImxpc3QtaXRlbS5jb21wb25lbnQuc2NzcyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiQUFBQTtFQUNJLHFCQUFBO0VBQ0EsYUFBQTtBQUNKIiwiZmlsZSI6Imxpc3QtaXRlbS5jb21wb25lbnQuc2NzcyIsInNvdXJjZXNDb250ZW50IjpbInNwYW4ge1xyXG4gICAgZGlzcGxheTogaW5saW5lLWJsb2NrO1xyXG4gICAgcGFkZGluZzogMTBweDtcclxufSJdfQ== */"] });


/***/ }),

/***/ 7001:
/*!*****************************************************************!*\
  !*** ./src/app/componetns/loader-component/loader.component.ts ***!
  \*****************************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "LoaderComponent": () => (/* binding */ LoaderComponent)
/* harmony export */ });
/* harmony import */ var _base_component__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ../base.component */ 2844);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var _angular_material_progress_spinner__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/material/progress-spinner */ 181);



class LoaderComponent extends _base_component__WEBPACK_IMPORTED_MODULE_0__.BaseComponent {
}
LoaderComponent.ɵfac = /*@__PURE__*/ function () { let ɵLoaderComponent_BaseFactory; return function LoaderComponent_Factory(t) { return (ɵLoaderComponent_BaseFactory || (ɵLoaderComponent_BaseFactory = _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵgetInheritedFactory"](LoaderComponent)))(t || LoaderComponent); }; }();
LoaderComponent.ɵcmp = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵdefineComponent"]({ type: LoaderComponent, selectors: [["gamestore-loader"]], features: [_angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵInheritDefinitionFeature"]], decls: 2, vars: 0, template: function LoaderComponent_Template(rf, ctx) { if (rf & 1) {
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵelementStart"](0, "div");
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵelement"](1, "mat-spinner");
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵelementEnd"]();
    } }, directives: [_angular_material_progress_spinner__WEBPACK_IMPORTED_MODULE_2__.MatSpinner], styles: ["\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJsb2FkZXIuY29tcG9uZW50LnNjc3MifQ== */"] });


/***/ }),

/***/ 6216:
/*!***************************************************************!*\
  !*** ./src/app/componetns/loader-component/loader.service.ts ***!
  \***************************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "LoaderService": () => (/* binding */ LoaderService)
/* harmony export */ });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! tslib */ 3786);
/* harmony import */ var rxjs__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! rxjs */ 9441);
/* harmony import */ var rxjs_operators__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! rxjs/operators */ 8636);
/* harmony import */ var _loader_component__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./loader.component */ 7001);
/* harmony import */ var _ngneat_until_destroy__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @ngneat/until-destroy */ 9758);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var _angular_material_dialog__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/material/dialog */ 2213);







let LoaderService = class LoaderService {
    constructor(dialog) {
        this.dialog = dialog;
        this.waitingList = [];
        this.addWaiting = new rxjs__WEBPACK_IMPORTED_MODULE_1__.Subject();
        this.removeWaiting = new rxjs__WEBPACK_IMPORTED_MODULE_1__.Subject();
        this.addWaiting.pipe((0,_ngneat_until_destroy__WEBPACK_IMPORTED_MODULE_2__.untilDestroyed)(this)).subscribe((loading) => {
            this.waitingList.push(loading);
            if (!this.current) {
                this.current = this.dialog.open(_loader_component__WEBPACK_IMPORTED_MODULE_0__.LoaderComponent, { disableClose: true });
            }
        });
        this.removeWaiting.pipe((0,_ngneat_until_destroy__WEBPACK_IMPORTED_MODULE_2__.untilDestroyed)(this)).subscribe((loading) => {
            var _a;
            if (!loading) {
                this.waitingList = [];
            }
            else {
                const index = this.waitingList.indexOf(loading);
                if (index >= 0) {
                    this.waitingList.splice(index, 1);
                }
            }
            if (!this.waitingList.length) {
                (_a = this.current) === null || _a === void 0 ? void 0 : _a.close();
                this.current = undefined;
            }
        });
    }
    openForLoading(loading) {
        this.addWaiting.next(loading);
        return loading.pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_3__.tap)((_) => this.removeWaiting.next(loading)));
    }
    closeLoader() {
        this.removeWaiting.next(undefined);
    }
};
LoaderService.ɵfac = function LoaderService_Factory(t) { return new (t || LoaderService)(_angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵinject"](_angular_material_dialog__WEBPACK_IMPORTED_MODULE_5__.MatDialog)); };
LoaderService.ɵprov = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵdefineInjectable"]({ token: LoaderService, factory: LoaderService.ɵfac, providedIn: 'root' });
LoaderService = (0,tslib__WEBPACK_IMPORTED_MODULE_6__.__decorate)([
    (0,_ngneat_until_destroy__WEBPACK_IMPORTED_MODULE_2__.UntilDestroy)()
], LoaderService);



/***/ }),

/***/ 9567:
/*!*****************************************************************************!*\
  !*** ./src/app/componetns/number-input-component/number-input.component.ts ***!
  \*****************************************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "NumberInputComponent": () => (/* binding */ NumberInputComponent)
/* harmony export */ });
/* harmony import */ var src_app_configuration_input_error_matcher__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! src/app/configuration/input-error-matcher */ 8430);
/* harmony import */ var _base_component__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../base.component */ 2844);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var _angular_material_form_field__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/material/form-field */ 5788);
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/common */ 4364);
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/forms */ 1707);
/* harmony import */ var _angular_material_input__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! @angular/material/input */ 4742);







function NumberInputComponent_mat_label_2_Template(rf, ctx) { if (rf & 1) {
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](0, "mat-label");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtext"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
} if (rf & 2) {
    const ctx_r0 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵnextContext"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtextInterpolate"](ctx_r0.name);
} }
function NumberInputComponent_mat_error_4_Template(rf, ctx) { if (rf & 1) {
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](0, "mat-error");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtext"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
} if (rf & 2) {
    const ctx_r1 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵnextContext"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtextInterpolate1"](" ", ctx_r1.labels.enterValidMessage, " ");
} }
class NumberInputComponent extends _base_component__WEBPACK_IMPORTED_MODULE_1__.BaseComponent {
    constructor() {
        super(...arguments);
        this.name = '';
        this.disableValidation = false;
        this.matcher = new src_app_configuration_input_error_matcher__WEBPACK_IMPORTED_MODULE_0__.InputErrorStateMatcher();
    }
    ngOnInit() {
        this.matcher.disableValidation = this.disableValidation;
    }
    isErrors() {
        return this.matcher.isErrorState(this.control, null);
    }
}
NumberInputComponent.ɵfac = /*@__PURE__*/ function () { let ɵNumberInputComponent_BaseFactory; return function NumberInputComponent_Factory(t) { return (ɵNumberInputComponent_BaseFactory || (ɵNumberInputComponent_BaseFactory = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵgetInheritedFactory"](NumberInputComponent)))(t || NumberInputComponent); }; }();
NumberInputComponent.ɵcmp = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵdefineComponent"]({ type: NumberInputComponent, selectors: [["gamestore-number-input"]], inputs: { control: "control", name: "name", disableValidation: "disableValidation" }, features: [_angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵInheritDefinitionFeature"]], decls: 5, vars: 4, consts: [[1, "text-input-wrapper"], ["appearance", "fill", 1, "example-full-width"], [4, "ngIf"], ["type", "number", "matInput", "", 3, "formControl", "errorStateMatcher"]], template: function NumberInputComponent_Template(rf, ctx) { if (rf & 1) {
        _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](0, "div", 0);
        _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](1, "mat-form-field", 1);
        _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtemplate"](2, NumberInputComponent_mat_label_2_Template, 2, 1, "mat-label", 2);
        _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelement"](3, "input", 3);
        _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtemplate"](4, NumberInputComponent_mat_error_4_Template, 2, 1, "mat-error", 2);
        _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
        _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
    } if (rf & 2) {
        _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](2);
        _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵproperty"]("ngIf", !!(ctx.name == null ? null : ctx.name.length));
        _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](1);
        _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵproperty"]("formControl", ctx.control)("errorStateMatcher", ctx.matcher);
        _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](1);
        _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵproperty"]("ngIf", ctx.isErrors);
    } }, directives: [_angular_material_form_field__WEBPACK_IMPORTED_MODULE_3__.MatFormField, _angular_common__WEBPACK_IMPORTED_MODULE_4__.NgIf, _angular_forms__WEBPACK_IMPORTED_MODULE_5__.NumberValueAccessor, _angular_material_input__WEBPACK_IMPORTED_MODULE_6__.MatInput, _angular_forms__WEBPACK_IMPORTED_MODULE_5__.DefaultValueAccessor, _angular_forms__WEBPACK_IMPORTED_MODULE_5__.NgControlStatus, _angular_forms__WEBPACK_IMPORTED_MODULE_5__.FormControlDirective, _angular_material_form_field__WEBPACK_IMPORTED_MODULE_3__.MatLabel, _angular_material_form_field__WEBPACK_IMPORTED_MODULE_3__.MatError], styles: [".text-input-wrapper[_ngcontent-%COMP%] {\n  padding-top: 5px;\n  padding-bottom: 5px;\n}\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbIm51bWJlci1pbnB1dC5jb21wb25lbnQuc2NzcyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiQUFBQTtFQUNJLGdCQUFBO0VBQ0EsbUJBQUE7QUFDSiIsImZpbGUiOiJudW1iZXItaW5wdXQuY29tcG9uZW50LnNjc3MiLCJzb3VyY2VzQ29udGVudCI6WyIudGV4dC1pbnB1dC13cmFwcGVyIHtcclxuICAgIHBhZGRpbmctdG9wOiA1cHg7XHJcbiAgICBwYWRkaW5nLWJvdHRvbTogNXB4O1xyXG59Il19 */"] });


/***/ }),

/***/ 5962:
/*!***************************************************************************!*\
  !*** ./src/app/componetns/radio-input-component/radio-input.component.ts ***!
  \***************************************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "RadioInputComponent": () => (/* binding */ RadioInputComponent)
/* harmony export */ });
/* harmony import */ var _base_component__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ../base.component */ 2844);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/common */ 4364);
/* harmony import */ var _angular_material_radio__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/material/radio */ 5644);
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/forms */ 1707);





function RadioInputComponent_div_1_Template(rf, ctx) { if (rf & 1) {
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵelementStart"](0, "div");
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵtext"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵelementEnd"]();
} if (rf & 2) {
    const ctx_r0 = _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵnextContext"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵtextInterpolate"](ctx_r0.name);
} }
function RadioInputComponent_div_3_Template(rf, ctx) { if (rf & 1) {
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵelementStart"](0, "div", 4);
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵelementStart"](1, "mat-radio-button", 5);
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵtext"](2);
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵelementEnd"]();
} if (rf & 2) {
    const item_r2 = ctx.$implicit;
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵproperty"]("value", item_r2.value);
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵtextInterpolate1"](" ", item_r2.title, " ");
} }
class RadioInputComponent extends _base_component__WEBPACK_IMPORTED_MODULE_0__.BaseComponent {
    constructor() {
        super(...arguments);
        this.name = '';
    }
}
RadioInputComponent.ɵfac = /*@__PURE__*/ function () { let ɵRadioInputComponent_BaseFactory; return function RadioInputComponent_Factory(t) { return (ɵRadioInputComponent_BaseFactory || (ɵRadioInputComponent_BaseFactory = _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵgetInheritedFactory"](RadioInputComponent)))(t || RadioInputComponent); }; }();
RadioInputComponent.ɵcmp = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵdefineComponent"]({ type: RadioInputComponent, selectors: [["gamestore-radio-input"]], inputs: { control: "control", items: "items", name: "name" }, features: [_angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵInheritDefinitionFeature"]], decls: 4, vars: 3, consts: [[1, "radio-input-wrapper"], [4, "ngIf"], [3, "formControl"], ["class", "radio-container", 4, "ngFor", "ngForOf"], [1, "radio-container"], [3, "value"]], template: function RadioInputComponent_Template(rf, ctx) { if (rf & 1) {
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵelementStart"](0, "div", 0);
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵtemplate"](1, RadioInputComponent_div_1_Template, 2, 1, "div", 1);
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵelementStart"](2, "mat-radio-group", 2);
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵtemplate"](3, RadioInputComponent_div_3_Template, 3, 2, "div", 3);
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵelementEnd"]();
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵelementEnd"]();
    } if (rf & 2) {
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵadvance"](1);
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵproperty"]("ngIf", !!(ctx.name == null ? null : ctx.name.length));
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵadvance"](1);
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵproperty"]("formControl", ctx.control);
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵadvance"](1);
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵproperty"]("ngForOf", ctx.items);
    } }, directives: [_angular_common__WEBPACK_IMPORTED_MODULE_2__.NgIf, _angular_material_radio__WEBPACK_IMPORTED_MODULE_3__.MatRadioGroup, _angular_forms__WEBPACK_IMPORTED_MODULE_4__.NgControlStatus, _angular_forms__WEBPACK_IMPORTED_MODULE_4__.FormControlDirective, _angular_common__WEBPACK_IMPORTED_MODULE_2__.NgForOf, _angular_material_radio__WEBPACK_IMPORTED_MODULE_3__.MatRadioButton], styles: [".radio-input-wrapper[_ngcontent-%COMP%] {\n  padding-top: 5px;\n  padding-bottom: 5px;\n}\n.radio-input-wrapper[_ngcontent-%COMP%]   .radio-container[_ngcontent-%COMP%] {\n  margin-bottom: 7px;\n}\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInJhZGlvLWlucHV0LmNvbXBvbmVudC5zY3NzIl0sIm5hbWVzIjpbXSwibWFwcGluZ3MiOiJBQUFBO0VBQ0ksZ0JBQUE7RUFDQSxtQkFBQTtBQUNKO0FBQ0k7RUFDSSxrQkFBQTtBQUNSIiwiZmlsZSI6InJhZGlvLWlucHV0LmNvbXBvbmVudC5zY3NzIiwic291cmNlc0NvbnRlbnQiOlsiLnJhZGlvLWlucHV0LXdyYXBwZXIge1xyXG4gICAgcGFkZGluZy10b3A6IDVweDtcclxuICAgIHBhZGRpbmctYm90dG9tOiA1cHg7XHJcblxyXG4gICAgLnJhZGlvLWNvbnRhaW5lciB7XHJcbiAgICAgICAgbWFyZ2luLWJvdHRvbTogN3B4O1xyXG4gICAgfVxyXG5cclxufSJdfQ== */"] });


/***/ }),

/***/ 9260:
/*!*********************************************************************************!*\
  !*** ./src/app/componetns/selector-input-component/selector-input.component.ts ***!
  \*********************************************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "SelectorInputComponent": () => (/* binding */ SelectorInputComponent)
/* harmony export */ });
/* harmony import */ var _base_component__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ../base.component */ 2844);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var _angular_material_form_field__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/material/form-field */ 5788);
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/common */ 4364);
/* harmony import */ var _angular_material_select__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/material/select */ 7007);
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/forms */ 1707);
/* harmony import */ var _angular_material_core__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! @angular/material/core */ 2220);







function SelectorInputComponent_mat_label_2_Template(rf, ctx) { if (rf & 1) {
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵelementStart"](0, "mat-label");
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵtext"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵelementEnd"]();
} if (rf & 2) {
    const ctx_r0 = _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵnextContext"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵtextInterpolate"](ctx_r0.name);
} }
function SelectorInputComponent_mat_option_4_Template(rf, ctx) { if (rf & 1) {
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵelementStart"](0, "mat-option", 5);
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵtext"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵelementEnd"]();
} if (rf & 2) {
    const value_r2 = ctx.$implicit;
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵproperty"]("value", value_r2.value);
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵtextInterpolate1"](" ", value_r2.name, " ");
} }
class SelectorInputComponent extends _base_component__WEBPACK_IMPORTED_MODULE_0__.BaseComponent {
    constructor() {
        super(...arguments);
        this.name = '';
        this.values = [];
    }
}
SelectorInputComponent.ɵfac = /*@__PURE__*/ function () { let ɵSelectorInputComponent_BaseFactory; return function SelectorInputComponent_Factory(t) { return (ɵSelectorInputComponent_BaseFactory || (ɵSelectorInputComponent_BaseFactory = _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵgetInheritedFactory"](SelectorInputComponent)))(t || SelectorInputComponent); }; }();
SelectorInputComponent.ɵcmp = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵdefineComponent"]({ type: SelectorInputComponent, selectors: [["gamestore-selector-input"]], inputs: { control: "control", name: "name", values: "values" }, features: [_angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵInheritDefinitionFeature"]], decls: 5, vars: 3, consts: [[1, "text-input-wrapper"], ["appearance", "fill", 1, "example-full-width"], [4, "ngIf"], [3, "formControl"], [3, "value", 4, "ngFor", "ngForOf"], [3, "value"]], template: function SelectorInputComponent_Template(rf, ctx) { if (rf & 1) {
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵelementStart"](0, "div", 0);
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵelementStart"](1, "mat-form-field", 1);
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵtemplate"](2, SelectorInputComponent_mat_label_2_Template, 2, 1, "mat-label", 2);
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵelementStart"](3, "mat-select", 3);
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵtemplate"](4, SelectorInputComponent_mat_option_4_Template, 2, 2, "mat-option", 4);
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵelementEnd"]();
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵelementEnd"]();
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵelementEnd"]();
    } if (rf & 2) {
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵadvance"](2);
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵproperty"]("ngIf", !!(ctx.name == null ? null : ctx.name.length));
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵadvance"](1);
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵproperty"]("formControl", ctx.control);
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵadvance"](1);
        _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵproperty"]("ngForOf", ctx.values);
    } }, directives: [_angular_material_form_field__WEBPACK_IMPORTED_MODULE_2__.MatFormField, _angular_common__WEBPACK_IMPORTED_MODULE_3__.NgIf, _angular_material_select__WEBPACK_IMPORTED_MODULE_4__.MatSelect, _angular_forms__WEBPACK_IMPORTED_MODULE_5__.NgControlStatus, _angular_forms__WEBPACK_IMPORTED_MODULE_5__.FormControlDirective, _angular_common__WEBPACK_IMPORTED_MODULE_3__.NgForOf, _angular_material_form_field__WEBPACK_IMPORTED_MODULE_2__.MatLabel, _angular_material_core__WEBPACK_IMPORTED_MODULE_6__.MatOption], styles: [".text-input-wrapper[_ngcontent-%COMP%] {\n  padding-top: 5px;\n  padding-bottom: 5px;\n}\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNlbGVjdG9yLWlucHV0LmNvbXBvbmVudC5zY3NzIl0sIm5hbWVzIjpbXSwibWFwcGluZ3MiOiJBQUFBO0VBQ0ksZ0JBQUE7RUFDQSxtQkFBQTtBQUNKIiwiZmlsZSI6InNlbGVjdG9yLWlucHV0LmNvbXBvbmVudC5zY3NzIiwic291cmNlc0NvbnRlbnQiOlsiLnRleHQtaW5wdXQtd3JhcHBlciB7XHJcbiAgICBwYWRkaW5nLXRvcDogNXB4O1xyXG4gICAgcGFkZGluZy1ib3R0b206IDVweDtcclxufSJdfQ== */"] });


/***/ }),

/***/ 2082:
/*!*************************************************************************!*\
  !*** ./src/app/componetns/text-input-component/text-input.component.ts ***!
  \*************************************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "TextInputComponent": () => (/* binding */ TextInputComponent)
/* harmony export */ });
/* harmony import */ var src_app_configuration_input_error_matcher__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! src/app/configuration/input-error-matcher */ 8430);
/* harmony import */ var _base_component__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../base.component */ 2844);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var _angular_material_form_field__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/material/form-field */ 5788);
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/common */ 4364);
/* harmony import */ var _angular_material_input__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/material/input */ 4742);
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! @angular/forms */ 1707);







function TextInputComponent_mat_label_2_Template(rf, ctx) { if (rf & 1) {
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](0, "mat-label");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtext"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
} if (rf & 2) {
    const ctx_r0 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵnextContext"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtextInterpolate"](ctx_r0.name);
} }
function TextInputComponent_mat_error_4_Template(rf, ctx) { if (rf & 1) {
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](0, "mat-error");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtext"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
} if (rf & 2) {
    const ctx_r1 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵnextContext"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtextInterpolate1"](" ", ctx_r1.labels.enterValidMessage, " ");
} }
class TextInputComponent extends _base_component__WEBPACK_IMPORTED_MODULE_1__.BaseComponent {
    constructor() {
        super(...arguments);
        this.name = '';
        this.disableValidation = false;
        this.matcher = new src_app_configuration_input_error_matcher__WEBPACK_IMPORTED_MODULE_0__.InputErrorStateMatcher();
    }
    ngOnInit() {
        this.matcher.disableValidation = this.disableValidation;
    }
    isErrors() {
        return this.matcher.isErrorState(this.control, null);
    }
}
TextInputComponent.ɵfac = /*@__PURE__*/ function () { let ɵTextInputComponent_BaseFactory; return function TextInputComponent_Factory(t) { return (ɵTextInputComponent_BaseFactory || (ɵTextInputComponent_BaseFactory = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵgetInheritedFactory"](TextInputComponent)))(t || TextInputComponent); }; }();
TextInputComponent.ɵcmp = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵdefineComponent"]({ type: TextInputComponent, selectors: [["gamestore-text-input"]], inputs: { control: "control", name: "name", disableValidation: "disableValidation" }, features: [_angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵInheritDefinitionFeature"]], decls: 5, vars: 4, consts: [[1, "text-input-wrapper"], ["appearance", "fill", 1, "example-full-width"], [4, "ngIf"], ["type", "text", "matInput", "", 3, "formControl", "errorStateMatcher"]], template: function TextInputComponent_Template(rf, ctx) { if (rf & 1) {
        _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](0, "div", 0);
        _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](1, "mat-form-field", 1);
        _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtemplate"](2, TextInputComponent_mat_label_2_Template, 2, 1, "mat-label", 2);
        _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelement"](3, "input", 3);
        _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtemplate"](4, TextInputComponent_mat_error_4_Template, 2, 1, "mat-error", 2);
        _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
        _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
    } if (rf & 2) {
        _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](2);
        _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵproperty"]("ngIf", !!(ctx.name == null ? null : ctx.name.length));
        _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](1);
        _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵproperty"]("formControl", ctx.control)("errorStateMatcher", ctx.matcher);
        _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](1);
        _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵproperty"]("ngIf", ctx.isErrors);
    } }, directives: [_angular_material_form_field__WEBPACK_IMPORTED_MODULE_3__.MatFormField, _angular_common__WEBPACK_IMPORTED_MODULE_4__.NgIf, _angular_material_input__WEBPACK_IMPORTED_MODULE_5__.MatInput, _angular_forms__WEBPACK_IMPORTED_MODULE_6__.DefaultValueAccessor, _angular_forms__WEBPACK_IMPORTED_MODULE_6__.NgControlStatus, _angular_forms__WEBPACK_IMPORTED_MODULE_6__.FormControlDirective, _angular_material_form_field__WEBPACK_IMPORTED_MODULE_3__.MatLabel, _angular_material_form_field__WEBPACK_IMPORTED_MODULE_3__.MatError], styles: [".text-input-wrapper[_ngcontent-%COMP%] {\n  padding-top: 5px;\n  padding-bottom: 5px;\n}\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInRleHQtaW5wdXQuY29tcG9uZW50LnNjc3MiXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IkFBQUE7RUFDSSxnQkFBQTtFQUNBLG1CQUFBO0FBQ0oiLCJmaWxlIjoidGV4dC1pbnB1dC5jb21wb25lbnQuc2NzcyIsInNvdXJjZXNDb250ZW50IjpbIi50ZXh0LWlucHV0LXdyYXBwZXIge1xyXG4gICAgcGFkZGluZy10b3A6IDVweDtcclxuICAgIHBhZGRpbmctYm90dG9tOiA1cHg7XHJcbn0iXX0= */"] });


/***/ }),

/***/ 3281:
/*!*********************************************************************************!*\
  !*** ./src/app/componetns/textarea-input-component/textarea-input.component.ts ***!
  \*********************************************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "TextareaInputComponent": () => (/* binding */ TextareaInputComponent)
/* harmony export */ });
/* harmony import */ var src_app_configuration_input_error_matcher__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! src/app/configuration/input-error-matcher */ 8430);
/* harmony import */ var _base_component__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../base.component */ 2844);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var _angular_material_form_field__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/material/form-field */ 5788);
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/common */ 4364);
/* harmony import */ var _angular_material_input__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/material/input */ 4742);
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! @angular/forms */ 1707);







function TextareaInputComponent_mat_label_2_Template(rf, ctx) { if (rf & 1) {
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](0, "mat-label");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtext"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
} if (rf & 2) {
    const ctx_r0 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵnextContext"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtextInterpolate"](ctx_r0.name);
} }
function TextareaInputComponent_mat_error_4_Template(rf, ctx) { if (rf & 1) {
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](0, "mat-error");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtext"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
} if (rf & 2) {
    const ctx_r1 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵnextContext"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtextInterpolate1"](" ", ctx_r1.labels.enterValidMessage, " ");
} }
class TextareaInputComponent extends _base_component__WEBPACK_IMPORTED_MODULE_1__.BaseComponent {
    constructor() {
        super(...arguments);
        this.name = '';
        this.disableValidation = false;
        this.matcher = new src_app_configuration_input_error_matcher__WEBPACK_IMPORTED_MODULE_0__.InputErrorStateMatcher();
    }
    ngOnInit() {
        this.matcher.disableValidation = this.disableValidation;
    }
    isErrors() {
        return this.matcher.isErrorState(this.control, null);
    }
}
TextareaInputComponent.ɵfac = /*@__PURE__*/ function () { let ɵTextareaInputComponent_BaseFactory; return function TextareaInputComponent_Factory(t) { return (ɵTextareaInputComponent_BaseFactory || (ɵTextareaInputComponent_BaseFactory = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵgetInheritedFactory"](TextareaInputComponent)))(t || TextareaInputComponent); }; }();
TextareaInputComponent.ɵcmp = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵdefineComponent"]({ type: TextareaInputComponent, selectors: [["gamestore-textarea-input"]], inputs: { control: "control", name: "name", disableValidation: "disableValidation" }, features: [_angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵInheritDefinitionFeature"]], decls: 5, vars: 4, consts: [[1, "text-input-wrapper"], ["appearance", "fill", 1, "example-full-width"], [4, "ngIf"], ["matInput", "", 3, "formControl", "errorStateMatcher"]], template: function TextareaInputComponent_Template(rf, ctx) { if (rf & 1) {
        _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](0, "div", 0);
        _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](1, "mat-form-field", 1);
        _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtemplate"](2, TextareaInputComponent_mat_label_2_Template, 2, 1, "mat-label", 2);
        _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelement"](3, "textarea", 3);
        _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtemplate"](4, TextareaInputComponent_mat_error_4_Template, 2, 1, "mat-error", 2);
        _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
        _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
    } if (rf & 2) {
        _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](2);
        _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵproperty"]("ngIf", !!(ctx.name == null ? null : ctx.name.length));
        _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](1);
        _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵproperty"]("formControl", ctx.control)("errorStateMatcher", ctx.matcher);
        _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](1);
        _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵproperty"]("ngIf", ctx.isErrors);
    } }, directives: [_angular_material_form_field__WEBPACK_IMPORTED_MODULE_3__.MatFormField, _angular_common__WEBPACK_IMPORTED_MODULE_4__.NgIf, _angular_material_input__WEBPACK_IMPORTED_MODULE_5__.MatInput, _angular_forms__WEBPACK_IMPORTED_MODULE_6__.DefaultValueAccessor, _angular_forms__WEBPACK_IMPORTED_MODULE_6__.NgControlStatus, _angular_forms__WEBPACK_IMPORTED_MODULE_6__.FormControlDirective, _angular_material_form_field__WEBPACK_IMPORTED_MODULE_3__.MatLabel, _angular_material_form_field__WEBPACK_IMPORTED_MODULE_3__.MatError], styles: [".text-input-wrapper[_ngcontent-%COMP%] {\n  padding-top: 5px;\n  padding-bottom: 5px;\n}\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInRleHRhcmVhLWlucHV0LmNvbXBvbmVudC5zY3NzIl0sIm5hbWVzIjpbXSwibWFwcGluZ3MiOiJBQUFBO0VBQ0ksZ0JBQUE7RUFDQSxtQkFBQTtBQUNKIiwiZmlsZSI6InRleHRhcmVhLWlucHV0LmNvbXBvbmVudC5zY3NzIiwic291cmNlc0NvbnRlbnQiOlsiLnRleHQtaW5wdXQtd3JhcHBlciB7XHJcbiAgICBwYWRkaW5nLXRvcDogNXB4O1xyXG4gICAgcGFkZGluZy1ib3R0b206IDVweDtcclxufSJdfQ== */"] });


/***/ }),

/***/ 5482:
/*!*********************************************************!*\
  !*** ./src/app/configuration/configuration-resolver.ts ***!
  \*********************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "appConfiguration": () => (/* binding */ appConfiguration),
/* harmony export */   "resolveConfigurations": () => (/* binding */ resolveConfigurations)
/* harmony export */ });
/* harmony import */ var C_Users_Vitalii_Slyva_Desktop_rdnew_node_modules_babel_runtime_helpers_esm_asyncToGenerator__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./node_modules/@babel/runtime/helpers/esm/asyncToGenerator */ 9369);
/* harmony import */ var _configuration__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./configuration */ 8939);


const appConfiguration = new _configuration__WEBPACK_IMPORTED_MODULE_1__.Configuration();
function resolveConfigurations() {
  return _resolveConfigurations.apply(this, arguments);
}

function _resolveConfigurations() {
  _resolveConfigurations = (0,C_Users_Vitalii_Slyva_Desktop_rdnew_node_modules_babel_runtime_helpers_esm_asyncToGenerator__WEBPACK_IMPORTED_MODULE_0__.default)(function* () {
    const routeConfig = '/assets/configuration/configuration.json';
    const response = yield fetch(routeConfig);
    const data = yield response.json();
    Object.keys(appConfiguration).forEach(x => {
      if (!data[x]) {
        return;
      }

      appConfiguration[x] = data[x];
    });
  });
  return _resolveConfigurations.apply(this, arguments);
}

/***/ }),

/***/ 8939:
/*!************************************************!*\
  !*** ./src/app/configuration/configuration.ts ***!
  \************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "Configuration": () => (/* binding */ Configuration)
/* harmony export */ });
class Configuration {
    constructor() {
        this.baseApiUrl = '';
        this.gameApiUrl = '';
        this.gameByIdApiUrl = '';
        this.gamesApiUrl = '';
        this.gamesByGenreApiUrl = '';
        this.gamesByPlatformApiUrl = '';
        this.getGameFileApiUrl = '';
        this.updateGameApiUrl = '';
        this.addGameApiUrl = '';
        this.deleteGameApiUrl = '';
        this.gamesByPublisherApiUrl = '';
        this.getPublishedDateOptionsApiUrl = '';
        this.getSortingOptionsApiUrl = '';
        this.getPaggingOptionsApiUrl = '';
        this.genreApiUrl = '';
        this.genresApiUrl = '';
        this.genresByGameApiUrl = '';
        this.genresByParentApiUrl = '';
        this.updateGenreApiUrl = '';
        this.addGenreApiUrl = '';
        this.deleteGenreApiUrl = '';
        this.platformApiUrl = '';
        this.platformsApiUrl = '';
        this.platformsByGameApiUrl = '';
        this.updatePlatformApiUrl = '';
        this.addPlatformApiUrl = '';
        this.deletePlatformApiUrl = '';
        this.publisherApiUrl = '';
        this.publishersApiUrl = '';
        this.publisherByGameApiUrl = '';
        this.addPublisherApiUrl = '';
        this.deletePublisherApiUrl = '';
        this.updatePublisherApiUrl = '';
        this.orderApiUrl = '';
        this.ordersApiUrl = '';
        this.orderDetailsApiUrl = '';
        this.buyGameApiUrl = '';
        this.cancelGameBuyApiUrl = '';
        this.basketApiUrl = '';
        this.makeOrderInfoApiUrl = '';
        this.payApiUrl = '';
        this.addReplyCommentApiUrl = '';
        this.addCommentApiUrl = '';
        this.commentsByGameApiUrl = '';
        this.addQouteCommentApiUrl = '';
        this.deleteCommentApiUrl = '';
        this.getBanDurationsApiUrl = '';
        this.banUserApiUrl = '';
    }
}


/***/ }),

/***/ 381:
/*!************************************************!*\
  !*** ./src/app/configuration/error-handler.ts ***!
  \************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "GlobalErrorHandlerService": () => (/* binding */ GlobalErrorHandlerService)
/* harmony export */ });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var ngx_toastr__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ngx-toastr */ 3315);
/* harmony import */ var _http_interceptor__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./http-interceptor */ 433);




class GlobalErrorHandlerService extends _angular_core__WEBPACK_IMPORTED_MODULE_1__.ErrorHandler {
    constructor(injector) {
        super();
        this.injector = injector;
    }
    get toastrService() {
        return this.injector.get(ngx_toastr__WEBPACK_IMPORTED_MODULE_2__.ToastrService);
    }
    handleError(error) {
        if (error.message === _http_interceptor__WEBPACK_IMPORTED_MODULE_0__.apiErrorTitle) {
            return;
        }
        this.toastrService.error(error.message, 'Something goes wrong!');
        super.handleError(error);
    }
}
GlobalErrorHandlerService.ɵfac = function GlobalErrorHandlerService_Factory(t) { return new (t || GlobalErrorHandlerService)(_angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵinject"](_angular_core__WEBPACK_IMPORTED_MODULE_1__.Injector)); };
GlobalErrorHandlerService.ɵprov = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵɵdefineInjectable"]({ token: GlobalErrorHandlerService, factory: GlobalErrorHandlerService.ɵfac });


/***/ }),

/***/ 433:
/*!***************************************************!*\
  !*** ./src/app/configuration/http-interceptor.ts ***!
  \***************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "apiErrorTitle": () => (/* binding */ apiErrorTitle),
/* harmony export */   "GlobalHttpInterceptorService": () => (/* binding */ GlobalHttpInterceptorService)
/* harmony export */ });
/* harmony import */ var rxjs_operators__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! rxjs/operators */ 8293);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var ngx_toastr__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ngx-toastr */ 3315);
/* harmony import */ var _componetns_loader_component_loader_service__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ../componetns/loader-component/loader.service */ 6216);




const apiErrorTitle = 'Error during API call!';
class GlobalHttpInterceptorService {
    constructor(toastr, loaderService) {
        this.toastr = toastr;
        this.loaderService = loaderService;
    }
    intercept(request, next) {
        return next
            .handle(request)
            .pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_1__.catchError)((error) => this.handleError(error)));
    }
    handleError(error) {
        this.loaderService.closeLoader();
        if (error.status === 0) {
            this.toastr.error('API is unavailable', apiErrorTitle);
        }
        else {
            this.toastr.error(`API '${error.url}' returned code ${error.status}${!!error.error ? `, error body was: '${error.error}'` : ''}`, apiErrorTitle);
        }
        throw new Error(apiErrorTitle);
    }
}
GlobalHttpInterceptorService.ɵfac = function GlobalHttpInterceptorService_Factory(t) { return new (t || GlobalHttpInterceptorService)(_angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵinject"](ngx_toastr__WEBPACK_IMPORTED_MODULE_3__.ToastrService), _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵinject"](_componetns_loader_component_loader_service__WEBPACK_IMPORTED_MODULE_0__.LoaderService)); };
GlobalHttpInterceptorService.ɵprov = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵdefineInjectable"]({ token: GlobalHttpInterceptorService, factory: GlobalHttpInterceptorService.ɵfac });


/***/ }),

/***/ 8430:
/*!******************************************************!*\
  !*** ./src/app/configuration/input-error-matcher.ts ***!
  \******************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "InputErrorStateMatcher": () => (/* binding */ InputErrorStateMatcher)
/* harmony export */ });
class InputErrorStateMatcher {
    constructor() {
        this.disableValidation = true;
    }
    isErrorState(control, form) {
        return !this.disableValidation && !!(control && control.invalid);
    }
}


/***/ }),

/***/ 5337:
/*!**************************************************!*\
  !*** ./src/app/configuration/input-validator.ts ***!
  \**************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "InputValidator": () => (/* binding */ InputValidator)
/* harmony export */ });
class InputValidator {
    static getNumberValidator() {
        return (control) => {
            if (!control.value) {
                return null;
            }
            if (Number.parseInt(control.value) < 0 ||
                Number.parseFloat(control.value) != Number.parseInt(control.value)) {
                return { invalidNumber: true };
            }
            return null;
        };
    }
}


/***/ }),

/***/ 5075:
/*!**********************************************!*\
  !*** ./src/app/configuration/page-routes.ts ***!
  \**********************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "PageRoutes": () => (/* binding */ PageRoutes)
/* harmony export */ });
var PageRoutes;
(function (PageRoutes) {
    PageRoutes["Games"] = "Games";
    PageRoutes["Game"] = "Game";
    PageRoutes["UpdateGame"] = "UpdateGame";
    PageRoutes["DeleteGame"] = "DeleteGame";
    PageRoutes["AddGame"] = "AddGame";
    PageRoutes["Genres"] = "Genres";
    PageRoutes["Genre"] = "Genre";
    PageRoutes["UpdateGenre"] = "UpdateGenre";
    PageRoutes["DeleteGenre"] = "DeleteGenre";
    PageRoutes["AddGenre"] = "AddGenre";
    PageRoutes["Platforms"] = "Platforms";
    PageRoutes["Platform"] = "Platform";
    PageRoutes["UpdatePlatform"] = "UpdatePlatform";
    PageRoutes["DeletePlatform"] = "DeletePlatform";
    PageRoutes["AddPlatform"] = "AddPlatform";
    PageRoutes["Publishers"] = "Publishers";
    PageRoutes["Publisher"] = "Publisher";
    PageRoutes["UpdatePublisher"] = "UpdatePublisher";
    PageRoutes["DeletePublisher"] = "DeletePublisher";
    PageRoutes["AddPublisher"] = "AddPublisher";
    PageRoutes["Order"] = "Order";
    PageRoutes["Orders"] = "Orders";
    PageRoutes["Basket"] = "Basket";
    PageRoutes["MakeOrder"] = "MakeOrder";
})(PageRoutes || (PageRoutes = {}));


/***/ }),

/***/ 1629:
/*!**************************************************!*\
  !*** ./src/app/configuration/routes-resolver.ts ***!
  \**************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "links": () => (/* binding */ links),
/* harmony export */   "resolveRoutesAsync": () => (/* binding */ resolveRoutesAsync)
/* harmony export */ });
/* harmony import */ var C_Users_Vitalii_Slyva_Desktop_rdnew_node_modules_babel_runtime_helpers_esm_asyncToGenerator__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./node_modules/@babel/runtime/helpers/esm/asyncToGenerator */ 9369);
/* harmony import */ var _pages_basket_page_basket_page_component__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../pages/basket-page/basket-page.component */ 7266);
/* harmony import */ var _pages_delete_game_page_delete_game_page_component__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../pages/delete-game-page/delete-game-page.component */ 9217);
/* harmony import */ var _pages_delete_genre_page_delete_genre_page_component__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../pages/delete-genre-page/delete-genre-page.component */ 7717);
/* harmony import */ var _pages_delete_patform_page_delete_platform_page_component__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ../pages/delete-patform-page/delete-platform-page.component */ 7974);
/* harmony import */ var _pages_delete_publisher_page_delete_publisher_page_component__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ../pages/delete-publisher-page/delete-publisher-page.component */ 8814);
/* harmony import */ var _pages_game_page_game_page_component__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ../pages/game-page/game-page.component */ 2042);
/* harmony import */ var _pages_games_page_games_page_component__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! ../pages/games-page/games-page.component */ 3299);
/* harmony import */ var _pages_genre_page_genre_page_component__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! ../pages/genre-page/genre-page.component */ 9629);
/* harmony import */ var _pages_genres_page_genres_page_component__WEBPACK_IMPORTED_MODULE_9__ = __webpack_require__(/*! ../pages/genres-page/genres-page.component */ 4092);
/* harmony import */ var _pages_make_order_page_make_order_page_component__WEBPACK_IMPORTED_MODULE_10__ = __webpack_require__(/*! ../pages/make-order-page/make-order-page.component */ 8427);
/* harmony import */ var _pages_order_page_order_page_component__WEBPACK_IMPORTED_MODULE_11__ = __webpack_require__(/*! ../pages/order-page/order-page.component */ 3733);
/* harmony import */ var _pages_orders_page_orders_page_component__WEBPACK_IMPORTED_MODULE_12__ = __webpack_require__(/*! ../pages/orders-page/orders-page.component */ 4158);
/* harmony import */ var _pages_platform_page_platform_page_component__WEBPACK_IMPORTED_MODULE_13__ = __webpack_require__(/*! ../pages/platform-page/platform-page.component */ 9885);
/* harmony import */ var _pages_platforms_page_platforms_page_component__WEBPACK_IMPORTED_MODULE_14__ = __webpack_require__(/*! ../pages/platforms-page/platforms-page.component */ 351);
/* harmony import */ var _pages_publisher_page_publisher_page_component__WEBPACK_IMPORTED_MODULE_15__ = __webpack_require__(/*! ../pages/publisher-page/publisher-page.component */ 7140);
/* harmony import */ var _pages_publishers_page_publishers_page_component__WEBPACK_IMPORTED_MODULE_16__ = __webpack_require__(/*! ../pages/publishers-page/publishers-page.component */ 1955);
/* harmony import */ var _pages_update_game_page_update_game_page_component__WEBPACK_IMPORTED_MODULE_17__ = __webpack_require__(/*! ../pages/update-game-page/update-game-page.component */ 512);
/* harmony import */ var _pages_update_genre_page_update_genre_page_component__WEBPACK_IMPORTED_MODULE_18__ = __webpack_require__(/*! ../pages/update-genre-page/update-genre-page.component */ 4606);
/* harmony import */ var _pages_update_platform_page_update_platform_page_component__WEBPACK_IMPORTED_MODULE_19__ = __webpack_require__(/*! ../pages/update-platform-page/update-platform-page.component */ 9053);
/* harmony import */ var _pages_update_publisher_page_update_publisher_page_component__WEBPACK_IMPORTED_MODULE_20__ = __webpack_require__(/*! ../pages/update-publisher-page/update-publisher-page.component */ 8392);
/* harmony import */ var _page_routes__WEBPACK_IMPORTED_MODULE_21__ = __webpack_require__(/*! ./page-routes */ 5075);






















const links = new Map();
function resolveRoutesAsync() {
  return _resolveRoutesAsync.apply(this, arguments);
}

function _resolveRoutesAsync() {
  _resolveRoutesAsync = (0,C_Users_Vitalii_Slyva_Desktop_rdnew_node_modules_babel_runtime_helpers_esm_asyncToGenerator__WEBPACK_IMPORTED_MODULE_0__.default)(function* () {
    const routeConfig = '/assets/configuration/route-configuration.json';
    const response = yield fetch(routeConfig);
    const data = yield response.json();
    const routes = [];
    Object.keys(_page_routes__WEBPACK_IMPORTED_MODULE_21__.PageRoutes).forEach(x => {
      if (!data[x]) {
        return;
      }

      let link = data[x].toString();

      if (!!link.length && link[0].toString() === '/') {
        link = link.substring(1);
      }

      if (!!link.length && link[link.length - 1].toString() === '/') {
        link = link.substring(0, link.length - 1);
      }

      switch (x) {
        case _page_routes__WEBPACK_IMPORTED_MODULE_21__.PageRoutes.Games:
          links.set(_page_routes__WEBPACK_IMPORTED_MODULE_21__.PageRoutes.Games, '/' + link);
          routes.push({
            path: link,
            pathMatch: 'full',
            component: _pages_games_page_games_page_component__WEBPACK_IMPORTED_MODULE_7__.GamesPageComponent
          });
          break;

        case _page_routes__WEBPACK_IMPORTED_MODULE_21__.PageRoutes.Game:
          links.set(_page_routes__WEBPACK_IMPORTED_MODULE_21__.PageRoutes.Game, '/' + link);
          routes.push({
            path: link + '/:key',
            pathMatch: 'full',
            component: _pages_game_page_game_page_component__WEBPACK_IMPORTED_MODULE_6__.GamePageComponent
          });
          break;

        case _page_routes__WEBPACK_IMPORTED_MODULE_21__.PageRoutes.DeleteGame:
          links.set(_page_routes__WEBPACK_IMPORTED_MODULE_21__.PageRoutes.DeleteGame, '/' + link);
          routes.push({
            path: link + '/:key',
            pathMatch: 'full',
            component: _pages_delete_game_page_delete_game_page_component__WEBPACK_IMPORTED_MODULE_2__.DeleteGamePageComponent
          });
          break;

        case _page_routes__WEBPACK_IMPORTED_MODULE_21__.PageRoutes.UpdateGame:
          links.set(_page_routes__WEBPACK_IMPORTED_MODULE_21__.PageRoutes.UpdateGame, '/' + link);
          routes.push({
            path: link + '/:key',
            pathMatch: 'full',
            component: _pages_update_game_page_update_game_page_component__WEBPACK_IMPORTED_MODULE_17__.UpdateGamePageComponent
          });
          break;

        case _page_routes__WEBPACK_IMPORTED_MODULE_21__.PageRoutes.AddGame:
          links.set(_page_routes__WEBPACK_IMPORTED_MODULE_21__.PageRoutes.AddGame, '/' + link);
          routes.push({
            path: link,
            pathMatch: 'full',
            component: _pages_update_game_page_update_game_page_component__WEBPACK_IMPORTED_MODULE_17__.UpdateGamePageComponent
          });
          break;

        case _page_routes__WEBPACK_IMPORTED_MODULE_21__.PageRoutes.Genres:
          links.set(_page_routes__WEBPACK_IMPORTED_MODULE_21__.PageRoutes.Genres, '/' + link);
          routes.push({
            path: link,
            pathMatch: 'full',
            component: _pages_genres_page_genres_page_component__WEBPACK_IMPORTED_MODULE_9__.GenresPageComponent
          });
          break;

        case _page_routes__WEBPACK_IMPORTED_MODULE_21__.PageRoutes.Genre:
          links.set(_page_routes__WEBPACK_IMPORTED_MODULE_21__.PageRoutes.Genre, '/' + link);
          routes.push({
            path: link + '/:id',
            pathMatch: 'full',
            component: _pages_genre_page_genre_page_component__WEBPACK_IMPORTED_MODULE_8__.GenrePageComponent
          });
          break;

        case _page_routes__WEBPACK_IMPORTED_MODULE_21__.PageRoutes.DeleteGenre:
          links.set(_page_routes__WEBPACK_IMPORTED_MODULE_21__.PageRoutes.DeleteGenre, '/' + link);
          routes.push({
            path: link + '/:id',
            pathMatch: 'full',
            component: _pages_delete_genre_page_delete_genre_page_component__WEBPACK_IMPORTED_MODULE_3__.DeleteGenrePageComponent
          });
          break;

        case _page_routes__WEBPACK_IMPORTED_MODULE_21__.PageRoutes.UpdateGenre:
          links.set(_page_routes__WEBPACK_IMPORTED_MODULE_21__.PageRoutes.UpdateGenre, '/' + link);
          routes.push({
            path: link + '/:id',
            pathMatch: 'full',
            component: _pages_update_genre_page_update_genre_page_component__WEBPACK_IMPORTED_MODULE_18__.UpdateGenrePageComponent
          });
          break;

        case _page_routes__WEBPACK_IMPORTED_MODULE_21__.PageRoutes.AddGenre:
          links.set(_page_routes__WEBPACK_IMPORTED_MODULE_21__.PageRoutes.AddGenre, '/' + link);
          routes.push({
            path: link,
            pathMatch: 'full',
            component: _pages_update_genre_page_update_genre_page_component__WEBPACK_IMPORTED_MODULE_18__.UpdateGenrePageComponent
          });
          break;

        case _page_routes__WEBPACK_IMPORTED_MODULE_21__.PageRoutes.Platforms:
          links.set(_page_routes__WEBPACK_IMPORTED_MODULE_21__.PageRoutes.Platforms, '/' + link);
          routes.push({
            path: link,
            pathMatch: 'full',
            component: _pages_platforms_page_platforms_page_component__WEBPACK_IMPORTED_MODULE_14__.PlatformsPageComponent
          });
          break;

        case _page_routes__WEBPACK_IMPORTED_MODULE_21__.PageRoutes.Platform:
          links.set(_page_routes__WEBPACK_IMPORTED_MODULE_21__.PageRoutes.Platform, '/' + link);
          routes.push({
            path: link + '/:id',
            pathMatch: 'full',
            component: _pages_platform_page_platform_page_component__WEBPACK_IMPORTED_MODULE_13__.PlatformPageComponent
          });
          break;

        case _page_routes__WEBPACK_IMPORTED_MODULE_21__.PageRoutes.DeletePlatform:
          links.set(_page_routes__WEBPACK_IMPORTED_MODULE_21__.PageRoutes.DeletePlatform, '/' + link);
          routes.push({
            path: link + '/:id',
            pathMatch: 'full',
            component: _pages_delete_patform_page_delete_platform_page_component__WEBPACK_IMPORTED_MODULE_4__.DeletePlatformPageComponent
          });
          break;

        case _page_routes__WEBPACK_IMPORTED_MODULE_21__.PageRoutes.UpdatePlatform:
          links.set(_page_routes__WEBPACK_IMPORTED_MODULE_21__.PageRoutes.UpdatePlatform, '/' + link);
          routes.push({
            path: link + '/:id',
            pathMatch: 'full',
            component: _pages_update_platform_page_update_platform_page_component__WEBPACK_IMPORTED_MODULE_19__.UpdatePlatformPageComponent
          });
          break;

        case _page_routes__WEBPACK_IMPORTED_MODULE_21__.PageRoutes.AddPlatform:
          links.set(_page_routes__WEBPACK_IMPORTED_MODULE_21__.PageRoutes.AddPlatform, '/' + link);
          routes.push({
            path: link,
            pathMatch: 'full',
            component: _pages_update_platform_page_update_platform_page_component__WEBPACK_IMPORTED_MODULE_19__.UpdatePlatformPageComponent
          });
          break;

        case _page_routes__WEBPACK_IMPORTED_MODULE_21__.PageRoutes.Publishers:
          links.set(_page_routes__WEBPACK_IMPORTED_MODULE_21__.PageRoutes.Publishers, '/' + link);
          routes.push({
            path: link,
            pathMatch: 'full',
            component: _pages_publishers_page_publishers_page_component__WEBPACK_IMPORTED_MODULE_16__.PublishersPageComponent
          });
          break;

        case _page_routes__WEBPACK_IMPORTED_MODULE_21__.PageRoutes.Publisher:
          links.set(_page_routes__WEBPACK_IMPORTED_MODULE_21__.PageRoutes.Publisher, '/' + link);
          routes.push({
            path: link + '/:id',
            pathMatch: 'full',
            component: _pages_publisher_page_publisher_page_component__WEBPACK_IMPORTED_MODULE_15__.PublisherPageComponent
          });
          break;

        case _page_routes__WEBPACK_IMPORTED_MODULE_21__.PageRoutes.DeletePublisher:
          links.set(_page_routes__WEBPACK_IMPORTED_MODULE_21__.PageRoutes.DeletePublisher, '/' + link);
          routes.push({
            path: link + '/:id',
            pathMatch: 'full',
            component: _pages_delete_publisher_page_delete_publisher_page_component__WEBPACK_IMPORTED_MODULE_5__.DeletePublisherPageComponent
          });
          break;

        case _page_routes__WEBPACK_IMPORTED_MODULE_21__.PageRoutes.UpdatePublisher:
          links.set(_page_routes__WEBPACK_IMPORTED_MODULE_21__.PageRoutes.UpdatePublisher, '/' + link);
          routes.push({
            path: link + '/:id',
            pathMatch: 'full',
            component: _pages_update_publisher_page_update_publisher_page_component__WEBPACK_IMPORTED_MODULE_20__.UpdatePublisherPageComponent
          });
          break;

        case _page_routes__WEBPACK_IMPORTED_MODULE_21__.PageRoutes.AddPublisher:
          links.set(_page_routes__WEBPACK_IMPORTED_MODULE_21__.PageRoutes.AddPublisher, '/' + link);
          routes.push({
            path: link,
            pathMatch: 'full',
            component: _pages_update_publisher_page_update_publisher_page_component__WEBPACK_IMPORTED_MODULE_20__.UpdatePublisherPageComponent
          });
          break;

        case _page_routes__WEBPACK_IMPORTED_MODULE_21__.PageRoutes.Basket:
          links.set(_page_routes__WEBPACK_IMPORTED_MODULE_21__.PageRoutes.Basket, '/' + link);
          routes.push({
            path: link,
            pathMatch: 'full',
            component: _pages_basket_page_basket_page_component__WEBPACK_IMPORTED_MODULE_1__.BasketPageComponent
          });
          break;

        case _page_routes__WEBPACK_IMPORTED_MODULE_21__.PageRoutes.Orders:
          links.set(_page_routes__WEBPACK_IMPORTED_MODULE_21__.PageRoutes.Orders, '/' + link);
          routes.push({
            path: link,
            pathMatch: 'full',
            component: _pages_orders_page_orders_page_component__WEBPACK_IMPORTED_MODULE_12__.OrdersPageComponent
          });
          break;

        case _page_routes__WEBPACK_IMPORTED_MODULE_21__.PageRoutes.Order:
          links.set(_page_routes__WEBPACK_IMPORTED_MODULE_21__.PageRoutes.Order, '/' + link);
          routes.push({
            path: link + '/:id',
            pathMatch: 'full',
            component: _pages_order_page_order_page_component__WEBPACK_IMPORTED_MODULE_11__.OrderPageComponent
          });
          break;

        case _page_routes__WEBPACK_IMPORTED_MODULE_21__.PageRoutes.MakeOrder:
          links.set(_page_routes__WEBPACK_IMPORTED_MODULE_21__.PageRoutes.MakeOrder, '/' + link);
          routes.push({
            path: link,
            pathMatch: 'full',
            component: _pages_make_order_page_make_order_page_component__WEBPACK_IMPORTED_MODULE_10__.MakeOrderPageComponent
          });
          break;
      }
    });
    return routes;
  });
  return _resolveRoutesAsync.apply(this, arguments);
}

/***/ }),

/***/ 2614:
/*!**********************************************!*\
  !*** ./src/app/configuration/shared-info.ts ***!
  \**********************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "gameCountSubject": () => (/* binding */ gameCountSubject)
/* harmony export */ });
/* harmony import */ var rxjs__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! rxjs */ 6491);

const gameCountSubject = new rxjs__WEBPACK_IMPORTED_MODULE_0__.BehaviorSubject(null);


/***/ }),

/***/ 2219:
/*!*************************************!*\
  !*** ./src/app/locals/en-labels.ts ***!
  \*************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "EnLabels": () => (/* binding */ EnLabels)
/* harmony export */ });
class EnLabels {
    constructor() {
        this.gamesMenuItem = 'Games';
        this.genresMenuItem = 'Genres';
        this.platformsMenuItem = 'Platforms';
        this.publishersMenuItem = 'Publishers';
        this.ordersMenuItem = 'Orders';
        this.basketMenuItem = 'Basket';
        this.addNewButtonLabel = 'Add';
        this.deleteButtonLabel = 'Delete';
        this.updateButtonLabel = 'Update';
        this.replyButtonLabel = 'Reply';
        this.quoteButtonLabel = 'Quoute';
        this.toPageLabel = 'To Page';
        this.downloadButtonLabel = 'Download';
        this.totalGamesLabel = 'Games count';
        this.saveButtonLabel = 'Save';
        this.buyButtonLabel = 'Buy';
        this.totalLabel = 'Total';
        this.payButtonLabel = 'Pay';
        this.makeOrderButtonLabel = 'Make Order';
        this.banButtonLabel = 'Ban';
        this.banDurationLabel = 'Ban duration';
        this.filterButtonLabel = 'Filter';
        this.gameKeyLabel = 'Key';
        this.gameNameLabel = 'Name';
        this.gameDescriptionLabel = 'Description';
        this.gameDiscountLabel = 'Discount';
        this.gameUnitInStockLabel = 'Unit in Stock';
        this.gamePriceLabel = 'Price';
        this.gameMinPriceLabel = 'Min price';
        this.gameMaxPriceLabel = 'Max price';
        this.gameDatePublishing = 'Date publishing';
        this.publisherCompanyNameLabel = 'Company Name';
        this.publisherDescriptionLabel = 'Description';
        this.publisherHomePageLabel = 'Home Page';
        this.publisherLabel = 'Publisher';
        this.genreNameLabel = 'Name';
        this.genreParentLabel = 'Parent';
        this.genreNestedLabel = 'Nested';
        this.orderCustomerId = 'Customer ID';
        this.orderDate = 'Date';
        this.orderDetailsLabel = 'Order details';
        this.orderDetailsGameLabel = 'Game';
        this.orderDetailsPriceLabel = 'Price';
        this.orderDetailsDiscountLabel = 'Discount';
        this.orderDetailsQuantityLabel = 'Quantity';
        this.platformTypeLabel = 'Type';
        this.deleteMessage = 'Are you sure about deleting?';
        this.enterValidMessage = 'Please enter valid value';
        this.emptyBasketMessage = 'Basket is empty';
        this.banMessage = 'Are you sure about ban?';
    }
}


/***/ }),

/***/ 7266:
/*!************************************************************!*\
  !*** ./src/app/pages/basket-page/basket-page.component.ts ***!
  \************************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "BasketPageComponent": () => (/* binding */ BasketPageComponent)
/* harmony export */ });
/* harmony import */ var rxjs__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! rxjs */ 2720);
/* harmony import */ var rxjs__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! rxjs */ 1134);
/* harmony import */ var rxjs_operators__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! rxjs/operators */ 9902);
/* harmony import */ var rxjs_operators__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! rxjs/operators */ 3927);
/* harmony import */ var src_app_componetns_base_component__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! src/app/componetns/base.component */ 2844);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var src_app_services_order_service__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! src/app/services/order.service */ 8132);
/* harmony import */ var src_app_services_game_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! src/app/services/game.service */ 1397);
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! @angular/common */ 4364);
/* harmony import */ var _angular_material_button__WEBPACK_IMPORTED_MODULE_9__ = __webpack_require__(/*! @angular/material/button */ 781);
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_10__ = __webpack_require__(/*! @angular/router */ 1258);









function BasketPageComponent_div_0_div_1_Template(rf, ctx) { if (rf & 1) {
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementStart"](0, "div", 5);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵtext"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementEnd"]();
} if (rf & 2) {
    const ctx_r1 = _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵnextContext"](2);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵtextInterpolate1"](" ", ctx_r1.labels.emptyBasketMessage, " ");
} }
function BasketPageComponent_div_0_div_2_Template(rf, ctx) { if (rf & 1) {
    const _r6 = _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵgetCurrentView"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementStart"](0, "div", 6);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementStart"](1, "a", 7);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵtext"](2);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementStart"](3, "button", 8);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵlistener"]("click", function BasketPageComponent_div_0_div_2_Template_button_click_3_listener() { const restoredCtx = _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵrestoreView"](_r6); const item_r4 = restoredCtx.$implicit; const ctx_r5 = _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵnextContext"](2); return ctx_r5.cancelBuy(item_r4.game.key); });
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵtext"](4);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementStart"](5, "div", 9);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementStart"](6, "span");
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵtext"](7);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementStart"](8, "span");
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵtext"](9);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementEnd"]();
} if (rf & 2) {
    const item_r4 = ctx.$implicit;
    const ctx_r2 = _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵnextContext"](2);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵpropertyInterpolate"]("routerLink", item_r4.gamePageLink);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵtextInterpolate"](item_r4.game.name);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵadvance"](2);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵtextInterpolate1"](" ", ctx_r2.labels.deleteButtonLabel, " ");
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵadvance"](3);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵtextInterpolate2"]("", ctx_r2.labels.orderDetailsQuantityLabel, ": ", item_r4.details.quantity, "");
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵadvance"](2);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵtextInterpolate2"]("", ctx_r2.labels.orderDetailsPriceLabel, ": ", item_r4.details.price, "");
} }
function BasketPageComponent_div_0_div_3_Template(rf, ctx) { if (rf & 1) {
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementStart"](0, "div");
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementStart"](1, "a", 10);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵtext"](2);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementEnd"]();
} if (rf & 2) {
    const ctx_r3 = _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵnextContext"](2);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵpropertyInterpolate"]("routerLink", ctx_r3.links.get(ctx_r3.pageRoutes.MakeOrder));
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵtextInterpolate"](ctx_r3.labels.makeOrderButtonLabel);
} }
function BasketPageComponent_div_0_Template(rf, ctx) { if (rf & 1) {
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementStart"](0, "div", 1);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵtemplate"](1, BasketPageComponent_div_0_div_1_Template, 2, 1, "div", 2);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵtemplate"](2, BasketPageComponent_div_0_div_2_Template, 10, 7, "div", 3);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵtemplate"](3, BasketPageComponent_div_0_div_3_Template, 3, 2, "div", 4);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementEnd"]();
} if (rf & 2) {
    const ctx_r0 = _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵnextContext"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵproperty"]("ngIf", !ctx_r0.orderInfoList.length);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵproperty"]("ngForOf", ctx_r0.orderInfoList);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵproperty"]("ngIf", !!(ctx_r0.orderInfoList == null ? null : ctx_r0.orderInfoList.length));
} }
class BasketPageComponent extends src_app_componetns_base_component__WEBPACK_IMPORTED_MODULE_0__.BaseComponent {
    constructor(orderService, gameService) {
        super();
        this.orderService = orderService;
        this.gameService = gameService;
    }
    ngOnInit() {
        this.refreshBasketItems();
    }
    refreshBasketItems() {
        this.orderService
            .getBasket()
            .pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_4__.switchMap)((x) => (0,rxjs__WEBPACK_IMPORTED_MODULE_5__.forkJoin)(!!x.length
            ? x.map((z) => this.gameService.getGameById(z.productId).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_6__.map)((y) => {
                return { orderDetail: z, game: y };
            })))
            : (0,rxjs__WEBPACK_IMPORTED_MODULE_7__.of)([]))))
            .subscribe((x) => {
            this.addDetailsInfo(x);
        });
    }
    addDetailsInfo(details) {
        this.orderInfoList = [];
        if (!(details === null || details === void 0 ? void 0 : details.length)) {
            return;
        }
        details.forEach((x) => {
            var _a, _b;
            if (!((_a = x === null || x === void 0 ? void 0 : x.game) === null || _a === void 0 ? void 0 : _a.key)) {
                return;
            }
            (_b = this.orderInfoList) === null || _b === void 0 ? void 0 : _b.push({
                game: x.game,
                details: x.orderDetail,
                gamePageLink: `${this.links.get(this.pageRoutes.Game)}/${x.game.key}`,
            });
        });
    }
    cancelBuy(gameKey) {
        this.orderService
            .cancelGameBuy(gameKey)
            .subscribe((_) => this.refreshBasketItems());
    }
}
BasketPageComponent.ɵfac = function BasketPageComponent_Factory(t) { return new (t || BasketPageComponent)(_angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵdirectiveInject"](src_app_services_order_service__WEBPACK_IMPORTED_MODULE_1__.OrderService), _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵdirectiveInject"](src_app_services_game_service__WEBPACK_IMPORTED_MODULE_2__.GameService)); };
BasketPageComponent.ɵcmp = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵdefineComponent"]({ type: BasketPageComponent, selectors: [["gamestore-basket"]], features: [_angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵInheritDefinitionFeature"]], decls: 1, vars: 1, consts: [["class", "basket-container", 4, "ngIf"], [1, "basket-container"], ["class", "empty-basket", 4, "ngIf"], ["class", "basket-item", 4, "ngFor", "ngForOf"], [4, "ngIf"], [1, "empty-basket"], [1, "basket-item"], ["mat-button", "", 3, "routerLink"], ["mat-stroked-button", "", "color", "accent", "type", "button", 3, "click"], [1, "basket-item-info"], ["mat-raised-button", "", "color", "primary", 3, "routerLink"]], template: function BasketPageComponent_Template(rf, ctx) { if (rf & 1) {
        _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵtemplate"](0, BasketPageComponent_div_0_Template, 4, 3, "div", 0);
    } if (rf & 2) {
        _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵproperty"]("ngIf", !!ctx.orderInfoList);
    } }, directives: [_angular_common__WEBPACK_IMPORTED_MODULE_8__.NgIf, _angular_common__WEBPACK_IMPORTED_MODULE_8__.NgForOf, _angular_material_button__WEBPACK_IMPORTED_MODULE_9__.MatAnchor, _angular_router__WEBPACK_IMPORTED_MODULE_10__.RouterLinkWithHref, _angular_material_button__WEBPACK_IMPORTED_MODULE_9__.MatButton], styles: [".basket-container[_ngcontent-%COMP%] {\n  padding: 15px;\n}\n.basket-container[_ngcontent-%COMP%]   .empty-basket[_ngcontent-%COMP%] {\n  text-align: center;\n  font-size: 20px;\n}\n.basket-container[_ngcontent-%COMP%]   .basket-item[_ngcontent-%COMP%] {\n  margin-bottom: 10px;\n  margin-top: 10px;\n}\n.basket-container[_ngcontent-%COMP%]   .basket-item[_ngcontent-%COMP%]   .basket-item-info[_ngcontent-%COMP%] {\n  padding-top: 7px;\n}\n.basket-container[_ngcontent-%COMP%]   .basket-item[_ngcontent-%COMP%]   .basket-item-info[_ngcontent-%COMP%]   span[_ngcontent-%COMP%] {\n  padding-left: 15px;\n}\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbImJhc2tldC1wYWdlLmNvbXBvbmVudC5zY3NzIl0sIm5hbWVzIjpbXSwibWFwcGluZ3MiOiJBQUFBO0VBQ0ksYUFBQTtBQUNKO0FBQ0k7RUFDSSxrQkFBQTtFQUNBLGVBQUE7QUFDUjtBQUVJO0VBQ0ksbUJBQUE7RUFDQSxnQkFBQTtBQUFSO0FBRVE7RUFDSSxnQkFBQTtBQUFaO0FBRVk7RUFDSSxrQkFBQTtBQUFoQiIsImZpbGUiOiJiYXNrZXQtcGFnZS5jb21wb25lbnQuc2NzcyIsInNvdXJjZXNDb250ZW50IjpbIi5iYXNrZXQtY29udGFpbmVye1xyXG4gICAgcGFkZGluZzogMTVweDtcclxuXHJcbiAgICAuZW1wdHktYmFza2V0IHtcclxuICAgICAgICB0ZXh0LWFsaWduOiBjZW50ZXI7XHJcbiAgICAgICAgZm9udC1zaXplOiAyMHB4O1xyXG4gICAgfVxyXG5cclxuICAgIC5iYXNrZXQtaXRlbSB7XHJcbiAgICAgICAgbWFyZ2luLWJvdHRvbTogMTBweDtcclxuICAgICAgICBtYXJnaW4tdG9wOiAxMHB4O1xyXG5cclxuICAgICAgICAuYmFza2V0LWl0ZW0taW5mbyB7XHJcbiAgICAgICAgICAgIHBhZGRpbmctdG9wOiA3cHg7XHJcblxyXG4gICAgICAgICAgICBzcGFuIHtcclxuICAgICAgICAgICAgICAgIHBhZGRpbmctbGVmdDogMTVweDtcclxuICAgICAgICAgICAgfVxyXG4gICAgICAgIH1cclxuICAgIH1cclxufSJdfQ== */"] });


/***/ }),

/***/ 6323:
/*!*********************************************************!*\
  !*** ./src/app/pages/basket-page/basket-page.module.ts ***!
  \*********************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "BasketPageModule": () => (/* binding */ BasketPageModule)
/* harmony export */ });
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! @angular/common */ 4364);
/* harmony import */ var src_app_componetns_common_components_module__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! src/app/componetns/common-components.module */ 1951);
/* harmony import */ var src_app_app_routing_module__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! src/app/app-routing.module */ 158);
/* harmony import */ var _angular_material_button__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! @angular/material/button */ 781);
/* harmony import */ var src_app_services_game_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! src/app/services/game.service */ 1397);
/* harmony import */ var src_app_services_order_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! src/app/services/order.service */ 8132);
/* harmony import */ var _basket_page_component__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ./basket-page.component */ 7266);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/core */ 2316);








class BasketPageModule {
}
BasketPageModule.ɵfac = function BasketPageModule_Factory(t) { return new (t || BasketPageModule)(); };
BasketPageModule.ɵmod = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_5__["ɵɵdefineNgModule"]({ type: BasketPageModule });
BasketPageModule.ɵinj = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_5__["ɵɵdefineInjector"]({ providers: [src_app_services_order_service__WEBPACK_IMPORTED_MODULE_3__.OrderService, src_app_services_game_service__WEBPACK_IMPORTED_MODULE_2__.GameService, _angular_common__WEBPACK_IMPORTED_MODULE_6__.DatePipe], imports: [[
            _angular_common__WEBPACK_IMPORTED_MODULE_6__.CommonModule,
            src_app_componetns_common_components_module__WEBPACK_IMPORTED_MODULE_0__.CommonComponentsModule,
            src_app_app_routing_module__WEBPACK_IMPORTED_MODULE_1__.AppRoutingModule,
            _angular_material_button__WEBPACK_IMPORTED_MODULE_7__.MatButtonModule,
        ]] });
(function () { (typeof ngJitMode === "undefined" || ngJitMode) && _angular_core__WEBPACK_IMPORTED_MODULE_5__["ɵɵsetNgModuleScope"](BasketPageModule, { declarations: [_basket_page_component__WEBPACK_IMPORTED_MODULE_4__.BasketPageComponent], imports: [_angular_common__WEBPACK_IMPORTED_MODULE_6__.CommonModule,
        src_app_componetns_common_components_module__WEBPACK_IMPORTED_MODULE_0__.CommonComponentsModule,
        src_app_app_routing_module__WEBPACK_IMPORTED_MODULE_1__.AppRoutingModule,
        _angular_material_button__WEBPACK_IMPORTED_MODULE_7__.MatButtonModule] }); })();


/***/ }),

/***/ 9217:
/*!**********************************************************************!*\
  !*** ./src/app/pages/delete-game-page/delete-game-page.component.ts ***!
  \**********************************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "DeleteGamePageComponent": () => (/* binding */ DeleteGamePageComponent)
/* harmony export */ });
/* harmony import */ var rxjs_operators__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! rxjs/operators */ 9902);
/* harmony import */ var src_app_componetns_base_component__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! src/app/componetns/base.component */ 2844);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var src_app_services_game_service__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! src/app/services/game.service */ 1397);
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/router */ 1258);





function DeleteGamePageComponent_article_0_Template(rf, ctx) { if (rf & 1) {
    const _r2 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵgetCurrentView"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](0, "article");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](1, "gamestore-delete-wrapper", 1);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵlistener"]("delete", function DeleteGamePageComponent_article_0_Template_gamestore_delete_wrapper_delete_1_listener() { _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵrestoreView"](_r2); const ctx_r1 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵnextContext"](); return ctx_r1.onDelete(); });
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
} if (rf & 2) {
    const ctx_r0 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵnextContext"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵproperty"]("name", ctx_r0.game.name)("pageLink", ctx_r0.gamePageLink);
} }
class DeleteGamePageComponent extends src_app_componetns_base_component__WEBPACK_IMPORTED_MODULE_0__.BaseComponent {
    constructor(gameService, route, router) {
        super();
        this.gameService = gameService;
        this.route = route;
        this.router = router;
    }
    get gamePageLink() {
        return !!this.game ? `${this.links.get(this.pageRoutes.Game)}/${this.game.key}` : undefined;
    }
    ngOnInit() {
        this.getRouteParam(this.route, 'key')
            .pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_3__.switchMap)((key) => this.gameService.getGame(key)))
            .subscribe((x) => (this.game = x));
    }
    onDelete() {
        this.gameService
            .deleteGame(this.game.key)
            .subscribe((_) => { var _a; return this.router.navigateByUrl((_a = this.links.get(this.pageRoutes.Games)) !== null && _a !== void 0 ? _a : ''); });
    }
}
DeleteGamePageComponent.ɵfac = function DeleteGamePageComponent_Factory(t) { return new (t || DeleteGamePageComponent)(_angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵdirectiveInject"](src_app_services_game_service__WEBPACK_IMPORTED_MODULE_1__.GameService), _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵdirectiveInject"](_angular_router__WEBPACK_IMPORTED_MODULE_4__.ActivatedRoute), _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵdirectiveInject"](_angular_router__WEBPACK_IMPORTED_MODULE_4__.Router)); };
DeleteGamePageComponent.ɵcmp = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵdefineComponent"]({ type: DeleteGamePageComponent, selectors: [["gamestore-delete-game"]], features: [_angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵInheritDefinitionFeature"]], decls: 1, vars: 1, consts: [[4, "ngIf"], [3, "name", "pageLink", "delete"]], template: function DeleteGamePageComponent_Template(rf, ctx) { if (rf & 1) {
        _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtemplate"](0, DeleteGamePageComponent_article_0_Template, 2, 2, "article", 0);
    } if (rf & 2) {
        _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵproperty"]("ngIf", !!ctx.game);
    } }, styles: ["\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJkZWxldGUtZ2FtZS1wYWdlLmNvbXBvbmVudC5zY3NzIn0= */"] });


/***/ }),

/***/ 4811:
/*!*******************************************************************!*\
  !*** ./src/app/pages/delete-game-page/delete-game-page.module.ts ***!
  \*******************************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "DeleteGamePageModule": () => (/* binding */ DeleteGamePageModule)
/* harmony export */ });
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/common */ 4364);
/* harmony import */ var src_app_componetns_common_components_module__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! src/app/componetns/common-components.module */ 1951);
/* harmony import */ var src_app_services_game_service__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! src/app/services/game.service */ 1397);
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! @angular/forms */ 1707);
/* harmony import */ var _delete_game_page_component__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./delete-game-page.component */ 9217);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var _componetns_delete_wrapper_component_delete_wrapper_component__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../../componetns/delete-wrapper-component/delete-wrapper.component */ 2303);








class DeleteGamePageModule {
}
DeleteGamePageModule.ɵfac = function DeleteGamePageModule_Factory(t) { return new (t || DeleteGamePageModule)(); };
DeleteGamePageModule.ɵmod = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵdefineNgModule"]({ type: DeleteGamePageModule });
DeleteGamePageModule.ɵinj = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵdefineInjector"]({ providers: [src_app_services_game_service__WEBPACK_IMPORTED_MODULE_1__.GameService], imports: [[_angular_common__WEBPACK_IMPORTED_MODULE_5__.CommonModule, src_app_componetns_common_components_module__WEBPACK_IMPORTED_MODULE_0__.CommonComponentsModule, _angular_forms__WEBPACK_IMPORTED_MODULE_6__.ReactiveFormsModule]] });
(function () { (typeof ngJitMode === "undefined" || ngJitMode) && _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵsetNgModuleScope"](DeleteGamePageModule, { declarations: [_delete_game_page_component__WEBPACK_IMPORTED_MODULE_2__.DeleteGamePageComponent], imports: [_angular_common__WEBPACK_IMPORTED_MODULE_5__.CommonModule, src_app_componetns_common_components_module__WEBPACK_IMPORTED_MODULE_0__.CommonComponentsModule, _angular_forms__WEBPACK_IMPORTED_MODULE_6__.ReactiveFormsModule] }); })();
_angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵsetComponentScope"](_delete_game_page_component__WEBPACK_IMPORTED_MODULE_2__.DeleteGamePageComponent, [_angular_common__WEBPACK_IMPORTED_MODULE_5__.NgIf, _componetns_delete_wrapper_component_delete_wrapper_component__WEBPACK_IMPORTED_MODULE_3__.DeleteWrapperComponent], []);


/***/ }),

/***/ 7717:
/*!************************************************************************!*\
  !*** ./src/app/pages/delete-genre-page/delete-genre-page.component.ts ***!
  \************************************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "DeleteGenrePageComponent": () => (/* binding */ DeleteGenrePageComponent)
/* harmony export */ });
/* harmony import */ var rxjs_operators__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! rxjs/operators */ 9902);
/* harmony import */ var src_app_componetns_base_component__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! src/app/componetns/base.component */ 2844);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var src_app_services_genre_service__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! src/app/services/genre.service */ 7776);
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/router */ 1258);





function DeleteGenrePageComponent_article_0_Template(rf, ctx) { if (rf & 1) {
    const _r2 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵgetCurrentView"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](0, "article");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](1, "gamestore-delete-wrapper", 1);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵlistener"]("delete", function DeleteGenrePageComponent_article_0_Template_gamestore_delete_wrapper_delete_1_listener() { _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵrestoreView"](_r2); const ctx_r1 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵnextContext"](); return ctx_r1.onDelete(); });
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
} if (rf & 2) {
    const ctx_r0 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵnextContext"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵproperty"]("name", ctx_r0.genre.name)("pageLink", ctx_r0.genrePageLink);
} }
class DeleteGenrePageComponent extends src_app_componetns_base_component__WEBPACK_IMPORTED_MODULE_0__.BaseComponent {
    constructor(genreService, route, router) {
        super();
        this.genreService = genreService;
        this.route = route;
        this.router = router;
    }
    get genrePageLink() {
        return !!this.genre ? `${this.links.get(this.pageRoutes.Genre)}/${this.genre.id}` : undefined;
    }
    ngOnInit() {
        this.getRouteParam(this.route, 'id')
            .pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_3__.switchMap)((id) => this.genreService.getGenre(id)))
            .subscribe((x) => (this.genre = x));
    }
    onDelete() {
        var _a;
        this.genreService
            .deleteGenre((_a = this.genre.id) !== null && _a !== void 0 ? _a : '')
            .subscribe((_) => { var _a; return this.router.navigateByUrl((_a = this.links.get(this.pageRoutes.Genres)) !== null && _a !== void 0 ? _a : ''); });
    }
}
DeleteGenrePageComponent.ɵfac = function DeleteGenrePageComponent_Factory(t) { return new (t || DeleteGenrePageComponent)(_angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵdirectiveInject"](src_app_services_genre_service__WEBPACK_IMPORTED_MODULE_1__.GenreService), _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵdirectiveInject"](_angular_router__WEBPACK_IMPORTED_MODULE_4__.ActivatedRoute), _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵdirectiveInject"](_angular_router__WEBPACK_IMPORTED_MODULE_4__.Router)); };
DeleteGenrePageComponent.ɵcmp = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵdefineComponent"]({ type: DeleteGenrePageComponent, selectors: [["gamestore-delete-genre"]], features: [_angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵInheritDefinitionFeature"]], decls: 1, vars: 1, consts: [[4, "ngIf"], [3, "name", "pageLink", "delete"]], template: function DeleteGenrePageComponent_Template(rf, ctx) { if (rf & 1) {
        _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtemplate"](0, DeleteGenrePageComponent_article_0_Template, 2, 2, "article", 0);
    } if (rf & 2) {
        _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵproperty"]("ngIf", !!ctx.genre);
    } }, styles: ["\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJkZWxldGUtZ2VucmUtcGFnZS5jb21wb25lbnQuc2NzcyJ9 */"] });


/***/ }),

/***/ 5432:
/*!*********************************************************************!*\
  !*** ./src/app/pages/delete-genre-page/delete-genre-page.module.ts ***!
  \*********************************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "DeleteGenrePageModule": () => (/* binding */ DeleteGenrePageModule)
/* harmony export */ });
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/common */ 4364);
/* harmony import */ var src_app_componetns_common_components_module__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! src/app/componetns/common-components.module */ 1951);
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! @angular/forms */ 1707);
/* harmony import */ var _delete_genre_page_component__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./delete-genre-page.component */ 7717);
/* harmony import */ var src_app_services_genre_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! src/app/services/genre.service */ 7776);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var _componetns_delete_wrapper_component_delete_wrapper_component__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../../componetns/delete-wrapper-component/delete-wrapper.component */ 2303);








class DeleteGenrePageModule {
}
DeleteGenrePageModule.ɵfac = function DeleteGenrePageModule_Factory(t) { return new (t || DeleteGenrePageModule)(); };
DeleteGenrePageModule.ɵmod = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵdefineNgModule"]({ type: DeleteGenrePageModule });
DeleteGenrePageModule.ɵinj = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵdefineInjector"]({ providers: [src_app_services_genre_service__WEBPACK_IMPORTED_MODULE_2__.GenreService], imports: [[_angular_common__WEBPACK_IMPORTED_MODULE_5__.CommonModule, src_app_componetns_common_components_module__WEBPACK_IMPORTED_MODULE_0__.CommonComponentsModule, _angular_forms__WEBPACK_IMPORTED_MODULE_6__.ReactiveFormsModule]] });
(function () { (typeof ngJitMode === "undefined" || ngJitMode) && _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵsetNgModuleScope"](DeleteGenrePageModule, { declarations: [_delete_genre_page_component__WEBPACK_IMPORTED_MODULE_1__.DeleteGenrePageComponent], imports: [_angular_common__WEBPACK_IMPORTED_MODULE_5__.CommonModule, src_app_componetns_common_components_module__WEBPACK_IMPORTED_MODULE_0__.CommonComponentsModule, _angular_forms__WEBPACK_IMPORTED_MODULE_6__.ReactiveFormsModule] }); })();
_angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵsetComponentScope"](_delete_genre_page_component__WEBPACK_IMPORTED_MODULE_1__.DeleteGenrePageComponent, [_angular_common__WEBPACK_IMPORTED_MODULE_5__.NgIf, _componetns_delete_wrapper_component_delete_wrapper_component__WEBPACK_IMPORTED_MODULE_3__.DeleteWrapperComponent], []);


/***/ }),

/***/ 7974:
/*!*****************************************************************************!*\
  !*** ./src/app/pages/delete-patform-page/delete-platform-page.component.ts ***!
  \*****************************************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "DeletePlatformPageComponent": () => (/* binding */ DeletePlatformPageComponent)
/* harmony export */ });
/* harmony import */ var rxjs_operators__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! rxjs/operators */ 9902);
/* harmony import */ var src_app_componetns_base_component__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! src/app/componetns/base.component */ 2844);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var src_app_services_platform_service__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! src/app/services/platform.service */ 8634);
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/router */ 1258);





function DeletePlatformPageComponent_article_0_Template(rf, ctx) { if (rf & 1) {
    const _r2 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵgetCurrentView"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](0, "article");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](1, "gamestore-delete-wrapper", 1);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵlistener"]("delete", function DeletePlatformPageComponent_article_0_Template_gamestore_delete_wrapper_delete_1_listener() { _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵrestoreView"](_r2); const ctx_r1 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵnextContext"](); return ctx_r1.onDelete(); });
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
} if (rf & 2) {
    const ctx_r0 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵnextContext"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵproperty"]("name", ctx_r0.platform.type)("pageLink", ctx_r0.platformPageLink);
} }
class DeletePlatformPageComponent extends src_app_componetns_base_component__WEBPACK_IMPORTED_MODULE_0__.BaseComponent {
    constructor(platformService, route, router) {
        super();
        this.platformService = platformService;
        this.route = route;
        this.router = router;
    }
    get platformPageLink() {
        return !!this.platform ? `${this.links.get(this.pageRoutes.Platform)}/${this.platform.id}` : undefined;
    }
    ngOnInit() {
        this.getRouteParam(this.route, 'id')
            .pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_3__.switchMap)((id) => this.platformService.getPlatform(id)))
            .subscribe((x) => (this.platform = x));
    }
    onDelete() {
        var _a;
        this.platformService
            .deletePlatform((_a = this.platform.id) !== null && _a !== void 0 ? _a : '')
            .subscribe((_) => { var _a; return this.router.navigateByUrl((_a = this.links.get(this.pageRoutes.Platforms)) !== null && _a !== void 0 ? _a : ''); });
    }
}
DeletePlatformPageComponent.ɵfac = function DeletePlatformPageComponent_Factory(t) { return new (t || DeletePlatformPageComponent)(_angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵdirectiveInject"](src_app_services_platform_service__WEBPACK_IMPORTED_MODULE_1__.PlatformService), _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵdirectiveInject"](_angular_router__WEBPACK_IMPORTED_MODULE_4__.ActivatedRoute), _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵdirectiveInject"](_angular_router__WEBPACK_IMPORTED_MODULE_4__.Router)); };
DeletePlatformPageComponent.ɵcmp = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵdefineComponent"]({ type: DeletePlatformPageComponent, selectors: [["gamestore-delete-platform"]], features: [_angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵInheritDefinitionFeature"]], decls: 1, vars: 1, consts: [[4, "ngIf"], [3, "name", "pageLink", "delete"]], template: function DeletePlatformPageComponent_Template(rf, ctx) { if (rf & 1) {
        _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtemplate"](0, DeletePlatformPageComponent_article_0_Template, 2, 2, "article", 0);
    } if (rf & 2) {
        _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵproperty"]("ngIf", !!ctx.platform);
    } }, styles: ["\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJkZWxldGUtcGxhdGZvcm0tcGFnZS5jb21wb25lbnQuc2NzcyJ9 */"] });


/***/ }),

/***/ 5883:
/*!**************************************************************************!*\
  !*** ./src/app/pages/delete-patform-page/delete-platform-page.module.ts ***!
  \**************************************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "DeletePlatformPageModule": () => (/* binding */ DeletePlatformPageModule)
/* harmony export */ });
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/common */ 4364);
/* harmony import */ var src_app_componetns_common_components_module__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! src/app/componetns/common-components.module */ 1951);
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! @angular/forms */ 1707);
/* harmony import */ var src_app_services_platform_service__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! src/app/services/platform.service */ 8634);
/* harmony import */ var _delete_platform_page_component__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./delete-platform-page.component */ 7974);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var _componetns_delete_wrapper_component_delete_wrapper_component__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../../componetns/delete-wrapper-component/delete-wrapper.component */ 2303);








class DeletePlatformPageModule {
}
DeletePlatformPageModule.ɵfac = function DeletePlatformPageModule_Factory(t) { return new (t || DeletePlatformPageModule)(); };
DeletePlatformPageModule.ɵmod = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵdefineNgModule"]({ type: DeletePlatformPageModule });
DeletePlatformPageModule.ɵinj = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵdefineInjector"]({ providers: [src_app_services_platform_service__WEBPACK_IMPORTED_MODULE_1__.PlatformService], imports: [[_angular_common__WEBPACK_IMPORTED_MODULE_5__.CommonModule, src_app_componetns_common_components_module__WEBPACK_IMPORTED_MODULE_0__.CommonComponentsModule, _angular_forms__WEBPACK_IMPORTED_MODULE_6__.ReactiveFormsModule]] });
(function () { (typeof ngJitMode === "undefined" || ngJitMode) && _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵsetNgModuleScope"](DeletePlatformPageModule, { declarations: [_delete_platform_page_component__WEBPACK_IMPORTED_MODULE_2__.DeletePlatformPageComponent], imports: [_angular_common__WEBPACK_IMPORTED_MODULE_5__.CommonModule, src_app_componetns_common_components_module__WEBPACK_IMPORTED_MODULE_0__.CommonComponentsModule, _angular_forms__WEBPACK_IMPORTED_MODULE_6__.ReactiveFormsModule] }); })();
_angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵsetComponentScope"](_delete_platform_page_component__WEBPACK_IMPORTED_MODULE_2__.DeletePlatformPageComponent, [_angular_common__WEBPACK_IMPORTED_MODULE_5__.NgIf, _componetns_delete_wrapper_component_delete_wrapper_component__WEBPACK_IMPORTED_MODULE_3__.DeleteWrapperComponent], []);


/***/ }),

/***/ 8814:
/*!********************************************************************************!*\
  !*** ./src/app/pages/delete-publisher-page/delete-publisher-page.component.ts ***!
  \********************************************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "DeletePublisherPageComponent": () => (/* binding */ DeletePublisherPageComponent)
/* harmony export */ });
/* harmony import */ var rxjs_operators__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! rxjs/operators */ 9902);
/* harmony import */ var src_app_componetns_base_component__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! src/app/componetns/base.component */ 2844);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var src_app_services_publisher_service__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! src/app/services/publisher.service */ 7441);
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/router */ 1258);





function DeletePublisherPageComponent_article_0_Template(rf, ctx) { if (rf & 1) {
    const _r2 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵgetCurrentView"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](0, "article");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](1, "gamestore-delete-wrapper", 1);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵlistener"]("delete", function DeletePublisherPageComponent_article_0_Template_gamestore_delete_wrapper_delete_1_listener() { _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵrestoreView"](_r2); const ctx_r1 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵnextContext"](); return ctx_r1.onDelete(); });
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
} if (rf & 2) {
    const ctx_r0 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵnextContext"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵproperty"]("name", ctx_r0.publisher.companyName)("pageLink", ctx_r0.publisherPageLink);
} }
class DeletePublisherPageComponent extends src_app_componetns_base_component__WEBPACK_IMPORTED_MODULE_0__.BaseComponent {
    constructor(publisherService, route, router) {
        super();
        this.publisherService = publisherService;
        this.route = route;
        this.router = router;
    }
    get publisherPageLink() {
        return !!this.publisher ? `${this.links.get(this.pageRoutes.Publisher)}/${this.publisher.companyName}` : undefined;
    }
    ngOnInit() {
        this.getRouteParam(this.route, 'id')
            .pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_3__.switchMap)((companyName) => this.publisherService.getPublisher(companyName)))
            .subscribe((x) => (this.publisher = x));
    }
    onDelete() {
        var _a;
        this.publisherService
            .deletePublisher((_a = this.publisher.id) !== null && _a !== void 0 ? _a : '')
            .subscribe((_) => { var _a; return this.router.navigateByUrl((_a = this.links.get(this.pageRoutes.Publishers)) !== null && _a !== void 0 ? _a : ''); });
    }
}
DeletePublisherPageComponent.ɵfac = function DeletePublisherPageComponent_Factory(t) { return new (t || DeletePublisherPageComponent)(_angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵdirectiveInject"](src_app_services_publisher_service__WEBPACK_IMPORTED_MODULE_1__.PublisherService), _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵdirectiveInject"](_angular_router__WEBPACK_IMPORTED_MODULE_4__.ActivatedRoute), _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵdirectiveInject"](_angular_router__WEBPACK_IMPORTED_MODULE_4__.Router)); };
DeletePublisherPageComponent.ɵcmp = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵdefineComponent"]({ type: DeletePublisherPageComponent, selectors: [["gamestore-delete-publisher"]], features: [_angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵInheritDefinitionFeature"]], decls: 1, vars: 1, consts: [[4, "ngIf"], [3, "name", "pageLink", "delete"]], template: function DeletePublisherPageComponent_Template(rf, ctx) { if (rf & 1) {
        _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtemplate"](0, DeletePublisherPageComponent_article_0_Template, 2, 2, "article", 0);
    } if (rf & 2) {
        _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵproperty"]("ngIf", !!ctx.publisher);
    } }, styles: ["\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJkZWxldGUtcHVibGlzaGVyLXBhZ2UuY29tcG9uZW50LnNjc3MifQ== */"] });


/***/ }),

/***/ 491:
/*!*****************************************************************************!*\
  !*** ./src/app/pages/delete-publisher-page/delete-publisher-page.module.ts ***!
  \*****************************************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "DeletePublisherPageModule": () => (/* binding */ DeletePublisherPageModule)
/* harmony export */ });
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/common */ 4364);
/* harmony import */ var src_app_componetns_common_components_module__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! src/app/componetns/common-components.module */ 1951);
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! @angular/forms */ 1707);
/* harmony import */ var _delete_publisher_page_component__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./delete-publisher-page.component */ 8814);
/* harmony import */ var src_app_services_publisher_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! src/app/services/publisher.service */ 7441);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var _componetns_delete_wrapper_component_delete_wrapper_component__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../../componetns/delete-wrapper-component/delete-wrapper.component */ 2303);








class DeletePublisherPageModule {
}
DeletePublisherPageModule.ɵfac = function DeletePublisherPageModule_Factory(t) { return new (t || DeletePublisherPageModule)(); };
DeletePublisherPageModule.ɵmod = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵdefineNgModule"]({ type: DeletePublisherPageModule });
DeletePublisherPageModule.ɵinj = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵdefineInjector"]({ providers: [src_app_services_publisher_service__WEBPACK_IMPORTED_MODULE_2__.PublisherService], imports: [[_angular_common__WEBPACK_IMPORTED_MODULE_5__.CommonModule, src_app_componetns_common_components_module__WEBPACK_IMPORTED_MODULE_0__.CommonComponentsModule, _angular_forms__WEBPACK_IMPORTED_MODULE_6__.ReactiveFormsModule]] });
(function () { (typeof ngJitMode === "undefined" || ngJitMode) && _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵsetNgModuleScope"](DeletePublisherPageModule, { declarations: [_delete_publisher_page_component__WEBPACK_IMPORTED_MODULE_1__.DeletePublisherPageComponent], imports: [_angular_common__WEBPACK_IMPORTED_MODULE_5__.CommonModule, src_app_componetns_common_components_module__WEBPACK_IMPORTED_MODULE_0__.CommonComponentsModule, _angular_forms__WEBPACK_IMPORTED_MODULE_6__.ReactiveFormsModule] }); })();
_angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵsetComponentScope"](_delete_publisher_page_component__WEBPACK_IMPORTED_MODULE_1__.DeletePublisherPageComponent, [_angular_common__WEBPACK_IMPORTED_MODULE_5__.NgIf, _componetns_delete_wrapper_component_delete_wrapper_component__WEBPACK_IMPORTED_MODULE_3__.DeleteWrapperComponent], []);


/***/ }),

/***/ 3448:
/*!*******************************************************************************************!*\
  !*** ./src/app/pages/game-page/components/add-comment-component/add-comment.component.ts ***!
  \*******************************************************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "AddCommentComponent": () => (/* binding */ AddCommentComponent)
/* harmony export */ });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_11__ = __webpack_require__(/*! tslib */ 3786);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! @angular/forms */ 1707);
/* harmony import */ var _ngneat_until_destroy__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! @ngneat/until-destroy */ 9758);
/* harmony import */ var rxjs__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! rxjs */ 9441);
/* harmony import */ var src_app_componetns_base_component__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! src/app/componetns/base.component */ 2844);
/* harmony import */ var _comment_component_comment_action__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../comment-component/comment-action */ 4232);
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_9__ = __webpack_require__(/*! @angular/common */ 4364);
/* harmony import */ var _angular_material_button__WEBPACK_IMPORTED_MODULE_10__ = __webpack_require__(/*! @angular/material/button */ 781);
/* harmony import */ var _componetns_form_component_form_component__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../../../../componetns/form-component/form.component */ 8205);
/* harmony import */ var _componetns_text_input_component_text_input_component__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../../../../componetns/text-input-component/text-input.component */ 2082);
/* harmony import */ var _componetns_textarea_input_component_textarea_input_component__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ../../../../componetns/textarea-input-component/textarea-input.component */ 3281);














function AddCommentComponent_div_1_Template(rf, ctx) { if (rf & 1) {
    const _r3 = _angular_core__WEBPACK_IMPORTED_MODULE_5__["ɵɵgetCurrentView"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_5__["ɵɵelementStart"](0, "div");
    _angular_core__WEBPACK_IMPORTED_MODULE_5__["ɵɵtext"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_5__["ɵɵelementStart"](2, "button", 2);
    _angular_core__WEBPACK_IMPORTED_MODULE_5__["ɵɵlistener"]("click", function AddCommentComponent_div_1_Template_button_click_2_listener() { _angular_core__WEBPACK_IMPORTED_MODULE_5__["ɵɵrestoreView"](_r3); const ctx_r2 = _angular_core__WEBPACK_IMPORTED_MODULE_5__["ɵɵnextContext"](); return ctx_r2.selectCancel.emit(); });
    _angular_core__WEBPACK_IMPORTED_MODULE_5__["ɵɵtext"](3, "X");
    _angular_core__WEBPACK_IMPORTED_MODULE_5__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_5__["ɵɵelementEnd"]();
} if (rf & 2) {
    const ctx_r0 = _angular_core__WEBPACK_IMPORTED_MODULE_5__["ɵɵnextContext"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_5__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_5__["ɵɵtextInterpolate2"](" ", ctx_r0.actionLabel, ": ", ctx_r0.currentCommentValue.name, " ");
} }
function AddCommentComponent_div_2_Template(rf, ctx) { if (rf & 1) {
    const _r5 = _angular_core__WEBPACK_IMPORTED_MODULE_5__["ɵɵgetCurrentView"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_5__["ɵɵelementStart"](0, "div");
    _angular_core__WEBPACK_IMPORTED_MODULE_5__["ɵɵelementStart"](1, "gamestore-form", 3);
    _angular_core__WEBPACK_IMPORTED_MODULE_5__["ɵɵlistener"]("save", function AddCommentComponent_div_2_Template_gamestore_form_save_1_listener() { _angular_core__WEBPACK_IMPORTED_MODULE_5__["ɵɵrestoreView"](_r5); const ctx_r4 = _angular_core__WEBPACK_IMPORTED_MODULE_5__["ɵɵnextContext"](); return ctx_r4.onSave(); });
    _angular_core__WEBPACK_IMPORTED_MODULE_5__["ɵɵelement"](2, "gamestore-text-input", 4);
    _angular_core__WEBPACK_IMPORTED_MODULE_5__["ɵɵelement"](3, "gamestore-textarea-input", 4);
    _angular_core__WEBPACK_IMPORTED_MODULE_5__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_5__["ɵɵelementEnd"]();
} if (rf & 2) {
    const ctx_r1 = _angular_core__WEBPACK_IMPORTED_MODULE_5__["ɵɵnextContext"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_5__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_5__["ɵɵproperty"]("form", ctx_r1.form);
    _angular_core__WEBPACK_IMPORTED_MODULE_5__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_5__["ɵɵproperty"]("control", ctx_r1.getFormControl("name"))("disableValidation", true);
    _angular_core__WEBPACK_IMPORTED_MODULE_5__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_5__["ɵɵproperty"]("control", ctx_r1.getFormControl("body"))("disableValidation", true);
} }
let AddCommentComponent = class AddCommentComponent extends src_app_componetns_base_component__WEBPACK_IMPORTED_MODULE_0__.BaseComponent {
    constructor(builder) {
        super();
        this.builder = builder;
        this.clearForm = new rxjs__WEBPACK_IMPORTED_MODULE_6__.Subject();
        this.selectCancel = new _angular_core__WEBPACK_IMPORTED_MODULE_5__.EventEmitter();
        this.saveComment = new _angular_core__WEBPACK_IMPORTED_MODULE_5__.EventEmitter();
    }
    set currentComment(value) {
        this.action = value === null || value === void 0 ? void 0 : value.action;
        this.currentCommentValue = value === null || value === void 0 ? void 0 : value.comment;
        this.createForm();
    }
    get actionLabel() {
        switch (this.action) {
            case _comment_component_comment_action__WEBPACK_IMPORTED_MODULE_1__.CommentAction.Reply:
                return this.labels.replyButtonLabel;
            case _comment_component_comment_action__WEBPACK_IMPORTED_MODULE_1__.CommentAction.Quote:
                return this.labels.quoteButtonLabel;
            default:
                return '';
        }
    }
    ngOnInit() {
        this.createForm();
        this === null || this === void 0 ? void 0 : this.clearForm.pipe((0,_ngneat_until_destroy__WEBPACK_IMPORTED_MODULE_7__.untilDestroyed)(this)).subscribe((_) => this.createForm());
    }
    getFormControl(name) {
        var _a;
        return (_a = this.form) === null || _a === void 0 ? void 0 : _a.get(name);
    }
    onSave() {
        const comment = this.form.value;
        this.saveComment.emit(comment);
    }
    createForm() {
        this.form = this.builder.group({
            id: [''],
            name: ['', _angular_forms__WEBPACK_IMPORTED_MODULE_8__.Validators.required],
            body: ['', _angular_forms__WEBPACK_IMPORTED_MODULE_8__.Validators.required],
        });
    }
};
AddCommentComponent.ɵfac = function AddCommentComponent_Factory(t) { return new (t || AddCommentComponent)(_angular_core__WEBPACK_IMPORTED_MODULE_5__["ɵɵdirectiveInject"](_angular_forms__WEBPACK_IMPORTED_MODULE_8__.FormBuilder)); };
AddCommentComponent.ɵcmp = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_5__["ɵɵdefineComponent"]({ type: AddCommentComponent, selectors: [["gamestore-add-comment"]], inputs: { currentComment: "currentComment", clearForm: "clearForm" }, outputs: { selectCancel: "selectCancel", saveComment: "saveComment" }, features: [_angular_core__WEBPACK_IMPORTED_MODULE_5__["ɵɵInheritDefinitionFeature"]], decls: 3, vars: 2, consts: [[1, "add-comment-container"], [4, "ngIf"], ["mat-button", "", "color", "accent", 3, "click"], ["idName", "id", 3, "form", "save"], [3, "control", "disableValidation"]], template: function AddCommentComponent_Template(rf, ctx) { if (rf & 1) {
        _angular_core__WEBPACK_IMPORTED_MODULE_5__["ɵɵelementStart"](0, "div", 0);
        _angular_core__WEBPACK_IMPORTED_MODULE_5__["ɵɵtemplate"](1, AddCommentComponent_div_1_Template, 4, 2, "div", 1);
        _angular_core__WEBPACK_IMPORTED_MODULE_5__["ɵɵtemplate"](2, AddCommentComponent_div_2_Template, 4, 5, "div", 1);
        _angular_core__WEBPACK_IMPORTED_MODULE_5__["ɵɵelementEnd"]();
    } if (rf & 2) {
        _angular_core__WEBPACK_IMPORTED_MODULE_5__["ɵɵadvance"](1);
        _angular_core__WEBPACK_IMPORTED_MODULE_5__["ɵɵproperty"]("ngIf", !!ctx.currentCommentValue && !!ctx.action);
        _angular_core__WEBPACK_IMPORTED_MODULE_5__["ɵɵadvance"](1);
        _angular_core__WEBPACK_IMPORTED_MODULE_5__["ɵɵproperty"]("ngIf", !!ctx.form);
    } }, directives: [_angular_common__WEBPACK_IMPORTED_MODULE_9__.NgIf, _angular_material_button__WEBPACK_IMPORTED_MODULE_10__.MatButton, _componetns_form_component_form_component__WEBPACK_IMPORTED_MODULE_2__.FormComponent, _componetns_text_input_component_text_input_component__WEBPACK_IMPORTED_MODULE_3__.TextInputComponent, _componetns_textarea_input_component_textarea_input_component__WEBPACK_IMPORTED_MODULE_4__.TextareaInputComponent], styles: [".add-comment-container[_ngcontent-%COMP%] {\n  margin-bottom: 15px;\n}\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbImFkZC1jb21tZW50LmNvbXBvbmVudC5zY3NzIl0sIm5hbWVzIjpbXSwibWFwcGluZ3MiOiJBQUFBO0VBQ0ksbUJBQUE7QUFDSiIsImZpbGUiOiJhZGQtY29tbWVudC5jb21wb25lbnQuc2NzcyIsInNvdXJjZXNDb250ZW50IjpbIi5hZGQtY29tbWVudC1jb250YWluZXIge1xyXG4gICAgbWFyZ2luLWJvdHRvbTogMTVweDtcclxufSJdfQ== */"] });
AddCommentComponent = (0,tslib__WEBPACK_IMPORTED_MODULE_11__.__decorate)([
    (0,_ngneat_until_destroy__WEBPACK_IMPORTED_MODULE_7__.UntilDestroy)()
], AddCommentComponent);



/***/ }),

/***/ 6229:
/*!*************************************************************************************!*\
  !*** ./src/app/pages/game-page/components/ban-user-component/ban-user.component.ts ***!
  \*************************************************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "BanUserComponent": () => (/* binding */ BanUserComponent)
/* harmony export */ });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/forms */ 1707);
/* harmony import */ var src_app_componetns_base_component__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! src/app/componetns/base.component */ 2844);
/* harmony import */ var src_app_services_comment_service__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! src/app/services/comment.service */ 3792);
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/common */ 4364);
/* harmony import */ var _componetns_selector_input_component_selector_input_component__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../../../../componetns/selector-input-component/selector-input.component */ 9260);
/* harmony import */ var _angular_material_button__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! @angular/material/button */ 781);








function BanUserComponent_article_0_Template(rf, ctx) { if (rf & 1) {
    const _r2 = _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵgetCurrentView"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementStart"](0, "article");
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementStart"](1, "p");
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵtext"](2);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementStart"](3, "h3");
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵtext"](4);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementStart"](5, "div");
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelement"](6, "gamestore-selector-input", 1);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementStart"](7, "div");
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementStart"](8, "button", 2);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵlistener"]("click", function BanUserComponent_article_0_Template_button_click_8_listener() { _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵrestoreView"](_r2); const ctx_r1 = _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵnextContext"](); return ctx_r1.onBan(); });
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵtext"](9);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementEnd"]();
} if (rf & 2) {
    const ctx_r0 = _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵnextContext"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵadvance"](2);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵtextInterpolate"](ctx_r0.labels.banMessage);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵadvance"](2);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵtextInterpolate"](ctx_r0.name);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵadvance"](2);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵproperty"]("name", ctx_r0.labels.banDurationLabel)("control", ctx_r0.control)("values", ctx_r0.banDurations);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵadvance"](2);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵproperty"]("disabled", !ctx_r0.control || ctx_r0.control.invalid);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵtextInterpolate1"](" ", ctx_r0.labels.banButtonLabel, " ");
} }
class BanUserComponent extends src_app_componetns_base_component__WEBPACK_IMPORTED_MODULE_0__.BaseComponent {
    constructor(commentService) {
        super();
        this.commentService = commentService;
        this.ban = new _angular_core__WEBPACK_IMPORTED_MODULE_3__.EventEmitter();
    }
    ngOnInit() {
        this.commentService.getBanDurations().subscribe((x) => (this.banDurations = x.map((z) => {
            return { name: z, value: z };
        })));
        this.control = new _angular_forms__WEBPACK_IMPORTED_MODULE_4__.FormControl('', _angular_forms__WEBPACK_IMPORTED_MODULE_4__.Validators.required);
    }
    onBan() {
        var _a;
        if (!((_a = this.control) === null || _a === void 0 ? void 0 : _a.value)) {
            return;
        }
        this.ban.emit(this.control.value.toString());
    }
}
BanUserComponent.ɵfac = function BanUserComponent_Factory(t) { return new (t || BanUserComponent)(_angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵdirectiveInject"](src_app_services_comment_service__WEBPACK_IMPORTED_MODULE_1__.CommentService)); };
BanUserComponent.ɵcmp = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵdefineComponent"]({ type: BanUserComponent, selectors: [["gamestore-ban-user"]], inputs: { name: "name" }, outputs: { ban: "ban" }, features: [_angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵInheritDefinitionFeature"]], decls: 1, vars: 1, consts: [[4, "ngIf"], [3, "name", "control", "values"], ["mat-raised-button", "", "color", "warn", 3, "disabled", "click"]], template: function BanUserComponent_Template(rf, ctx) { if (rf & 1) {
        _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵtemplate"](0, BanUserComponent_article_0_Template, 10, 7, "article", 0);
    } if (rf & 2) {
        _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵproperty"]("ngIf", !!ctx.control && !!ctx.banDurations);
    } }, directives: [_angular_common__WEBPACK_IMPORTED_MODULE_5__.NgIf, _componetns_selector_input_component_selector_input_component__WEBPACK_IMPORTED_MODULE_2__.SelectorInputComponent, _angular_material_button__WEBPACK_IMPORTED_MODULE_6__.MatButton], styles: ["h3[_ngcontent-%COMP%] {\n  font-weight: 500;\n}\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbImJhbi11c2VyLmNvbXBvbmVudC5zY3NzIl0sIm5hbWVzIjpbXSwibWFwcGluZ3MiOiJBQUFBO0VBQ0ksZ0JBQUE7QUFDSiIsImZpbGUiOiJiYW4tdXNlci5jb21wb25lbnQuc2NzcyIsInNvdXJjZXNDb250ZW50IjpbImgze1xyXG4gICAgZm9udC13ZWlnaHQ6IDUwMDtcclxufSJdfQ== */"] });


/***/ }),

/***/ 4232:
/*!********************************************************************************!*\
  !*** ./src/app/pages/game-page/components/comment-component/comment-action.ts ***!
  \********************************************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "CommentAction": () => (/* binding */ CommentAction)
/* harmony export */ });
var CommentAction;
(function (CommentAction) {
    CommentAction["Reply"] = "Reply";
    CommentAction["Quote"] = "Quote";
})(CommentAction || (CommentAction = {}));


/***/ }),

/***/ 6819:
/*!***********************************************************************************!*\
  !*** ./src/app/pages/game-page/components/comment-component/comment.component.ts ***!
  \***********************************************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "CommentComponent": () => (/* binding */ CommentComponent)
/* harmony export */ });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var src_app_componetns_base_component__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! src/app/componetns/base.component */ 2844);
/* harmony import */ var _comment_action__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./comment-action */ 4232);
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/common */ 4364);
/* harmony import */ var _angular_material_button__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/material/button */ 781);






function CommentComponent_div_0_div_12_gamestore_comment_1_Template(rf, ctx) { if (rf & 1) {
    const _r5 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵgetCurrentView"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](0, "gamestore-comment", 9);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵlistener"]("select", function CommentComponent_div_0_div_12_gamestore_comment_1_Template_gamestore_comment_select_0_listener($event) { _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵrestoreView"](_r5); const ctx_r4 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵnextContext"](3); return ctx_r4.select.emit($event); })("deleteComment", function CommentComponent_div_0_div_12_gamestore_comment_1_Template_gamestore_comment_deleteComment_0_listener($event) { _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵrestoreView"](_r5); const ctx_r6 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵnextContext"](3); return ctx_r6.deleteComment.emit($event); })("banComment", function CommentComponent_div_0_div_12_gamestore_comment_1_Template_gamestore_comment_banComment_0_listener($event) { _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵrestoreView"](_r5); const ctx_r7 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵnextContext"](3); return ctx_r7.banComment.emit($event); });
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
} if (rf & 2) {
    const childComment_r3 = ctx.$implicit;
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵproperty"]("comment", childComment_r3);
} }
function CommentComponent_div_0_div_12_Template(rf, ctx) { if (rf & 1) {
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](0, "div", 7);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtemplate"](1, CommentComponent_div_0_div_12_gamestore_comment_1_Template, 1, 1, "gamestore-comment", 8);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
} if (rf & 2) {
    const ctx_r1 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵnextContext"](2);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵproperty"]("ngForOf", ctx_r1.comment.childComments);
} }
function CommentComponent_div_0_Template(rf, ctx) { if (rf & 1) {
    const _r9 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵgetCurrentView"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](0, "div", 1);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](1, "div", 2);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtext"](2);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](3, "button", 3);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵlistener"]("click", function CommentComponent_div_0_Template_button_click_3_listener() { _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵrestoreView"](_r9); const ctx_r8 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵnextContext"](); return ctx_r8.onAction(ctx_r8.action.Reply); });
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtext"](4);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](5, "button", 3);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵlistener"]("click", function CommentComponent_div_0_Template_button_click_5_listener() { _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵrestoreView"](_r9); const ctx_r10 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵnextContext"](); return ctx_r10.onAction(ctx_r10.action.Quote); });
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtext"](6);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](7, "button", 4);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵlistener"]("click", function CommentComponent_div_0_Template_button_click_7_listener() { _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵrestoreView"](_r9); const ctx_r11 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵnextContext"](); return ctx_r11.deleteComment.emit(ctx_r11.comment); });
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtext"](8);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](9, "button", 4);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵlistener"]("click", function CommentComponent_div_0_Template_button_click_9_listener() { _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵrestoreView"](_r9); const ctx_r12 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵnextContext"](); return ctx_r12.banComment.emit(ctx_r12.comment); });
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtext"](10);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelement"](11, "div", 5);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtemplate"](12, CommentComponent_div_0_div_12_Template, 2, 1, "div", 6);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
} if (rf & 2) {
    const ctx_r0 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵnextContext"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵpropertyInterpolate1"]("id", "comment", ctx_r0.comment.id, "");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](2);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtextInterpolate1"](" ", ctx_r0.comment.name, " ");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](2);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtextInterpolate1"](" ", ctx_r0.labels.replyButtonLabel, " ");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](2);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtextInterpolate1"](" ", ctx_r0.labels.quoteButtonLabel, " ");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](2);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtextInterpolate1"](" ", ctx_r0.labels.deleteButtonLabel, " ");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](2);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtextInterpolate1"](" ", ctx_r0.labels.banButtonLabel, " ");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵproperty"]("innerHtml", ctx_r0.comment.body, _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵsanitizeHtml"]);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵproperty"]("ngIf", !!(ctx_r0.comment.childComments == null ? null : ctx_r0.comment.childComments.length));
} }
class CommentComponent extends src_app_componetns_base_component__WEBPACK_IMPORTED_MODULE_0__.BaseComponent {
    constructor() {
        super();
        this.select = new _angular_core__WEBPACK_IMPORTED_MODULE_2__.EventEmitter();
        this.deleteComment = new _angular_core__WEBPACK_IMPORTED_MODULE_2__.EventEmitter();
        this.banComment = new _angular_core__WEBPACK_IMPORTED_MODULE_2__.EventEmitter();
        this.action = _comment_action__WEBPACK_IMPORTED_MODULE_1__.CommentAction;
    }
    onAction(action) {
        this.select.emit({ comment: this.comment, action });
    }
}
CommentComponent.ɵfac = function CommentComponent_Factory(t) { return new (t || CommentComponent)(); };
CommentComponent.ɵcmp = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵdefineComponent"]({ type: CommentComponent, selectors: [["gamestore-comment"]], inputs: { comment: "comment" }, outputs: { select: "select", deleteComment: "deleteComment", banComment: "banComment" }, features: [_angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵInheritDefinitionFeature"]], decls: 1, vars: 1, consts: [["class", "comment-container", 3, "id", 4, "ngIf"], [1, "comment-container", 3, "id"], [1, "comment-name"], ["mat-button", "", "color", "accent", 3, "click"], ["mat-raised-button", "", "color", "warn", 3, "click"], [1, "comment-body", 3, "innerHtml"], ["class", "child-comments", 4, "ngIf"], [1, "child-comments"], [3, "comment", "select", "deleteComment", "banComment", 4, "ngFor", "ngForOf"], [3, "comment", "select", "deleteComment", "banComment"]], template: function CommentComponent_Template(rf, ctx) { if (rf & 1) {
        _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtemplate"](0, CommentComponent_div_0_Template, 13, 8, "div", 0);
    } if (rf & 2) {
        _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵproperty"]("ngIf", !!ctx.comment);
    } }, directives: [_angular_common__WEBPACK_IMPORTED_MODULE_3__.NgIf, _angular_material_button__WEBPACK_IMPORTED_MODULE_4__.MatButton, _angular_common__WEBPACK_IMPORTED_MODULE_3__.NgForOf, CommentComponent], styles: [".comment-container[_ngcontent-%COMP%] {\n  margin-bottom: 7px;\n}\n.comment-container[_ngcontent-%COMP%]   .comment-name[_ngcontent-%COMP%] {\n  font-weight: 500;\n  margin-bottom: 3px;\n}\n.comment-container[_ngcontent-%COMP%]   .child-comments[_ngcontent-%COMP%] {\n  padding-left: 15px;\n  box-sizing: border-box;\n}\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbImNvbW1lbnQuY29tcG9uZW50LnNjc3MiXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IkFBQUE7RUFDSSxrQkFBQTtBQUNKO0FBQ0k7RUFDSSxnQkFBQTtFQUNBLGtCQUFBO0FBQ1I7QUFFSTtFQUNJLGtCQUFBO0VBQ0Esc0JBQUE7QUFBUiIsImZpbGUiOiJjb21tZW50LmNvbXBvbmVudC5zY3NzIiwic291cmNlc0NvbnRlbnQiOlsiLmNvbW1lbnQtY29udGFpbmVye1xyXG4gICAgbWFyZ2luLWJvdHRvbTogN3B4O1xyXG5cclxuICAgIC5jb21tZW50LW5hbWUge1xyXG4gICAgICAgIGZvbnQtd2VpZ2h0OiA1MDA7XHJcbiAgICAgICAgbWFyZ2luLWJvdHRvbTogM3B4O1xyXG4gICAgfVxyXG5cclxuICAgIC5jaGlsZC1jb21tZW50cyB7XHJcbiAgICAgICAgcGFkZGluZy1sZWZ0OiAxNXB4O1xyXG4gICAgICAgIGJveC1zaXppbmc6IGJvcmRlci1ib3g7XHJcbiAgICB9XHJcbn0iXX0= */"] });


/***/ }),

/***/ 8003:
/*!*************************************************************************************!*\
  !*** ./src/app/pages/game-page/components/comments-component/comments.component.ts ***!
  \*************************************************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "CommentsComponent": () => (/* binding */ CommentsComponent)
/* harmony export */ });
/* harmony import */ var rxjs__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! rxjs */ 9441);
/* harmony import */ var src_app_componetns_base_component__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! src/app/componetns/base.component */ 2844);
/* harmony import */ var src_app_componetns_delete_wrapper_component_delete_wrapper_component__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! src/app/componetns/delete-wrapper-component/delete-wrapper.component */ 2303);
/* harmony import */ var rxjs_operators__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! rxjs/operators */ 8636);
/* harmony import */ var rxjs_operators__WEBPACK_IMPORTED_MODULE_9__ = __webpack_require__(/*! rxjs/operators */ 2663);
/* harmony import */ var rxjs_operators__WEBPACK_IMPORTED_MODULE_10__ = __webpack_require__(/*! rxjs/operators */ 9902);
/* harmony import */ var _ban_user_component_ban_user_component__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../ban-user-component/ban-user.component */ 6229);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var src_app_services_comment_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! src/app/services/comment.service */ 3792);
/* harmony import */ var _angular_material_dialog__WEBPACK_IMPORTED_MODULE_11__ = __webpack_require__(/*! @angular/material/dialog */ 2213);
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_12__ = __webpack_require__(/*! @angular/common */ 4364);
/* harmony import */ var _add_comment_component_add_comment_component__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ../add-comment-component/add-comment.component */ 3448);
/* harmony import */ var _comment_component_comment_component__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ../comment-component/comment.component */ 6819);











function CommentsComponent_div_0_gamestore_comment_2_Template(rf, ctx) { if (rf & 1) {
    const _r4 = _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵgetCurrentView"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵelementStart"](0, "gamestore-comment", 4);
    _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵlistener"]("select", function CommentsComponent_div_0_gamestore_comment_2_Template_gamestore_comment_select_0_listener($event) { _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵrestoreView"](_r4); const ctx_r3 = _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵnextContext"](2); return ctx_r3.onSelect($event); })("deleteComment", function CommentsComponent_div_0_gamestore_comment_2_Template_gamestore_comment_deleteComment_0_listener($event) { _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵrestoreView"](_r4); const ctx_r5 = _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵnextContext"](2); return ctx_r5.onDeleteComment($event); })("banComment", function CommentsComponent_div_0_gamestore_comment_2_Template_gamestore_comment_banComment_0_listener($event) { _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵrestoreView"](_r4); const ctx_r6 = _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵnextContext"](2); return ctx_r6.onBanComment($event); });
    _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵelementEnd"]();
} if (rf & 2) {
    const comment_r2 = ctx.$implicit;
    _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵproperty"]("comment", comment_r2);
} }
function CommentsComponent_div_0_Template(rf, ctx) { if (rf & 1) {
    const _r8 = _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵgetCurrentView"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵelementStart"](0, "div", 1);
    _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵelementStart"](1, "gamestore-add-comment", 2);
    _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵlistener"]("selectCancel", function CommentsComponent_div_0_Template_gamestore_add_comment_selectCancel_1_listener() { _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵrestoreView"](_r8); const ctx_r7 = _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵnextContext"](); return ctx_r7.onSelectCancel(); })("saveComment", function CommentsComponent_div_0_Template_gamestore_add_comment_saveComment_1_listener($event) { _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵrestoreView"](_r8); const ctx_r9 = _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵnextContext"](); return ctx_r9.onSave($event); });
    _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵtemplate"](2, CommentsComponent_div_0_gamestore_comment_2_Template, 1, 1, "gamestore-comment", 3);
    _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵelementEnd"]();
} if (rf & 2) {
    const ctx_r0 = _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵnextContext"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵproperty"]("currentComment", ctx_r0.selectedComment)("clearForm", ctx_r0.clearCommentInput);
    _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵproperty"]("ngForOf", ctx_r0.comments);
} }
class CommentsComponent extends src_app_componetns_base_component__WEBPACK_IMPORTED_MODULE_0__.BaseComponent {
    constructor(commentsService, dialog) {
        super();
        this.commentsService = commentsService;
        this.dialog = dialog;
        this.clearCommentInput = new rxjs__WEBPACK_IMPORTED_MODULE_7__.Subject();
        this.comments = [];
    }
    ngOnInit() {
        this.loadComments();
    }
    onSelect(selected) {
        this.onSelectCancel();
        this.selectedComment = selected;
    }
    onSave(comment) {
        var _a, _b, _c, _d, _e;
        this.commentsService
            .addComment(comment, this.gameKey, (_c = (_b = (_a = this.selectedComment) === null || _a === void 0 ? void 0 : _a.comment) === null || _b === void 0 ? void 0 : _b.id) !== null && _c !== void 0 ? _c : '', (_e = (_d = this.selectedComment) === null || _d === void 0 ? void 0 : _d.action) !== null && _e !== void 0 ? _e : '')
            .subscribe((x) => {
            this.onSelectCancel();
            this.clearCommentInput.next();
            if (!!(x === null || x === void 0 ? void 0 : x.length)) {
                this.comments = x;
            }
            else {
                this.loadComments();
            }
        });
    }
    onSelectCancel() {
        this.selectedComment = undefined;
    }
    onDeleteComment(comment) {
        const deleteDialog = this.dialog.open(src_app_componetns_delete_wrapper_component_delete_wrapper_component__WEBPACK_IMPORTED_MODULE_1__.DeleteWrapperComponent);
        deleteDialog.componentInstance.name = comment.name;
        this.handleDialog(deleteDialog, deleteDialog.componentInstance.delete, (_) => {
            var _a;
            return this.commentsService
                .deleteComment((_a = comment === null || comment === void 0 ? void 0 : comment.id) !== null && _a !== void 0 ? _a : '', this.gameKey)
                .pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_8__.tap)(() => this.loadComments()));
        });
    }
    onBanComment(comment) {
        const banDialog = this.dialog.open(_ban_user_component_ban_user_component__WEBPACK_IMPORTED_MODULE_2__.BanUserComponent);
        banDialog.componentInstance.name = comment.name;
        this.handleDialog(banDialog, banDialog.componentInstance.ban, (x) => this.commentsService
            .banUser(x, comment.name)
            .pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_8__.tap)(() => this.loadComments())));
    }
    handleDialog(dialog, event, eventHandler) {
        const closed = new rxjs__WEBPACK_IMPORTED_MODULE_7__.Subject();
        event
            .pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_9__.takeUntil)(closed), (0,rxjs_operators__WEBPACK_IMPORTED_MODULE_8__.tap)((_) => dialog.close()), (0,rxjs_operators__WEBPACK_IMPORTED_MODULE_10__.switchMap)((x) => eventHandler(x)))
            .subscribe();
        dialog.afterClosed().subscribe((_) => {
            closed.next();
            closed.complete();
        });
    }
    loadComments() {
        this.commentsService
            .getCommentsByGameKey(this.gameKey)
            .subscribe((x) => (this.comments = x));
    }
}
CommentsComponent.ɵfac = function CommentsComponent_Factory(t) { return new (t || CommentsComponent)(_angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵdirectiveInject"](src_app_services_comment_service__WEBPACK_IMPORTED_MODULE_3__.CommentService), _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵdirectiveInject"](_angular_material_dialog__WEBPACK_IMPORTED_MODULE_11__.MatDialog)); };
CommentsComponent.ɵcmp = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵdefineComponent"]({ type: CommentsComponent, selectors: [["gamestore-comments"]], inputs: { gameKey: "gameKey" }, features: [_angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵInheritDefinitionFeature"]], decls: 1, vars: 1, consts: [["class", "comments-container", 4, "ngIf"], [1, "comments-container"], [3, "currentComment", "clearForm", "selectCancel", "saveComment"], [3, "comment", "select", "deleteComment", "banComment", 4, "ngFor", "ngForOf"], [3, "comment", "select", "deleteComment", "banComment"]], template: function CommentsComponent_Template(rf, ctx) { if (rf & 1) {
        _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵtemplate"](0, CommentsComponent_div_0_Template, 3, 3, "div", 0);
    } if (rf & 2) {
        _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵproperty"]("ngIf", !!ctx.comments);
    } }, directives: [_angular_common__WEBPACK_IMPORTED_MODULE_12__.NgIf, _add_comment_component_add_comment_component__WEBPACK_IMPORTED_MODULE_4__.AddCommentComponent, _angular_common__WEBPACK_IMPORTED_MODULE_12__.NgForOf, _comment_component_comment_component__WEBPACK_IMPORTED_MODULE_5__.CommentComponent], styles: [".comments-container[_ngcontent-%COMP%] {\n  border-top: 1px solid #4a494a;\n  padding-top: 10px;\n}\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbImNvbW1lbnRzLmNvbXBvbmVudC5zY3NzIl0sIm5hbWVzIjpbXSwibWFwcGluZ3MiOiJBQUFBO0VBQ0UsNkJBQUE7RUFDQSxpQkFBQTtBQUNGIiwiZmlsZSI6ImNvbW1lbnRzLmNvbXBvbmVudC5zY3NzIiwic291cmNlc0NvbnRlbnQiOlsiLmNvbW1lbnRzLWNvbnRhaW5lciB7XHJcbiAgYm9yZGVyLXRvcDogMXB4IHNvbGlkICM0YTQ5NGE7XHJcbiAgcGFkZGluZy10b3A6IDEwcHg7XHJcbn0iXX0= */"] });


/***/ }),

/***/ 2042:
/*!********************************************************!*\
  !*** ./src/app/pages/game-page/game-page.component.ts ***!
  \********************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "GamePageComponent": () => (/* binding */ GamePageComponent)
/* harmony export */ });
/* harmony import */ var rxjs__WEBPACK_IMPORTED_MODULE_9__ = __webpack_require__(/*! rxjs */ 2720);
/* harmony import */ var rxjs_operators__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! rxjs/operators */ 9902);
/* harmony import */ var rxjs_operators__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! rxjs/operators */ 8636);
/* harmony import */ var src_app_componetns_base_component__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! src/app/componetns/base.component */ 2844);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var src_app_services_game_service__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! src/app/services/game.service */ 1397);
/* harmony import */ var src_app_services_genre_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! src/app/services/genre.service */ 7776);
/* harmony import */ var src_app_services_platform_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! src/app/services/platform.service */ 8634);
/* harmony import */ var src_app_services_publisher_service__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! src/app/services/publisher.service */ 7441);
/* harmony import */ var src_app_services_order_service__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! src/app/services/order.service */ 8132);
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_10__ = __webpack_require__(/*! @angular/router */ 1258);










const _c0 = ["download"];
function GamePageComponent_div_0_Template(rf, ctx) { if (rf & 1) {
    const _r3 = _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵgetCurrentView"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵelementStart"](0, "div");
    _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵelementStart"](1, "div", 1);
    _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵelementStart"](2, "a", 2);
    _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵtext"](3);
    _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵelementStart"](4, "div", 3);
    _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵelementStart"](5, "button", 4);
    _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵlistener"]("click", function GamePageComponent_div_0_Template_button_click_5_listener() { _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵrestoreView"](_r3); const ctx_r2 = _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵnextContext"](); return ctx_r2.buy(); });
    _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵtext"](6);
    _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵelementStart"](7, "gamestore-info-wrapper", 5);
    _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵelement"](8, "gamestore-info", 6);
    _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵelementStart"](9, "div");
    _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵelementStart"](10, "a", 7, 8);
    _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵtext"](12);
    _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵelement"](13, "gamestore-comments", 9);
    _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵelementEnd"]();
} if (rf & 2) {
    const ctx_r0 = _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵnextContext"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵadvance"](2);
    _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵpropertyInterpolate"]("routerLink", ctx_r0.links.get(ctx_r0.pageRoutes.Games));
    _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵtextInterpolate1"](" ", ctx_r0.labels.gamesMenuItem, " ");
    _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵadvance"](3);
    _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵtextInterpolate1"](" ", ctx_r0.labels.buyButtonLabel, " ");
    _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵproperty"]("deleteLink", ctx_r0.deleteGameLink)("updateLink", ctx_r0.updateGameLink);
    _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵproperty"]("infoList", ctx_r0.gameInfoList);
    _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵadvance"](4);
    _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵtextInterpolate"](ctx_r0.labels.downloadButtonLabel);
    _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵproperty"]("gameKey", ctx_r0.game.key);
} }
class GamePageComponent extends src_app_componetns_base_component__WEBPACK_IMPORTED_MODULE_0__.BaseComponent {
    constructor(gameService, genreService, platformService, publisherService, orderService, route, router) {
        super();
        this.gameService = gameService;
        this.genreService = genreService;
        this.platformService = platformService;
        this.publisherService = publisherService;
        this.orderService = orderService;
        this.route = route;
        this.router = router;
        this.gameInfoList = [];
    }
    get deleteGameLink() {
        var _a;
        return `${this.links.get(this.pageRoutes.DeleteGame)}/${(_a = this.gameValue) === null || _a === void 0 ? void 0 : _a.key}`;
    }
    get updateGameLink() {
        var _a;
        return `${this.links.get(this.pageRoutes.UpdateGame)}/${(_a = this.gameValue) === null || _a === void 0 ? void 0 : _a.key}`;
    }
    get game() {
        return this.gameValue;
    }
    set game(value) {
        var _a, _b, _c, _d;
        this.gameValue = value;
        this.gameInfoList = [];
        if (!value) {
            return;
        }
        this.gameInfoList.push({
            name: this.labels.gameNameLabel,
            value: value.name,
        }, {
            name: this.labels.gameKeyLabel,
            value: value.key,
        }, {
            name: this.labels.gameDescriptionLabel,
            value: (_a = value.description) !== null && _a !== void 0 ? _a : '',
        }, {
            name: this.labels.gamePriceLabel,
            value: ((_b = value.price) !== null && _b !== void 0 ? _b : 0).toString(),
        }, {
            name: this.labels.gameDiscountLabel,
            value: ((_c = value.discount) !== null && _c !== void 0 ? _c : 0).toString(),
        }, {
            name: this.labels.gameUnitInStockLabel,
            value: ((_d = value.unitInStock) !== null && _d !== void 0 ? _d : 0).toString(),
        });
    }
    ngOnInit() {
        this.getRouteParam(this.route, 'key')
            .pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_7__.switchMap)((key) => this.gameService.getGame(key)), (0,rxjs_operators__WEBPACK_IMPORTED_MODULE_8__.tap)((x) => (this.game = x)), (0,rxjs_operators__WEBPACK_IMPORTED_MODULE_7__.switchMap)((x) => (0,rxjs__WEBPACK_IMPORTED_MODULE_9__.forkJoin)({
            genres: this.genreService.getGenresByGameKey(x.key),
            platforms: this.platformService.getPlatformsByGameKey(x.key),
            file: this.gameService.getGameFile(x.key),
            publisher: this.publisherService.getPublisherByGameKey(x.key),
        })))
            .subscribe((x) => {
            this.addPatformsInfo(x.platforms);
            this.addGenresInfo(x.genres);
            this.file = x.file;
            this.addDownloadFile();
            this.addPublisherInfo(x.publisher);
        });
    }
    ngAfterViewInit() {
        this.addDownloadFile();
    }
    addDownloadFile() {
        if (!!this.file && !!this.downloadLink) {
            const downloadURL = window.URL.createObjectURL(this.file);
            this.downloadLink._elementRef.nativeElement.href = downloadURL;
        }
    }
    addPatformsInfo(platforms) {
        if (!(platforms === null || platforms === void 0 ? void 0 : platforms.length)) {
            return;
        }
        const platformsInfo = {
            name: this.labels.platformsMenuItem,
            nestedValues: [],
        };
        platforms.forEach((x) => platformsInfo.nestedValues.push({
            title: x.type,
            pageLink: `${this.links.get(this.pageRoutes.Platform)}/${x.id}`,
        }));
        this.gameInfoList.push(platformsInfo);
    }
    addPublisherInfo(publisher) {
        if (!publisher) {
            return;
        }
        this.gameInfoList.push({
            name: this.labels.publisherLabel,
            value: publisher.companyName,
            pageLink: `${this.links.get(this.pageRoutes.Publisher)}/${publisher.companyName}`,
        });
    }
    addGenresInfo(genres) {
        if (!(genres === null || genres === void 0 ? void 0 : genres.length)) {
            return;
        }
        const genresInfo = {
            name: this.labels.genresMenuItem,
            nestedValues: [],
        };
        genres.forEach((x) => genresInfo.nestedValues.push({
            title: x.name,
            pageLink: `${this.links.get(this.pageRoutes.Genre)}/${x.id}`,
        }));
        this.gameInfoList.push(genresInfo);
    }
    buy() {
        this.orderService
            .buyGame(this.game.key)
            .subscribe((_) => this.router.navigateByUrl(this.links.get(this.pageRoutes.Basket)));
    }
}
GamePageComponent.ɵfac = function GamePageComponent_Factory(t) { return new (t || GamePageComponent)(_angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵdirectiveInject"](src_app_services_game_service__WEBPACK_IMPORTED_MODULE_1__.GameService), _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵdirectiveInject"](src_app_services_genre_service__WEBPACK_IMPORTED_MODULE_2__.GenreService), _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵdirectiveInject"](src_app_services_platform_service__WEBPACK_IMPORTED_MODULE_3__.PlatformService), _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵdirectiveInject"](src_app_services_publisher_service__WEBPACK_IMPORTED_MODULE_4__.PublisherService), _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵdirectiveInject"](src_app_services_order_service__WEBPACK_IMPORTED_MODULE_5__.OrderService), _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵdirectiveInject"](_angular_router__WEBPACK_IMPORTED_MODULE_10__.ActivatedRoute), _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵdirectiveInject"](_angular_router__WEBPACK_IMPORTED_MODULE_10__.Router)); };
GamePageComponent.ɵcmp = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵdefineComponent"]({ type: GamePageComponent, selectors: [["gamestore-game"]], viewQuery: function GamePageComponent_Query(rf, ctx) { if (rf & 1) {
        _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵviewQuery"](_c0, 5);
    } if (rf & 2) {
        let _t;
        _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵqueryRefresh"](_t = _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵloadQuery"]()) && (ctx.downloadLink = _t.first);
    } }, features: [_angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵInheritDefinitionFeature"]], decls: 1, vars: 1, consts: [[4, "ngIf"], [1, "to-list-button"], ["mat-button", "", 3, "routerLink"], [1, "buy-button"], ["type", "button", "mat-raised-button", "", "color", "primary", 3, "click"], [3, "deleteLink", "updateLink"], [3, "infoList"], ["mat-button", "", "href", "", "download", ""], ["download", ""], [3, "gameKey"]], template: function GamePageComponent_Template(rf, ctx) { if (rf & 1) {
        _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵtemplate"](0, GamePageComponent_div_0_Template, 14, 8, "div", 0);
    } if (rf & 2) {
        _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵproperty"]("ngIf", !!ctx.game);
    } }, styles: [".to-list-button[_ngcontent-%COMP%], .buy-button[_ngcontent-%COMP%] {\n  margin-bottom: 10px;\n}\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbImdhbWUtcGFnZS5jb21wb25lbnQuc2NzcyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiQUFBQTtFQUNJLG1CQUFBO0FBQ0oiLCJmaWxlIjoiZ2FtZS1wYWdlLmNvbXBvbmVudC5zY3NzIiwic291cmNlc0NvbnRlbnQiOlsiLnRvLWxpc3QtYnV0dG9uLCAuYnV5LWJ1dHRvbiAge1xyXG4gICAgbWFyZ2luLWJvdHRvbTogMTBweDtcclxufSJdfQ== */"] });


/***/ }),

/***/ 7389:
/*!*****************************************************!*\
  !*** ./src/app/pages/game-page/game-page.module.ts ***!
  \*****************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "GamePageModule": () => (/* binding */ GamePageModule)
/* harmony export */ });
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_16__ = __webpack_require__(/*! @angular/common */ 4364);
/* harmony import */ var src_app_componetns_common_components_module__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! src/app/componetns/common-components.module */ 1951);
/* harmony import */ var src_app_services_game_service__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! src/app/services/game.service */ 1397);
/* harmony import */ var _game_page_component__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./game-page.component */ 2042);
/* harmony import */ var src_app_app_routing_module__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! src/app/app-routing.module */ 158);
/* harmony import */ var _angular_material_button__WEBPACK_IMPORTED_MODULE_17__ = __webpack_require__(/*! @angular/material/button */ 781);
/* harmony import */ var src_app_services_genre_service__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! src/app/services/genre.service */ 7776);
/* harmony import */ var src_app_services_platform_service__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! src/app/services/platform.service */ 8634);
/* harmony import */ var src_app_services_publisher_service__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! src/app/services/publisher.service */ 7441);
/* harmony import */ var src_app_services_order_service__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! src/app/services/order.service */ 8132);
/* harmony import */ var _components_add_comment_component_add_comment_component__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! ./components/add-comment-component/add-comment.component */ 3448);
/* harmony import */ var _components_comment_component_comment_component__WEBPACK_IMPORTED_MODULE_9__ = __webpack_require__(/*! ./components/comment-component/comment.component */ 6819);
/* harmony import */ var _components_comments_component_comments_component__WEBPACK_IMPORTED_MODULE_10__ = __webpack_require__(/*! ./components/comments-component/comments.component */ 8003);
/* harmony import */ var src_app_services_comment_service__WEBPACK_IMPORTED_MODULE_11__ = __webpack_require__(/*! src/app/services/comment.service */ 3792);
/* harmony import */ var _components_ban_user_component_ban_user_component__WEBPACK_IMPORTED_MODULE_12__ = __webpack_require__(/*! ./components/ban-user-component/ban-user.component */ 6229);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_15__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_18__ = __webpack_require__(/*! @angular/router */ 1258);
/* harmony import */ var _componetns_info_wrapper_component_info_wrapper_component__WEBPACK_IMPORTED_MODULE_13__ = __webpack_require__(/*! ../../componetns/info-wrapper-component/info-wrapper.component */ 7990);
/* harmony import */ var _componetns_info_component_info_component__WEBPACK_IMPORTED_MODULE_14__ = __webpack_require__(/*! ../../componetns/info-component/info.component */ 4130);





















class GamePageModule {
}
GamePageModule.ɵfac = function GamePageModule_Factory(t) { return new (t || GamePageModule)(); };
GamePageModule.ɵmod = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_15__["ɵɵdefineNgModule"]({ type: GamePageModule });
GamePageModule.ɵinj = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_15__["ɵɵdefineInjector"]({ providers: [
        src_app_services_game_service__WEBPACK_IMPORTED_MODULE_1__.GameService,
        src_app_services_genre_service__WEBPACK_IMPORTED_MODULE_4__.GenreService,
        src_app_services_platform_service__WEBPACK_IMPORTED_MODULE_5__.PlatformService,
        src_app_services_publisher_service__WEBPACK_IMPORTED_MODULE_6__.PublisherService,
        src_app_services_order_service__WEBPACK_IMPORTED_MODULE_7__.OrderService,
        src_app_services_comment_service__WEBPACK_IMPORTED_MODULE_11__.CommentService
    ], imports: [[
            _angular_common__WEBPACK_IMPORTED_MODULE_16__.CommonModule,
            src_app_componetns_common_components_module__WEBPACK_IMPORTED_MODULE_0__.CommonComponentsModule,
            src_app_app_routing_module__WEBPACK_IMPORTED_MODULE_3__.AppRoutingModule,
            _angular_material_button__WEBPACK_IMPORTED_MODULE_17__.MatButtonModule,
        ]] });
(function () { (typeof ngJitMode === "undefined" || ngJitMode) && _angular_core__WEBPACK_IMPORTED_MODULE_15__["ɵɵsetNgModuleScope"](GamePageModule, { declarations: [_game_page_component__WEBPACK_IMPORTED_MODULE_2__.GamePageComponent,
        _components_add_comment_component_add_comment_component__WEBPACK_IMPORTED_MODULE_8__.AddCommentComponent,
        _components_comments_component_comments_component__WEBPACK_IMPORTED_MODULE_10__.CommentsComponent,
        _components_comment_component_comment_component__WEBPACK_IMPORTED_MODULE_9__.CommentComponent,
        _components_ban_user_component_ban_user_component__WEBPACK_IMPORTED_MODULE_12__.BanUserComponent], imports: [_angular_common__WEBPACK_IMPORTED_MODULE_16__.CommonModule,
        src_app_componetns_common_components_module__WEBPACK_IMPORTED_MODULE_0__.CommonComponentsModule,
        src_app_app_routing_module__WEBPACK_IMPORTED_MODULE_3__.AppRoutingModule,
        _angular_material_button__WEBPACK_IMPORTED_MODULE_17__.MatButtonModule] }); })();
_angular_core__WEBPACK_IMPORTED_MODULE_15__["ɵɵsetComponentScope"](_game_page_component__WEBPACK_IMPORTED_MODULE_2__.GamePageComponent, [_angular_common__WEBPACK_IMPORTED_MODULE_16__.NgIf, _angular_material_button__WEBPACK_IMPORTED_MODULE_17__.MatAnchor, _angular_router__WEBPACK_IMPORTED_MODULE_18__.RouterLinkWithHref, _angular_material_button__WEBPACK_IMPORTED_MODULE_17__.MatButton, _componetns_info_wrapper_component_info_wrapper_component__WEBPACK_IMPORTED_MODULE_13__.InfoWrapperComponent, _componetns_info_component_info_component__WEBPACK_IMPORTED_MODULE_14__.InfoComponent, _components_comments_component_comments_component__WEBPACK_IMPORTED_MODULE_10__.CommentsComponent], []);


/***/ }),

/***/ 8289:
/*!******************************************************************************!*\
  !*** ./src/app/pages/games-page/components/filter-wrapper/filter-trigger.ts ***!
  \******************************************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "FilterTrigger": () => (/* binding */ FilterTrigger)
/* harmony export */ });
var FilterTrigger;
(function (FilterTrigger) {
    FilterTrigger["ApplyFilters"] = "ApplyFilters";
    FilterTrigger["PageChange"] = "PageChange";
    FilterTrigger["SortingChange"] = "SortingChange";
    FilterTrigger["PageCountChange"] = "PageCountChange";
})(FilterTrigger || (FilterTrigger = {}));


/***/ }),

/***/ 9586:
/*!****************************************************************************************!*\
  !*** ./src/app/pages/games-page/components/filter-wrapper/filter-wrapper.component.ts ***!
  \****************************************************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "FilterWrapperComponent": () => (/* binding */ FilterWrapperComponent)
/* harmony export */ });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_22__ = __webpack_require__(/*! tslib */ 3786);
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_16__ = __webpack_require__(/*! @angular/common/http */ 3882);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_12__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var _ngneat_until_destroy__WEBPACK_IMPORTED_MODULE_15__ = __webpack_require__(/*! @ngneat/until-destroy */ 9758);
/* harmony import */ var rxjs__WEBPACK_IMPORTED_MODULE_13__ = __webpack_require__(/*! rxjs */ 9441);
/* harmony import */ var rxjs__WEBPACK_IMPORTED_MODULE_14__ = __webpack_require__(/*! rxjs */ 2720);
/* harmony import */ var rxjs_operators__WEBPACK_IMPORTED_MODULE_17__ = __webpack_require__(/*! rxjs/operators */ 2663);
/* harmony import */ var src_app_componetns_base_component__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! src/app/componetns/base.component */ 2844);
/* harmony import */ var _filter_trigger__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./filter-trigger */ 8289);
/* harmony import */ var src_app_services_genre_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! src/app/services/genre.service */ 7776);
/* harmony import */ var src_app_services_platform_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! src/app/services/platform.service */ 8634);
/* harmony import */ var src_app_services_publisher_service__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! src/app/services/publisher.service */ 7441);
/* harmony import */ var src_app_services_game_service__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! src/app/services/game.service */ 1397);
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_18__ = __webpack_require__(/*! @angular/router */ 1258);
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_19__ = __webpack_require__(/*! @angular/forms */ 1707);
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_20__ = __webpack_require__(/*! @angular/common */ 4364);
/* harmony import */ var _angular_material_button__WEBPACK_IMPORTED_MODULE_21__ = __webpack_require__(/*! @angular/material/button */ 781);
/* harmony import */ var _componetns_checkboxes_input_component_checkboxes_input_component__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ../../../../componetns/checkboxes-input-component/checkboxes-input.component */ 5583);
/* harmony import */ var _componetns_number_input_component_number_input_component__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! ../../../../componetns/number-input-component/number-input.component */ 9567);
/* harmony import */ var _componetns_radio_input_component_radio_input_component__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! ../../../../componetns/radio-input-component/radio-input.component */ 5962);
/* harmony import */ var _componetns_text_input_component_text_input_component__WEBPACK_IMPORTED_MODULE_9__ = __webpack_require__(/*! ../../../../componetns/text-input-component/text-input.component */ 2082);
/* harmony import */ var _sort_wrapper_sort_wrapper_component__WEBPACK_IMPORTED_MODULE_10__ = __webpack_require__(/*! ../sort-wrapper/sort-wrapper.component */ 5457);
/* harmony import */ var _pagging_wrapper_pagging_wrapper_component__WEBPACK_IMPORTED_MODULE_11__ = __webpack_require__(/*! ../pagging-wrapper/pagging-wrapper.component */ 4804);























function FilterWrapperComponent_article_0_Template(rf, ctx) { if (rf & 1) {
    const _r2 = _angular_core__WEBPACK_IMPORTED_MODULE_12__["ɵɵgetCurrentView"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_12__["ɵɵelementStart"](0, "article");
    _angular_core__WEBPACK_IMPORTED_MODULE_12__["ɵɵelementStart"](1, "aside", 1);
    _angular_core__WEBPACK_IMPORTED_MODULE_12__["ɵɵelementStart"](2, "div", 2);
    _angular_core__WEBPACK_IMPORTED_MODULE_12__["ɵɵelementStart"](3, "button", 3);
    _angular_core__WEBPACK_IMPORTED_MODULE_12__["ɵɵlistener"]("click", function FilterWrapperComponent_article_0_Template_button_click_3_listener() { _angular_core__WEBPACK_IMPORTED_MODULE_12__["ɵɵrestoreView"](_r2); const ctx_r1 = _angular_core__WEBPACK_IMPORTED_MODULE_12__["ɵɵnextContext"](); return ctx_r1.applyFilters(); });
    _angular_core__WEBPACK_IMPORTED_MODULE_12__["ɵɵtext"](4);
    _angular_core__WEBPACK_IMPORTED_MODULE_12__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_12__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_12__["ɵɵelement"](5, "gamestore-checkboxes-input", 4);
    _angular_core__WEBPACK_IMPORTED_MODULE_12__["ɵɵelement"](6, "gamestore-checkboxes-input", 4);
    _angular_core__WEBPACK_IMPORTED_MODULE_12__["ɵɵelement"](7, "gamestore-checkboxes-input", 4);
    _angular_core__WEBPACK_IMPORTED_MODULE_12__["ɵɵelement"](8, "gamestore-number-input", 5);
    _angular_core__WEBPACK_IMPORTED_MODULE_12__["ɵɵelement"](9, "gamestore-number-input", 5);
    _angular_core__WEBPACK_IMPORTED_MODULE_12__["ɵɵelement"](10, "gamestore-radio-input", 6);
    _angular_core__WEBPACK_IMPORTED_MODULE_12__["ɵɵelement"](11, "gamestore-text-input", 5);
    _angular_core__WEBPACK_IMPORTED_MODULE_12__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_12__["ɵɵelementStart"](12, "div", 7);
    _angular_core__WEBPACK_IMPORTED_MODULE_12__["ɵɵelementStart"](13, "gamestore-sort-wrapper", 8);
    _angular_core__WEBPACK_IMPORTED_MODULE_12__["ɵɵelementStart"](14, "gamestore-pagging-wrapper", 9);
    _angular_core__WEBPACK_IMPORTED_MODULE_12__["ɵɵprojection"](15);
    _angular_core__WEBPACK_IMPORTED_MODULE_12__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_12__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_12__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_12__["ɵɵelementEnd"]();
} if (rf & 2) {
    const ctx_r0 = _angular_core__WEBPACK_IMPORTED_MODULE_12__["ɵɵnextContext"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_12__["ɵɵadvance"](3);
    _angular_core__WEBPACK_IMPORTED_MODULE_12__["ɵɵproperty"]("disabled", ctx_r0.form.disabled);
    _angular_core__WEBPACK_IMPORTED_MODULE_12__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_12__["ɵɵtextInterpolate1"](" ", ctx_r0.labels.filterButtonLabel, " ");
    _angular_core__WEBPACK_IMPORTED_MODULE_12__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_12__["ɵɵproperty"]("name", ctx_r0.labels.genresMenuItem)("controls", ctx_r0.getFormControlArray("genres"))("items", ctx_r0.genreItems);
    _angular_core__WEBPACK_IMPORTED_MODULE_12__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_12__["ɵɵproperty"]("name", ctx_r0.labels.platformsMenuItem)("controls", ctx_r0.getFormControlArray("platforms"))("items", ctx_r0.platformItems);
    _angular_core__WEBPACK_IMPORTED_MODULE_12__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_12__["ɵɵproperty"]("name", ctx_r0.labels.publishersMenuItem)("controls", ctx_r0.getFormControlArray("publishers"))("items", ctx_r0.publisherItems);
    _angular_core__WEBPACK_IMPORTED_MODULE_12__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_12__["ɵɵproperty"]("name", ctx_r0.labels.gameMinPriceLabel)("control", ctx_r0.getFormControl("minPrice"));
    _angular_core__WEBPACK_IMPORTED_MODULE_12__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_12__["ɵɵproperty"]("name", ctx_r0.labels.gameMaxPriceLabel)("control", ctx_r0.getFormControl("maxPrice"));
    _angular_core__WEBPACK_IMPORTED_MODULE_12__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_12__["ɵɵproperty"]("name", ctx_r0.labels.gameDatePublishing)("control", ctx_r0.getFormControl("datePublishing"))("items", ctx_r0.datesPublishingItems);
    _angular_core__WEBPACK_IMPORTED_MODULE_12__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_12__["ɵɵproperty"]("name", ctx_r0.labels.gameNameLabel)("control", ctx_r0.getFormControl("name"));
    _angular_core__WEBPACK_IMPORTED_MODULE_12__["ɵɵadvance"](2);
    _angular_core__WEBPACK_IMPORTED_MODULE_12__["ɵɵproperty"]("sortControl", ctx_r0.getFormControl("sort"));
    _angular_core__WEBPACK_IMPORTED_MODULE_12__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_12__["ɵɵproperty"]("pageCountControl", ctx_r0.getFormControl("pageCount"))("pageControl", ctx_r0.getFormControl("page"))("totalPages", ctx_r0.totalPages);
} }
const _c0 = ["*"];
let FilterWrapperComponent = class FilterWrapperComponent extends src_app_componetns_base_component__WEBPACK_IMPORTED_MODULE_0__.BaseComponent {
    constructor(genreService, platformService, publisherService, gameService, route, builder) {
        super();
        this.genreService = genreService;
        this.platformService = platformService;
        this.publisherService = publisherService;
        this.gameService = gameService;
        this.route = route;
        this.builder = builder;
        this.unsubscribe = new rxjs__WEBPACK_IMPORTED_MODULE_13__.Subject();
        this.totalPages = 1;
        this.currentPage = 1;
        this.apply = new _angular_core__WEBPACK_IMPORTED_MODULE_12__.EventEmitter();
        this.genreItems = [];
        this.platformItems = [];
        this.publisherItems = [];
        this.datesPublishingItems = [];
        this.genres = [];
        this.publishers = [];
        this.platforms = [];
        this.datesPublishing = [];
    }
    ngOnInit() {
        (0,rxjs__WEBPACK_IMPORTED_MODULE_14__.forkJoin)({
            genres: this.genreService.getGenres(),
            platforms: this.platformService.getPlatforms(),
            publishers: this.publisherService.getPublishers(),
            datesPublishing: this.gameService.getPublishedDateOptions(),
        }).subscribe((x) => {
            this.platforms = x.platforms;
            this.publishers = x.publishers;
            this.genres = x.genres;
            this.datesPublishing = x.datesPublishing;
            this.createForm(this.route.queryParams.getValue());
            this.applyFilters(_filter_trigger__WEBPACK_IMPORTED_MODULE_1__.FilterTrigger.ApplyFilters);
        });
        this.pagesSubject.pipe((0,_ngneat_until_destroy__WEBPACK_IMPORTED_MODULE_15__.untilDestroyed)(this)).subscribe((x) => {
            var _a;
            this.totalPages = x.totalPages;
            (_a = this.getFormControl('page')) === null || _a === void 0 ? void 0 : _a.setValue(x.page);
        });
        this.gamesLoadSubject.pipe((0,_ngneat_until_destroy__WEBPACK_IMPORTED_MODULE_15__.untilDestroyed)(this)).subscribe((_) => {
            var _a;
            (_a = this.form) === null || _a === void 0 ? void 0 : _a.enable();
            this.subscribeControlChanges();
        });
    }
    getFormControl(name) {
        var _a;
        return (_a = this.form) === null || _a === void 0 ? void 0 : _a.get(name);
    }
    getFormControlArray(name) {
        var _a;
        return ((_a = this.form) === null || _a === void 0 ? void 0 : _a.get(name)).controls.map((x) => x);
    }
    applyFilters(trigger = _filter_trigger__WEBPACK_IMPORTED_MODULE_1__.FilterTrigger.ApplyFilters) {
        var _a, _b, _c, _d, _e, _f, _g, _h, _j, _k;
        if ((_a = this.form) === null || _a === void 0 ? void 0 : _a.disabled) {
            return;
        }
        this.unsubscribe.next();
        (_b = this.form) === null || _b === void 0 ? void 0 : _b.disable();
        const selectedGenres = this.genres
            .filter((x, i) => !!this.form.value.genres[i])
            .map((x) => { var _a; return (_a = x.id) !== null && _a !== void 0 ? _a : ''; });
        const selectedPlatforms = this.platforms
            .filter((x, i) => !!this.form.value.platforms[i])
            .map((x) => { var _a; return (_a = x.id) !== null && _a !== void 0 ? _a : ''; });
        const selectedPublihers = this.publishers
            .filter((x, i) => !!this.form.value.publishers[i])
            .map((x) => { var _a; return (_a = x.id) !== null && _a !== void 0 ? _a : ''; });
        const filterModel = {
            genres: selectedGenres !== null && selectedGenres !== void 0 ? selectedGenres : '',
            platforms: selectedPlatforms !== null && selectedPlatforms !== void 0 ? selectedPlatforms : '',
            publishers: selectedPublihers !== null && selectedPublihers !== void 0 ? selectedPublihers : '',
            maxPrice: (_c = this.form.value.maxPrice) !== null && _c !== void 0 ? _c : '',
            minPrice: (_d = this.form.value.minPrice) !== null && _d !== void 0 ? _d : '',
            name: (_e = this.form.value.name) !== null && _e !== void 0 ? _e : '',
            datePublishing: (_f = this.form.value.datePublishing) !== null && _f !== void 0 ? _f : '',
            sort: (_g = this.form.value.sort) !== null && _g !== void 0 ? _g : '',
            page: (_h = this.form.value.page) !== null && _h !== void 0 ? _h : '',
            pageCount: (_j = this.form.value.pageCount) !== null && _j !== void 0 ? _j : '',
            trigger: (_k = trigger === null || trigger === void 0 ? void 0 : trigger.toString()) !== null && _k !== void 0 ? _k : '',
        };
        const params = new _angular_common_http__WEBPACK_IMPORTED_MODULE_16__.HttpParams({
            fromObject: filterModel,
            encoder: new _angular_common_http__WEBPACK_IMPORTED_MODULE_16__.HttpUrlEncodingCodec(),
        });
        this.apply.emit(params);
    }
    createForm(params) {
        var _a, _b, _c, _d, _e, _f, _g;
        this.form = this.builder.group({
            genres: this.builder.array(this.genres.map((x) => { var _a; return !!((_a = params['genres']) === null || _a === void 0 ? void 0 : _a.includes(x.id)); })),
            platforms: this.builder.array(this.platforms.map((x) => { var _a; return !!((_a = params['platforms']) === null || _a === void 0 ? void 0 : _a.includes(x.id)); })),
            publishers: this.builder.array(this.publishers.map((x) => { var _a; return !!((_a = params['publishers']) === null || _a === void 0 ? void 0 : _a.includes(x.id)); })),
            maxPrice: [(_a = params['maxPrice']) !== null && _a !== void 0 ? _a : ''],
            minPrice: [(_b = params['minPrice']) !== null && _b !== void 0 ? _b : ''],
            name: [(_c = params['name']) !== null && _c !== void 0 ? _c : ''],
            datePublishing: [(_d = params['datePublishing']) !== null && _d !== void 0 ? _d : ''],
            sort: [(_e = params['sort']) !== null && _e !== void 0 ? _e : ''],
            page: [Number.parseInt((_f = params['page']) !== null && _f !== void 0 ? _f : this.currentPage.toString())],
            pageCount: [(_g = params['pageCount']) !== null && _g !== void 0 ? _g : ''],
        });
        this.genreItems = this.genres.map((x) => x.name);
        this.platformItems = this.platforms.map((x) => x.type);
        this.publisherItems = this.publishers.map((x) => x.companyName);
        this.datesPublishingItems = this.datesPublishing.map((x) => {
            return { value: x, title: x };
        });
        this.subscribeControlChanges();
    }
    subscribeControlChanges() {
        this.getFormControl('sort')
            .valueChanges.pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_17__.takeUntil)(this.unsubscribe))
            .subscribe((_) => this.applyFilters(_filter_trigger__WEBPACK_IMPORTED_MODULE_1__.FilterTrigger.SortingChange));
        this.getFormControl('page')
            .valueChanges.pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_17__.takeUntil)(this.unsubscribe))
            .subscribe((_) => this.applyFilters(_filter_trigger__WEBPACK_IMPORTED_MODULE_1__.FilterTrigger.PageChange));
        this.getFormControl('pageCount')
            .valueChanges.pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_17__.takeUntil)(this.unsubscribe))
            .subscribe((_) => this.applyFilters(_filter_trigger__WEBPACK_IMPORTED_MODULE_1__.FilterTrigger.PageCountChange));
    }
};
FilterWrapperComponent.ɵfac = function FilterWrapperComponent_Factory(t) { return new (t || FilterWrapperComponent)(_angular_core__WEBPACK_IMPORTED_MODULE_12__["ɵɵdirectiveInject"](src_app_services_genre_service__WEBPACK_IMPORTED_MODULE_2__.GenreService), _angular_core__WEBPACK_IMPORTED_MODULE_12__["ɵɵdirectiveInject"](src_app_services_platform_service__WEBPACK_IMPORTED_MODULE_3__.PlatformService), _angular_core__WEBPACK_IMPORTED_MODULE_12__["ɵɵdirectiveInject"](src_app_services_publisher_service__WEBPACK_IMPORTED_MODULE_4__.PublisherService), _angular_core__WEBPACK_IMPORTED_MODULE_12__["ɵɵdirectiveInject"](src_app_services_game_service__WEBPACK_IMPORTED_MODULE_5__.GameService), _angular_core__WEBPACK_IMPORTED_MODULE_12__["ɵɵdirectiveInject"](_angular_router__WEBPACK_IMPORTED_MODULE_18__.ActivatedRoute), _angular_core__WEBPACK_IMPORTED_MODULE_12__["ɵɵdirectiveInject"](_angular_forms__WEBPACK_IMPORTED_MODULE_19__.FormBuilder)); };
FilterWrapperComponent.ɵcmp = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_12__["ɵɵdefineComponent"]({ type: FilterWrapperComponent, selectors: [["gamestore-filter-wrapper"]], inputs: { totalPages: "totalPages", currentPage: "currentPage", pagesSubject: "pagesSubject", gamesLoadSubject: "gamesLoadSubject" }, outputs: { apply: "apply" }, features: [_angular_core__WEBPACK_IMPORTED_MODULE_12__["ɵɵInheritDefinitionFeature"]], ngContentSelectors: _c0, decls: 1, vars: 1, consts: [[4, "ngIf"], [1, "filters-container"], [1, "filter-button"], ["mat-raised-button", "", "color", "primary", "type", "button", 3, "disabled", "click"], [3, "name", "controls", "items"], [3, "name", "control"], [3, "name", "control", "items"], [1, "content-container"], [3, "sortControl"], [3, "pageCountControl", "pageControl", "totalPages"]], template: function FilterWrapperComponent_Template(rf, ctx) { if (rf & 1) {
        _angular_core__WEBPACK_IMPORTED_MODULE_12__["ɵɵprojectionDef"]();
        _angular_core__WEBPACK_IMPORTED_MODULE_12__["ɵɵtemplate"](0, FilterWrapperComponent_article_0_Template, 16, 24, "article", 0);
    } if (rf & 2) {
        _angular_core__WEBPACK_IMPORTED_MODULE_12__["ɵɵproperty"]("ngIf", !!ctx.form);
    } }, directives: [_angular_common__WEBPACK_IMPORTED_MODULE_20__.NgIf, _angular_material_button__WEBPACK_IMPORTED_MODULE_21__.MatButton, _componetns_checkboxes_input_component_checkboxes_input_component__WEBPACK_IMPORTED_MODULE_6__.CheckboxesInputComponent, _componetns_number_input_component_number_input_component__WEBPACK_IMPORTED_MODULE_7__.NumberInputComponent, _componetns_radio_input_component_radio_input_component__WEBPACK_IMPORTED_MODULE_8__.RadioInputComponent, _componetns_text_input_component_text_input_component__WEBPACK_IMPORTED_MODULE_9__.TextInputComponent, _sort_wrapper_sort_wrapper_component__WEBPACK_IMPORTED_MODULE_10__.SortWrapperComponent, _pagging_wrapper_pagging_wrapper_component__WEBPACK_IMPORTED_MODULE_11__.PaggingWrapperComponent], styles: ["article[_ngcontent-%COMP%] {\n  float: left;\n  width: 100%;\n}\narticle[_ngcontent-%COMP%]   .filters-container[_ngcontent-%COMP%] {\n  float: left;\n  width: 300px;\n}\narticle[_ngcontent-%COMP%]   .filters-container[_ngcontent-%COMP%]   .filter-button[_ngcontent-%COMP%] {\n  margin-bottom: 15px;\n  text-align: center;\n}\narticle[_ngcontent-%COMP%]   .content-container[_ngcontent-%COMP%] {\n  float: left;\n  width: calc(100% - 300px);\n}\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbImZpbHRlci13cmFwcGVyLmNvbXBvbmVudC5zY3NzIl0sIm5hbWVzIjpbXSwibWFwcGluZ3MiOiJBQUFBO0VBQ0ksV0FBQTtFQUNBLFdBQUE7QUFDSjtBQUNJO0VBQ0ksV0FBQTtFQUNBLFlBQUE7QUFDUjtBQUNRO0VBQ0ksbUJBQUE7RUFDQSxrQkFBQTtBQUNaO0FBR0k7RUFDSSxXQUFBO0VBQ0EseUJBQUE7QUFEUiIsImZpbGUiOiJmaWx0ZXItd3JhcHBlci5jb21wb25lbnQuc2NzcyIsInNvdXJjZXNDb250ZW50IjpbImFydGljbGUge1xyXG4gICAgZmxvYXQ6IGxlZnQ7XHJcbiAgICB3aWR0aDogMTAwJTtcclxuXHJcbiAgICAuZmlsdGVycy1jb250YWluZXIge1xyXG4gICAgICAgIGZsb2F0OiBsZWZ0O1xyXG4gICAgICAgIHdpZHRoOiAzMDBweDtcclxuXHJcbiAgICAgICAgLmZpbHRlci1idXR0b24ge1xyXG4gICAgICAgICAgICBtYXJnaW4tYm90dG9tOiAxNXB4O1xyXG4gICAgICAgICAgICB0ZXh0LWFsaWduOiBjZW50ZXI7XHJcbiAgICAgICAgfVxyXG4gICAgfVxyXG5cclxuICAgIC5jb250ZW50LWNvbnRhaW5lciB7XHJcbiAgICAgICAgZmxvYXQ6IGxlZnQ7XHJcbiAgICAgICAgd2lkdGg6IGNhbGMoMTAwJSAtIDMwMHB4KTtcclxuICAgIH1cclxufSJdfQ== */"] });
FilterWrapperComponent = (0,tslib__WEBPACK_IMPORTED_MODULE_22__.__decorate)([
    (0,_ngneat_until_destroy__WEBPACK_IMPORTED_MODULE_15__.UntilDestroy)()
], FilterWrapperComponent);



/***/ }),

/***/ 4804:
/*!******************************************************************************************!*\
  !*** ./src/app/pages/games-page/components/pagging-wrapper/pagging-wrapper.component.ts ***!
  \******************************************************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "PaggingWrapperComponent": () => (/* binding */ PaggingWrapperComponent)
/* harmony export */ });
/* harmony import */ var src_app_componetns_base_component__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! src/app/componetns/base.component */ 2844);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var src_app_services_game_service__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! src/app/services/game.service */ 1397);
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/common */ 4364);
/* harmony import */ var _angular_material_button__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/material/button */ 781);
/* harmony import */ var _componetns_selector_input_component_selector_input_component__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../../../../componetns/selector-input-component/selector-input.component */ 9260);






function PaggingWrapperComponent_div_0_Template(rf, ctx) { if (rf & 1) {
    const _r2 = _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵgetCurrentView"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementStart"](0, "div", 1);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementStart"](1, "div", 2);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵprojection"](2);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementStart"](3, "div", 3);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementStart"](4, "div", 4);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementStart"](5, "button", 5);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵlistener"]("click", function PaggingWrapperComponent_div_0_Template_button_click_5_listener() { _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵrestoreView"](_r2); const ctx_r1 = _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵnextContext"](); return ctx_r1.onPrevChange(); });
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵtext"](6, " < ");
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementStart"](7, "span");
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵtext"](8);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementStart"](9, "button", 5);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵlistener"]("click", function PaggingWrapperComponent_div_0_Template_button_click_9_listener() { _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵrestoreView"](_r2); const ctx_r3 = _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵnextContext"](); return ctx_r3.onNextChange(); });
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵtext"](10, " > ");
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelement"](11, "gamestore-selector-input", 6);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementEnd"]();
} if (rf & 2) {
    const ctx_r0 = _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵnextContext"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵadvance"](5);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵproperty"]("disabled", ctx_r0.currentPage <= 1 || ctx_r0.pageControl.disabled);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵadvance"](3);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵtextInterpolate"](ctx_r0.currentPage);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵproperty"]("disabled", ctx_r0.currentPage >= ctx_r0.totalPages || ctx_r0.pageControl.disabled);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵadvance"](2);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵproperty"]("control", ctx_r0.pageCountControl)("values", ctx_r0.paggings);
} }
const _c0 = ["*"];
class PaggingWrapperComponent extends src_app_componetns_base_component__WEBPACK_IMPORTED_MODULE_0__.BaseComponent {
    constructor(gameService) {
        super();
        this.gameService = gameService;
        this.totalPages = 1;
        this.paggings = [];
    }
    get currentPage() {
        var _a;
        const pageFromControl = Number.parseInt((_a = this.pageControl.value) !== null && _a !== void 0 ? _a : '1');
        return !!pageFromControl ? pageFromControl : 1;
    }
    ngOnInit() {
        this.gameService.getPaggingOptions().subscribe((x) => {
            this.paggings = x.map((z) => {
                return { name: z, value: z };
            });
        });
    }
    onPrevChange() {
        if (this.currentPage <= 1) {
            return;
        }
        this.pageControl.setValue(this.currentPage - 1);
    }
    onNextChange() {
        if (this.currentPage >= this.totalPages) {
            return;
        }
        this.pageControl.setValue(this.currentPage + 1);
    }
}
PaggingWrapperComponent.ɵfac = function PaggingWrapperComponent_Factory(t) { return new (t || PaggingWrapperComponent)(_angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵdirectiveInject"](src_app_services_game_service__WEBPACK_IMPORTED_MODULE_1__.GameService)); };
PaggingWrapperComponent.ɵcmp = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵdefineComponent"]({ type: PaggingWrapperComponent, selectors: [["gamestore-pagging-wrapper"]], inputs: { pageCountControl: "pageCountControl", pageControl: "pageControl", totalPages: "totalPages" }, features: [_angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵInheritDefinitionFeature"]], ngContentSelectors: _c0, decls: 1, vars: 1, consts: [["class", "pagging-container", 4, "ngIf"], [1, "pagging-container"], [1, "content-container"], [1, "bottom-panel-container"], [1, "page-controls"], ["mat-stroked-button", "", "type", "button", 3, "disabled", "click"], [3, "control", "values"]], template: function PaggingWrapperComponent_Template(rf, ctx) { if (rf & 1) {
        _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵprojectionDef"]();
        _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵtemplate"](0, PaggingWrapperComponent_div_0_Template, 12, 5, "div", 0);
    } if (rf & 2) {
        _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵproperty"]("ngIf", !!ctx.pageCountControl && !!ctx.pageControl);
    } }, directives: [_angular_common__WEBPACK_IMPORTED_MODULE_4__.NgIf, _angular_material_button__WEBPACK_IMPORTED_MODULE_5__.MatButton, _componetns_selector_input_component_selector_input_component__WEBPACK_IMPORTED_MODULE_2__.SelectorInputComponent], styles: [".pagging-container[_ngcontent-%COMP%] {\n  width: 100%;\n}\n.pagging-container[_ngcontent-%COMP%]   .bottom-panel-container[_ngcontent-%COMP%] {\n  text-align: right;\n}\n.pagging-container[_ngcontent-%COMP%]   .bottom-panel-container[_ngcontent-%COMP%]   gamestore-selector-input[_ngcontent-%COMP%] {\n  display: inline-block;\n}\n.pagging-container[_ngcontent-%COMP%]   .bottom-panel-container[_ngcontent-%COMP%]   .page-controls[_ngcontent-%COMP%] {\n  display: inline-block;\n  padding-right: 15px;\n}\n.pagging-container[_ngcontent-%COMP%]   .bottom-panel-container[_ngcontent-%COMP%]   .page-controls[_ngcontent-%COMP%]   span[_ngcontent-%COMP%] {\n  padding-left: 15px;\n  padding-right: 15px;\n}\n.pagging-container[_ngcontent-%COMP%]   .content-container[_ngcontent-%COMP%] {\n  margin-bottom: 20px;\n}\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInBhZ2dpbmctd3JhcHBlci5jb21wb25lbnQuc2NzcyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiQUFBQTtFQUNJLFdBQUE7QUFDSjtBQUNJO0VBQ0ksaUJBQUE7QUFDUjtBQUNRO0VBQ0kscUJBQUE7QUFDWjtBQUVRO0VBQ0kscUJBQUE7RUFDQSxtQkFBQTtBQUFaO0FBRVk7RUFDSSxrQkFBQTtFQUNBLG1CQUFBO0FBQWhCO0FBS0k7RUFDSSxtQkFBQTtBQUhSIiwiZmlsZSI6InBhZ2dpbmctd3JhcHBlci5jb21wb25lbnQuc2NzcyIsInNvdXJjZXNDb250ZW50IjpbIi5wYWdnaW5nLWNvbnRhaW5lciB7XHJcbiAgICB3aWR0aDogMTAwJTtcclxuXHJcbiAgICAuYm90dG9tLXBhbmVsLWNvbnRhaW5lciB7XHJcbiAgICAgICAgdGV4dC1hbGlnbjogcmlnaHQ7XHJcblxyXG4gICAgICAgIGdhbWVzdG9yZS1zZWxlY3Rvci1pbnB1dCB7XHJcbiAgICAgICAgICAgIGRpc3BsYXk6IGlubGluZS1ibG9jaztcclxuICAgICAgICB9XHJcblxyXG4gICAgICAgIC5wYWdlLWNvbnRyb2xzIHtcclxuICAgICAgICAgICAgZGlzcGxheTogaW5saW5lLWJsb2NrO1xyXG4gICAgICAgICAgICBwYWRkaW5nLXJpZ2h0OiAxNXB4O1xyXG5cclxuICAgICAgICAgICAgc3BhbiB7XHJcbiAgICAgICAgICAgICAgICBwYWRkaW5nLWxlZnQ6IDE1cHg7XHJcbiAgICAgICAgICAgICAgICBwYWRkaW5nLXJpZ2h0OiAxNXB4O1xyXG4gICAgICAgICAgICB9XHJcbiAgICAgICAgfVxyXG4gICAgfVxyXG5cclxuICAgIC5jb250ZW50LWNvbnRhaW5lciB7XHJcbiAgICAgICAgbWFyZ2luLWJvdHRvbTogMjBweDtcclxuICAgIH1cclxufSJdfQ== */"] });


/***/ }),

/***/ 5457:
/*!************************************************************************************!*\
  !*** ./src/app/pages/games-page/components/sort-wrapper/sort-wrapper.component.ts ***!
  \************************************************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "SortWrapperComponent": () => (/* binding */ SortWrapperComponent)
/* harmony export */ });
/* harmony import */ var src_app_componetns_base_component__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! src/app/componetns/base.component */ 2844);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var src_app_services_game_service__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! src/app/services/game.service */ 1397);
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/common */ 4364);
/* harmony import */ var _componetns_selector_input_component_selector_input_component__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../../../../componetns/selector-input-component/selector-input.component */ 9260);





function SortWrapperComponent_div_0_Template(rf, ctx) { if (rf & 1) {
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementStart"](0, "div", 1);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementStart"](1, "div", 2);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelement"](2, "gamestore-selector-input", 3);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementStart"](3, "div", 4);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵprojection"](4);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementEnd"]();
} if (rf & 2) {
    const ctx_r0 = _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵnextContext"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵadvance"](2);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵproperty"]("control", ctx_r0.sortControl)("values", ctx_r0.sortings);
} }
const _c0 = ["*"];
class SortWrapperComponent extends src_app_componetns_base_component__WEBPACK_IMPORTED_MODULE_0__.BaseComponent {
    constructor(gameService) {
        super();
        this.gameService = gameService;
        this.sortings = [];
    }
    ngOnInit() {
        this.gameService.getSortingOptions().subscribe((x) => {
            this.sortings = x.map((z) => {
                return { name: z, value: z };
            });
        });
    }
}
SortWrapperComponent.ɵfac = function SortWrapperComponent_Factory(t) { return new (t || SortWrapperComponent)(_angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵdirectiveInject"](src_app_services_game_service__WEBPACK_IMPORTED_MODULE_1__.GameService)); };
SortWrapperComponent.ɵcmp = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵdefineComponent"]({ type: SortWrapperComponent, selectors: [["gamestore-sort-wrapper"]], inputs: { sortControl: "sortControl" }, features: [_angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵInheritDefinitionFeature"]], ngContentSelectors: _c0, decls: 1, vars: 1, consts: [["class", "sort-container", 4, "ngIf"], [1, "sort-container"], [1, "top-panel-container"], [3, "control", "values"], [1, "content-container"]], template: function SortWrapperComponent_Template(rf, ctx) { if (rf & 1) {
        _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵprojectionDef"]();
        _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵtemplate"](0, SortWrapperComponent_div_0_Template, 5, 2, "div", 0);
    } if (rf & 2) {
        _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵproperty"]("ngIf", !!ctx.sortControl);
    } }, directives: [_angular_common__WEBPACK_IMPORTED_MODULE_4__.NgIf, _componetns_selector_input_component_selector_input_component__WEBPACK_IMPORTED_MODULE_2__.SelectorInputComponent], styles: [".sort-container[_ngcontent-%COMP%] {\n  width: 100%;\n}\n.sort-container[_ngcontent-%COMP%]   .top-panel-container[_ngcontent-%COMP%] {\n  text-align: right;\n}\n.sort-container[_ngcontent-%COMP%]   .top-panel-container[_ngcontent-%COMP%]   gamestore-selector-input[_ngcontent-%COMP%] {\n  display: inline-block;\n}\n.sort-container[_ngcontent-%COMP%]   .content-container[_ngcontent-%COMP%] {\n  margin-top: 20px;\n}\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNvcnQtd3JhcHBlci5jb21wb25lbnQuc2NzcyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiQUFBQTtFQUNJLFdBQUE7QUFDSjtBQUNJO0VBQ0ksaUJBQUE7QUFDUjtBQUNRO0VBQ0kscUJBQUE7QUFDWjtBQUdJO0VBQ0ksZ0JBQUE7QUFEUiIsImZpbGUiOiJzb3J0LXdyYXBwZXIuY29tcG9uZW50LnNjc3MiLCJzb3VyY2VzQ29udGVudCI6WyIuc29ydC1jb250YWluZXIge1xyXG4gICAgd2lkdGg6IDEwMCU7XHJcblxyXG4gICAgLnRvcC1wYW5lbC1jb250YWluZXIge1xyXG4gICAgICAgIHRleHQtYWxpZ246IHJpZ2h0O1xyXG5cclxuICAgICAgICBnYW1lc3RvcmUtc2VsZWN0b3ItaW5wdXQge1xyXG4gICAgICAgICAgICBkaXNwbGF5OiBpbmxpbmUtYmxvY2s7XHJcbiAgICAgICAgfVxyXG4gICAgfVxyXG5cclxuICAgIC5jb250ZW50LWNvbnRhaW5lciB7XHJcbiAgICAgICAgbWFyZ2luLXRvcDogMjBweDtcclxuICAgIH1cclxufSJdfQ== */"] });


/***/ }),

/***/ 3299:
/*!**********************************************************!*\
  !*** ./src/app/pages/games-page/games-page.component.ts ***!
  \**********************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "GamesPageComponent": () => (/* binding */ GamesPageComponent)
/* harmony export */ });
/* harmony import */ var rxjs__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! rxjs */ 6491);
/* harmony import */ var rxjs__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! rxjs */ 9441);
/* harmony import */ var rxjs_operators__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! rxjs/operators */ 8636);
/* harmony import */ var rxjs_operators__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! rxjs/operators */ 3927);
/* harmony import */ var src_app_componetns_base_component__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! src/app/componetns/base.component */ 2844);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var src_app_services_game_service__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! src/app/services/game.service */ 1397);





class GamesPageComponent extends src_app_componetns_base_component__WEBPACK_IMPORTED_MODULE_0__.BaseComponent {
    constructor(gameService) {
        super();
        this.gameService = gameService;
        this.gamesList = [];
        this.pagesSubject = new rxjs__WEBPACK_IMPORTED_MODULE_2__.BehaviorSubject({
            totalPages: 1,
            page: 1,
        });
        this.gamesLoadSubject = new rxjs__WEBPACK_IMPORTED_MODULE_3__.Subject();
    }
    loadGames(filterParams) {
        this.gameService
            .getGames(filterParams)
            .pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_4__.tap)((x) => {
            this.pagesSubject.next({
                totalPages: !!x.totalPages ? x.totalPages : 1,
                page: !!x.currentPage ? x.currentPage : 1,
            });
        }), (0,rxjs_operators__WEBPACK_IMPORTED_MODULE_5__.map)((gamesInfo) => gamesInfo.games.map((game) => {
            const gameItem = {
                title: game.name,
                pageLink: `${this.links.get(this.pageRoutes.Game)}/${game.key}`,
                updateLink: `${this.links.get(this.pageRoutes.UpdateGame)}/${game.key}`,
                deleteLink: `${this.links.get(this.pageRoutes.DeleteGame)}/${game.key}`,
            };
            return gameItem;
        })))
            .subscribe((x) => this.onGamesLoaded(x), () => this.onGamesLoaded([]));
    }
    onGamesLoaded(games) {
        this.gamesList = games !== null && games !== void 0 ? games : [];
        this.gamesLoadSubject.next();
    }
}
GamesPageComponent.ɵfac = function GamesPageComponent_Factory(t) { return new (t || GamesPageComponent)(_angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵdirectiveInject"](src_app_services_game_service__WEBPACK_IMPORTED_MODULE_1__.GameService)); };
GamesPageComponent.ɵcmp = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵdefineComponent"]({ type: GamesPageComponent, selectors: [["gamestore-games"]], features: [_angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵInheritDefinitionFeature"]], decls: 3, vars: 4, consts: [[3, "pagesSubject", "gamesLoadSubject", "apply"], [3, "listItems", "addLink"]], template: function GamesPageComponent_Template(rf, ctx) { if (rf & 1) {
        _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵelementStart"](0, "div");
        _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵelementStart"](1, "gamestore-filter-wrapper", 0);
        _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵlistener"]("apply", function GamesPageComponent_Template_gamestore_filter_wrapper_apply_1_listener($event) { return ctx.loadGames($event); });
        _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵelement"](2, "gamestore-list", 1);
        _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵelementEnd"]();
        _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵelementEnd"]();
    } if (rf & 2) {
        _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵadvance"](1);
        _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵproperty"]("pagesSubject", ctx.pagesSubject)("gamesLoadSubject", ctx.gamesLoadSubject);
        _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵadvance"](1);
        _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵproperty"]("listItems", ctx.gamesList)("addLink", ctx.links.get(ctx.pageRoutes.AddGame));
    } }, styles: ["\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJnYW1lcy1wYWdlLmNvbXBvbmVudC5zY3NzIn0= */"] });


/***/ }),

/***/ 564:
/*!*******************************************************!*\
  !*** ./src/app/pages/games-page/games-page.module.ts ***!
  \*******************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "GamesPageModule": () => (/* binding */ GamesPageModule)
/* harmony export */ });
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_11__ = __webpack_require__(/*! @angular/common */ 4364);
/* harmony import */ var src_app_componetns_common_components_module__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! src/app/componetns/common-components.module */ 1951);
/* harmony import */ var src_app_services_game_service__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! src/app/services/game.service */ 1397);
/* harmony import */ var _games_page_component__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./games-page.component */ 3299);
/* harmony import */ var _components_filter_wrapper_filter_wrapper_component__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./components/filter-wrapper/filter-wrapper.component */ 9586);
/* harmony import */ var src_app_services_platform_service__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! src/app/services/platform.service */ 8634);
/* harmony import */ var src_app_services_genre_service__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! src/app/services/genre.service */ 7776);
/* harmony import */ var src_app_services_publisher_service__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! src/app/services/publisher.service */ 7441);
/* harmony import */ var _components_sort_wrapper_sort_wrapper_component__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! ./components/sort-wrapper/sort-wrapper.component */ 5457);
/* harmony import */ var _components_pagging_wrapper_pagging_wrapper_component__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! ./components/pagging-wrapper/pagging-wrapper.component */ 4804);
/* harmony import */ var _angular_material_button__WEBPACK_IMPORTED_MODULE_12__ = __webpack_require__(/*! @angular/material/button */ 781);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_10__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var _componetns_list_component_list_component__WEBPACK_IMPORTED_MODULE_9__ = __webpack_require__(/*! ../../componetns/list-component/list.component */ 9860);













class GamesPageModule {
}
GamesPageModule.ɵfac = function GamesPageModule_Factory(t) { return new (t || GamesPageModule)(); };
GamesPageModule.ɵmod = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_10__["ɵɵdefineNgModule"]({ type: GamesPageModule });
GamesPageModule.ɵinj = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_10__["ɵɵdefineInjector"]({ providers: [src_app_services_game_service__WEBPACK_IMPORTED_MODULE_1__.GameService, src_app_services_platform_service__WEBPACK_IMPORTED_MODULE_4__.PlatformService, src_app_services_genre_service__WEBPACK_IMPORTED_MODULE_5__.GenreService, src_app_services_publisher_service__WEBPACK_IMPORTED_MODULE_6__.PublisherService], imports: [[_angular_common__WEBPACK_IMPORTED_MODULE_11__.CommonModule, src_app_componetns_common_components_module__WEBPACK_IMPORTED_MODULE_0__.CommonComponentsModule, _angular_material_button__WEBPACK_IMPORTED_MODULE_12__.MatButtonModule]] });
(function () { (typeof ngJitMode === "undefined" || ngJitMode) && _angular_core__WEBPACK_IMPORTED_MODULE_10__["ɵɵsetNgModuleScope"](GamesPageModule, { declarations: [_games_page_component__WEBPACK_IMPORTED_MODULE_2__.GamesPageComponent,
        _components_filter_wrapper_filter_wrapper_component__WEBPACK_IMPORTED_MODULE_3__.FilterWrapperComponent,
        _components_sort_wrapper_sort_wrapper_component__WEBPACK_IMPORTED_MODULE_7__.SortWrapperComponent,
        _components_pagging_wrapper_pagging_wrapper_component__WEBPACK_IMPORTED_MODULE_8__.PaggingWrapperComponent], imports: [_angular_common__WEBPACK_IMPORTED_MODULE_11__.CommonModule, src_app_componetns_common_components_module__WEBPACK_IMPORTED_MODULE_0__.CommonComponentsModule, _angular_material_button__WEBPACK_IMPORTED_MODULE_12__.MatButtonModule] }); })();
_angular_core__WEBPACK_IMPORTED_MODULE_10__["ɵɵsetComponentScope"](_games_page_component__WEBPACK_IMPORTED_MODULE_2__.GamesPageComponent, [_components_filter_wrapper_filter_wrapper_component__WEBPACK_IMPORTED_MODULE_3__.FilterWrapperComponent, _componetns_list_component_list_component__WEBPACK_IMPORTED_MODULE_9__.ListComponent], []);


/***/ }),

/***/ 9629:
/*!**********************************************************!*\
  !*** ./src/app/pages/genre-page/genre-page.component.ts ***!
  \**********************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "GenrePageComponent": () => (/* binding */ GenrePageComponent)
/* harmony export */ });
/* harmony import */ var rxjs__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! rxjs */ 2720);
/* harmony import */ var rxjs__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! rxjs */ 1134);
/* harmony import */ var rxjs_operators__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! rxjs/operators */ 9902);
/* harmony import */ var rxjs_operators__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! rxjs/operators */ 8636);
/* harmony import */ var src_app_componetns_base_component__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! src/app/componetns/base.component */ 2844);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var src_app_services_genre_service__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! src/app/services/genre.service */ 7776);
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! @angular/router */ 1258);
/* harmony import */ var src_app_services_game_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! src/app/services/game.service */ 1397);







function GenrePageComponent_div_0_Template(rf, ctx) { if (rf & 1) {
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementStart"](0, "div");
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementStart"](1, "div", 1);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementStart"](2, "a", 2);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵtext"](3);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementStart"](4, "gamestore-info-wrapper", 3);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelement"](5, "gamestore-info", 4);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementEnd"]();
} if (rf & 2) {
    const ctx_r0 = _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵnextContext"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵadvance"](2);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵpropertyInterpolate"]("routerLink", ctx_r0.links.get(ctx_r0.pageRoutes.Genres));
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵtextInterpolate1"](" ", ctx_r0.labels.genresMenuItem, " ");
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵproperty"]("deleteLink", ctx_r0.deleteGenreLink)("updateLink", ctx_r0.updateGenreLink);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵproperty"]("infoList", ctx_r0.genreInfoList);
} }
class GenrePageComponent extends src_app_componetns_base_component__WEBPACK_IMPORTED_MODULE_0__.BaseComponent {
    constructor(genreService, route, gameService) {
        super();
        this.genreService = genreService;
        this.route = route;
        this.gameService = gameService;
        this.genreInfoList = [];
    }
    get deleteGenreLink() {
        var _a;
        return `${this.links.get(this.pageRoutes.DeleteGenre)}/${(_a = this.genreValue) === null || _a === void 0 ? void 0 : _a.id}`;
    }
    get updateGenreLink() {
        var _a;
        return `${this.links.get(this.pageRoutes.UpdateGenre)}/${(_a = this.genreValue) === null || _a === void 0 ? void 0 : _a.id}`;
    }
    get genre() {
        return this.genreValue;
    }
    set genre(value) {
        this.genreValue = value;
        this.genreInfoList = [];
        if (!value) {
            return;
        }
        this.genreInfoList.push({
            name: this.labels.genreNameLabel,
            value: value.name,
        });
    }
    ngOnInit() {
        this.getRouteParam(this.route, 'id')
            .pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_4__.switchMap)((id) => this.genreService.getGenre(id)), (0,rxjs_operators__WEBPACK_IMPORTED_MODULE_5__.tap)((x) => (this.genre = x)), (0,rxjs_operators__WEBPACK_IMPORTED_MODULE_4__.switchMap)((x) => (0,rxjs__WEBPACK_IMPORTED_MODULE_6__.forkJoin)({
            parent: !!(x === null || x === void 0 ? void 0 : x.parentGenreId)
                ? this.genreService.getGenre(x.parentGenreId)
                : (0,rxjs__WEBPACK_IMPORTED_MODULE_7__.of)(undefined),
            nested: !!(x === null || x === void 0 ? void 0 : x.id)
                ? this.genreService.getGenresByParent(x.id)
                : (0,rxjs__WEBPACK_IMPORTED_MODULE_7__.of)([]),
            games: !!(x === null || x === void 0 ? void 0 : x.id) ? this.gameService.getGamesByGenre(x.id) : (0,rxjs__WEBPACK_IMPORTED_MODULE_7__.of)([]),
        })))
            .subscribe((x) => {
            var _a, _b;
            if (!!x.parent) {
                this.addParentInfo(x.parent);
            }
            if (!!((_a = x.nested) === null || _a === void 0 ? void 0 : _a.length)) {
                this.addNestedGenresInfo(x.nested);
            }
            if (!!((_b = x.games) === null || _b === void 0 ? void 0 : _b.length)) {
                this.addGamesInfo(x.games);
            }
        });
    }
    addParentInfo(genre) {
        const parentInfo = {
            name: this.labels.genreParentLabel,
            value: genre.name,
            pageLink: `${this.links.get(this.pageRoutes.Genre)}/${genre.id}`,
        };
        this.genreInfoList.push(parentInfo);
    }
    addNestedGenresInfo(genres) {
        if (!(genres === null || genres === void 0 ? void 0 : genres.length)) {
            return;
        }
        const genresInfo = {
            name: this.labels.genreNestedLabel,
            nestedValues: [],
        };
        genres.forEach((x) => genresInfo.nestedValues.push({
            title: x.name,
            pageLink: `${this.links.get(this.pageRoutes.Genre)}/${x.id}`,
        }));
        this.genreInfoList.push(genresInfo);
    }
    addGamesInfo(games) {
        if (!(games === null || games === void 0 ? void 0 : games.length)) {
            return;
        }
        const gamesInfo = {
            name: this.labels.gamesMenuItem,
            nestedValues: [],
        };
        games.forEach((x) => gamesInfo.nestedValues.push({
            title: x.name,
            pageLink: `${this.links.get(this.pageRoutes.Game)}/${x.key}`,
        }));
        this.genreInfoList.push(gamesInfo);
    }
}
GenrePageComponent.ɵfac = function GenrePageComponent_Factory(t) { return new (t || GenrePageComponent)(_angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵdirectiveInject"](src_app_services_genre_service__WEBPACK_IMPORTED_MODULE_1__.GenreService), _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵdirectiveInject"](_angular_router__WEBPACK_IMPORTED_MODULE_8__.ActivatedRoute), _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵdirectiveInject"](src_app_services_game_service__WEBPACK_IMPORTED_MODULE_2__.GameService)); };
GenrePageComponent.ɵcmp = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵdefineComponent"]({ type: GenrePageComponent, selectors: [["gamestore-genre"]], features: [_angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵInheritDefinitionFeature"]], decls: 1, vars: 1, consts: [[4, "ngIf"], [1, "to-list-button"], ["mat-button", "", 3, "routerLink"], [3, "deleteLink", "updateLink"], [3, "infoList"]], template: function GenrePageComponent_Template(rf, ctx) { if (rf & 1) {
        _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵtemplate"](0, GenrePageComponent_div_0_Template, 6, 5, "div", 0);
    } if (rf & 2) {
        _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵproperty"]("ngIf", !!ctx.genre);
    } }, styles: [".to-list-button[_ngcontent-%COMP%] {\n  margin-bottom: 10px;\n}\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbImdlbnJlLXBhZ2UuY29tcG9uZW50LnNjc3MiXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IkFBQUE7RUFDSSxtQkFBQTtBQUNKIiwiZmlsZSI6ImdlbnJlLXBhZ2UuY29tcG9uZW50LnNjc3MiLCJzb3VyY2VzQ29udGVudCI6WyIudG8tbGlzdC1idXR0b24ge1xyXG4gICAgbWFyZ2luLWJvdHRvbTogMTBweDtcclxufSJdfQ== */"] });


/***/ }),

/***/ 4108:
/*!*******************************************************!*\
  !*** ./src/app/pages/genre-page/genre-page.module.ts ***!
  \*******************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "GenrePageModule": () => (/* binding */ GenrePageModule)
/* harmony export */ });
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! @angular/common */ 4364);
/* harmony import */ var src_app_componetns_common_components_module__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! src/app/componetns/common-components.module */ 1951);
/* harmony import */ var src_app_app_routing_module__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! src/app/app-routing.module */ 158);
/* harmony import */ var _angular_material_button__WEBPACK_IMPORTED_MODULE_9__ = __webpack_require__(/*! @angular/material/button */ 781);
/* harmony import */ var _genre_page_component__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./genre-page.component */ 9629);
/* harmony import */ var src_app_services_genre_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! src/app/services/genre.service */ 7776);
/* harmony import */ var src_app_services_game_service__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! src/app/services/game.service */ 1397);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_10__ = __webpack_require__(/*! @angular/router */ 1258);
/* harmony import */ var _componetns_info_wrapper_component_info_wrapper_component__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ../../componetns/info-wrapper-component/info-wrapper.component */ 7990);
/* harmony import */ var _componetns_info_component_info_component__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ../../componetns/info-component/info.component */ 4130);













class GenrePageModule {
}
GenrePageModule.ɵfac = function GenrePageModule_Factory(t) { return new (t || GenrePageModule)(); };
GenrePageModule.ɵmod = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_7__["ɵɵdefineNgModule"]({ type: GenrePageModule });
GenrePageModule.ɵinj = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_7__["ɵɵdefineInjector"]({ providers: [src_app_services_genre_service__WEBPACK_IMPORTED_MODULE_3__.GenreService, src_app_services_game_service__WEBPACK_IMPORTED_MODULE_4__.GameService], imports: [[_angular_common__WEBPACK_IMPORTED_MODULE_8__.CommonModule, src_app_componetns_common_components_module__WEBPACK_IMPORTED_MODULE_0__.CommonComponentsModule, src_app_app_routing_module__WEBPACK_IMPORTED_MODULE_1__.AppRoutingModule, _angular_material_button__WEBPACK_IMPORTED_MODULE_9__.MatButtonModule]] });
(function () { (typeof ngJitMode === "undefined" || ngJitMode) && _angular_core__WEBPACK_IMPORTED_MODULE_7__["ɵɵsetNgModuleScope"](GenrePageModule, { declarations: [_genre_page_component__WEBPACK_IMPORTED_MODULE_2__.GenrePageComponent], imports: [_angular_common__WEBPACK_IMPORTED_MODULE_8__.CommonModule, src_app_componetns_common_components_module__WEBPACK_IMPORTED_MODULE_0__.CommonComponentsModule, src_app_app_routing_module__WEBPACK_IMPORTED_MODULE_1__.AppRoutingModule, _angular_material_button__WEBPACK_IMPORTED_MODULE_9__.MatButtonModule] }); })();
_angular_core__WEBPACK_IMPORTED_MODULE_7__["ɵɵsetComponentScope"](_genre_page_component__WEBPACK_IMPORTED_MODULE_2__.GenrePageComponent, [_angular_common__WEBPACK_IMPORTED_MODULE_8__.NgIf, _angular_material_button__WEBPACK_IMPORTED_MODULE_9__.MatAnchor, _angular_router__WEBPACK_IMPORTED_MODULE_10__.RouterLinkWithHref, _componetns_info_wrapper_component_info_wrapper_component__WEBPACK_IMPORTED_MODULE_5__.InfoWrapperComponent, _componetns_info_component_info_component__WEBPACK_IMPORTED_MODULE_6__.InfoComponent], []);


/***/ }),

/***/ 4092:
/*!************************************************************!*\
  !*** ./src/app/pages/genres-page/genres-page.component.ts ***!
  \************************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "GenresPageComponent": () => (/* binding */ GenresPageComponent)
/* harmony export */ });
/* harmony import */ var rxjs_operators__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! rxjs/operators */ 3927);
/* harmony import */ var src_app_componetns_base_component__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! src/app/componetns/base.component */ 2844);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var src_app_services_genre_service__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! src/app/services/genre.service */ 7776);




class GenresPageComponent extends src_app_componetns_base_component__WEBPACK_IMPORTED_MODULE_0__.BaseComponent {
    constructor(genreService) {
        super();
        this.genreService = genreService;
        this.genresList = [];
    }
    ngOnInit() {
        this.genreService
            .getGenres()
            .pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_2__.map)((genres) => genres.map((genre) => {
            const genreItem = {
                title: genre.name,
                pageLink: `${this.links.get(this.pageRoutes.Genre)}/${genre.id}`,
                updateLink: `${this.links.get(this.pageRoutes.UpdateGenre)}/${genre.id}`,
                deleteLink: `${this.links.get(this.pageRoutes.DeleteGenre)}/${genre.id}`,
            };
            return genreItem;
        })))
            .subscribe((x) => (this.genresList = x !== null && x !== void 0 ? x : []));
    }
}
GenresPageComponent.ɵfac = function GenresPageComponent_Factory(t) { return new (t || GenresPageComponent)(_angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵdirectiveInject"](src_app_services_genre_service__WEBPACK_IMPORTED_MODULE_1__.GenreService)); };
GenresPageComponent.ɵcmp = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵdefineComponent"]({ type: GenresPageComponent, selectors: [["gamestore-genres"]], features: [_angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵInheritDefinitionFeature"]], decls: 2, vars: 2, consts: [[3, "listItems", "addLink"]], template: function GenresPageComponent_Template(rf, ctx) { if (rf & 1) {
        _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementStart"](0, "article");
        _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelement"](1, "gamestore-list", 0);
        _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementEnd"]();
    } if (rf & 2) {
        _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵadvance"](1);
        _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵproperty"]("listItems", ctx.genresList)("addLink", ctx.links.get(ctx.pageRoutes.AddGenre));
    } }, styles: ["\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJnZW5yZXMtcGFnZS5jb21wb25lbnQuc2NzcyJ9 */"] });


/***/ }),

/***/ 7204:
/*!*********************************************************!*\
  !*** ./src/app/pages/genres-page/genres-page.module.ts ***!
  \*********************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "GenresPageModule": () => (/* binding */ GenresPageModule)
/* harmony export */ });
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/common */ 4364);
/* harmony import */ var src_app_componetns_common_components_module__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! src/app/componetns/common-components.module */ 1951);
/* harmony import */ var _genres_page_component__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./genres-page.component */ 4092);
/* harmony import */ var src_app_services_genre_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! src/app/services/genre.service */ 7776);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var _componetns_list_component_list_component__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../../componetns/list-component/list.component */ 9860);






class GenresPageModule {
}
GenresPageModule.ɵfac = function GenresPageModule_Factory(t) { return new (t || GenresPageModule)(); };
GenresPageModule.ɵmod = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵdefineNgModule"]({ type: GenresPageModule });
GenresPageModule.ɵinj = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵdefineInjector"]({ providers: [src_app_services_genre_service__WEBPACK_IMPORTED_MODULE_2__.GenreService], imports: [[_angular_common__WEBPACK_IMPORTED_MODULE_5__.CommonModule, src_app_componetns_common_components_module__WEBPACK_IMPORTED_MODULE_0__.CommonComponentsModule]] });
(function () { (typeof ngJitMode === "undefined" || ngJitMode) && _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵsetNgModuleScope"](GenresPageModule, { declarations: [_genres_page_component__WEBPACK_IMPORTED_MODULE_1__.GenresPageComponent], imports: [_angular_common__WEBPACK_IMPORTED_MODULE_5__.CommonModule, src_app_componetns_common_components_module__WEBPACK_IMPORTED_MODULE_0__.CommonComponentsModule] }); })();
_angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵsetComponentScope"](_genres_page_component__WEBPACK_IMPORTED_MODULE_1__.GenresPageComponent, [_componetns_list_component_list_component__WEBPACK_IMPORTED_MODULE_3__.ListComponent], []);


/***/ }),

/***/ 6728:
/*!********************************************************!*\
  !*** ./src/app/pages/main-page/main-page.component.ts ***!
  \********************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "MainPageComponent": () => (/* binding */ MainPageComponent)
/* harmony export */ });
/* harmony import */ var src_app_componetns_base_component__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! src/app/componetns/base.component */ 2844);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var _componetns_list_component_list_component__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../../componetns/list-component/list.component */ 9860);



class MainPageComponent extends src_app_componetns_base_component__WEBPACK_IMPORTED_MODULE_0__.BaseComponent {
    constructor() {
        super(...arguments);
        this.mainListItems = [
            {
                title: this.labels.gamesMenuItem,
                pageLink: this.links.get(this.pageRoutes.Games)
            },
            {
                title: this.labels.genresMenuItem,
                pageLink: this.links.get(this.pageRoutes.Genres)
            },
            {
                title: this.labels.platformsMenuItem,
                pageLink: this.links.get(this.pageRoutes.Platforms)
            },
            {
                title: this.labels.publishersMenuItem,
                pageLink: this.links.get(this.pageRoutes.Publishers)
            },
            {
                title: this.labels.ordersMenuItem,
                pageLink: this.links.get(this.pageRoutes.Orders)
            }
        ];
    }
}
MainPageComponent.ɵfac = /*@__PURE__*/ function () { let ɵMainPageComponent_BaseFactory; return function MainPageComponent_Factory(t) { return (ɵMainPageComponent_BaseFactory || (ɵMainPageComponent_BaseFactory = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵgetInheritedFactory"](MainPageComponent)))(t || MainPageComponent); }; }();
MainPageComponent.ɵcmp = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵdefineComponent"]({ type: MainPageComponent, selectors: [["gamestore-main"]], features: [_angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵInheritDefinitionFeature"]], decls: 2, vars: 1, consts: [[3, "listItems"]], template: function MainPageComponent_Template(rf, ctx) { if (rf & 1) {
        _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](0, "article");
        _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelement"](1, "gamestore-list", 0);
        _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
    } if (rf & 2) {
        _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](1);
        _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵproperty"]("listItems", ctx.mainListItems);
    } }, directives: [_componetns_list_component_list_component__WEBPACK_IMPORTED_MODULE_1__.ListComponent], styles: ["\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJtYWluLXBhZ2UuY29tcG9uZW50LnNjc3MifQ== */"] });


/***/ }),

/***/ 2287:
/*!*****************************************************!*\
  !*** ./src/app/pages/main-page/main-page.module.ts ***!
  \*****************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "MainPageModule": () => (/* binding */ MainPageModule)
/* harmony export */ });
/* harmony import */ var _main_page_component__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./main-page.component */ 6728);
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/common */ 4364);
/* harmony import */ var src_app_componetns_common_components_module__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! src/app/componetns/common-components.module */ 1951);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/core */ 2316);




class MainPageModule {
}
MainPageModule.ɵfac = function MainPageModule_Factory(t) { return new (t || MainPageModule)(); };
MainPageModule.ɵmod = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵdefineNgModule"]({ type: MainPageModule });
MainPageModule.ɵinj = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵdefineInjector"]({ imports: [[_angular_common__WEBPACK_IMPORTED_MODULE_3__.CommonModule, src_app_componetns_common_components_module__WEBPACK_IMPORTED_MODULE_1__.CommonComponentsModule]] });
(function () { (typeof ngJitMode === "undefined" || ngJitMode) && _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵsetNgModuleScope"](MainPageModule, { declarations: [_main_page_component__WEBPACK_IMPORTED_MODULE_0__.MainPageComponent], imports: [_angular_common__WEBPACK_IMPORTED_MODULE_3__.CommonModule, src_app_componetns_common_components_module__WEBPACK_IMPORTED_MODULE_1__.CommonComponentsModule] }); })();


/***/ }),

/***/ 6908:
/*!*********************************************************************************************************!*\
  !*** ./src/app/pages/make-order-page/components/terminal-result-component/terminal-result.component.ts ***!
  \*********************************************************************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "TerminalResultComponent": () => (/* binding */ TerminalResultComponent)
/* harmony export */ });
/* harmony import */ var src_app_componetns_base_component__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! src/app/componetns/base.component */ 2844);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/common */ 4364);
/* harmony import */ var _componetns_info_wrapper_component_info_wrapper_component__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../../../../componetns/info-wrapper-component/info-wrapper.component */ 7990);
/* harmony import */ var _componetns_info_component_info_component__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../../../../componetns/info-component/info.component */ 4130);





function TerminalResultComponent_div_0_Template(rf, ctx) { if (rf & 1) {
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementStart"](0, "div");
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementStart"](1, "gamestore-info-wrapper");
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelement"](2, "gamestore-info", 1);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementEnd"]();
} if (rf & 2) {
    const ctx_r0 = _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵnextContext"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵadvance"](2);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵproperty"]("infoList", ctx_r0.resultInfoList);
} }
class TerminalResultComponent extends src_app_componetns_base_component__WEBPACK_IMPORTED_MODULE_0__.BaseComponent {
    constructor() {
        super(...arguments);
        this.resultInfoList = [];
    }
    set terminalResult(value) {
        this.resultInfoList = [];
        if (!value) {
            return;
        }
        this.resultInfoList.push({
            name: 'User Id',
            value: value.userId,
        }, {
            name: 'Order Id',
            value: value.orderId,
        }, {
            name: 'Payment Date',
            value: value.paymentDate,
        }, {
            name: 'Sum',
            value: value.sum.toString(),
        });
    }
}
TerminalResultComponent.ɵfac = /*@__PURE__*/ function () { let ɵTerminalResultComponent_BaseFactory; return function TerminalResultComponent_Factory(t) { return (ɵTerminalResultComponent_BaseFactory || (ɵTerminalResultComponent_BaseFactory = _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵgetInheritedFactory"](TerminalResultComponent)))(t || TerminalResultComponent); }; }();
TerminalResultComponent.ɵcmp = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵdefineComponent"]({ type: TerminalResultComponent, selectors: [["gamestore-terminal-result"]], inputs: { terminalResult: "terminalResult" }, features: [_angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵInheritDefinitionFeature"]], decls: 1, vars: 1, consts: [[4, "ngIf"], [3, "infoList"]], template: function TerminalResultComponent_Template(rf, ctx) { if (rf & 1) {
        _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵtemplate"](0, TerminalResultComponent_div_0_Template, 3, 1, "div", 0);
    } if (rf & 2) {
        _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵproperty"]("ngIf", !!(ctx.resultInfoList == null ? null : ctx.resultInfoList.length));
    } }, directives: [_angular_common__WEBPACK_IMPORTED_MODULE_4__.NgIf, _componetns_info_wrapper_component_info_wrapper_component__WEBPACK_IMPORTED_MODULE_1__.InfoWrapperComponent, _componetns_info_component_info_component__WEBPACK_IMPORTED_MODULE_2__.InfoComponent], styles: ["\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJ0ZXJtaW5hbC1yZXN1bHQuY29tcG9uZW50LnNjc3MifQ== */"] });


/***/ }),

/***/ 2550:
/*!***************************************************************************************************!*\
  !*** ./src/app/pages/make-order-page/components/visa-payment-component/visa-payment.component.ts ***!
  \***************************************************************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "VisaPaymentComponent": () => (/* binding */ VisaPaymentComponent)
/* harmony export */ });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var src_app_componetns_base_component__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! src/app/componetns/base.component */ 2844);
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/forms */ 1707);
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! @angular/common */ 4364);
/* harmony import */ var _componetns_form_component_form_component__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../../../../componetns/form-component/form.component */ 8205);
/* harmony import */ var _componetns_text_input_component_text_input_component__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../../../../componetns/text-input-component/text-input.component */ 2082);
/* harmony import */ var _componetns_number_input_component_number_input_component__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../../../../componetns/number-input-component/number-input.component */ 9567);








function VisaPaymentComponent_article_0_Template(rf, ctx) { if (rf & 1) {
    const _r2 = _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵgetCurrentView"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵelementStart"](0, "article");
    _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵelementStart"](1, "gamestore-form", 1);
    _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵlistener"]("save", function VisaPaymentComponent_article_0_Template_gamestore_form_save_1_listener() { _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵrestoreView"](_r2); const ctx_r1 = _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵnextContext"](); return ctx_r1.payVisa.emit(ctx_r1.form.value); });
    _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵelement"](2, "gamestore-text-input", 2);
    _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵelement"](3, "gamestore-text-input", 3);
    _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵelement"](4, "gamestore-number-input", 4);
    _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵelement"](5, "gamestore-number-input", 5);
    _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵelement"](6, "gamestore-number-input", 6);
    _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵelementEnd"]();
} if (rf & 2) {
    const ctx_r0 = _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵnextContext"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵproperty"]("form", ctx_r0.form);
    _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵproperty"]("control", ctx_r0.getFormControl("holder"));
    _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵproperty"]("control", ctx_r0.getFormControl("cardNumber"));
    _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵproperty"]("control", ctx_r0.getFormControl("monthExpire"));
    _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵproperty"]("control", ctx_r0.getFormControl("yearExpire"));
    _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵproperty"]("control", ctx_r0.getFormControl("cvv2"));
} }
class VisaPaymentComponent extends src_app_componetns_base_component__WEBPACK_IMPORTED_MODULE_0__.BaseComponent {
    constructor(builder) {
        super();
        this.builder = builder;
        this.payVisa = new _angular_core__WEBPACK_IMPORTED_MODULE_4__.EventEmitter();
    }
    getFormControl(name) {
        var _a;
        return (_a = this.form) === null || _a === void 0 ? void 0 : _a.get(name);
    }
    ngOnInit() {
        this.form = this.builder.group({
            holder: [''],
            cardNumber: [''],
            monthExpire: [''],
            yearExpire: [''],
            cvv2: [''],
        });
    }
}
VisaPaymentComponent.ɵfac = function VisaPaymentComponent_Factory(t) { return new (t || VisaPaymentComponent)(_angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵdirectiveInject"](_angular_forms__WEBPACK_IMPORTED_MODULE_5__.FormBuilder)); };
VisaPaymentComponent.ɵcmp = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵdefineComponent"]({ type: VisaPaymentComponent, selectors: [["gamestore-visa-payment"]], outputs: { payVisa: "payVisa" }, features: [_angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵInheritDefinitionFeature"]], decls: 1, vars: 1, consts: [[4, "ngIf"], [3, "form", "save"], ["name", "Holder", 3, "control"], ["name", "Card Number", 3, "control"], ["name", "Month Expire", 3, "control"], ["name", "Year Expire", 3, "control"], ["name", "CVV2", 3, "control"]], template: function VisaPaymentComponent_Template(rf, ctx) { if (rf & 1) {
        _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵtemplate"](0, VisaPaymentComponent_article_0_Template, 7, 6, "article", 0);
    } if (rf & 2) {
        _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵproperty"]("ngIf", !!ctx.form);
    } }, directives: [_angular_common__WEBPACK_IMPORTED_MODULE_6__.NgIf, _componetns_form_component_form_component__WEBPACK_IMPORTED_MODULE_1__.FormComponent, _componetns_text_input_component_text_input_component__WEBPACK_IMPORTED_MODULE_2__.TextInputComponent, _componetns_number_input_component_number_input_component__WEBPACK_IMPORTED_MODULE_3__.NumberInputComponent], styles: ["\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJ2aXNhLXBheW1lbnQuY29tcG9uZW50LnNjc3MifQ== */"] });


/***/ }),

/***/ 8427:
/*!********************************************************************!*\
  !*** ./src/app/pages/make-order-page/make-order-page.component.ts ***!
  \********************************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "MakeOrderPageComponent": () => (/* binding */ MakeOrderPageComponent)
/* harmony export */ });
/* harmony import */ var src_app_componetns_base_component__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! src/app/componetns/base.component */ 2844);
/* harmony import */ var _payment_methods_enum__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./payment-methods.enum */ 8993);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var src_app_services_order_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! src/app/services/order.service */ 8132);
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/router */ 1258);





function MakeOrderPageComponent_div_0_div_1_div_3_div_1_Template(rf, ctx) { if (rf & 1) {
    const _r8 = _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵgetCurrentView"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementStart"](0, "div", 7);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelement"](1, "img", 8);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementStart"](2, "span", 9);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵtext"](3);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementStart"](4, "span");
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵtext"](5);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementStart"](6, "button", 10);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵlistener"]("click", function MakeOrderPageComponent_div_0_div_1_div_3_div_1_Template_button_click_6_listener() { const restoredCtx = _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵrestoreView"](_r8); const method_r6 = restoredCtx.$implicit; const ctx_r7 = _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵnextContext"](4); return ctx_r7.onPay(method_r6.method); });
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵtext"](7);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementEnd"]();
} if (rf & 2) {
    const method_r6 = ctx.$implicit;
    const ctx_r5 = _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵnextContext"](4);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵpropertyInterpolate"]("src", method_r6.imageUrl, _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵsanitizeUrl"]);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵadvance"](2);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵtextInterpolate"](method_r6.title);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵadvance"](2);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵtextInterpolate"](method_r6.description);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵadvance"](2);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵtextInterpolate1"](" ", ctx_r5.labels.payButtonLabel, " ");
} }
function MakeOrderPageComponent_div_0_div_1_div_3_Template(rf, ctx) { if (rf & 1) {
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementStart"](0, "div");
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵtemplate"](1, MakeOrderPageComponent_div_0_div_1_div_3_div_1_Template, 8, 4, "div", 6);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementEnd"]();
} if (rf & 2) {
    const ctx_r4 = _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵnextContext"](3);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵproperty"]("ngForOf", ctx_r4.paymentMethods);
} }
function MakeOrderPageComponent_div_0_div_1_Template(rf, ctx) { if (rf & 1) {
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementStart"](0, "div");
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementStart"](1, "div", 5);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵtext"](2);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵtemplate"](3, MakeOrderPageComponent_div_0_div_1_div_3_Template, 2, 1, "div", 2);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementEnd"]();
} if (rf & 2) {
    const ctx_r1 = _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵnextContext"](2);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵadvance"](2);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵtextInterpolate2"]("", ctx_r1.labels.totalLabel, " : ", ctx_r1.totalForPay, "");
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵproperty"]("ngIf", !!(ctx_r1.paymentMethods == null ? null : ctx_r1.paymentMethods.length));
} }
function MakeOrderPageComponent_div_0_gamestore_terminal_result_2_Template(rf, ctx) { if (rf & 1) {
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelement"](0, "gamestore-terminal-result", 11);
} if (rf & 2) {
    const ctx_r2 = _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵnextContext"](2);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵproperty"]("terminalResult", ctx_r2.terminalResult);
} }
function MakeOrderPageComponent_div_0_gamestore_visa_payment_3_Template(rf, ctx) { if (rf & 1) {
    const _r10 = _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵgetCurrentView"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementStart"](0, "gamestore-visa-payment", 12);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵlistener"]("payVisa", function MakeOrderPageComponent_div_0_gamestore_visa_payment_3_Template_gamestore_visa_payment_payVisa_0_listener($event) { _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵrestoreView"](_r10); const ctx_r9 = _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵnextContext"](2); return ctx_r9.onPayVisa($event); });
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementEnd"]();
} }
function MakeOrderPageComponent_div_0_Template(rf, ctx) { if (rf & 1) {
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementStart"](0, "div", 1);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵtemplate"](1, MakeOrderPageComponent_div_0_div_1_Template, 4, 3, "div", 2);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵtemplate"](2, MakeOrderPageComponent_div_0_gamestore_terminal_result_2_Template, 1, 1, "gamestore-terminal-result", 3);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵtemplate"](3, MakeOrderPageComponent_div_0_gamestore_visa_payment_3_Template, 1, 0, "gamestore-visa-payment", 4);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementEnd"]();
} if (rf & 2) {
    const ctx_r0 = _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵnextContext"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵproperty"]("ngIf", !ctx_r0.terminalResult && !ctx_r0.paymentViaVisa);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵproperty"]("ngIf", !!ctx_r0.terminalResult && !ctx_r0.paymentViaVisa);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵproperty"]("ngIf", !ctx_r0.terminalResult && ctx_r0.paymentViaVisa);
} }
class MakeOrderPageComponent extends src_app_componetns_base_component__WEBPACK_IMPORTED_MODULE_0__.BaseComponent {
    constructor(orderService, router) {
        super();
        this.orderService = orderService;
        this.router = router;
        this.paymentViaVisa = false;
        this.paymentMethods = [];
    }
    ngOnInit() {
        this.orderService.getBasket().subscribe((x) => {
            if (!(x === null || x === void 0 ? void 0 : x.length)) {
                return;
            }
            let total = 0;
            x.forEach((z) => {
                var _a, _b, _c, _d, _e;
                return (total +=
                    ((_a = z.price) !== null && _a !== void 0 ? _a : 0) * ((_b = z.quantity) !== null && _b !== void 0 ? _b : 0) -
                        (((_c = z.discount) !== null && _c !== void 0 ? _c : 0) * ((_d = z.price) !== null && _d !== void 0 ? _d : 0) * ((_e = z.quantity) !== null && _e !== void 0 ? _e : 0)) / 100);
            });
            this.totalForPay = Number.parseInt(total.toString());
        });
        this.orderService.getMakeOrderInfo().subscribe((x) => {
            var _a, _b, _c;
            return (this.paymentMethods =
                (_c = (_b = (_a = x === null || x === void 0 ? void 0 : x.paymentMethods) === null || _a === void 0 ? void 0 : _a.filter((z) => !!(z === null || z === void 0 ? void 0 : z.title) &&
                    Object.values(_payment_methods_enum__WEBPACK_IMPORTED_MODULE_1__.PaymentMethods).some((y) => y === z.title))) === null || _b === void 0 ? void 0 : _b.map((z) => {
                    return {
                        title: z.title,
                        description: z.description,
                        imageUrl: z.imageUrl,
                        method: z.title === _payment_methods_enum__WEBPACK_IMPORTED_MODULE_1__.PaymentMethods.Visa
                            ? _payment_methods_enum__WEBPACK_IMPORTED_MODULE_1__.PaymentMethods.Visa
                            : z.title === _payment_methods_enum__WEBPACK_IMPORTED_MODULE_1__.PaymentMethods.Terminal
                                ? _payment_methods_enum__WEBPACK_IMPORTED_MODULE_1__.PaymentMethods.Terminal
                                : _payment_methods_enum__WEBPACK_IMPORTED_MODULE_1__.PaymentMethods.Bank,
                    };
                })) !== null && _c !== void 0 ? _c : []);
        });
    }
    onPay(method) {
        switch (method) {
            case _payment_methods_enum__WEBPACK_IMPORTED_MODULE_1__.PaymentMethods.Bank:
                this.payViaBank();
                break;
            case _payment_methods_enum__WEBPACK_IMPORTED_MODULE_1__.PaymentMethods.Terminal:
                this.payViaTerminal();
                break;
            case _payment_methods_enum__WEBPACK_IMPORTED_MODULE_1__.PaymentMethods.Visa:
                this.payVisa();
                break;
        }
    }
    payViaBank() {
        this.orderService.getBankFile(_payment_methods_enum__WEBPACK_IMPORTED_MODULE_1__.PaymentMethods.Bank).subscribe((data) => {
            const downloadURL = window.URL.createObjectURL(data);
            window.open(downloadURL);
            this.router.navigateByUrl('');
        });
    }
    payViaTerminal() {
        this.orderService.payTerminal(_payment_methods_enum__WEBPACK_IMPORTED_MODULE_1__.PaymentMethods.Terminal).subscribe((data) => {
            this.terminalResult = data;
        });
    }
    payVisa() {
        this.paymentViaVisa = true;
    }
    onPayVisa(model) {
        this.orderService.payVisa(_payment_methods_enum__WEBPACK_IMPORTED_MODULE_1__.PaymentMethods.Visa, model).subscribe((_) => {
            this.router.navigateByUrl('');
        });
    }
}
MakeOrderPageComponent.ɵfac = function MakeOrderPageComponent_Factory(t) { return new (t || MakeOrderPageComponent)(_angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵdirectiveInject"](src_app_services_order_service__WEBPACK_IMPORTED_MODULE_2__.OrderService), _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵdirectiveInject"](_angular_router__WEBPACK_IMPORTED_MODULE_4__.Router)); };
MakeOrderPageComponent.ɵcmp = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵdefineComponent"]({ type: MakeOrderPageComponent, selectors: [["gamestore-make-order"]], features: [_angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵInheritDefinitionFeature"]], decls: 1, vars: 1, consts: [["class", "make-order-container", 4, "ngIf"], [1, "make-order-container"], [4, "ngIf"], [3, "terminalResult", 4, "ngIf"], [3, "payVisa", 4, "ngIf"], [1, "total"], ["class", "payment-method", 4, "ngFor", "ngForOf"], [1, "payment-method"], [3, "src"], [1, "title"], ["mat-raised-button", "", "color", "primary", "type", "button", 3, "click"], [3, "terminalResult"], [3, "payVisa"]], template: function MakeOrderPageComponent_Template(rf, ctx) { if (rf & 1) {
        _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵtemplate"](0, MakeOrderPageComponent_div_0_Template, 4, 3, "div", 0);
    } if (rf & 2) {
        _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵproperty"]("ngIf", ctx.totalForPay !== undefined);
    } }, styles: [".make-order-container[_ngcontent-%COMP%] {\n  padding: 15px;\n}\n.make-order-container[_ngcontent-%COMP%]   .total[_ngcontent-%COMP%] {\n  margin-bottom: 20px;\n  font-size: 18px;\n}\n.make-order-container[_ngcontent-%COMP%]   .payment-method[_ngcontent-%COMP%] {\n  margin-bottom: 15px;\n}\n.make-order-container[_ngcontent-%COMP%]   .payment-method[_ngcontent-%COMP%]   img[_ngcontent-%COMP%] {\n  width: 50px;\n  height: 50px;\n  margin-right: 20px;\n}\n.make-order-container[_ngcontent-%COMP%]   .payment-method[_ngcontent-%COMP%]   span[_ngcontent-%COMP%] {\n  display: inline-block;\n  padding-right: 15px;\n  top: -20px;\n  position: relative;\n}\n.make-order-container[_ngcontent-%COMP%]   .payment-method[_ngcontent-%COMP%]   .title[_ngcontent-%COMP%] {\n  font-size: 18px;\n  font-weight: 550;\n}\n.make-order-container[_ngcontent-%COMP%]   .payment-method[_ngcontent-%COMP%]   button[_ngcontent-%COMP%] {\n  margin-left: 10px;\n  top: -20px;\n  position: relative;\n}\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbIm1ha2Utb3JkZXItcGFnZS5jb21wb25lbnQuc2NzcyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiQUFBQTtFQUNJLGFBQUE7QUFDSjtBQUNJO0VBQ0ksbUJBQUE7RUFDQSxlQUFBO0FBQ1I7QUFFSTtFQUNJLG1CQUFBO0FBQVI7QUFFUTtFQUNJLFdBQUE7RUFDQSxZQUFBO0VBRUEsa0JBQUE7QUFEWjtBQUlRO0VBQ0kscUJBQUE7RUFDQSxtQkFBQTtFQUNBLFVBQUE7RUFDQSxrQkFBQTtBQUZaO0FBS1E7RUFDSSxlQUFBO0VBQ0EsZ0JBQUE7QUFIWjtBQU1RO0VBQ0ksaUJBQUE7RUFDQSxVQUFBO0VBQ0Esa0JBQUE7QUFKWiIsImZpbGUiOiJtYWtlLW9yZGVyLXBhZ2UuY29tcG9uZW50LnNjc3MiLCJzb3VyY2VzQ29udGVudCI6WyIubWFrZS1vcmRlci1jb250YWluZXIge1xyXG4gICAgcGFkZGluZzogMTVweDtcclxuXHJcbiAgICAudG90YWwge1xyXG4gICAgICAgIG1hcmdpbi1ib3R0b206IDIwcHg7XHJcbiAgICAgICAgZm9udC1zaXplOiAxOHB4O1xyXG4gICAgfVxyXG5cclxuICAgIC5wYXltZW50LW1ldGhvZCB7XHJcbiAgICAgICAgbWFyZ2luLWJvdHRvbTogMTVweDtcclxuXHJcbiAgICAgICAgaW1nIHtcclxuICAgICAgICAgICAgd2lkdGg6IDUwcHg7XHJcbiAgICAgICAgICAgIGhlaWdodDogNTBweDtcclxuXHJcbiAgICAgICAgICAgIG1hcmdpbi1yaWdodDogMjBweDtcclxuICAgICAgICB9XHJcblxyXG4gICAgICAgIHNwYW4ge1xyXG4gICAgICAgICAgICBkaXNwbGF5OiBpbmxpbmUtYmxvY2s7XHJcbiAgICAgICAgICAgIHBhZGRpbmctcmlnaHQ6IDE1cHg7XHJcbiAgICAgICAgICAgIHRvcDogLTIwcHg7XHJcbiAgICAgICAgICAgIHBvc2l0aW9uOiByZWxhdGl2ZTtcclxuICAgICAgICB9XHJcblxyXG4gICAgICAgIC50aXRsZSB7XHJcbiAgICAgICAgICAgIGZvbnQtc2l6ZTogMThweDtcclxuICAgICAgICAgICAgZm9udC13ZWlnaHQ6IDU1MDtcclxuICAgICAgICB9XHJcblxyXG4gICAgICAgIGJ1dHRvbiB7XHJcbiAgICAgICAgICAgIG1hcmdpbi1sZWZ0OiAxMHB4O1xyXG4gICAgICAgICAgICB0b3A6IC0yMHB4O1xyXG4gICAgICAgICAgICBwb3NpdGlvbjogcmVsYXRpdmU7XHJcbiAgICAgICAgfVxyXG4gICAgfVxyXG59Il19 */"] });


/***/ }),

/***/ 893:
/*!*****************************************************************!*\
  !*** ./src/app/pages/make-order-page/make-order-page.module.ts ***!
  \*****************************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "MakeOrderPageModule": () => (/* binding */ MakeOrderPageModule)
/* harmony export */ });
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! @angular/common */ 4364);
/* harmony import */ var src_app_componetns_common_components_module__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! src/app/componetns/common-components.module */ 1951);
/* harmony import */ var src_app_app_routing_module__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! src/app/app-routing.module */ 158);
/* harmony import */ var _angular_material_button__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! @angular/material/button */ 781);
/* harmony import */ var src_app_services_order_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! src/app/services/order.service */ 8132);
/* harmony import */ var _make_order_page_component__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./make-order-page.component */ 8427);
/* harmony import */ var _components_terminal_result_component_terminal_result_component__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ./components/terminal-result-component/terminal-result.component */ 6908);
/* harmony import */ var _components_visa_payment_component_visa_payment_component__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ./components/visa-payment-component/visa-payment.component */ 2550);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! @angular/core */ 2316);











class MakeOrderPageModule {
}
MakeOrderPageModule.ɵfac = function MakeOrderPageModule_Factory(t) { return new (t || MakeOrderPageModule)(); };
MakeOrderPageModule.ɵmod = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵdefineNgModule"]({ type: MakeOrderPageModule });
MakeOrderPageModule.ɵinj = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵdefineInjector"]({ providers: [src_app_services_order_service__WEBPACK_IMPORTED_MODULE_2__.OrderService], imports: [[
            _angular_common__WEBPACK_IMPORTED_MODULE_7__.CommonModule,
            src_app_componetns_common_components_module__WEBPACK_IMPORTED_MODULE_0__.CommonComponentsModule,
            src_app_app_routing_module__WEBPACK_IMPORTED_MODULE_1__.AppRoutingModule,
            _angular_material_button__WEBPACK_IMPORTED_MODULE_8__.MatButtonModule,
        ]] });
(function () { (typeof ngJitMode === "undefined" || ngJitMode) && _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵsetNgModuleScope"](MakeOrderPageModule, { declarations: [_make_order_page_component__WEBPACK_IMPORTED_MODULE_3__.MakeOrderPageComponent, _components_terminal_result_component_terminal_result_component__WEBPACK_IMPORTED_MODULE_4__.TerminalResultComponent, _components_visa_payment_component_visa_payment_component__WEBPACK_IMPORTED_MODULE_5__.VisaPaymentComponent], imports: [_angular_common__WEBPACK_IMPORTED_MODULE_7__.CommonModule,
        src_app_componetns_common_components_module__WEBPACK_IMPORTED_MODULE_0__.CommonComponentsModule,
        src_app_app_routing_module__WEBPACK_IMPORTED_MODULE_1__.AppRoutingModule,
        _angular_material_button__WEBPACK_IMPORTED_MODULE_8__.MatButtonModule] }); })();
_angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵsetComponentScope"](_make_order_page_component__WEBPACK_IMPORTED_MODULE_3__.MakeOrderPageComponent, [_angular_common__WEBPACK_IMPORTED_MODULE_7__.NgIf, _angular_common__WEBPACK_IMPORTED_MODULE_7__.NgForOf, _angular_material_button__WEBPACK_IMPORTED_MODULE_8__.MatButton, _components_terminal_result_component_terminal_result_component__WEBPACK_IMPORTED_MODULE_4__.TerminalResultComponent, _components_visa_payment_component_visa_payment_component__WEBPACK_IMPORTED_MODULE_5__.VisaPaymentComponent], []);


/***/ }),

/***/ 8993:
/*!***************************************************************!*\
  !*** ./src/app/pages/make-order-page/payment-methods.enum.ts ***!
  \***************************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "PaymentMethods": () => (/* binding */ PaymentMethods)
/* harmony export */ });
var PaymentMethods;
(function (PaymentMethods) {
    PaymentMethods["Bank"] = "Bank";
    PaymentMethods["Terminal"] = "IBox terminal";
    PaymentMethods["Visa"] = "Visa";
})(PaymentMethods || (PaymentMethods = {}));


/***/ }),

/***/ 3733:
/*!**********************************************************!*\
  !*** ./src/app/pages/order-page/order-page.component.ts ***!
  \**********************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "OrderPageComponent": () => (/* binding */ OrderPageComponent)
/* harmony export */ });
/* harmony import */ var rxjs__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! rxjs */ 2720);
/* harmony import */ var rxjs_operators__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! rxjs/operators */ 9902);
/* harmony import */ var rxjs_operators__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! rxjs/operators */ 8636);
/* harmony import */ var rxjs_operators__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! rxjs/operators */ 3927);
/* harmony import */ var src_app_componetns_base_component__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! src/app/componetns/base.component */ 2844);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var src_app_services_order_service__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! src/app/services/order.service */ 8132);
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! @angular/router */ 1258);
/* harmony import */ var src_app_services_game_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! src/app/services/game.service */ 1397);
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_9__ = __webpack_require__(/*! @angular/common */ 4364);








function OrderPageComponent_div_0_Template(rf, ctx) { if (rf & 1) {
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementStart"](0, "div");
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementStart"](1, "div", 1);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementStart"](2, "a", 2);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵtext"](3);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementStart"](4, "gamestore-info-wrapper");
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelement"](5, "gamestore-info", 3);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementEnd"]();
} if (rf & 2) {
    const ctx_r0 = _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵnextContext"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵadvance"](2);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵpropertyInterpolate"]("routerLink", ctx_r0.links.get(ctx_r0.pageRoutes.Orders));
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵtextInterpolate1"](" ", ctx_r0.labels.ordersMenuItem, " ");
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵadvance"](2);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵproperty"]("infoList", ctx_r0.orderInfoList);
} }
class OrderPageComponent extends src_app_componetns_base_component__WEBPACK_IMPORTED_MODULE_0__.BaseComponent {
    constructor(orderService, route, gameService, datePipe) {
        super();
        this.orderService = orderService;
        this.route = route;
        this.gameService = gameService;
        this.datePipe = datePipe;
        this.orderInfoList = [];
    }
    get order() {
        return this.orderValue;
    }
    set order(value) {
        var _a;
        this.orderValue = value;
        this.orderInfoList = [];
        if (!value) {
            return;
        }
        this.orderInfoList.push({
            name: this.labels.orderCustomerId,
            value: value.customerId,
        }, {
            name: this.labels.orderDate,
            value: !!value.date
                ? (_a = this.datePipe.transform(value.date, 'yyyy-MM-dd')) !== null && _a !== void 0 ? _a : ''
                : '',
        });
    }
    ngOnInit() {
        this.getRouteParam(this.route, 'id')
            .pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_4__.switchMap)((x) => (0,rxjs__WEBPACK_IMPORTED_MODULE_5__.forkJoin)({
            order: this.orderService.getOrder(x),
            orderDetails: this.orderService.getOrderDetails(x),
        })), (0,rxjs_operators__WEBPACK_IMPORTED_MODULE_6__.tap)((x) => (this.order = x.order)), (0,rxjs_operators__WEBPACK_IMPORTED_MODULE_4__.switchMap)((x) => (0,rxjs__WEBPACK_IMPORTED_MODULE_5__.forkJoin)(x.orderDetails.map((z) => this.gameService.getGameById(z.productId).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_7__.map)((y) => {
            return { orderDetail: z, game: y };
        }))))))
            .subscribe((x) => {
            if (!!(x === null || x === void 0 ? void 0 : x.length)) {
                this.addDetailsInfo(x);
            }
        });
    }
    addDetailsInfo(details) {
        if (!(details === null || details === void 0 ? void 0 : details.length)) {
            return;
        }
        const detailsInfo = {
            name: this.labels.orderDetailsLabel,
            nestedValues: [],
        };
        this.orderInfoList.push(detailsInfo);
        details.forEach((x) => {
            const detailInfo = {
                nestedValues: [],
            };
            detailInfo.nestedValues.push({
                title: x.game.name,
                pageLink: `${this.links.get(this.pageRoutes.Game)}/${x.game.key}`,
            });
            detailInfo.nestedValues.push({
                title: x.orderDetail.price === undefined
                    ? ''
                    : `${this.labels.orderDetailsPriceLabel}: ${x.orderDetail.price}`,
            });
            detailInfo.nestedValues.push({
                title: x.orderDetail.discount === undefined
                    ? ''
                    : `${this.labels.orderDetailsDiscountLabel}: ${x.orderDetail.discount}`,
            });
            detailInfo.nestedValues.push({
                title: x.orderDetail.quantity === undefined
                    ? ''
                    : `${this.labels.orderDetailsQuantityLabel}: ${x.orderDetail.quantity}`,
            });
            this.orderInfoList.push(detailInfo);
        });
    }
}
OrderPageComponent.ɵfac = function OrderPageComponent_Factory(t) { return new (t || OrderPageComponent)(_angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵdirectiveInject"](src_app_services_order_service__WEBPACK_IMPORTED_MODULE_1__.OrderService), _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵdirectiveInject"](_angular_router__WEBPACK_IMPORTED_MODULE_8__.ActivatedRoute), _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵdirectiveInject"](src_app_services_game_service__WEBPACK_IMPORTED_MODULE_2__.GameService), _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵdirectiveInject"](_angular_common__WEBPACK_IMPORTED_MODULE_9__.DatePipe)); };
OrderPageComponent.ɵcmp = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵdefineComponent"]({ type: OrderPageComponent, selectors: [["gamestore-order"]], features: [_angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵInheritDefinitionFeature"]], decls: 1, vars: 1, consts: [[4, "ngIf"], [1, "to-list-button"], ["mat-button", "", 3, "routerLink"], [3, "infoList"]], template: function OrderPageComponent_Template(rf, ctx) { if (rf & 1) {
        _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵtemplate"](0, OrderPageComponent_div_0_Template, 6, 3, "div", 0);
    } if (rf & 2) {
        _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵproperty"]("ngIf", !!ctx.order);
    } }, styles: [".to-list-button[_ngcontent-%COMP%] {\n  margin-bottom: 10px;\n}\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbIm9yZGVyLXBhZ2UuY29tcG9uZW50LnNjc3MiXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IkFBQUE7RUFDSSxtQkFBQTtBQUNKIiwiZmlsZSI6Im9yZGVyLXBhZ2UuY29tcG9uZW50LnNjc3MiLCJzb3VyY2VzQ29udGVudCI6WyIudG8tbGlzdC1idXR0b24ge1xyXG4gICAgbWFyZ2luLWJvdHRvbTogMTBweDtcclxufSJdfQ== */"] });


/***/ }),

/***/ 7235:
/*!*******************************************************!*\
  !*** ./src/app/pages/order-page/order-page.module.ts ***!
  \*******************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "OrderPageModule": () => (/* binding */ OrderPageModule)
/* harmony export */ });
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! @angular/common */ 4364);
/* harmony import */ var src_app_componetns_common_components_module__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! src/app/componetns/common-components.module */ 1951);
/* harmony import */ var src_app_app_routing_module__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! src/app/app-routing.module */ 158);
/* harmony import */ var _angular_material_button__WEBPACK_IMPORTED_MODULE_9__ = __webpack_require__(/*! @angular/material/button */ 781);
/* harmony import */ var src_app_services_game_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! src/app/services/game.service */ 1397);
/* harmony import */ var src_app_services_order_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! src/app/services/order.service */ 8132);
/* harmony import */ var _order_page_component__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ./order-page.component */ 3733);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_10__ = __webpack_require__(/*! @angular/router */ 1258);
/* harmony import */ var _componetns_info_wrapper_component_info_wrapper_component__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ../../componetns/info-wrapper-component/info-wrapper.component */ 7990);
/* harmony import */ var _componetns_info_component_info_component__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ../../componetns/info-component/info.component */ 4130);













class OrderPageModule {
}
OrderPageModule.ɵfac = function OrderPageModule_Factory(t) { return new (t || OrderPageModule)(); };
OrderPageModule.ɵmod = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_7__["ɵɵdefineNgModule"]({ type: OrderPageModule });
OrderPageModule.ɵinj = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_7__["ɵɵdefineInjector"]({ providers: [src_app_services_order_service__WEBPACK_IMPORTED_MODULE_3__.OrderService, src_app_services_game_service__WEBPACK_IMPORTED_MODULE_2__.GameService, _angular_common__WEBPACK_IMPORTED_MODULE_8__.DatePipe], imports: [[
            _angular_common__WEBPACK_IMPORTED_MODULE_8__.CommonModule,
            src_app_componetns_common_components_module__WEBPACK_IMPORTED_MODULE_0__.CommonComponentsModule,
            src_app_app_routing_module__WEBPACK_IMPORTED_MODULE_1__.AppRoutingModule,
            _angular_material_button__WEBPACK_IMPORTED_MODULE_9__.MatButtonModule,
        ]] });
(function () { (typeof ngJitMode === "undefined" || ngJitMode) && _angular_core__WEBPACK_IMPORTED_MODULE_7__["ɵɵsetNgModuleScope"](OrderPageModule, { declarations: [_order_page_component__WEBPACK_IMPORTED_MODULE_4__.OrderPageComponent], imports: [_angular_common__WEBPACK_IMPORTED_MODULE_8__.CommonModule,
        src_app_componetns_common_components_module__WEBPACK_IMPORTED_MODULE_0__.CommonComponentsModule,
        src_app_app_routing_module__WEBPACK_IMPORTED_MODULE_1__.AppRoutingModule,
        _angular_material_button__WEBPACK_IMPORTED_MODULE_9__.MatButtonModule] }); })();
_angular_core__WEBPACK_IMPORTED_MODULE_7__["ɵɵsetComponentScope"](_order_page_component__WEBPACK_IMPORTED_MODULE_4__.OrderPageComponent, [_angular_common__WEBPACK_IMPORTED_MODULE_8__.NgIf, _angular_material_button__WEBPACK_IMPORTED_MODULE_9__.MatAnchor, _angular_router__WEBPACK_IMPORTED_MODULE_10__.RouterLinkWithHref, _componetns_info_wrapper_component_info_wrapper_component__WEBPACK_IMPORTED_MODULE_5__.InfoWrapperComponent, _componetns_info_component_info_component__WEBPACK_IMPORTED_MODULE_6__.InfoComponent], []);


/***/ }),

/***/ 4158:
/*!************************************************************!*\
  !*** ./src/app/pages/orders-page/orders-page.component.ts ***!
  \************************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "OrdersPageComponent": () => (/* binding */ OrdersPageComponent)
/* harmony export */ });
/* harmony import */ var rxjs_operators__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! rxjs/operators */ 3927);
/* harmony import */ var src_app_componetns_base_component__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! src/app/componetns/base.component */ 2844);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var src_app_services_order_service__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! src/app/services/order.service */ 8132);
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/common */ 4364);





class OrdersPageComponent extends src_app_componetns_base_component__WEBPACK_IMPORTED_MODULE_0__.BaseComponent {
    constructor(orderService, datePipe) {
        super();
        this.orderService = orderService;
        this.datePipe = datePipe;
        this.ordersList = [];
    }
    ngOnInit() {
        this.orderService
            .getOrders()
            .pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_2__.map)((orders) => orders.map((order) => {
            const orderItem = {
                title: !!order.date
                    ? `${this.labels.orderCustomerId}:${order.customerId} - ${this.labels.orderDate}:${this.datePipe.transform(order.date, 'yyyy-MM-dd')}`
                    : `${this.labels.orderCustomerId}:${order.customerId}`,
                pageLink: `${this.links.get(this.pageRoutes.Order)}/${order.id}`,
            };
            return orderItem;
        })))
            .subscribe((x) => (this.ordersList = x !== null && x !== void 0 ? x : []));
    }
}
OrdersPageComponent.ɵfac = function OrdersPageComponent_Factory(t) { return new (t || OrdersPageComponent)(_angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵdirectiveInject"](src_app_services_order_service__WEBPACK_IMPORTED_MODULE_1__.OrderService), _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵdirectiveInject"](_angular_common__WEBPACK_IMPORTED_MODULE_4__.DatePipe)); };
OrdersPageComponent.ɵcmp = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵdefineComponent"]({ type: OrdersPageComponent, selectors: [["gamestore-orders"]], features: [_angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵInheritDefinitionFeature"]], decls: 2, vars: 1, consts: [[3, "listItems"]], template: function OrdersPageComponent_Template(rf, ctx) { if (rf & 1) {
        _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementStart"](0, "article");
        _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelement"](1, "gamestore-list", 0);
        _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementEnd"]();
    } if (rf & 2) {
        _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵadvance"](1);
        _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵproperty"]("listItems", ctx.ordersList);
    } }, styles: ["\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJvcmRlcnMtcGFnZS5jb21wb25lbnQuc2NzcyJ9 */"] });


/***/ }),

/***/ 5529:
/*!*********************************************************!*\
  !*** ./src/app/pages/orders-page/orders-page.module.ts ***!
  \*********************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "OrdersPageModule": () => (/* binding */ OrdersPageModule)
/* harmony export */ });
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/common */ 4364);
/* harmony import */ var src_app_componetns_common_components_module__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! src/app/componetns/common-components.module */ 1951);
/* harmony import */ var src_app_services_order_service__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! src/app/services/order.service */ 8132);
/* harmony import */ var _orders_page_component__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./orders-page.component */ 4158);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var _componetns_list_component_list_component__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../../componetns/list-component/list.component */ 9860);






class OrdersPageModule {
}
OrdersPageModule.ɵfac = function OrdersPageModule_Factory(t) { return new (t || OrdersPageModule)(); };
OrdersPageModule.ɵmod = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵdefineNgModule"]({ type: OrdersPageModule });
OrdersPageModule.ɵinj = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵdefineInjector"]({ providers: [src_app_services_order_service__WEBPACK_IMPORTED_MODULE_1__.OrderService, _angular_common__WEBPACK_IMPORTED_MODULE_5__.DatePipe], imports: [[_angular_common__WEBPACK_IMPORTED_MODULE_5__.CommonModule, src_app_componetns_common_components_module__WEBPACK_IMPORTED_MODULE_0__.CommonComponentsModule]] });
(function () { (typeof ngJitMode === "undefined" || ngJitMode) && _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵsetNgModuleScope"](OrdersPageModule, { declarations: [_orders_page_component__WEBPACK_IMPORTED_MODULE_2__.OrdersPageComponent], imports: [_angular_common__WEBPACK_IMPORTED_MODULE_5__.CommonModule, src_app_componetns_common_components_module__WEBPACK_IMPORTED_MODULE_0__.CommonComponentsModule] }); })();
_angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵsetComponentScope"](_orders_page_component__WEBPACK_IMPORTED_MODULE_2__.OrdersPageComponent, [_componetns_list_component_list_component__WEBPACK_IMPORTED_MODULE_3__.ListComponent], []);


/***/ }),

/***/ 9885:
/*!****************************************************************!*\
  !*** ./src/app/pages/platform-page/platform-page.component.ts ***!
  \****************************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "PlatformPageComponent": () => (/* binding */ PlatformPageComponent)
/* harmony export */ });
/* harmony import */ var rxjs__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! rxjs */ 1134);
/* harmony import */ var rxjs_operators__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! rxjs/operators */ 9902);
/* harmony import */ var rxjs_operators__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! rxjs/operators */ 8636);
/* harmony import */ var src_app_componetns_base_component__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! src/app/componetns/base.component */ 2844);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var src_app_services_platform_service__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! src/app/services/platform.service */ 8634);
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! @angular/router */ 1258);
/* harmony import */ var src_app_services_game_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! src/app/services/game.service */ 1397);







function PlatformPageComponent_div_0_Template(rf, ctx) { if (rf & 1) {
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementStart"](0, "div");
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementStart"](1, "div", 1);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementStart"](2, "a", 2);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵtext"](3);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementStart"](4, "gamestore-info-wrapper", 3);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelement"](5, "gamestore-info", 4);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementEnd"]();
} if (rf & 2) {
    const ctx_r0 = _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵnextContext"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵadvance"](2);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵpropertyInterpolate"]("routerLink", ctx_r0.links.get(ctx_r0.pageRoutes.Platforms));
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵtextInterpolate1"](" ", ctx_r0.labels.platformsMenuItem, " ");
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵproperty"]("deleteLink", ctx_r0.deletePlatformLink)("updateLink", ctx_r0.updatePlatformLink);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵproperty"]("infoList", ctx_r0.platformInfoList);
} }
class PlatformPageComponent extends src_app_componetns_base_component__WEBPACK_IMPORTED_MODULE_0__.BaseComponent {
    constructor(platformService, route, gameService) {
        super();
        this.platformService = platformService;
        this.route = route;
        this.gameService = gameService;
        this.platformInfoList = [];
    }
    get deletePlatformLink() {
        var _a;
        return `${this.links.get(this.pageRoutes.DeletePlatform)}/${(_a = this.platformValue) === null || _a === void 0 ? void 0 : _a.id}`;
    }
    get updatePlatformLink() {
        var _a;
        return `${this.links.get(this.pageRoutes.UpdatePlatform)}/${(_a = this.platformValue) === null || _a === void 0 ? void 0 : _a.id}`;
    }
    get platform() {
        return this.platformValue;
    }
    set platform(value) {
        this.platformValue = value;
        this.platformInfoList = [];
        if (!value) {
            return;
        }
        this.platformInfoList.push({
            name: this.labels.platformTypeLabel,
            value: value.type,
        });
    }
    ngOnInit() {
        this.getRouteParam(this.route, 'id')
            .pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_4__.switchMap)((id) => this.platformService.getPlatform(id)), (0,rxjs_operators__WEBPACK_IMPORTED_MODULE_5__.tap)((x) => (this.platform = x)), (0,rxjs_operators__WEBPACK_IMPORTED_MODULE_4__.switchMap)((x) => {
            var _a, _b;
            return !!((_a = x === null || x === void 0 ? void 0 : x.id) === null || _a === void 0 ? void 0 : _a.length)
                ? this.gameService.getGamesByPlatfrom((_b = x.id) !== null && _b !== void 0 ? _b : '')
                : (0,rxjs__WEBPACK_IMPORTED_MODULE_6__.of)([]);
        }))
            .subscribe((x) => this.addGamesInfo(x));
    }
    addGamesInfo(games) {
        if (!(games === null || games === void 0 ? void 0 : games.length)) {
            return;
        }
        const gamesInfo = {
            name: this.labels.gamesMenuItem,
            nestedValues: [],
        };
        games.forEach((x) => gamesInfo.nestedValues.push({
            title: x.name,
            pageLink: `${this.links.get(this.pageRoutes.Game)}/${x.key}`,
        }));
        this.platformInfoList.push(gamesInfo);
    }
}
PlatformPageComponent.ɵfac = function PlatformPageComponent_Factory(t) { return new (t || PlatformPageComponent)(_angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵdirectiveInject"](src_app_services_platform_service__WEBPACK_IMPORTED_MODULE_1__.PlatformService), _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵdirectiveInject"](_angular_router__WEBPACK_IMPORTED_MODULE_7__.ActivatedRoute), _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵdirectiveInject"](src_app_services_game_service__WEBPACK_IMPORTED_MODULE_2__.GameService)); };
PlatformPageComponent.ɵcmp = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵdefineComponent"]({ type: PlatformPageComponent, selectors: [["gamestore-platform"]], features: [_angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵInheritDefinitionFeature"]], decls: 1, vars: 1, consts: [[4, "ngIf"], [1, "to-list-button"], ["mat-button", "", 3, "routerLink"], [3, "deleteLink", "updateLink"], [3, "infoList"]], template: function PlatformPageComponent_Template(rf, ctx) { if (rf & 1) {
        _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵtemplate"](0, PlatformPageComponent_div_0_Template, 6, 5, "div", 0);
    } if (rf & 2) {
        _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵproperty"]("ngIf", !!ctx.platform);
    } }, styles: [".to-list-button[_ngcontent-%COMP%] {\n  margin-bottom: 10px;\n}\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInBsYXRmb3JtLXBhZ2UuY29tcG9uZW50LnNjc3MiXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IkFBQUE7RUFDSSxtQkFBQTtBQUNKIiwiZmlsZSI6InBsYXRmb3JtLXBhZ2UuY29tcG9uZW50LnNjc3MiLCJzb3VyY2VzQ29udGVudCI6WyIudG8tbGlzdC1idXR0b24ge1xyXG4gICAgbWFyZ2luLWJvdHRvbTogMTBweDtcclxufSJdfQ== */"] });


/***/ }),

/***/ 7351:
/*!*************************************************************!*\
  !*** ./src/app/pages/platform-page/platform-page.module.ts ***!
  \*************************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "PlatformPageModule": () => (/* binding */ PlatformPageModule)
/* harmony export */ });
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! @angular/common */ 4364);
/* harmony import */ var src_app_componetns_common_components_module__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! src/app/componetns/common-components.module */ 1951);
/* harmony import */ var src_app_app_routing_module__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! src/app/app-routing.module */ 158);
/* harmony import */ var _angular_material_button__WEBPACK_IMPORTED_MODULE_9__ = __webpack_require__(/*! @angular/material/button */ 781);
/* harmony import */ var _platform_page_component__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./platform-page.component */ 9885);
/* harmony import */ var src_app_services_platform_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! src/app/services/platform.service */ 8634);
/* harmony import */ var src_app_services_game_service__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! src/app/services/game.service */ 1397);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_10__ = __webpack_require__(/*! @angular/router */ 1258);
/* harmony import */ var _componetns_info_wrapper_component_info_wrapper_component__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ../../componetns/info-wrapper-component/info-wrapper.component */ 7990);
/* harmony import */ var _componetns_info_component_info_component__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ../../componetns/info-component/info.component */ 4130);













class PlatformPageModule {
}
PlatformPageModule.ɵfac = function PlatformPageModule_Factory(t) { return new (t || PlatformPageModule)(); };
PlatformPageModule.ɵmod = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_7__["ɵɵdefineNgModule"]({ type: PlatformPageModule });
PlatformPageModule.ɵinj = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_7__["ɵɵdefineInjector"]({ providers: [src_app_services_platform_service__WEBPACK_IMPORTED_MODULE_3__.PlatformService, src_app_services_game_service__WEBPACK_IMPORTED_MODULE_4__.GameService], imports: [[
            _angular_common__WEBPACK_IMPORTED_MODULE_8__.CommonModule,
            src_app_componetns_common_components_module__WEBPACK_IMPORTED_MODULE_0__.CommonComponentsModule,
            src_app_app_routing_module__WEBPACK_IMPORTED_MODULE_1__.AppRoutingModule,
            _angular_material_button__WEBPACK_IMPORTED_MODULE_9__.MatButtonModule,
        ]] });
(function () { (typeof ngJitMode === "undefined" || ngJitMode) && _angular_core__WEBPACK_IMPORTED_MODULE_7__["ɵɵsetNgModuleScope"](PlatformPageModule, { declarations: [_platform_page_component__WEBPACK_IMPORTED_MODULE_2__.PlatformPageComponent], imports: [_angular_common__WEBPACK_IMPORTED_MODULE_8__.CommonModule,
        src_app_componetns_common_components_module__WEBPACK_IMPORTED_MODULE_0__.CommonComponentsModule,
        src_app_app_routing_module__WEBPACK_IMPORTED_MODULE_1__.AppRoutingModule,
        _angular_material_button__WEBPACK_IMPORTED_MODULE_9__.MatButtonModule] }); })();
_angular_core__WEBPACK_IMPORTED_MODULE_7__["ɵɵsetComponentScope"](_platform_page_component__WEBPACK_IMPORTED_MODULE_2__.PlatformPageComponent, [_angular_common__WEBPACK_IMPORTED_MODULE_8__.NgIf, _angular_material_button__WEBPACK_IMPORTED_MODULE_9__.MatAnchor, _angular_router__WEBPACK_IMPORTED_MODULE_10__.RouterLinkWithHref, _componetns_info_wrapper_component_info_wrapper_component__WEBPACK_IMPORTED_MODULE_5__.InfoWrapperComponent, _componetns_info_component_info_component__WEBPACK_IMPORTED_MODULE_6__.InfoComponent], []);


/***/ }),

/***/ 351:
/*!******************************************************************!*\
  !*** ./src/app/pages/platforms-page/platforms-page.component.ts ***!
  \******************************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "PlatformsPageComponent": () => (/* binding */ PlatformsPageComponent)
/* harmony export */ });
/* harmony import */ var rxjs_operators__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! rxjs/operators */ 3927);
/* harmony import */ var src_app_componetns_base_component__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! src/app/componetns/base.component */ 2844);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var src_app_services_platform_service__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! src/app/services/platform.service */ 8634);




class PlatformsPageComponent extends src_app_componetns_base_component__WEBPACK_IMPORTED_MODULE_0__.BaseComponent {
    constructor(platformService) {
        super();
        this.platformService = platformService;
        this.platformsList = [];
    }
    ngOnInit() {
        this.platformService
            .getPlatforms()
            .pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_2__.map)((platforms) => platforms.map((platform) => {
            const platformItem = {
                title: platform.type,
                pageLink: `${this.links.get(this.pageRoutes.Platform)}/${platform.id}`,
                updateLink: `${this.links.get(this.pageRoutes.UpdatePlatform)}/${platform.id}`,
                deleteLink: `${this.links.get(this.pageRoutes.DeletePlatform)}/${platform.id}`,
            };
            return platformItem;
        })))
            .subscribe((x) => (this.platformsList = x !== null && x !== void 0 ? x : []));
    }
}
PlatformsPageComponent.ɵfac = function PlatformsPageComponent_Factory(t) { return new (t || PlatformsPageComponent)(_angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵdirectiveInject"](src_app_services_platform_service__WEBPACK_IMPORTED_MODULE_1__.PlatformService)); };
PlatformsPageComponent.ɵcmp = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵdefineComponent"]({ type: PlatformsPageComponent, selectors: [["gamestore-platforms"]], features: [_angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵInheritDefinitionFeature"]], decls: 2, vars: 2, consts: [[3, "listItems", "addLink"]], template: function PlatformsPageComponent_Template(rf, ctx) { if (rf & 1) {
        _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementStart"](0, "article");
        _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelement"](1, "gamestore-list", 0);
        _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementEnd"]();
    } if (rf & 2) {
        _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵadvance"](1);
        _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵproperty"]("listItems", ctx.platformsList)("addLink", ctx.links.get(ctx.pageRoutes.AddPlatform));
    } }, styles: ["\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJwbGF0Zm9ybXMtcGFnZS5jb21wb25lbnQuc2NzcyJ9 */"] });


/***/ }),

/***/ 3952:
/*!***************************************************************!*\
  !*** ./src/app/pages/platforms-page/platforms-page.module.ts ***!
  \***************************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "PlatformsPageModule": () => (/* binding */ PlatformsPageModule)
/* harmony export */ });
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/common */ 4364);
/* harmony import */ var src_app_componetns_common_components_module__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! src/app/componetns/common-components.module */ 1951);
/* harmony import */ var _platforms_page_component__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./platforms-page.component */ 351);
/* harmony import */ var src_app_services_platform_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! src/app/services/platform.service */ 8634);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var _componetns_list_component_list_component__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../../componetns/list-component/list.component */ 9860);






class PlatformsPageModule {
}
PlatformsPageModule.ɵfac = function PlatformsPageModule_Factory(t) { return new (t || PlatformsPageModule)(); };
PlatformsPageModule.ɵmod = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵdefineNgModule"]({ type: PlatformsPageModule });
PlatformsPageModule.ɵinj = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵdefineInjector"]({ providers: [src_app_services_platform_service__WEBPACK_IMPORTED_MODULE_2__.PlatformService], imports: [[_angular_common__WEBPACK_IMPORTED_MODULE_5__.CommonModule, src_app_componetns_common_components_module__WEBPACK_IMPORTED_MODULE_0__.CommonComponentsModule]] });
(function () { (typeof ngJitMode === "undefined" || ngJitMode) && _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵsetNgModuleScope"](PlatformsPageModule, { declarations: [_platforms_page_component__WEBPACK_IMPORTED_MODULE_1__.PlatformsPageComponent], imports: [_angular_common__WEBPACK_IMPORTED_MODULE_5__.CommonModule, src_app_componetns_common_components_module__WEBPACK_IMPORTED_MODULE_0__.CommonComponentsModule] }); })();
_angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵsetComponentScope"](_platforms_page_component__WEBPACK_IMPORTED_MODULE_1__.PlatformsPageComponent, [_componetns_list_component_list_component__WEBPACK_IMPORTED_MODULE_3__.ListComponent], []);


/***/ }),

/***/ 7140:
/*!******************************************************************!*\
  !*** ./src/app/pages/publisher-page/publisher-page.component.ts ***!
  \******************************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "PublisherPageComponent": () => (/* binding */ PublisherPageComponent)
/* harmony export */ });
/* harmony import */ var rxjs__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! rxjs */ 2720);
/* harmony import */ var rxjs__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! rxjs */ 1134);
/* harmony import */ var rxjs_operators__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! rxjs/operators */ 9902);
/* harmony import */ var rxjs_operators__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! rxjs/operators */ 8636);
/* harmony import */ var src_app_componetns_base_component__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! src/app/componetns/base.component */ 2844);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var src_app_services_publisher_service__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! src/app/services/publisher.service */ 7441);
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! @angular/router */ 1258);
/* harmony import */ var src_app_services_game_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! src/app/services/game.service */ 1397);







function PublisherPageComponent_div_0_a_6_Template(rf, ctx) { if (rf & 1) {
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementStart"](0, "a", 6);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵtext"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementEnd"]();
} if (rf & 2) {
    const ctx_r1 = _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵnextContext"](2);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵpropertyInterpolate"]("href", ctx_r1.publisher.homePage, _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵsanitizeUrl"]);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵtextInterpolate"](ctx_r1.labels.publisherHomePageLabel);
} }
function PublisherPageComponent_div_0_Template(rf, ctx) { if (rf & 1) {
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementStart"](0, "div");
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementStart"](1, "div", 1);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementStart"](2, "a", 2);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵtext"](3);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementStart"](4, "gamestore-info-wrapper", 3);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelement"](5, "gamestore-info", 4);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵtemplate"](6, PublisherPageComponent_div_0_a_6_Template, 2, 2, "a", 5);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementEnd"]();
} if (rf & 2) {
    const ctx_r0 = _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵnextContext"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵadvance"](2);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵpropertyInterpolate"]("routerLink", ctx_r0.links.get(ctx_r0.pageRoutes.Publishers));
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵtextInterpolate1"](" ", ctx_r0.labels.publishersMenuItem, " ");
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵproperty"]("deleteLink", ctx_r0.deletePublisherLink)("updateLink", ctx_r0.updatePublisherLink);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵproperty"]("infoList", ctx_r0.publisherInfoList);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵproperty"]("ngIf", !!(ctx_r0.publisher.homePage == null ? null : ctx_r0.publisher.homePage.length));
} }
class PublisherPageComponent extends src_app_componetns_base_component__WEBPACK_IMPORTED_MODULE_0__.BaseComponent {
    constructor(publisherService, route, gameService) {
        super();
        this.publisherService = publisherService;
        this.route = route;
        this.gameService = gameService;
        this.publisherInfoList = [];
    }
    get deletePublisherLink() {
        var _a;
        return `${this.links.get(this.pageRoutes.DeletePublisher)}/${(_a = this.publisherValue) === null || _a === void 0 ? void 0 : _a.companyName}`;
    }
    get updatePublisherLink() {
        var _a;
        return `${this.links.get(this.pageRoutes.UpdatePublisher)}/${(_a = this.publisherValue) === null || _a === void 0 ? void 0 : _a.companyName}`;
    }
    get publisher() {
        return this.publisherValue;
    }
    set publisher(value) {
        var _a;
        this.publisherValue = value;
        this.publisherInfoList = [];
        if (!value) {
            return;
        }
        this.publisherInfoList.push({
            name: this.labels.publisherCompanyNameLabel,
            value: value.companyName,
        }, {
            name: this.labels.publisherDescriptionLabel,
            value: (_a = this.publisher) === null || _a === void 0 ? void 0 : _a.description
        });
    }
    ngOnInit() {
        this.getRouteParam(this.route, 'id')
            .pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_4__.switchMap)((companyName) => this.publisherService.getPublisher(companyName)), (0,rxjs_operators__WEBPACK_IMPORTED_MODULE_5__.tap)((x) => (this.publisher = x)), (0,rxjs_operators__WEBPACK_IMPORTED_MODULE_4__.switchMap)((x) => (0,rxjs__WEBPACK_IMPORTED_MODULE_6__.forkJoin)({
            games: !!(x === null || x === void 0 ? void 0 : x.companyName) ? this.gameService.getGamesByPublisher(x.companyName) : (0,rxjs__WEBPACK_IMPORTED_MODULE_7__.of)([]),
        })))
            .subscribe((x) => {
            var _a;
            if (!!((_a = x.games) === null || _a === void 0 ? void 0 : _a.length)) {
                this.addGamesInfo(x.games);
            }
        });
    }
    addGamesInfo(games) {
        if (!(games === null || games === void 0 ? void 0 : games.length)) {
            return;
        }
        const gamesInfo = {
            name: this.labels.gamesMenuItem,
            nestedValues: [],
        };
        games.forEach((x) => gamesInfo.nestedValues.push({
            title: x.name,
            pageLink: `${this.links.get(this.pageRoutes.Game)}/${x.key}`,
        }));
        this.publisherInfoList.push(gamesInfo);
    }
}
PublisherPageComponent.ɵfac = function PublisherPageComponent_Factory(t) { return new (t || PublisherPageComponent)(_angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵdirectiveInject"](src_app_services_publisher_service__WEBPACK_IMPORTED_MODULE_1__.PublisherService), _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵdirectiveInject"](_angular_router__WEBPACK_IMPORTED_MODULE_8__.ActivatedRoute), _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵdirectiveInject"](src_app_services_game_service__WEBPACK_IMPORTED_MODULE_2__.GameService)); };
PublisherPageComponent.ɵcmp = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵdefineComponent"]({ type: PublisherPageComponent, selectors: [["gamestore-publisher"]], features: [_angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵInheritDefinitionFeature"]], decls: 1, vars: 1, consts: [[4, "ngIf"], [1, "to-list-button"], ["mat-button", "", 3, "routerLink"], [3, "deleteLink", "updateLink"], [3, "infoList"], ["mat-button", "", "target", "_blank", 3, "href", 4, "ngIf"], ["mat-button", "", "target", "_blank", 3, "href"]], template: function PublisherPageComponent_Template(rf, ctx) { if (rf & 1) {
        _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵtemplate"](0, PublisherPageComponent_div_0_Template, 7, 6, "div", 0);
    } if (rf & 2) {
        _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵproperty"]("ngIf", !!ctx.publisher);
    } }, styles: [".to-list-button[_ngcontent-%COMP%] {\n  margin-bottom: 10px;\n}\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInB1Ymxpc2hlci1wYWdlLmNvbXBvbmVudC5zY3NzIl0sIm5hbWVzIjpbXSwibWFwcGluZ3MiOiJBQUFBO0VBQ0ksbUJBQUE7QUFDSiIsImZpbGUiOiJwdWJsaXNoZXItcGFnZS5jb21wb25lbnQuc2NzcyIsInNvdXJjZXNDb250ZW50IjpbIi50by1saXN0LWJ1dHRvbiB7XHJcbiAgICBtYXJnaW4tYm90dG9tOiAxMHB4O1xyXG59Il19 */"] });


/***/ }),

/***/ 5640:
/*!***************************************************************!*\
  !*** ./src/app/pages/publisher-page/publisher-page.module.ts ***!
  \***************************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "PublisherPageModule": () => (/* binding */ PublisherPageModule)
/* harmony export */ });
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! @angular/common */ 4364);
/* harmony import */ var src_app_componetns_common_components_module__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! src/app/componetns/common-components.module */ 1951);
/* harmony import */ var src_app_app_routing_module__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! src/app/app-routing.module */ 158);
/* harmony import */ var _angular_material_button__WEBPACK_IMPORTED_MODULE_9__ = __webpack_require__(/*! @angular/material/button */ 781);
/* harmony import */ var _publisher_page_component__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./publisher-page.component */ 7140);
/* harmony import */ var src_app_services_publisher_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! src/app/services/publisher.service */ 7441);
/* harmony import */ var src_app_services_game_service__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! src/app/services/game.service */ 1397);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_10__ = __webpack_require__(/*! @angular/router */ 1258);
/* harmony import */ var _componetns_info_wrapper_component_info_wrapper_component__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ../../componetns/info-wrapper-component/info-wrapper.component */ 7990);
/* harmony import */ var _componetns_info_component_info_component__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ../../componetns/info-component/info.component */ 4130);













class PublisherPageModule {
}
PublisherPageModule.ɵfac = function PublisherPageModule_Factory(t) { return new (t || PublisherPageModule)(); };
PublisherPageModule.ɵmod = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_7__["ɵɵdefineNgModule"]({ type: PublisherPageModule });
PublisherPageModule.ɵinj = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_7__["ɵɵdefineInjector"]({ providers: [src_app_services_publisher_service__WEBPACK_IMPORTED_MODULE_3__.PublisherService, src_app_services_game_service__WEBPACK_IMPORTED_MODULE_4__.GameService], imports: [[_angular_common__WEBPACK_IMPORTED_MODULE_8__.CommonModule, src_app_componetns_common_components_module__WEBPACK_IMPORTED_MODULE_0__.CommonComponentsModule, src_app_app_routing_module__WEBPACK_IMPORTED_MODULE_1__.AppRoutingModule, _angular_material_button__WEBPACK_IMPORTED_MODULE_9__.MatButtonModule]] });
(function () { (typeof ngJitMode === "undefined" || ngJitMode) && _angular_core__WEBPACK_IMPORTED_MODULE_7__["ɵɵsetNgModuleScope"](PublisherPageModule, { declarations: [_publisher_page_component__WEBPACK_IMPORTED_MODULE_2__.PublisherPageComponent], imports: [_angular_common__WEBPACK_IMPORTED_MODULE_8__.CommonModule, src_app_componetns_common_components_module__WEBPACK_IMPORTED_MODULE_0__.CommonComponentsModule, src_app_app_routing_module__WEBPACK_IMPORTED_MODULE_1__.AppRoutingModule, _angular_material_button__WEBPACK_IMPORTED_MODULE_9__.MatButtonModule] }); })();
_angular_core__WEBPACK_IMPORTED_MODULE_7__["ɵɵsetComponentScope"](_publisher_page_component__WEBPACK_IMPORTED_MODULE_2__.PublisherPageComponent, [_angular_common__WEBPACK_IMPORTED_MODULE_8__.NgIf, _angular_material_button__WEBPACK_IMPORTED_MODULE_9__.MatAnchor, _angular_router__WEBPACK_IMPORTED_MODULE_10__.RouterLinkWithHref, _componetns_info_wrapper_component_info_wrapper_component__WEBPACK_IMPORTED_MODULE_5__.InfoWrapperComponent, _componetns_info_component_info_component__WEBPACK_IMPORTED_MODULE_6__.InfoComponent], []);


/***/ }),

/***/ 1955:
/*!********************************************************************!*\
  !*** ./src/app/pages/publishers-page/publishers-page.component.ts ***!
  \********************************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "PublishersPageComponent": () => (/* binding */ PublishersPageComponent)
/* harmony export */ });
/* harmony import */ var rxjs_operators__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! rxjs/operators */ 3927);
/* harmony import */ var src_app_componetns_base_component__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! src/app/componetns/base.component */ 2844);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var src_app_services_publisher_service__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! src/app/services/publisher.service */ 7441);




class PublishersPageComponent extends src_app_componetns_base_component__WEBPACK_IMPORTED_MODULE_0__.BaseComponent {
    constructor(publisherService) {
        super();
        this.publisherService = publisherService;
        this.publishersList = [];
    }
    ngOnInit() {
        this.publisherService
            .getPublishers()
            .pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_2__.map)((publishers) => publishers.map((publisher) => {
            const publisherItem = {
                title: publisher.companyName,
                pageLink: `${this.links.get(this.pageRoutes.Publisher)}/${publisher.companyName}`,
                updateLink: `${this.links.get(this.pageRoutes.UpdatePublisher)}/${publisher.companyName}`,
                deleteLink: `${this.links.get(this.pageRoutes.DeletePublisher)}/${publisher.companyName}`,
            };
            return publisherItem;
        })))
            .subscribe((x) => (this.publishersList = x !== null && x !== void 0 ? x : []));
    }
}
PublishersPageComponent.ɵfac = function PublishersPageComponent_Factory(t) { return new (t || PublishersPageComponent)(_angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵdirectiveInject"](src_app_services_publisher_service__WEBPACK_IMPORTED_MODULE_1__.PublisherService)); };
PublishersPageComponent.ɵcmp = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵdefineComponent"]({ type: PublishersPageComponent, selectors: [["gamestore-publishers"]], features: [_angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵInheritDefinitionFeature"]], decls: 2, vars: 2, consts: [[3, "listItems", "addLink"]], template: function PublishersPageComponent_Template(rf, ctx) { if (rf & 1) {
        _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementStart"](0, "article");
        _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelement"](1, "gamestore-list", 0);
        _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵelementEnd"]();
    } if (rf & 2) {
        _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵadvance"](1);
        _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵproperty"]("listItems", ctx.publishersList)("addLink", ctx.links.get(ctx.pageRoutes.AddPublisher));
    } }, styles: ["\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJwdWJsaXNoZXJzLXBhZ2UuY29tcG9uZW50LnNjc3MifQ== */"] });


/***/ }),

/***/ 9596:
/*!*****************************************************************!*\
  !*** ./src/app/pages/publishers-page/publishers-page.module.ts ***!
  \*****************************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "PublishersPageModule": () => (/* binding */ PublishersPageModule)
/* harmony export */ });
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/common */ 4364);
/* harmony import */ var src_app_componetns_common_components_module__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! src/app/componetns/common-components.module */ 1951);
/* harmony import */ var _publishers_page_component__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./publishers-page.component */ 1955);
/* harmony import */ var src_app_services_publisher_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! src/app/services/publisher.service */ 7441);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var _componetns_list_component_list_component__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../../componetns/list-component/list.component */ 9860);






class PublishersPageModule {
}
PublishersPageModule.ɵfac = function PublishersPageModule_Factory(t) { return new (t || PublishersPageModule)(); };
PublishersPageModule.ɵmod = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵdefineNgModule"]({ type: PublishersPageModule });
PublishersPageModule.ɵinj = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵdefineInjector"]({ providers: [src_app_services_publisher_service__WEBPACK_IMPORTED_MODULE_2__.PublisherService], imports: [[_angular_common__WEBPACK_IMPORTED_MODULE_5__.CommonModule, src_app_componetns_common_components_module__WEBPACK_IMPORTED_MODULE_0__.CommonComponentsModule]] });
(function () { (typeof ngJitMode === "undefined" || ngJitMode) && _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵsetNgModuleScope"](PublishersPageModule, { declarations: [_publishers_page_component__WEBPACK_IMPORTED_MODULE_1__.PublishersPageComponent], imports: [_angular_common__WEBPACK_IMPORTED_MODULE_5__.CommonModule, src_app_componetns_common_components_module__WEBPACK_IMPORTED_MODULE_0__.CommonComponentsModule] }); })();
_angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵsetComponentScope"](_publishers_page_component__WEBPACK_IMPORTED_MODULE_1__.PublishersPageComponent, [_componetns_list_component_list_component__WEBPACK_IMPORTED_MODULE_3__.ListComponent], []);


/***/ }),

/***/ 512:
/*!**********************************************************************!*\
  !*** ./src/app/pages/update-game-page/update-game-page.component.ts ***!
  \**********************************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "UpdateGamePageComponent": () => (/* binding */ UpdateGamePageComponent)
/* harmony export */ });
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_11__ = __webpack_require__(/*! @angular/forms */ 1707);
/* harmony import */ var rxjs__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! rxjs */ 1134);
/* harmony import */ var rxjs__WEBPACK_IMPORTED_MODULE_10__ = __webpack_require__(/*! rxjs */ 2720);
/* harmony import */ var rxjs_operators__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! rxjs/operators */ 9902);
/* harmony import */ var rxjs_operators__WEBPACK_IMPORTED_MODULE_9__ = __webpack_require__(/*! rxjs/operators */ 8636);
/* harmony import */ var src_app_componetns_base_component__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! src/app/componetns/base.component */ 2844);
/* harmony import */ var src_app_configuration_input_validator__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! src/app/configuration/input-validator */ 5337);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var src_app_services_game_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! src/app/services/game.service */ 1397);
/* harmony import */ var src_app_services_genre_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! src/app/services/genre.service */ 7776);
/* harmony import */ var src_app_services_platform_service__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! src/app/services/platform.service */ 8634);
/* harmony import */ var src_app_services_publisher_service__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! src/app/services/publisher.service */ 7441);
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_12__ = __webpack_require__(/*! @angular/router */ 1258);












function UpdateGamePageComponent_article_0_Template(rf, ctx) { if (rf & 1) {
    const _r2 = _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵgetCurrentView"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵelementStart"](0, "article");
    _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵelementStart"](1, "gamestore-form", 1);
    _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵlistener"]("save", function UpdateGamePageComponent_article_0_Template_gamestore_form_save_1_listener() { _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵrestoreView"](_r2); const ctx_r1 = _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵnextContext"](); return ctx_r1.onSave(); });
    _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵelement"](2, "gamestore-text-input", 2);
    _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵelement"](3, "gamestore-text-input", 2);
    _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵelement"](4, "gamestore-number-input", 2);
    _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵelement"](5, "gamestore-number-input", 2);
    _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵelement"](6, "gamestore-number-input", 2);
    _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵelement"](7, "gamestore-textarea-input", 2);
    _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵelement"](8, "gamestore-checkboxes-input", 3);
    _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵelement"](9, "gamestore-checkboxes-input", 3);
    _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵelement"](10, "gamestore-selector-input", 4);
    _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵelementEnd"]();
} if (rf & 2) {
    const ctx_r0 = _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵnextContext"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵproperty"]("form", ctx_r0.form)("pageLink", ctx_r0.gamePageLink);
    _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵproperty"]("name", ctx_r0.labels.gameKeyLabel)("control", ctx_r0.getFormControl("key"));
    _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵproperty"]("name", ctx_r0.labels.gameNameLabel)("control", ctx_r0.getFormControl("name"));
    _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵproperty"]("name", ctx_r0.labels.gamePriceLabel)("control", ctx_r0.getFormControl("price"));
    _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵproperty"]("name", ctx_r0.labels.gameDiscountLabel)("control", ctx_r0.getFormControl("discount"));
    _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵproperty"]("name", ctx_r0.labels.gameUnitInStockLabel)("control", ctx_r0.getFormControl("unitInStock"));
    _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵproperty"]("name", ctx_r0.labels.gameDescriptionLabel)("control", ctx_r0.getFormControl("description"));
    _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵproperty"]("name", ctx_r0.labels.genresMenuItem)("controls", ctx_r0.getFormControlArray("genres"))("items", ctx_r0.genreItems);
    _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵproperty"]("name", ctx_r0.labels.platformsMenuItem)("controls", ctx_r0.getFormControlArray("platforms"))("items", ctx_r0.platformItems);
    _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵproperty"]("name", ctx_r0.labels.publisherLabel)("control", ctx_r0.getFormControl("publisher"))("values", ctx_r0.publishers);
} }
class UpdateGamePageComponent extends src_app_componetns_base_component__WEBPACK_IMPORTED_MODULE_0__.BaseComponent {
    constructor(gameService, genreService, platformService, publisherService, route, builder, router) {
        super();
        this.gameService = gameService;
        this.genreService = genreService;
        this.platformService = platformService;
        this.publisherService = publisherService;
        this.route = route;
        this.builder = builder;
        this.router = router;
        this.genreItems = [];
        this.platformItems = [];
        this.genres = [];
        this.publishers = [{ name: '-', value: '' }];
        this.platforms = [];
        this.gameGenres = [];
        this.gamePlatforms = [];
    }
    ngOnInit() {
        this.getRouteParam(this.route, 'key')
            .pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_7__.switchMap)((key) => !!(key === null || key === void 0 ? void 0 : key.length) ? this.gameService.getGame(key) : (0,rxjs__WEBPACK_IMPORTED_MODULE_8__.of)(undefined)), (0,rxjs_operators__WEBPACK_IMPORTED_MODULE_9__.tap)((x) => (this.game = x)), (0,rxjs_operators__WEBPACK_IMPORTED_MODULE_7__.switchMap)((x) => {
            var _a, _b, _c;
            return (0,rxjs__WEBPACK_IMPORTED_MODULE_10__.forkJoin)({
                gameGenres: !!((_a = x === null || x === void 0 ? void 0 : x.key) === null || _a === void 0 ? void 0 : _a.length)
                    ? this.genreService.getGenresByGameKey(x.key)
                    : (0,rxjs__WEBPACK_IMPORTED_MODULE_8__.of)([]),
                gamePlatforms: !!((_b = x === null || x === void 0 ? void 0 : x.key) === null || _b === void 0 ? void 0 : _b.length)
                    ? this.platformService.getPlatformsByGameKey(x.key)
                    : (0,rxjs__WEBPACK_IMPORTED_MODULE_8__.of)([]),
                gamePublisher: !!((_c = x === null || x === void 0 ? void 0 : x.key) === null || _c === void 0 ? void 0 : _c.length)
                    ? this.publisherService.getPublisherByGameKey(x.key)
                    : (0,rxjs__WEBPACK_IMPORTED_MODULE_8__.of)(undefined),
                genres: this.genreService.getGenres(),
                platforms: this.platformService.getPlatforms(),
                publishers: this.publisherService.getPublishers(),
            });
        }))
            .subscribe((x) => {
            this.platforms = x.platforms;
            x.publishers.forEach((publisher) => {
                var _a;
                return this.publishers.push({
                    name: publisher.companyName,
                    value: (_a = publisher.id) !== null && _a !== void 0 ? _a : '',
                });
            });
            this.genres = x.genres;
            this.gameGenres = x.gameGenres;
            this.gamePlatforms = x.gamePlatforms;
            this.gamePublisher = x.gamePublisher;
            this.createForm();
        });
    }
    getFormControl(name) {
        var _a;
        return (_a = this.form) === null || _a === void 0 ? void 0 : _a.get(name);
    }
    getFormControlArray(name) {
        var _a;
        return ((_a = this.form) === null || _a === void 0 ? void 0 : _a.get(name)).controls.map((x) => x);
    }
    onSave() {
        const game = {
            id: this.form.value.id,
            name: this.form.value.name,
            description: this.form.value.description,
            key: this.form.value.key,
            unitInStock: this.form.value.unitInStock,
            price: this.form.value.price,
            discount: this.form.value.discount,
        };
        const selectedGenres = this.genres
            .filter((x, i) => !!this.form.value.genres[i])
            .map((x) => { var _a; return (_a = x.id) !== null && _a !== void 0 ? _a : ''; });
        const selectedPlatforms = this.platforms
            .filter((x, i) => !!this.form.value.platforms[i])
            .map((x) => { var _a; return (_a = x.id) !== null && _a !== void 0 ? _a : ''; });
        const selectedPublisher = this.form.value.publisher;
        (!!game.id
            ? this.gameService.updateGame(game, selectedGenres, selectedPlatforms, selectedPublisher)
            : this.gameService.addGame(game, selectedGenres, selectedPlatforms, selectedPublisher)).subscribe((_) => {
            var _a;
            return this.router.navigateByUrl(!!game.id
                ? this.links.get(this.pageRoutes.Game) + `/${game.key}`
                : (_a = this.links.get(this.pageRoutes.Games)) !== null && _a !== void 0 ? _a : '');
        });
    }
    createForm() {
        var _a, _b, _c, _d, _e, _f, _g, _h, _j, _k, _l, _m, _o, _p, _q, _r;
        this.gamePageLink = !!this.game
            ? `${this.links.get(this.pageRoutes.Game)}/${this.game.key}`
            : undefined;
        this.form = this.builder.group({
            id: [(_b = (_a = this.game) === null || _a === void 0 ? void 0 : _a.id) !== null && _b !== void 0 ? _b : ''],
            name: [(_d = (_c = this.game) === null || _c === void 0 ? void 0 : _c.name) !== null && _d !== void 0 ? _d : '', _angular_forms__WEBPACK_IMPORTED_MODULE_11__.Validators.required],
            key: [(_f = (_e = this.game) === null || _e === void 0 ? void 0 : _e.key) !== null && _f !== void 0 ? _f : ''],
            description: [(_h = (_g = this.game) === null || _g === void 0 ? void 0 : _g.description) !== null && _h !== void 0 ? _h : ''],
            unitInStock: [
                (_k = (_j = this.game) === null || _j === void 0 ? void 0 : _j.unitInStock) !== null && _k !== void 0 ? _k : '',
                [_angular_forms__WEBPACK_IMPORTED_MODULE_11__.Validators.required, src_app_configuration_input_validator__WEBPACK_IMPORTED_MODULE_1__.InputValidator.getNumberValidator()],
            ],
            price: [
                (_m = (_l = this.game) === null || _l === void 0 ? void 0 : _l.price) !== null && _m !== void 0 ? _m : '',
                [_angular_forms__WEBPACK_IMPORTED_MODULE_11__.Validators.required, src_app_configuration_input_validator__WEBPACK_IMPORTED_MODULE_1__.InputValidator.getNumberValidator()],
            ],
            discount: [
                (_p = (_o = this.game) === null || _o === void 0 ? void 0 : _o.discount) !== null && _p !== void 0 ? _p : '',
                [_angular_forms__WEBPACK_IMPORTED_MODULE_11__.Validators.required, src_app_configuration_input_validator__WEBPACK_IMPORTED_MODULE_1__.InputValidator.getNumberValidator()],
            ],
            publisher: [(_r = (_q = this.gamePublisher) === null || _q === void 0 ? void 0 : _q.id) !== null && _r !== void 0 ? _r : ''],
            genres: this.builder.array(this.genres.map((x) => this.gameGenres.some((z) => z.id === x.id))),
            platforms: this.builder.array(this.platforms.map((x) => this.gamePlatforms.some((z) => z.id === x.id))),
        });
        this.genreItems = this.genres.map((x) => x.name);
        this.platformItems = this.platforms.map((x) => x.type);
    }
}
UpdateGamePageComponent.ɵfac = function UpdateGamePageComponent_Factory(t) { return new (t || UpdateGamePageComponent)(_angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵdirectiveInject"](src_app_services_game_service__WEBPACK_IMPORTED_MODULE_2__.GameService), _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵdirectiveInject"](src_app_services_genre_service__WEBPACK_IMPORTED_MODULE_3__.GenreService), _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵdirectiveInject"](src_app_services_platform_service__WEBPACK_IMPORTED_MODULE_4__.PlatformService), _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵdirectiveInject"](src_app_services_publisher_service__WEBPACK_IMPORTED_MODULE_5__.PublisherService), _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵdirectiveInject"](_angular_router__WEBPACK_IMPORTED_MODULE_12__.ActivatedRoute), _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵdirectiveInject"](_angular_forms__WEBPACK_IMPORTED_MODULE_11__.FormBuilder), _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵdirectiveInject"](_angular_router__WEBPACK_IMPORTED_MODULE_12__.Router)); };
UpdateGamePageComponent.ɵcmp = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵdefineComponent"]({ type: UpdateGamePageComponent, selectors: [["gamestore-update-game"]], features: [_angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵInheritDefinitionFeature"]], decls: 1, vars: 1, consts: [[4, "ngIf"], ["idName", "id", 3, "form", "pageLink", "save"], [3, "name", "control"], [3, "name", "controls", "items"], [3, "name", "control", "values"]], template: function UpdateGamePageComponent_Template(rf, ctx) { if (rf & 1) {
        _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵtemplate"](0, UpdateGamePageComponent_article_0_Template, 11, 23, "article", 0);
    } if (rf & 2) {
        _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵproperty"]("ngIf", !!ctx.form);
    } }, styles: ["\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJ1cGRhdGUtZ2FtZS1wYWdlLmNvbXBvbmVudC5zY3NzIn0= */"] });


/***/ }),

/***/ 640:
/*!*******************************************************************!*\
  !*** ./src/app/pages/update-game-page/update-game-page.module.ts ***!
  \*******************************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "UpdateGamePageModule": () => (/* binding */ UpdateGamePageModule)
/* harmony export */ });
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_13__ = __webpack_require__(/*! @angular/common */ 4364);
/* harmony import */ var src_app_componetns_common_components_module__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! src/app/componetns/common-components.module */ 1951);
/* harmony import */ var src_app_services_game_service__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! src/app/services/game.service */ 1397);
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_14__ = __webpack_require__(/*! @angular/forms */ 1707);
/* harmony import */ var _update_game_page_component__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./update-game-page.component */ 512);
/* harmony import */ var src_app_services_genre_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! src/app/services/genre.service */ 7776);
/* harmony import */ var src_app_services_platform_service__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! src/app/services/platform.service */ 8634);
/* harmony import */ var src_app_services_publisher_service__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! src/app/services/publisher.service */ 7441);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_12__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var _componetns_form_component_form_component__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ../../componetns/form-component/form.component */ 8205);
/* harmony import */ var _componetns_text_input_component_text_input_component__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! ../../componetns/text-input-component/text-input.component */ 2082);
/* harmony import */ var _componetns_number_input_component_number_input_component__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! ../../componetns/number-input-component/number-input.component */ 9567);
/* harmony import */ var _componetns_textarea_input_component_textarea_input_component__WEBPACK_IMPORTED_MODULE_9__ = __webpack_require__(/*! ../../componetns/textarea-input-component/textarea-input.component */ 3281);
/* harmony import */ var _componetns_checkboxes_input_component_checkboxes_input_component__WEBPACK_IMPORTED_MODULE_10__ = __webpack_require__(/*! ../../componetns/checkboxes-input-component/checkboxes-input.component */ 5583);
/* harmony import */ var _componetns_selector_input_component_selector_input_component__WEBPACK_IMPORTED_MODULE_11__ = __webpack_require__(/*! ../../componetns/selector-input-component/selector-input.component */ 9260);
















class UpdateGamePageModule {
}
UpdateGamePageModule.ɵfac = function UpdateGamePageModule_Factory(t) { return new (t || UpdateGamePageModule)(); };
UpdateGamePageModule.ɵmod = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_12__["ɵɵdefineNgModule"]({ type: UpdateGamePageModule });
UpdateGamePageModule.ɵinj = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_12__["ɵɵdefineInjector"]({ providers: [src_app_services_game_service__WEBPACK_IMPORTED_MODULE_1__.GameService, src_app_services_genre_service__WEBPACK_IMPORTED_MODULE_3__.GenreService, src_app_services_platform_service__WEBPACK_IMPORTED_MODULE_4__.PlatformService, src_app_services_publisher_service__WEBPACK_IMPORTED_MODULE_5__.PublisherService], imports: [[_angular_common__WEBPACK_IMPORTED_MODULE_13__.CommonModule, src_app_componetns_common_components_module__WEBPACK_IMPORTED_MODULE_0__.CommonComponentsModule, _angular_forms__WEBPACK_IMPORTED_MODULE_14__.ReactiveFormsModule]] });
(function () { (typeof ngJitMode === "undefined" || ngJitMode) && _angular_core__WEBPACK_IMPORTED_MODULE_12__["ɵɵsetNgModuleScope"](UpdateGamePageModule, { declarations: [_update_game_page_component__WEBPACK_IMPORTED_MODULE_2__.UpdateGamePageComponent], imports: [_angular_common__WEBPACK_IMPORTED_MODULE_13__.CommonModule, src_app_componetns_common_components_module__WEBPACK_IMPORTED_MODULE_0__.CommonComponentsModule, _angular_forms__WEBPACK_IMPORTED_MODULE_14__.ReactiveFormsModule] }); })();
_angular_core__WEBPACK_IMPORTED_MODULE_12__["ɵɵsetComponentScope"](_update_game_page_component__WEBPACK_IMPORTED_MODULE_2__.UpdateGamePageComponent, [_angular_common__WEBPACK_IMPORTED_MODULE_13__.NgIf, _componetns_form_component_form_component__WEBPACK_IMPORTED_MODULE_6__.FormComponent, _componetns_text_input_component_text_input_component__WEBPACK_IMPORTED_MODULE_7__.TextInputComponent, _componetns_number_input_component_number_input_component__WEBPACK_IMPORTED_MODULE_8__.NumberInputComponent, _componetns_textarea_input_component_textarea_input_component__WEBPACK_IMPORTED_MODULE_9__.TextareaInputComponent, _componetns_checkboxes_input_component_checkboxes_input_component__WEBPACK_IMPORTED_MODULE_10__.CheckboxesInputComponent, _componetns_selector_input_component_selector_input_component__WEBPACK_IMPORTED_MODULE_11__.SelectorInputComponent], []);


/***/ }),

/***/ 4606:
/*!************************************************************************!*\
  !*** ./src/app/pages/update-genre-page/update-genre-page.component.ts ***!
  \************************************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "UpdateGenrePageComponent": () => (/* binding */ UpdateGenrePageComponent)
/* harmony export */ });
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! @angular/forms */ 1707);
/* harmony import */ var rxjs__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! rxjs */ 1134);
/* harmony import */ var rxjs__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! rxjs */ 2720);
/* harmony import */ var rxjs_operators__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! rxjs/operators */ 9902);
/* harmony import */ var src_app_componetns_base_component__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! src/app/componetns/base.component */ 2844);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var src_app_services_genre_service__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! src/app/services/genre.service */ 7776);
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! @angular/router */ 1258);








function UpdateGenrePageComponent_article_0_Template(rf, ctx) { if (rf & 1) {
    const _r2 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵgetCurrentView"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](0, "article");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](1, "gamestore-form", 1);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵlistener"]("save", function UpdateGenrePageComponent_article_0_Template_gamestore_form_save_1_listener() { _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵrestoreView"](_r2); const ctx_r1 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵnextContext"](); return ctx_r1.onSave(); });
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelement"](2, "gamestore-selector-input", 2);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelement"](3, "gamestore-text-input", 3);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
} if (rf & 2) {
    const ctx_r0 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵnextContext"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵproperty"]("form", ctx_r0.form)("pageLink", ctx_r0.genrePageLink);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵproperty"]("name", ctx_r0.labels.genreParentLabel)("control", ctx_r0.getFormControl("parentGenreId"))("values", ctx_r0.genres);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵproperty"]("name", ctx_r0.labels.genreNameLabel)("control", ctx_r0.getFormControl("name"));
} }
class UpdateGenrePageComponent extends src_app_componetns_base_component__WEBPACK_IMPORTED_MODULE_0__.BaseComponent {
    constructor(genreService, route, builder, router) {
        super();
        this.genreService = genreService;
        this.route = route;
        this.builder = builder;
        this.router = router;
        this.genres = [{ name: '-', value: '' }];
    }
    ngOnInit() {
        this.getRouteParam(this.route, 'id')
            .pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_3__.switchMap)((id) => !!(id === null || id === void 0 ? void 0 : id.length) ? this.genreService.getGenre(id) : (0,rxjs__WEBPACK_IMPORTED_MODULE_4__.of)(undefined)))
            .pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_3__.switchMap)((x) => (0,rxjs__WEBPACK_IMPORTED_MODULE_5__.forkJoin)({
            genres: this.genreService.getGenres(),
            genre: (0,rxjs__WEBPACK_IMPORTED_MODULE_4__.of)(x),
        })))
            .subscribe((x) => {
            x.genres.forEach((genre) => { var _a; return this.genres.push({ name: genre.name, value: (_a = genre.id) !== null && _a !== void 0 ? _a : '' }); });
            this.createForm(x.genre);
        });
    }
    getFormControl(name) {
        var _a;
        return (_a = this.form) === null || _a === void 0 ? void 0 : _a.get(name);
    }
    onSave() {
        const genre = this.form.value;
        (!!genre.id
            ? this.genreService.updateGenre(genre)
            : this.genreService.addGenre(genre)).subscribe((_) => {
            var _a;
            return this.router.navigateByUrl(!!genre.id
                ? this.links.get(this.pageRoutes.Genre) + `/${genre.id}`
                : (_a = this.links.get(this.pageRoutes.Genres)) !== null && _a !== void 0 ? _a : '');
        });
    }
    createForm(genre) {
        var _a, _b, _c;
        this.genrePageLink = !!genre
            ? `${this.links.get(this.pageRoutes.Genre)}/${genre.id}`
            : undefined;
        this.form = this.builder.group({
            id: [(_a = genre === null || genre === void 0 ? void 0 : genre.id) !== null && _a !== void 0 ? _a : ''],
            parentGenreId: [(_b = genre === null || genre === void 0 ? void 0 : genre.parentGenreId) !== null && _b !== void 0 ? _b : ''],
            name: [(_c = genre === null || genre === void 0 ? void 0 : genre.name) !== null && _c !== void 0 ? _c : '', _angular_forms__WEBPACK_IMPORTED_MODULE_6__.Validators.required],
        });
    }
}
UpdateGenrePageComponent.ɵfac = function UpdateGenrePageComponent_Factory(t) { return new (t || UpdateGenrePageComponent)(_angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵdirectiveInject"](src_app_services_genre_service__WEBPACK_IMPORTED_MODULE_1__.GenreService), _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵdirectiveInject"](_angular_router__WEBPACK_IMPORTED_MODULE_7__.ActivatedRoute), _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵdirectiveInject"](_angular_forms__WEBPACK_IMPORTED_MODULE_6__.FormBuilder), _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵdirectiveInject"](_angular_router__WEBPACK_IMPORTED_MODULE_7__.Router)); };
UpdateGenrePageComponent.ɵcmp = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵdefineComponent"]({ type: UpdateGenrePageComponent, selectors: [["gamestore-update-genre"]], features: [_angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵInheritDefinitionFeature"]], decls: 1, vars: 1, consts: [[4, "ngIf"], ["idName", "id", 3, "form", "pageLink", "save"], [3, "name", "control", "values"], [3, "name", "control"]], template: function UpdateGenrePageComponent_Template(rf, ctx) { if (rf & 1) {
        _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtemplate"](0, UpdateGenrePageComponent_article_0_Template, 4, 7, "article", 0);
    } if (rf & 2) {
        _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵproperty"]("ngIf", !!ctx.form);
    } }, styles: ["\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJ1cGRhdGUtZ2VucmUtcGFnZS5jb21wb25lbnQuc2NzcyJ9 */"] });


/***/ }),

/***/ 159:
/*!*********************************************************************!*\
  !*** ./src/app/pages/update-genre-page/update-genre-page.module.ts ***!
  \*********************************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "UpdateGenrePageModule": () => (/* binding */ UpdateGenrePageModule)
/* harmony export */ });
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! @angular/common */ 4364);
/* harmony import */ var src_app_componetns_common_components_module__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! src/app/componetns/common-components.module */ 1951);
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! @angular/forms */ 1707);
/* harmony import */ var _update_genre_page_component__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./update-genre-page.component */ 4606);
/* harmony import */ var src_app_services_genre_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! src/app/services/genre.service */ 7776);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var _componetns_form_component_form_component__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../../componetns/form-component/form.component */ 8205);
/* harmony import */ var _componetns_selector_input_component_selector_input_component__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ../../componetns/selector-input-component/selector-input.component */ 9260);
/* harmony import */ var _componetns_text_input_component_text_input_component__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ../../componetns/text-input-component/text-input.component */ 2082);










class UpdateGenrePageModule {
}
UpdateGenrePageModule.ɵfac = function UpdateGenrePageModule_Factory(t) { return new (t || UpdateGenrePageModule)(); };
UpdateGenrePageModule.ɵmod = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵdefineNgModule"]({ type: UpdateGenrePageModule });
UpdateGenrePageModule.ɵinj = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵdefineInjector"]({ providers: [src_app_services_genre_service__WEBPACK_IMPORTED_MODULE_2__.GenreService], imports: [[_angular_common__WEBPACK_IMPORTED_MODULE_7__.CommonModule, src_app_componetns_common_components_module__WEBPACK_IMPORTED_MODULE_0__.CommonComponentsModule, _angular_forms__WEBPACK_IMPORTED_MODULE_8__.ReactiveFormsModule]] });
(function () { (typeof ngJitMode === "undefined" || ngJitMode) && _angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵsetNgModuleScope"](UpdateGenrePageModule, { declarations: [_update_genre_page_component__WEBPACK_IMPORTED_MODULE_1__.UpdateGenrePageComponent], imports: [_angular_common__WEBPACK_IMPORTED_MODULE_7__.CommonModule, src_app_componetns_common_components_module__WEBPACK_IMPORTED_MODULE_0__.CommonComponentsModule, _angular_forms__WEBPACK_IMPORTED_MODULE_8__.ReactiveFormsModule] }); })();
_angular_core__WEBPACK_IMPORTED_MODULE_6__["ɵɵsetComponentScope"](_update_genre_page_component__WEBPACK_IMPORTED_MODULE_1__.UpdateGenrePageComponent, [_angular_common__WEBPACK_IMPORTED_MODULE_7__.NgIf, _componetns_form_component_form_component__WEBPACK_IMPORTED_MODULE_3__.FormComponent, _componetns_selector_input_component_selector_input_component__WEBPACK_IMPORTED_MODULE_4__.SelectorInputComponent, _componetns_text_input_component_text_input_component__WEBPACK_IMPORTED_MODULE_5__.TextInputComponent], []);


/***/ }),

/***/ 9053:
/*!******************************************************************************!*\
  !*** ./src/app/pages/update-platform-page/update-platform-page.component.ts ***!
  \******************************************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "UpdatePlatformPageComponent": () => (/* binding */ UpdatePlatformPageComponent)
/* harmony export */ });
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/forms */ 1707);
/* harmony import */ var rxjs__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! rxjs */ 1134);
/* harmony import */ var rxjs_operators__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! rxjs/operators */ 9902);
/* harmony import */ var src_app_componetns_base_component__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! src/app/componetns/base.component */ 2844);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var src_app_services_platform_service__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! src/app/services/platform.service */ 8634);
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! @angular/router */ 1258);








function UpdatePlatformPageComponent_article_0_Template(rf, ctx) { if (rf & 1) {
    const _r2 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵgetCurrentView"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](0, "article");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](1, "gamestore-form", 1);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵlistener"]("save", function UpdatePlatformPageComponent_article_0_Template_gamestore_form_save_1_listener() { _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵrestoreView"](_r2); const ctx_r1 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵnextContext"](); return ctx_r1.onSave(); });
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelement"](2, "gamestore-text-input", 2);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
} if (rf & 2) {
    const ctx_r0 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵnextContext"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵproperty"]("form", ctx_r0.form)("pageLink", ctx_r0.platformPageLink);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵproperty"]("name", ctx_r0.labels.platformTypeLabel)("control", ctx_r0.getFormControl("type"));
} }
class UpdatePlatformPageComponent extends src_app_componetns_base_component__WEBPACK_IMPORTED_MODULE_0__.BaseComponent {
    constructor(platformService, route, builder, router) {
        super();
        this.platformService = platformService;
        this.route = route;
        this.builder = builder;
        this.router = router;
    }
    ngOnInit() {
        this.getRouteParam(this.route, 'id')
            .pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_3__.switchMap)((id) => !!(id === null || id === void 0 ? void 0 : id.length) ? this.platformService.getPlatform(id) : (0,rxjs__WEBPACK_IMPORTED_MODULE_4__.of)(undefined)))
            .subscribe((x) => this.createForm(x));
    }
    getFormControl(name) {
        var _a;
        return (_a = this.form) === null || _a === void 0 ? void 0 : _a.get(name);
    }
    onSave() {
        const platform = this.form.value;
        (!!platform.id
            ? this.platformService.updatePlatform(platform)
            : this.platformService.addPlatform(platform)).subscribe((_) => {
            var _a;
            return this.router.navigateByUrl(!!platform.id
                ? this.links.get(this.pageRoutes.Platform) + `/${platform.id}`
                : (_a = this.links.get(this.pageRoutes.Platforms)) !== null && _a !== void 0 ? _a : '');
        });
    }
    createForm(platform) {
        var _a, _b;
        this.platformPageLink = !!platform ? `${this.links.get(this.pageRoutes.Platform)}/${platform.id}` : undefined;
        this.form = this.builder.group({
            id: [(_a = platform === null || platform === void 0 ? void 0 : platform.id) !== null && _a !== void 0 ? _a : ''],
            type: [(_b = platform === null || platform === void 0 ? void 0 : platform.type) !== null && _b !== void 0 ? _b : '', _angular_forms__WEBPACK_IMPORTED_MODULE_5__.Validators.required],
        });
    }
}
UpdatePlatformPageComponent.ɵfac = function UpdatePlatformPageComponent_Factory(t) { return new (t || UpdatePlatformPageComponent)(_angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵdirectiveInject"](src_app_services_platform_service__WEBPACK_IMPORTED_MODULE_1__.PlatformService), _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵdirectiveInject"](_angular_router__WEBPACK_IMPORTED_MODULE_6__.ActivatedRoute), _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵdirectiveInject"](_angular_forms__WEBPACK_IMPORTED_MODULE_5__.FormBuilder), _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵdirectiveInject"](_angular_router__WEBPACK_IMPORTED_MODULE_6__.Router)); };
UpdatePlatformPageComponent.ɵcmp = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵdefineComponent"]({ type: UpdatePlatformPageComponent, selectors: [["gamestore-update-platform"]], features: [_angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵInheritDefinitionFeature"]], decls: 1, vars: 1, consts: [[4, "ngIf"], ["idName", "id", 3, "form", "pageLink", "save"], [3, "name", "control"]], template: function UpdatePlatformPageComponent_Template(rf, ctx) { if (rf & 1) {
        _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtemplate"](0, UpdatePlatformPageComponent_article_0_Template, 3, 4, "article", 0);
    } if (rf & 2) {
        _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵproperty"]("ngIf", !!ctx.form);
    } }, styles: ["\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJ1cGRhdGUtcGxhdGZvcm0tcGFnZS5jb21wb25lbnQuc2NzcyJ9 */"] });


/***/ }),

/***/ 4231:
/*!***************************************************************************!*\
  !*** ./src/app/pages/update-platform-page/update-platform-page.module.ts ***!
  \***************************************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "UpdatePlatformPageModule": () => (/* binding */ UpdatePlatformPageModule)
/* harmony export */ });
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! @angular/common */ 4364);
/* harmony import */ var src_app_componetns_common_components_module__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! src/app/componetns/common-components.module */ 1951);
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! @angular/forms */ 1707);
/* harmony import */ var src_app_services_platform_service__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! src/app/services/platform.service */ 8634);
/* harmony import */ var _update_platform_page_component__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./update-platform-page.component */ 9053);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var _componetns_form_component_form_component__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../../componetns/form-component/form.component */ 8205);
/* harmony import */ var _componetns_text_input_component_text_input_component__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ../../componetns/text-input-component/text-input.component */ 2082);









class UpdatePlatformPageModule {
}
UpdatePlatformPageModule.ɵfac = function UpdatePlatformPageModule_Factory(t) { return new (t || UpdatePlatformPageModule)(); };
UpdatePlatformPageModule.ɵmod = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_5__["ɵɵdefineNgModule"]({ type: UpdatePlatformPageModule });
UpdatePlatformPageModule.ɵinj = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_5__["ɵɵdefineInjector"]({ providers: [src_app_services_platform_service__WEBPACK_IMPORTED_MODULE_1__.PlatformService], imports: [[_angular_common__WEBPACK_IMPORTED_MODULE_6__.CommonModule, src_app_componetns_common_components_module__WEBPACK_IMPORTED_MODULE_0__.CommonComponentsModule, _angular_forms__WEBPACK_IMPORTED_MODULE_7__.ReactiveFormsModule]] });
(function () { (typeof ngJitMode === "undefined" || ngJitMode) && _angular_core__WEBPACK_IMPORTED_MODULE_5__["ɵɵsetNgModuleScope"](UpdatePlatformPageModule, { declarations: [_update_platform_page_component__WEBPACK_IMPORTED_MODULE_2__.UpdatePlatformPageComponent], imports: [_angular_common__WEBPACK_IMPORTED_MODULE_6__.CommonModule, src_app_componetns_common_components_module__WEBPACK_IMPORTED_MODULE_0__.CommonComponentsModule, _angular_forms__WEBPACK_IMPORTED_MODULE_7__.ReactiveFormsModule] }); })();
_angular_core__WEBPACK_IMPORTED_MODULE_5__["ɵɵsetComponentScope"](_update_platform_page_component__WEBPACK_IMPORTED_MODULE_2__.UpdatePlatformPageComponent, [_angular_common__WEBPACK_IMPORTED_MODULE_6__.NgIf, _componetns_form_component_form_component__WEBPACK_IMPORTED_MODULE_3__.FormComponent, _componetns_text_input_component_text_input_component__WEBPACK_IMPORTED_MODULE_4__.TextInputComponent], []);


/***/ }),

/***/ 8392:
/*!********************************************************************************!*\
  !*** ./src/app/pages/update-publisher-page/update-publisher-page.component.ts ***!
  \********************************************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "UpdatePublisherPageComponent": () => (/* binding */ UpdatePublisherPageComponent)
/* harmony export */ });
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/forms */ 1707);
/* harmony import */ var rxjs__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! rxjs */ 1134);
/* harmony import */ var rxjs_operators__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! rxjs/operators */ 9902);
/* harmony import */ var src_app_componetns_base_component__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! src/app/componetns/base.component */ 2844);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var src_app_services_publisher_service__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! src/app/services/publisher.service */ 7441);
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! @angular/router */ 1258);








function UpdatePublisherPageComponent_article_0_Template(rf, ctx) { if (rf & 1) {
    const _r2 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵgetCurrentView"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](0, "article");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](1, "gamestore-form", 1);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵlistener"]("save", function UpdatePublisherPageComponent_article_0_Template_gamestore_form_save_1_listener() { _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵrestoreView"](_r2); const ctx_r1 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵnextContext"](); return ctx_r1.onSave(); });
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelement"](2, "gamestore-text-input", 2);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelement"](3, "gamestore-text-input", 2);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelement"](4, "gamestore-text-input", 2);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
} if (rf & 2) {
    const ctx_r0 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵnextContext"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵproperty"]("form", ctx_r0.form)("pageLink", ctx_r0.publisherPageLink);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵproperty"]("name", ctx_r0.labels.publisherCompanyNameLabel)("control", ctx_r0.getFormControl("companyName"));
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵproperty"]("name", ctx_r0.labels.publisherDescriptionLabel)("control", ctx_r0.getFormControl("description"));
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵproperty"]("name", ctx_r0.labels.publisherHomePageLabel)("control", ctx_r0.getFormControl("homePage"));
} }
class UpdatePublisherPageComponent extends src_app_componetns_base_component__WEBPACK_IMPORTED_MODULE_0__.BaseComponent {
    constructor(publisherService, route, builder, router) {
        super();
        this.publisherService = publisherService;
        this.route = route;
        this.builder = builder;
        this.router = router;
    }
    ngOnInit() {
        this.getRouteParam(this.route, 'id')
            .pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_3__.switchMap)((companyName) => !!(companyName === null || companyName === void 0 ? void 0 : companyName.length) ? this.publisherService.getPublisher(companyName) : (0,rxjs__WEBPACK_IMPORTED_MODULE_4__.of)(undefined)))
            .subscribe((x) => {
            this.createForm(x);
        });
    }
    getFormControl(name) {
        var _a;
        return (_a = this.form) === null || _a === void 0 ? void 0 : _a.get(name);
    }
    onSave() {
        const publisher = this.form.value;
        (!!publisher.id
            ? this.publisherService.updatePublisher(publisher)
            : this.publisherService.addPublisher(publisher)).subscribe((_) => {
            var _a;
            return this.router.navigateByUrl(!!publisher.id
                ? this.links.get(this.pageRoutes.Publisher) + `/${publisher.companyName}`
                : (_a = this.links.get(this.pageRoutes.Publishers)) !== null && _a !== void 0 ? _a : '');
        });
    }
    createForm(publisher) {
        var _a, _b, _c, _d;
        this.publisherPageLink = !!publisher
            ? `${this.links.get(this.pageRoutes.Publisher)}/${publisher.companyName}`
            : undefined;
        this.form = this.builder.group({
            id: [(_a = publisher === null || publisher === void 0 ? void 0 : publisher.id) !== null && _a !== void 0 ? _a : ''],
            companyName: [(_b = publisher === null || publisher === void 0 ? void 0 : publisher.companyName) !== null && _b !== void 0 ? _b : '', _angular_forms__WEBPACK_IMPORTED_MODULE_5__.Validators.required],
            description: [(_c = publisher === null || publisher === void 0 ? void 0 : publisher.description) !== null && _c !== void 0 ? _c : ''],
            homePage: [(_d = publisher === null || publisher === void 0 ? void 0 : publisher.homePage) !== null && _d !== void 0 ? _d : ''],
        });
    }
}
UpdatePublisherPageComponent.ɵfac = function UpdatePublisherPageComponent_Factory(t) { return new (t || UpdatePublisherPageComponent)(_angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵdirectiveInject"](src_app_services_publisher_service__WEBPACK_IMPORTED_MODULE_1__.PublisherService), _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵdirectiveInject"](_angular_router__WEBPACK_IMPORTED_MODULE_6__.ActivatedRoute), _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵdirectiveInject"](_angular_forms__WEBPACK_IMPORTED_MODULE_5__.FormBuilder), _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵdirectiveInject"](_angular_router__WEBPACK_IMPORTED_MODULE_6__.Router)); };
UpdatePublisherPageComponent.ɵcmp = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵdefineComponent"]({ type: UpdatePublisherPageComponent, selectors: [["gamestore-update-publisher"]], features: [_angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵInheritDefinitionFeature"]], decls: 1, vars: 1, consts: [[4, "ngIf"], ["idName", "id", 3, "form", "pageLink", "save"], [3, "name", "control"]], template: function UpdatePublisherPageComponent_Template(rf, ctx) { if (rf & 1) {
        _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtemplate"](0, UpdatePublisherPageComponent_article_0_Template, 5, 8, "article", 0);
    } if (rf & 2) {
        _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵproperty"]("ngIf", !!ctx.form);
    } }, styles: ["\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJ1cGRhdGUtcHVibGlzaGVyLXBhZ2UuY29tcG9uZW50LnNjc3MifQ== */"] });


/***/ }),

/***/ 97:
/*!*****************************************************************************!*\
  !*** ./src/app/pages/update-publisher-page/update-publisher-page.module.ts ***!
  \*****************************************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "UpdatePublisherPageModule": () => (/* binding */ UpdatePublisherPageModule)
/* harmony export */ });
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! @angular/common */ 4364);
/* harmony import */ var src_app_componetns_common_components_module__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! src/app/componetns/common-components.module */ 1951);
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! @angular/forms */ 1707);
/* harmony import */ var _update_publisher_page_component__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./update-publisher-page.component */ 8392);
/* harmony import */ var src_app_services_publisher_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! src/app/services/publisher.service */ 7441);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var _componetns_form_component_form_component__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../../componetns/form-component/form.component */ 8205);
/* harmony import */ var _componetns_text_input_component_text_input_component__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ../../componetns/text-input-component/text-input.component */ 2082);









class UpdatePublisherPageModule {
}
UpdatePublisherPageModule.ɵfac = function UpdatePublisherPageModule_Factory(t) { return new (t || UpdatePublisherPageModule)(); };
UpdatePublisherPageModule.ɵmod = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_5__["ɵɵdefineNgModule"]({ type: UpdatePublisherPageModule });
UpdatePublisherPageModule.ɵinj = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_5__["ɵɵdefineInjector"]({ providers: [src_app_services_publisher_service__WEBPACK_IMPORTED_MODULE_2__.PublisherService], imports: [[_angular_common__WEBPACK_IMPORTED_MODULE_6__.CommonModule, src_app_componetns_common_components_module__WEBPACK_IMPORTED_MODULE_0__.CommonComponentsModule, _angular_forms__WEBPACK_IMPORTED_MODULE_7__.ReactiveFormsModule]] });
(function () { (typeof ngJitMode === "undefined" || ngJitMode) && _angular_core__WEBPACK_IMPORTED_MODULE_5__["ɵɵsetNgModuleScope"](UpdatePublisherPageModule, { declarations: [_update_publisher_page_component__WEBPACK_IMPORTED_MODULE_1__.UpdatePublisherPageComponent], imports: [_angular_common__WEBPACK_IMPORTED_MODULE_6__.CommonModule, src_app_componetns_common_components_module__WEBPACK_IMPORTED_MODULE_0__.CommonComponentsModule, _angular_forms__WEBPACK_IMPORTED_MODULE_7__.ReactiveFormsModule] }); })();
_angular_core__WEBPACK_IMPORTED_MODULE_5__["ɵɵsetComponentScope"](_update_publisher_page_component__WEBPACK_IMPORTED_MODULE_1__.UpdatePublisherPageComponent, [_angular_common__WEBPACK_IMPORTED_MODULE_6__.NgIf, _componetns_form_component_form_component__WEBPACK_IMPORTED_MODULE_3__.FormComponent, _componetns_text_input_component_text_input_component__WEBPACK_IMPORTED_MODULE_4__.TextInputComponent], []);


/***/ }),

/***/ 5136:
/*!******************************************!*\
  !*** ./src/app/services/base.service.ts ***!
  \******************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "BaseService": () => (/* binding */ BaseService)
/* harmony export */ });
/* harmony import */ var rxjs_operators__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! rxjs/operators */ 8636);
/* harmony import */ var rxjs_operators__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! rxjs/operators */ 3927);
/* harmony import */ var _configuration_configuration_resolver__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ../configuration/configuration-resolver */ 5482);
/* harmony import */ var _configuration_shared_info__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../configuration/shared-info */ 2614);



class BaseService {
    constructor(http, loaderService) {
        this.http = http;
        this.loaderService = loaderService;
    }
    get(url) {
        return this.interceptRequest(this.http.get(_configuration_configuration_resolver__WEBPACK_IMPORTED_MODULE_0__.appConfiguration.baseApiUrl + url, {
            observe: 'response',
        }));
    }
    getWithParams(url, params) {
        return this.interceptRequest(this.http.get(_configuration_configuration_resolver__WEBPACK_IMPORTED_MODULE_0__.appConfiguration.baseApiUrl + url, {
            params: params,
            observe: 'response',
        }));
    }
    getFile(url) {
        return this.interceptRequest(this.http.get(_configuration_configuration_resolver__WEBPACK_IMPORTED_MODULE_0__.appConfiguration.baseApiUrl + url, {
            responseType: 'blob',
            observe: 'response',
        }));
    }
    getFilePost(url, body) {
        return this.interceptRequest(this.http.post(_configuration_configuration_resolver__WEBPACK_IMPORTED_MODULE_0__.appConfiguration.baseApiUrl + url, body, {
            responseType: 'blob',
            observe: 'response',
        }));
    }
    post(url, body) {
        return this.interceptRequest(this.http.post(_configuration_configuration_resolver__WEBPACK_IMPORTED_MODULE_0__.appConfiguration.baseApiUrl + url, body, {
            observe: 'response',
        }));
    }
    put(url, body) {
        return this.interceptRequest(this.http.put(_configuration_configuration_resolver__WEBPACK_IMPORTED_MODULE_0__.appConfiguration.baseApiUrl + url, body, {
            observe: 'response',
        }));
    }
    delete(url, body) {
        return this.interceptRequest(this.http.delete(_configuration_configuration_resolver__WEBPACK_IMPORTED_MODULE_0__.appConfiguration.baseApiUrl + url, {
            body: body,
            observe: 'response',
        }));
    }
    interceptRequest(request) {
        return this.loaderService.openForLoading(request.pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_2__.tap)((x) => _configuration_shared_info__WEBPACK_IMPORTED_MODULE_1__.gameCountSubject.next(x.headers.get('x-total-numbers-of-games'))), (0,rxjs_operators__WEBPACK_IMPORTED_MODULE_3__.map)((x) => { var _a; return (_a = x.body) !== null && _a !== void 0 ? _a : {}; })));
    }
}


/***/ }),

/***/ 3792:
/*!*********************************************!*\
  !*** ./src/app/services/comment.service.ts ***!
  \*********************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "CommentService": () => (/* binding */ CommentService)
/* harmony export */ });
/* harmony import */ var src_environments_environment__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! src/environments/environment */ 2340);
/* harmony import */ var _configuration_configuration_resolver__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../configuration/configuration-resolver */ 5482);
/* harmony import */ var _base_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./base.service */ 5136);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/common/http */ 3882);
/* harmony import */ var _componetns_loader_component_loader_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../componetns/loader-component/loader.service */ 6216);






class CommentService extends _base_service__WEBPACK_IMPORTED_MODULE_2__.BaseService {
    constructor(http, loaderService) {
        super(http, loaderService);
    }
    getCommentsByGameKey(gameKey) {
        return this.get(_configuration_configuration_resolver__WEBPACK_IMPORTED_MODULE_1__.appConfiguration.commentsByGameApiUrl.replace(src_environments_environment__WEBPACK_IMPORTED_MODULE_0__.environment.routeKeyIdentifier, gameKey));
    }
    addComment(comment, gameKey, parentId, action) {
        return this.post(_configuration_configuration_resolver__WEBPACK_IMPORTED_MODULE_1__.appConfiguration.addCommentApiUrl.replace(src_environments_environment__WEBPACK_IMPORTED_MODULE_0__.environment.routeKeyIdentifier, gameKey), {
            comment,
            parentId,
            action,
        });
    }
    banUser(duration, user) {
        return this.post(_configuration_configuration_resolver__WEBPACK_IMPORTED_MODULE_1__.appConfiguration.banUserApiUrl, { user, duration });
    }
    deleteComment(id, gameKey) {
        return this.delete(_configuration_configuration_resolver__WEBPACK_IMPORTED_MODULE_1__.appConfiguration.deleteCommentApiUrl.replace(src_environments_environment__WEBPACK_IMPORTED_MODULE_0__.environment.routeKeyIdentifier, gameKey)
            .replace(src_environments_environment__WEBPACK_IMPORTED_MODULE_0__.environment.routeIdIdentifier, id), {});
    }
    getBanDurations() {
        return this.get(_configuration_configuration_resolver__WEBPACK_IMPORTED_MODULE_1__.appConfiguration.getBanDurationsApiUrl);
    }
}
CommentService.ɵfac = function CommentService_Factory(t) { return new (t || CommentService)(_angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵinject"](_angular_common_http__WEBPACK_IMPORTED_MODULE_5__.HttpClient), _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵinject"](_componetns_loader_component_loader_service__WEBPACK_IMPORTED_MODULE_3__.LoaderService)); };
CommentService.ɵprov = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵdefineInjectable"]({ token: CommentService, factory: CommentService.ɵfac });


/***/ }),

/***/ 1397:
/*!******************************************!*\
  !*** ./src/app/services/game.service.ts ***!
  \******************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "GameService": () => (/* binding */ GameService)
/* harmony export */ });
/* harmony import */ var src_environments_environment__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! src/environments/environment */ 2340);
/* harmony import */ var _configuration_configuration_resolver__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../configuration/configuration-resolver */ 5482);
/* harmony import */ var _base_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./base.service */ 5136);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/common/http */ 3882);
/* harmony import */ var _componetns_loader_component_loader_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../componetns/loader-component/loader.service */ 6216);






class GameService extends _base_service__WEBPACK_IMPORTED_MODULE_2__.BaseService {
    constructor(http, loaderService) {
        super(http, loaderService);
    }
    getGame(key) {
        return this.get(_configuration_configuration_resolver__WEBPACK_IMPORTED_MODULE_1__.appConfiguration.gameApiUrl.replace(src_environments_environment__WEBPACK_IMPORTED_MODULE_0__.environment.routeKeyIdentifier, key));
    }
    getGameById(id) {
        return this.get(_configuration_configuration_resolver__WEBPACK_IMPORTED_MODULE_1__.appConfiguration.gameByIdApiUrl.replace(src_environments_environment__WEBPACK_IMPORTED_MODULE_0__.environment.routeIdIdentifier, id));
    }
    getGames(filterParams) {
        return this.getWithParams(_configuration_configuration_resolver__WEBPACK_IMPORTED_MODULE_1__.appConfiguration.gamesApiUrl, filterParams);
    }
    addGame(game, genres, platforms, publisher) {
        return this.post(_configuration_configuration_resolver__WEBPACK_IMPORTED_MODULE_1__.appConfiguration.addGameApiUrl, {
            game,
            genres,
            platforms,
            publisher,
        });
    }
    updateGame(game, genres, platforms, publisher) {
        return this.put(_configuration_configuration_resolver__WEBPACK_IMPORTED_MODULE_1__.appConfiguration.updateGameApiUrl, {
            game,
            genres,
            platforms,
            publisher,
        });
    }
    deleteGame(key) {
        return this.delete(_configuration_configuration_resolver__WEBPACK_IMPORTED_MODULE_1__.appConfiguration.deleteGameApiUrl.replace(src_environments_environment__WEBPACK_IMPORTED_MODULE_0__.environment.routeKeyIdentifier, key), {});
    }
    getGamesByGenre(genreId) {
        return this.get(_configuration_configuration_resolver__WEBPACK_IMPORTED_MODULE_1__.appConfiguration.gamesByGenreApiUrl.replace(src_environments_environment__WEBPACK_IMPORTED_MODULE_0__.environment.routeIdIdentifier, genreId));
    }
    getGamesByPlatfrom(platformId) {
        return this.get(_configuration_configuration_resolver__WEBPACK_IMPORTED_MODULE_1__.appConfiguration.gamesByPlatformApiUrl.replace(src_environments_environment__WEBPACK_IMPORTED_MODULE_0__.environment.routeIdIdentifier, platformId));
    }
    getGamesByPublisher(companyName) {
        return this.get(_configuration_configuration_resolver__WEBPACK_IMPORTED_MODULE_1__.appConfiguration.gamesByPublisherApiUrl.replace(src_environments_environment__WEBPACK_IMPORTED_MODULE_0__.environment.routeCompanyNameIdentifier, companyName));
    }
    getGameFile(key) {
        return this.getFile(_configuration_configuration_resolver__WEBPACK_IMPORTED_MODULE_1__.appConfiguration.getGameFileApiUrl.replace(src_environments_environment__WEBPACK_IMPORTED_MODULE_0__.environment.routeKeyIdentifier, key));
    }
    getPublishedDateOptions() {
        return this.get(_configuration_configuration_resolver__WEBPACK_IMPORTED_MODULE_1__.appConfiguration.getPublishedDateOptionsApiUrl);
    }
    getSortingOptions() {
        return this.get(_configuration_configuration_resolver__WEBPACK_IMPORTED_MODULE_1__.appConfiguration.getSortingOptionsApiUrl);
    }
    getPaggingOptions() {
        return this.get(_configuration_configuration_resolver__WEBPACK_IMPORTED_MODULE_1__.appConfiguration.getPaggingOptionsApiUrl);
    }
}
GameService.ɵfac = function GameService_Factory(t) { return new (t || GameService)(_angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵinject"](_angular_common_http__WEBPACK_IMPORTED_MODULE_5__.HttpClient), _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵinject"](_componetns_loader_component_loader_service__WEBPACK_IMPORTED_MODULE_3__.LoaderService)); };
GameService.ɵprov = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵdefineInjectable"]({ token: GameService, factory: GameService.ɵfac });


/***/ }),

/***/ 7776:
/*!*******************************************!*\
  !*** ./src/app/services/genre.service.ts ***!
  \*******************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "GenreService": () => (/* binding */ GenreService)
/* harmony export */ });
/* harmony import */ var src_environments_environment__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! src/environments/environment */ 2340);
/* harmony import */ var _configuration_configuration_resolver__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../configuration/configuration-resolver */ 5482);
/* harmony import */ var _base_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./base.service */ 5136);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/common/http */ 3882);
/* harmony import */ var _componetns_loader_component_loader_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../componetns/loader-component/loader.service */ 6216);






class GenreService extends _base_service__WEBPACK_IMPORTED_MODULE_2__.BaseService {
    constructor(http, loaderService) {
        super(http, loaderService);
    }
    getGenre(id) {
        return this.get(_configuration_configuration_resolver__WEBPACK_IMPORTED_MODULE_1__.appConfiguration.genreApiUrl.replace(src_environments_environment__WEBPACK_IMPORTED_MODULE_0__.environment.routeIdIdentifier, id));
    }
    getGenres() {
        return this.get(_configuration_configuration_resolver__WEBPACK_IMPORTED_MODULE_1__.appConfiguration.genresApiUrl);
    }
    getGenresByGameKey(gameKey) {
        return this.get(_configuration_configuration_resolver__WEBPACK_IMPORTED_MODULE_1__.appConfiguration.genresByGameApiUrl.replace(src_environments_environment__WEBPACK_IMPORTED_MODULE_0__.environment.routeKeyIdentifier, gameKey));
    }
    getGenresByParent(id) {
        return this.get(_configuration_configuration_resolver__WEBPACK_IMPORTED_MODULE_1__.appConfiguration.genresByParentApiUrl.replace(src_environments_environment__WEBPACK_IMPORTED_MODULE_0__.environment.routeIdIdentifier, id));
    }
    addGenre(genre) {
        return this.post(_configuration_configuration_resolver__WEBPACK_IMPORTED_MODULE_1__.appConfiguration.addGenreApiUrl, { genre });
    }
    updateGenre(genre) {
        return this.put(_configuration_configuration_resolver__WEBPACK_IMPORTED_MODULE_1__.appConfiguration.updateGenreApiUrl, { genre });
    }
    deleteGenre(id) {
        return this.delete(_configuration_configuration_resolver__WEBPACK_IMPORTED_MODULE_1__.appConfiguration.deleteGenreApiUrl.replace(src_environments_environment__WEBPACK_IMPORTED_MODULE_0__.environment.routeIdIdentifier, id), {});
    }
}
GenreService.ɵfac = function GenreService_Factory(t) { return new (t || GenreService)(_angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵinject"](_angular_common_http__WEBPACK_IMPORTED_MODULE_5__.HttpClient), _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵinject"](_componetns_loader_component_loader_service__WEBPACK_IMPORTED_MODULE_3__.LoaderService)); };
GenreService.ɵprov = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵdefineInjectable"]({ token: GenreService, factory: GenreService.ɵfac });


/***/ }),

/***/ 8132:
/*!*******************************************!*\
  !*** ./src/app/services/order.service.ts ***!
  \*******************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "OrderService": () => (/* binding */ OrderService)
/* harmony export */ });
/* harmony import */ var src_environments_environment__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! src/environments/environment */ 2340);
/* harmony import */ var _configuration_configuration_resolver__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../configuration/configuration-resolver */ 5482);
/* harmony import */ var _base_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./base.service */ 5136);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/common/http */ 3882);
/* harmony import */ var _componetns_loader_component_loader_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../componetns/loader-component/loader.service */ 6216);






class OrderService extends _base_service__WEBPACK_IMPORTED_MODULE_2__.BaseService {
    constructor(http, loaderService) {
        super(http, loaderService);
    }
    getOrder(id) {
        return this.get(_configuration_configuration_resolver__WEBPACK_IMPORTED_MODULE_1__.appConfiguration.orderApiUrl.replace(src_environments_environment__WEBPACK_IMPORTED_MODULE_0__.environment.routeIdIdentifier, id));
    }
    getOrders() {
        return this.get(_configuration_configuration_resolver__WEBPACK_IMPORTED_MODULE_1__.appConfiguration.ordersApiUrl);
    }
    getMakeOrderInfo() {
        return this.get(_configuration_configuration_resolver__WEBPACK_IMPORTED_MODULE_1__.appConfiguration.makeOrderInfoApiUrl);
    }
    getOrderDetails(orderId) {
        return this.get(_configuration_configuration_resolver__WEBPACK_IMPORTED_MODULE_1__.appConfiguration.orderDetailsApiUrl.replace(src_environments_environment__WEBPACK_IMPORTED_MODULE_0__.environment.routeIdIdentifier, orderId));
    }
    getBasket() {
        return this.get(_configuration_configuration_resolver__WEBPACK_IMPORTED_MODULE_1__.appConfiguration.basketApiUrl);
    }
    buyGame(gameKey) {
        return this.post(_configuration_configuration_resolver__WEBPACK_IMPORTED_MODULE_1__.appConfiguration.buyGameApiUrl.replace(src_environments_environment__WEBPACK_IMPORTED_MODULE_0__.environment.routeKeyIdentifier, gameKey), {});
    }
    cancelGameBuy(gameKey) {
        return this.delete(_configuration_configuration_resolver__WEBPACK_IMPORTED_MODULE_1__.appConfiguration.cancelGameBuyApiUrl.replace(src_environments_environment__WEBPACK_IMPORTED_MODULE_0__.environment.routeKeyIdentifier, gameKey), {});
    }
    getBankFile(method) {
        return this.getFilePost(_configuration_configuration_resolver__WEBPACK_IMPORTED_MODULE_1__.appConfiguration.payApiUrl, { method });
    }
    payTerminal(method) {
        return this.post(_configuration_configuration_resolver__WEBPACK_IMPORTED_MODULE_1__.appConfiguration.payApiUrl, { method });
    }
    payVisa(method, model) {
        return this.post(_configuration_configuration_resolver__WEBPACK_IMPORTED_MODULE_1__.appConfiguration.payApiUrl, {
            method,
            model,
        });
    }
}
OrderService.ɵfac = function OrderService_Factory(t) { return new (t || OrderService)(_angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵinject"](_angular_common_http__WEBPACK_IMPORTED_MODULE_5__.HttpClient), _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵinject"](_componetns_loader_component_loader_service__WEBPACK_IMPORTED_MODULE_3__.LoaderService)); };
OrderService.ɵprov = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵdefineInjectable"]({ token: OrderService, factory: OrderService.ɵfac });


/***/ }),

/***/ 8634:
/*!**********************************************!*\
  !*** ./src/app/services/platform.service.ts ***!
  \**********************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "PlatformService": () => (/* binding */ PlatformService)
/* harmony export */ });
/* harmony import */ var src_environments_environment__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! src/environments/environment */ 2340);
/* harmony import */ var _configuration_configuration_resolver__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../configuration/configuration-resolver */ 5482);
/* harmony import */ var _base_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./base.service */ 5136);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/common/http */ 3882);
/* harmony import */ var _componetns_loader_component_loader_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../componetns/loader-component/loader.service */ 6216);






class PlatformService extends _base_service__WEBPACK_IMPORTED_MODULE_2__.BaseService {
    constructor(http, loaderService) {
        super(http, loaderService);
    }
    getPlatform(id) {
        return this.get(_configuration_configuration_resolver__WEBPACK_IMPORTED_MODULE_1__.appConfiguration.platformApiUrl.replace(src_environments_environment__WEBPACK_IMPORTED_MODULE_0__.environment.routeIdIdentifier, id));
    }
    getPlatformsByGameKey(gameKey) {
        return this.get(_configuration_configuration_resolver__WEBPACK_IMPORTED_MODULE_1__.appConfiguration.platformsByGameApiUrl.replace(src_environments_environment__WEBPACK_IMPORTED_MODULE_0__.environment.routeKeyIdentifier, gameKey));
    }
    getPlatforms() {
        return this.get(_configuration_configuration_resolver__WEBPACK_IMPORTED_MODULE_1__.appConfiguration.platformsApiUrl);
    }
    addPlatform(platform) {
        return this.post(_configuration_configuration_resolver__WEBPACK_IMPORTED_MODULE_1__.appConfiguration.addPlatformApiUrl, { platform });
    }
    updatePlatform(platform) {
        return this.put(_configuration_configuration_resolver__WEBPACK_IMPORTED_MODULE_1__.appConfiguration.updatePlatformApiUrl, { platform });
    }
    deletePlatform(id) {
        return this.delete(_configuration_configuration_resolver__WEBPACK_IMPORTED_MODULE_1__.appConfiguration.deletePlatformApiUrl.replace(src_environments_environment__WEBPACK_IMPORTED_MODULE_0__.environment.routeIdIdentifier, id), {});
    }
}
PlatformService.ɵfac = function PlatformService_Factory(t) { return new (t || PlatformService)(_angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵinject"](_angular_common_http__WEBPACK_IMPORTED_MODULE_5__.HttpClient), _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵinject"](_componetns_loader_component_loader_service__WEBPACK_IMPORTED_MODULE_3__.LoaderService)); };
PlatformService.ɵprov = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵdefineInjectable"]({ token: PlatformService, factory: PlatformService.ɵfac });


/***/ }),

/***/ 7441:
/*!***********************************************!*\
  !*** ./src/app/services/publisher.service.ts ***!
  \***********************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "PublisherService": () => (/* binding */ PublisherService)
/* harmony export */ });
/* harmony import */ var src_environments_environment__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! src/environments/environment */ 2340);
/* harmony import */ var _configuration_configuration_resolver__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../configuration/configuration-resolver */ 5482);
/* harmony import */ var _base_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./base.service */ 5136);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/common/http */ 3882);
/* harmony import */ var _componetns_loader_component_loader_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../componetns/loader-component/loader.service */ 6216);






class PublisherService extends _base_service__WEBPACK_IMPORTED_MODULE_2__.BaseService {
    constructor(http, loaderService) {
        super(http, loaderService);
    }
    getPublisher(companyName) {
        return this.get(_configuration_configuration_resolver__WEBPACK_IMPORTED_MODULE_1__.appConfiguration.publisherApiUrl.replace(src_environments_environment__WEBPACK_IMPORTED_MODULE_0__.environment.routeCompanyNameIdentifier, companyName));
    }
    getPublishers() {
        return this.get(_configuration_configuration_resolver__WEBPACK_IMPORTED_MODULE_1__.appConfiguration.publishersApiUrl);
    }
    getPublisherByGameKey(gameKey) {
        return this.get(_configuration_configuration_resolver__WEBPACK_IMPORTED_MODULE_1__.appConfiguration.publisherByGameApiUrl.replace(src_environments_environment__WEBPACK_IMPORTED_MODULE_0__.environment.routeKeyIdentifier, gameKey));
    }
    addPublisher(publisher) {
        return this.post(_configuration_configuration_resolver__WEBPACK_IMPORTED_MODULE_1__.appConfiguration.addPublisherApiUrl, { publisher });
    }
    updatePublisher(publisher) {
        return this.put(_configuration_configuration_resolver__WEBPACK_IMPORTED_MODULE_1__.appConfiguration.updatePublisherApiUrl, { publisher });
    }
    deletePublisher(id) {
        return this.delete(_configuration_configuration_resolver__WEBPACK_IMPORTED_MODULE_1__.appConfiguration.deletePublisherApiUrl.replace(src_environments_environment__WEBPACK_IMPORTED_MODULE_0__.environment.routeIdIdentifier, id), {});
    }
}
PublisherService.ɵfac = function PublisherService_Factory(t) { return new (t || PublisherService)(_angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵinject"](_angular_common_http__WEBPACK_IMPORTED_MODULE_5__.HttpClient), _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵinject"](_componetns_loader_component_loader_service__WEBPACK_IMPORTED_MODULE_3__.LoaderService)); };
PublisherService.ɵprov = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵdefineInjectable"]({ token: PublisherService, factory: PublisherService.ɵfac });


/***/ }),

/***/ 2340:
/*!*****************************************!*\
  !*** ./src/environments/environment.ts ***!
  \*****************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "environment": () => (/* binding */ environment)
/* harmony export */ });
const environment = {
    routeIdIdentifier: '{id}',
    routeKeyIdentifier: '{key}',
    routeCompanyNameIdentifier: '{companyname}',
};


/***/ }),

/***/ 4431:
/*!*********************!*\
  !*** ./src/main.ts ***!
  \*********************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony import */ var _angular_platform_browser__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/platform-browser */ 1570);
/* harmony import */ var _app_app_module__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./app/app.module */ 6747);


_angular_platform_browser__WEBPACK_IMPORTED_MODULE_1__.platformBrowser().bootstrapModule(_app_app_module__WEBPACK_IMPORTED_MODULE_0__.AppModule)
    .catch(err => console.error(err));


/***/ })

},
/******/ __webpack_require__ => { // webpackRuntimeModules
/******/ var __webpack_exec__ = (moduleId) => (__webpack_require__(__webpack_require__.s = moduleId))
/******/ __webpack_require__.O(0, ["vendor"], () => (__webpack_exec__(4431)));
/******/ var __webpack_exports__ = __webpack_require__.O();
/******/ }
]);
//# sourceMappingURL=main.js.map