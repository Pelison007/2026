import { useState } from "react";
import { Produto } from "./models/Produto";

function CadastrarProduto() {
  const [nome, setNome] = useState("");

  function enviarProdutoAPI(e: any){
    e.preventDefault();

    const produto : Produto = {
      nome : nome,
    };

    fetch("http://localhost:5195/api/produto/cadastrar", 
      {
        method : "POST",
        headers : {
          "Content-Type" : "application/json"
        },
        body : JSON.stringify(produto),
      }).then((resposta) => {
        return resposta.json();
      }).then((dados) => {
        console.log(dados);
      });
  }

  function escreverNome(e: any){
    //console.log(e.target.value);]
    setNome(e.target.value);
  }

  return (
    <div>
      <form onSubmit={enviarProdutoAPI}>
        <h1>Cadastrar Produto</h1>
        <div>
          <label>Valor</label>
          <input type="text" onChange={escreverNome} required />
        </div>

        <div>
          <label>Nome</label>
          <input type="text" />
        </div>

        <button type="submit">
          Cadastrar
        </button>
      </form>
    </div>
  );
}

export default CadastrarProduto;
