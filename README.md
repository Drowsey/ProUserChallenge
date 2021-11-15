## ProUser - Bemol Digital

Login e criação de contas de usuário para acesso a canais de comunicação.

#### Pré-requisitos

É necessário instalar antes:

- [VSCode](https://code.visualstudio.com/download) (recomendado) para editar o código, mas pode ser usado qualquer editor.

- [Git](https://git-scm.com) para clonar o repositório para sua máquina.

- [.NET Core](https://dotnet.microsoft.com/download) para rodar o backend.

- [Node.js](https://nodejs.org/en/download/) para a instalação do Angular CLI

- [MongoDB ](https://www.mongodb.com/try/download/community)- Banco de dados usado nesse projeto



#### Ativando o backend

Após ter o MongoDb Conectado ao localhost pela porta padrão(localhost:27017), pelo git bash, navegue até a pasta a receber o projeto e insira o comando: 

```bash
$ git clone https://github.com/Drowsey/ProUserChallenge
```

Para acessar a pasta da API

```bash
$ cd back/ProUser.API
```

Necessário instalar as dependências necessárias

```bash
$ dotnet restore
```

Execute a api

```bash
$ dotnet run
```



#### Ativando o frontend

Considerando que ainda está na pasta ProUser.API, digite o seguinte comando para ir para a pasta ProUser-App

```bash
$ cd ../../front/ProUser-app
```

Instale o Angular CLI

```bash
$ npm install -g @angular/cli
```

Execute o app

```bash
$ ng start
```

