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
    baseURL: "https://F:7236/api/",
	method: 'POST'
});

//const postlogin = async ({ Cpf, Password }: { Cpf: string; Password: string }): Promise<boolean> => {
//    let response;
//    try {
//         response = await API.post("/Login", { Cpf, Password });

//        if (response.status === 200) {
//            console.log("Login bem-sucedido:", response.data);
//            return true;
//        }
//        return false;
//    } catch (error) {
//        console.error("Erro na chamada de login:", error, response);
//        return false;
//    }
//};

//async function postlogin() {
//    const loginData = {
//        cpf: "123456789",
//        password: "password123"
//    };

//    try {
//        const response = await axios.post('https://localhost:53782/login', loginData);
//        console.log(response.data);
//    } catch (err) {
//        console.error(err.response?.data || err.message);
//    }
//}


async function postlogin() {
    const response = await fetch('Login');
    if (response.ok) {
        const data = await response.json();
    }
}
export { postlogin }