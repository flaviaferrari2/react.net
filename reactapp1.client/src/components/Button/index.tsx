import { Container } from "./styles";

interface IButtonProps {
    title: string;
    space: boolean;
    isPrimary: "green" | "blue";
    onClink?: () => void;
}
export function Button({ title, isPrimary, space, onClink }: IButtonProps) {
    return (
        <Container isPrimary={isPrimary} space={space} onClick={onClink}>
            <h1>{title}</h1>
        </Container>
    );
}