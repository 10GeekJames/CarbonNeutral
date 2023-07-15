window.appCulture = {
    get: () => {
        try {
            return window.localStorage['AppLanguage'];
        } catch {
            return "en-US";
        }
    },
    set: (value) => window.localStorage['AppLanguage'] = value
};
window.activeBusinessData = {
    get: () => {
        try {
            return JSON.parse(window.localStorage['ActiveBusinessData']);
        } catch {
            return JSON.parse("{}");
        }
    },
    set: (value) => window.localStorage['ActiveBusinessData'] = JSON.stringify(value)
};
window.activeUserData = {
    get: () => {
        try {
            return JSON.parse(window.localStorage['ActiveUserData']);
        } catch {
            return JSON.parse("{}");
        }
    },
    set: (value) => window.localStorage['ActiveUserData'] = JSON.stringify(value)
};
window.individualData = {
    get: () => {
        try {
            return JSON.parse(window.localStorage['IndividualData']);
        } catch {
            return JSON.parse("{}");
        }
    },
    set: (value) => window.localStorage['IndividualData'] = JSON.stringify(value)
};
window.headspace = {
    get: () => {
        try {
            return window.localStorage['headspace'];
        } catch {
            return -1;
        }
    },
    set: (value) => window.localStorage['headspace'] = value
};

redirectToCheckout = function (sessionId) {
    var stripe = Stripe('pk_test_51LDXe5FeOepq0GS5c81DTuC1P5WqjnnFZANEzIA5NiQNrSKeaNznmR5aIkOJ7qie8INF5fh1mjJuMrN17OOM2GQB00GcauohcI');
    stripe.redirectToCheckout({
        sessionId: sessionId
    });
};