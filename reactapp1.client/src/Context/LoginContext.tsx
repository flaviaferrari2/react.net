import {
    ReactNode,
    createContext,
    Dispatch,
    SetStateAction,
    useContext,
    useState,
    useEffect,
} from "react";

interface IContextProps {
    children: ReactNode;
}

interface IContext {
    user: string;
    setUser: Dispatch<SetStateAction<string>>;
}

const Context = createContext({} as IContext);

const LoginContextProvider = ({ children }: IContextProps) => {
    const [user, setUser] = useState<string>("");

    useEffect(() => { },[])
    return (
        <Context.Provider value={{ user, setUser }}>{children}</Context.Provider>
    );
};

const useLoginContextPath = () => {
    const context = useContext(Context);
    return context;
};

export { LoginContextProvider, useLoginContextPath };