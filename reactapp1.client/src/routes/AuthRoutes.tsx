import { Routes, Route, BrowserRouter } from "react-router-dom";

import { AuthNotFound } from "../pages/AuthPages/AuthNotFound";
import React from "react";
import { Signin } from "../pages/AuthPages/Signin";

export const AuthRoutes = () => {
    return (
        <BrowserRouter>
            <Routes>
                <Route path="/" element={<Signin />} />
                <Route path="*" element={<AuthNotFound />} />
            </Routes>
        </BrowserRouter>
    );
};