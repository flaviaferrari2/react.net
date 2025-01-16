import { Link } from "react-router-dom";
import { Containt } from "./styles";


export const AuthNotFound = () => {
    return (
        <Containt>
            <h1 className="error">404</h1>
            <h2>Ops! Algo deu errado…</h2>
            <p>Volte para o login!</p>
            <Link to="/">
                <button>Voltar</button>
            </Link>
        </Containt>
    );
};