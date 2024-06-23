// src/services/tokenService.js
let updateTokenHandler = null;

export const setUpdateTokenHandler = (handler) => {
  updateTokenHandler = handler;
};

export const getUpdateTokenHandler = () => updateTokenHandler;

let logOutTokenHandler = null;

export const setLogOutTokenHandler = (handler) => {
    logOutTokenHandler = handler;
};

export const getLogOutTokenHandler = () => logOutTokenHandler;
