import { ThemeProvider } from "styled-components";
import * as React from "react";

import { Routes } from "./routes/index";
import theme from "./theme/index";
import { GlobalStyles } from "./styles/GlobalStyles"
import AppProvider from "./Context";

function App() {
    return (
        <AppProvider>
            <ThemeProvider {...{ theme }}>
                <Routes />
                <GlobalStyles />
            </ThemeProvider>
        </AppProvider>
    );
}

export default App;