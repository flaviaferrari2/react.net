import { Dispatch, SetStateAction } from "react";

import { Container } from "./styles";

interface IFieldProps {
    title: string;
    type: string;
    name: string;
    value?: string;
    onChange: Dispatch<SetStateAction<string>>;
}

export function Field({ title, type, name, value, onChange }: IFieldProps) {
    return (
        <Container>
            <div>
                <label>{title}</label>
                <input
                    type={type}
                    name={name}
                    value={value}
                    onChange={(e) => onChange(e.target.value)}
                />
            </div>
        </Container>
    );
}