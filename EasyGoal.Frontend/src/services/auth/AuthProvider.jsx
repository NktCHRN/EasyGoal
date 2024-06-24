import React, { createContext, useContext, useState, useEffect, useCallback } from 'react';
import { jwtDecode } from 'jwt-decode';
import { setLogOutTokenHandler, setUpdateTokenHandler } from './tokenService';

const AuthContext = createContext();

export const AuthProvider = ({ children }) => {
  const [isAuthenticated, setIsAuthenticated] = useState(false);
  const [user, setUser] = useState(null);

  const nameClaim = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname";
  const emailClaim = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress";

  useEffect(() => {
    const token = localStorage.getItem('accessToken');
    if (token) {
      try {
        const decodedToken = jwtDecode(token);
        setUser({
          name: decodedToken[nameClaim],
          email: decodedToken[emailClaim],
        });
        setIsAuthenticated(true);
      } catch (error) {
        console.error('Invalid token', error);
      }
    }
  }, []);

  const login = (token, refreshToken) => {
    const decodedToken = jwtDecode(token);
    console.log(decodedToken);
    setUser({
      name: decodedToken[nameClaim],
      email: decodedToken[emailClaim],
    });
    setIsAuthenticated(true);
    localStorage.setItem('accessToken', token);
    localStorage.setItem('refreshToken', refreshToken);
  };

  const logout = useCallback(() => {
    setIsAuthenticated(false);
    setUser(null);
    localStorage.removeItem('accessToken');
    localStorage.removeItem('refreshToken');
  }, []);

  const updateToken = useCallback((token, refreshToken) => {
    const decodedToken = jwtDecode(token);
    setUser({
      name: decodedToken[nameClaim],
      email: decodedToken[emailClaim],
    });
    localStorage.setItem('accessToken', token);
    localStorage.setItem('refreshToken', refreshToken);
  }, []);

  useEffect(() => {
    setUpdateTokenHandler(updateToken);
  }, [updateToken]);

  useEffect(() => {
    setLogOutTokenHandler(logout);
  }, [logout]);

  return (
    <AuthContext.Provider value={{ isAuthenticated, user, login, logout }}>
      {children}
    </AuthContext.Provider>
  );
};

export const useAuth = () => useContext(AuthContext);
