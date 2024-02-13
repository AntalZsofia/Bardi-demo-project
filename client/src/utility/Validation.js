const isValidName = (name) => {
    const nameRegex = /^[a-zA-Z0-9-._]{4,20}$/;
    return nameRegex.test(name);
};

export {isValidName};
