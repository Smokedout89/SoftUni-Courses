function extensibleObject() {
    let proto = {};
    let instance = Object.create(proto);

    instance.extend = function (templates) {
        Object.entries(templates).forEach(([key, value]) => {
            if (typeof value === 'function') {
                proto[key] = value;
            } else {
                instance[key] = value;
            }
        });
    }

    return instance;
}