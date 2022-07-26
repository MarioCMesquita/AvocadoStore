# Projeto Avocado Store
O objetivo deste projeto era desenvolver algo simples que tivesse algumas das funções básicas de uma aplicação, como Login e Cadastro de Usuários. O Frontend representa uma loja online fictícia com o tema "abacate". Este frontend foi desenvolvido com Angular (HTML, SCSS e Typescript) e se comunica com uma API em C# .Net Core que posteriormente se comunica com um banco de dados MSSQL. Além destas tecnologias também possui geração e autenticação de tokens JWT e a possibilidade de se gerar um Container em Docker para o deploy.


# Sumário
- [Frontend](https://github.com/MarioCMesquita/AvocadoStore#frontend)
- [Backend](https://github.com/MarioCMesquita/AvocadoStore#backend)
- [Database](https://github.com/MarioCMesquita/AvocadoStore#database)

<br><br>
> ## Frontend:

Para rodar o frontend é preciso ter instalado na máquina pelo menos o Node junto ao NPM, com isto, basta abrir o projeto em qualquer IDE de preferência e executar o comando "npm install" seguido por "npm start" para executar o projeto.

Na página principal é possível visualizar informações sobre o tema e também sobre alguns produtos, além de um botão "Entrar" que leva o usuário a tela de Login.
![image](https://user-images.githubusercontent.com/62727390/180668483-0d25526f-f71f-4d79-ad0b-0291f578ac37.png)

Se você utilizar o backup do banco de dados que está na pasta [Database](Database) e estiver com a [API](API) rodando, na tela Login é possível realizar o login utilizando as credenciais **mario.casas** e **mario**.
![image](https://user-images.githubusercontent.com/62727390/180668630-049fd714-d497-4f99-9b0c-502de49e57b6.png)

Após logado é exibida uma tela com a mensagem "Voce está logado!" e um botão "Sair".
![image](https://user-images.githubusercontent.com/62727390/180668738-35a4b606-362e-4e5d-9be2-766b62e8fe21.png)

<br><br>
> ## Backend:

O backend foi criado a partir do Visual Studio, então é recomendado utilizar o mesmo para rodar a API. Com o projeto aberto, é necessário alterar a string de conexão com o banco de dados, no arquivo "appsettings.json" é possível alterar a ConnectionString "AvocadoStore" apontando para o seu banco local.

Além dos endpoints de Login e CRUD de Usuários, também existem outros endpoints, como os de Produtos. Na pasta [Postman](Postman) tem o Environment e também a Collection AvocadoStore, que podem ser importados e utilizados dentro do Postman para testar todos os Endpoints existentes na API.

<br><br>
> ## Database:

Na pasta [Database](Database) há uma cópia do banco de dados AvocadoStore, basta realizar a restauração do mesmo no Microsoft Management Studio para rodar e utilizar o banco. 
