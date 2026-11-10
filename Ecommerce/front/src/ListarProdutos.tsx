import { useEffect, useState } from "react";

function ListarProdutos() {

  //Estados / Variavéis
  //const[localidade, setLocalidade] = useState("");
  //const[logradouro, setLogradouro] = useState("");
  const[produtos, setProdutos] = useState([]);

  //useEffect é utilizado para executar qualquer código
  //no momento em que o componente estiver sendo aberto
/*  useEffect(() => {
    //AXIOS para realizar as requisições    
    fetch("https://viacep.com.br/ws/80020010/json/")
      .then(resposta => {
        return resposta.json();
      })
      .then(dados => {
        setLocalidade(dados.localidade);
        setLogradouro(dados.logradouro);
        console.log(dados)
      });
  }, []); */

  useEffect(() => {
    fetch("http://localhost:5195/api/produto/listar")
    .then(resposta =>{
      return resposta.json();
    })
    .then(produtos =>{
      console.table(produtos);
      setProdutos(produtos);
    })
  })

  return (
    <div>
      <h1>Lista de Produtos</h1>
      <ul>
        {produtos.map((produto : any) => (
          <li>
            {produto.id}
          </li>
        ))
        }
      </ul>
    </div>
  );
}

export default ListarProdutos;

//Mostrar os dados do endereço na página da aplicação
// - Estados

//Realizar a requisição para a sua API
// - Verificar o erro de CORS da API
// -