import styled, { css } from "styled-components";

interface IContainerProps {
    isPrimary: string;
    space: boolean;
}
export const Container = styled.div<IContainerProps>`
  display: flex;
  justify-content: center;
  align-items: center;
  cursor: pointer;
  border-radius: 8px;
  width: 260px;
  height: 50px;

  h1 {
    font-size: 1.1rem;
    font-weight: 600;
  }

  ${({ isPrimary }) =>
        isPrimary === "green"
            ? css`
          background-color: ${({ theme }) => theme.COLORS.BLUE};
          color: var(--white);

          :hover {
            color: ${({ theme }) => theme.COLORS.BLUE_100};
          }
        `
            : isPrimary === "blue"
                ? css`
          background-color: ${({ theme }) => theme.COLORS.BROWN};
          color: var(--white);
          :hover {
            background-color: ${({ theme }) => theme.COLORS.BROWN};
          }
        `
                : css`
          background-color: ${({ theme }) => theme.COLORS.GREEN_20};
          color: var(--white);
        `}
  ${({ space }) =>
        space === true
            ? css`
          margin-right: 8px;
        `
            : css``}

  @media (max-width: 550px) {
    width: 100%;
    margin-top: 18px;
  }
`;