import { Dispatch, SetStateAction } from "react";
import axios from "axios";
interface ILogin {
    Cpf: string
    Passaword: string
}
//const teste = async ({ setCpf, setPassaword}: ILogin) => {
//    const response = await fetch('Login');
//    if (response.ok) {
//        //const data = await response.json();
//    }
//}

//interface IBackupDatabase {
//    photoInscription: InscricaoFoto[];
//}
export const API = axios.create({
    baseURL: "https://localhost:7236/login",
});

const postlogin = async ({ Cpf, Password }: { Cpf: string; Password: string }): Promise<boolean> => {
    let response;
    try {
         response = await API.post("/login", { Cpf, Password });

        if (response.status === 200) {
            console.log("Login bem-sucedido:", response.data);
            return true;
        }
        return false;
    } catch (error) {
        console.error("Erro na chamada de login:", error, response);
        return false;
    }
};


//async function postlogin() {
//    const response = await fetch('Login/login');
//    if (response.ok) {
//        const data = await response.json();
//    }
//}
export { postlogin }