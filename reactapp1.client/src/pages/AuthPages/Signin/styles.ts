import styled from "styled-components";

export const CustomPageContainer = styled.div`
  display: flex;
  flex-direction: column;
  align-items: center;
  width: 100%;
  /* height: 100vh; */
  transition: 0.3s all;

  .custom-page-content {
    padding: 0.4rem;
    background-color: ${({ theme }) => theme.COLORS.BROWN};
    height: 100%;
    width: 100%;
    /* overflow-y: auto; */

    .custom-page {
      display: flex;
      flex-direction: row;
      width: 100%;
      background-color: white;
      min-height: 98vh;
    }
    .custom-logo{
      width: 50%;
      background-color: ${({ theme }) => theme.COLORS.BROWN};

      .nameSytema{
          height: 100%;
          width: 100%;
          display: flex;
          justify-content: center;
          align-items: center;
          color: ${({ theme }) => theme.COLORS.WHITE}
      }
    }
    .custom-form{
      display: flex;
      flex-direction: column;
      justify-content: center;
      align-items: center;
      width: 50%;
      background-color: ${({ theme }) => theme.COLORS.WHITE};
  }
`;