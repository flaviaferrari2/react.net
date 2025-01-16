import styled from "styled-components";

export const Container = styled.div`
  display: flex;
  align-items: center;
  justify-content: center;
  width: 100%;
  margin-bottom: 1rem;

  div {
    width: 400px;
    display: flex;
    align-items: flex-start;
    flex-direction: column;
  }

  label {
    font-weight: 700;
    margin-top: 10px;
  }

  input {
    width: 100%;
    padding: 1rem;
    height: 2.5rem;
    font-size: 1rem;
    margin-top: 4px;
    border-radius: 0.5rem;
    border: 0;
    box-shadow: 0 0 0 0;
    outline: 0;
     background-color: ${({ theme }) => theme.COLORS.LIGHT_GRAY_10};
  }
`;