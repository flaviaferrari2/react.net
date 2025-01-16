import styled from "styled-components";

export const Containt = styled.div`
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  background-color: ${({ theme }) => theme.COLORS.GREYISH_BLUE_10};
  width: 100%;
  height: 100vh;

  .error {
    color: ${({ theme }) => theme.COLORS.DEEP_NAVY_BLUE_30};
    font-size: 12.5rem;
  }

  h2 {
    color: var(--white);
    font-size: 2.6rem;
    margin-bottom: 10px;
    @media (max-width: 720px) {
      text-align: center;
    }
    @media (max-width: 490px) {
      text-align: center;
    }
  }
  p {
    color: var(--white);
    font-size: 1.5rem;
    margin-bottom: 20px;
  }
  button {
    display: flex;
    justify-content: center;
    align-items: center;
    background-color: ${({ theme }) => theme.COLORS.DEEP_NAVY_BLUE_50};
    color: var(--white);
    border: 0;
    width: 181px;
    height: 55px;
    font-size: 1.5rem;
    margin: 5px 0px;
    border-radius: 10px;
    cursor: pointer;
    transition: 0.3s all;
    :hover {
      background-color: ${({ theme }) => theme.COLORS.DEEP_NAVY_BLUE_30};
    }
  }
  a {
    text-decoration: none;
  }
`;