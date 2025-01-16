/* eslint-disable @typescript-eslint/no-unused-vars */
import styled, { createGlobalStyle } from "styled-components";



export const GlobalStyles = createGlobalStyle`


  :root {
    --background: #f0f2f5;
    --backgroundContainer: #CDCDCD;
    --backgroundHeader: #001D31;
    --backgroundSignin: #002741;
    --backgroundTableMenu: #012840;
    --buttonSubmit: #00446B;
    --text-title: #363f5f;
    --text-body: #969cb3;
    --white: #fff;
    --black: #000000;
    --blue-menu: #025373;
    --button: #30A54A;
    --buttonHover: #26893C;
    --buttonOption: #D9D9D9;
    --inputForm: #ECECEC;
    --fieForm: #837C7C;
  }

  html{
    @media (max-width: 1080px){
      font-size: 93.75%;
    }
    @media (max-width: 720px){
      font-size: 87.5%;
    }
  }
  
  *{
    margin: 0;
    padding: 0;
    box-sizing: border-box;
  }

  body{
    background-color: var(--background);
    -webkit-font-smoothing: antialiased;
  }
  

  body,input,textarea,button{
    font-family:'Poppins', sans-serif;
    font-weight: 400;
  }
  h1,h2,h3,h4,h5,h6,strong{
    font-weight: 600;
  }
  button{
    cursor: pointer;
  }
 
  .react-modal-overlay {
    background: rgba(0, 0, 0, 0.5);
    position: fixed;
    top: 0;
    bottom: 0;
    right: 0;
    left: 0;
    display: flex;
    align-items: center;
    justify-content: center;
  }

  .react-modal-content {
    background: var(--white);
    padding: 3rem;
    position: relative;
    border-radius: 0.24;
    display: flex;
    justify-content: center;
    align-items: center;
    flex-direction: column;
    border-radius: 8px;

    @media (max-width: 550px) {
      padding: 1rem;
  }
  }

  .img-modal{
    width: 400px;
    height: 400px;
    border-radius: 0.25rem;
  }

  .button-modal{
    cursor: pointer;
    border: 0;
    position: absolute;
    bottom: 91%;
    left: 85%;
    background: var(--background);
    color: var(--white);
    padding: 0.5rem;
    border-radius: 0.25rem;
    &:hover {
    filter: brightness(0.7);
  }
  }

`;
