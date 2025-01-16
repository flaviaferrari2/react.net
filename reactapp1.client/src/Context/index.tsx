import { ReactNode } from "react";
import { LoginContextProvider } from "./LoginContext";



interface IAppProvider {
    children: ReactNode;
}

const AppProvider = ({ children }: IAppProvider) => {
    return (
        <LoginContextProvider>
            {children }
        </LoginContextProvider>
    );
};

export default AppProvider;