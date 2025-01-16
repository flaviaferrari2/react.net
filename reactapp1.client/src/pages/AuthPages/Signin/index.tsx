import { CustomPageContainer } from "./styles"
import Logout from "../../../assets/SisControl4.png";
import { Field } from "../../../components/Field";
import { useEffect, useState } from "react";
import { Button } from "../../../components/Button";
import { postlogin } from "./services";
export const Signin = () => {
	const [Cpf, setCpf] = useState<string>("123456789");
	const [Password, setPassaword] = useState<string>("password123");




    return (
		<CustomPageContainer>
			<div className="custom-page-content">
				<div className="custom-page">
					<div className="custom-logo">
						<img
							className="iconUser"
							src={Logout}
							alt="Ordem"
							width="200"
							height="50"
						/>
						<div className="nameSytema">
							<h1>Concurso 4.0</h1>
						</div>
					</div> 
					<div className="custom-form">
						<Field
							title="Seu CPF"
							type="text"
							name="cpf"
							value={Cpf}
							onChange={setCpf}
						/>
						<Field
							title="Sua senha"
							type="passaword"
							name="passaword"
							value={Password}
							onChange={setPassaword}
						/>
						<Button isPrimary="green" title="Entrar" onClink={() => postlogin({Cpf, Password})} space={false} />
					</div> 
				</div>
			</div>
		</CustomPageContainer>
				
	)

}
