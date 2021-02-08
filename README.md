_Repositório apenas para estudo_

# Criando arquitetura em camadas com DDD + Injeção de dep. + EF

Instrutor:

- [Eric Andrade](https://medium.com/@ericandrade_24404)

Referências:

- https://medium.com/@ericandrade_24404/parte-01-criando-arquitetura-em-camadas-com-ddd-inje%C3%A7%C3%A3o-de-dep-ef-60b851c88461
- https://medium.com/@ericandrade_24404/parte-02-criando-arquitetura-em-camadas-com-ddd-inje%C3%A7%C3%A3o-de-dep-ef-defac0005667

<br>
<br>
<hr>

## Teórico

### **Todas as camadas**:

**01 - Apresentação / Presentation**

Camada responsável por abranger tudo o que diz respeito a interface de usuário (UI):

- Aplicação Desktop (WinForms)
- Aplicação Web (Angular, React, Vue)
- Aplicação Mobile (Android)

**02 - Serviços / Service**

Toda forma de comunicação remota acontecerá aqui, muito usada em aplicação web, e nem sempre é implementada quando se trata de uma aplicação que consegue e suporta comunicar com a cama Aplicação (a seguir).
Algumas das implementações mais comuns:

- Web API (HTTP)
- SignalR
- WebSockets

**03 - Aplicação / Application**

Camada responsável por fazer a(s) aplicação(s) se comunicar diretamente com o Domínio. Nela são implementados:

- Classes dos Serviços da aplicação
- Interfaces (contratos)
- DataTransferObjects (DTO)
- AutoMapper

**04 - Domínio / Domain**

Aqui é onde o DDD acontece! E nela nós temos:

- Entidades
- Interfaces (contratos) para Serviços e Repositórios
- Classes dos Serviços do domínio
- Validações (se necessário)

**05 - Infraestrutura / Infrastructure**

Camada que da suporte as demais camadas. Que atualmente é dividida por duas camadas com seus respectivos conteúdos:

**Data:**

- Repositórios
- DataModel (Mapeamento)
- Persistência de dados

**CrossCutting** _(camada que atravessa todas as outras, portando possui referência de todas elas)_:

- IoC (Inversão de controle)

<br>
<br>

### **Comunição entre camadas**

**01 - Apresentação**: recebe referência de “_Aplicação_”, “_Domínio_” e da “_CrossCutting_” (em “_Infraestrutura_”), em casos de aplicações front-end a comunicação é feita unicamente com a cama de “_Serviços_” (API, por exemplo).

**02 - Serviços**: recebe referência de “_Aplicação_”.

**03 - Aplicação**: recebe referência de “_Domínio_”.

**04 - Domínio**: embora seja a camada que mais da suporte às outras camadas, ela é a única que não recebe referência de ninguém, logo ela não depende de nada! Porem ela se comunica de forma _“indireta”_ com a camada _Data (Infraestrutura)_, e isso só é possível graças à interfaces (sim, aquela que você assina o nome dos métodos, coisa e tal).

**05 - Infraestrutura**: por último, e não menos importante, temos esta camada que (como dito anteriormente) possui “subcamadas” _Data_ e _CrossCutting_, onde recebem referência do domínio.

- **_Data_**: tem o objetivo de persistir dados ou qualquer outra comunicação externa.

- **_CrossCutting (Ioc)_**: é onde registrados todas as interfaces e classes existente no projeto, para que o mesmo seja responsável por instanciar a árvore de dependências de toda a arquitetura.

<br>
<br>
<hr>

## Prático

- **Domain**:

  Domínio da aplicação:

  Diretórios:

  - **Entities**: Entidades do modelo

  - **Interfaces**: as interfaces deste diretório, são as mesmas que serão implementadas nas classes `Services` desta camada (**Domain**) e nas classes `Repositpry` da camada Infra.**Data**
    - Repositories
    - Services

- **Application**:

  Se comunicará diretamente com o Domínio

  Referências:

  - `Domain`

  Pacotes:

  - `AutoMapper.Extensions.Microsoft.DependencyInjection`

  Diretórios:

  - **DTO**: São classes muito parecidas com as `Entities` do `Domain`, e geralmente são usadas para retornar à sua aplicação (`Presentation`) informações bem peculiares a ela, então é comum você vê classes `Entity` e `DTO` com mesmos nomes (ou conteúdos), assim: `Dish.cs` e `DishDTO.cs`.

  - **Interfaces**: estas interfaces são para as classes `Services` desta camada

  - **Services**: estas são as classes de serviços desta camada que implementam as interfaces que criamos anteriormente.

  Arquivos:

  - **MappingEntidade.cs**: Esta classe serve para que registremos no `AutoMapper` as classes `Entity` e `DTO`, para que seja possível realizar a conversão de uma para a outra.

- **Infra**:

  Já deixamos prontas as camadas Domínio e Aplicação, agora iremos dar início a preparação da camada Infra, onde ela se divide em IoC e Data.

  - Infra.**Data**:

    Esta subcamada é praticamente o coração da camada Data, é onde persistiremos todas as informações, onde comunicaremos com o banco de dados propriamente dito.

    Referências:

    - Domain

    Pacotes:

    - `Microsoft.EntityFrameworkCore`
    - `Microsoft.EntityFrameworkCore.Relational`
    - `Microsoft.EntityFrameworkCore.Design`
    - `Microsoft.EntityFrameworkCore.Tools`
    - ~~`Pomelo.EntityFrameworkCore.MySql`~~
    - `Npgsql.EntityFrameworkCore.PostgreSQL`

    Diretórios:

    - Data.**Contexts**: Classe que herdamos o `DbContext` do `EntityFrameWork`, responsável por abrir transações e commita-las após término da persistência.

      - `Context.cs`

    - Data.**Mapeamentos**: Classes onde fazemos o mapeamento das entidades como tabelas do banco de dados, onde a nome da tabela é a própria entidade e as colunas são as propriedades desta entidade.

    - Data.**Repositories**: estes serão os repositórios, onde são realizadas as consultas e inserções do banco de dados, tudo isso usando o `Context`. É aqui são implementadas as interfaces de repositórios criadas em `Domain`.

  - Infra.**IoC**:

    Esta subcamada é responsável por ter referências de todas as demais camadas (exceto serviços), pois é ela quem coleta toda a.

    Referencias:

    - Domain
    - Application
    - Infra.Data

    Pacotes:

    - `Microsoft.Extensions.DependencyInjection`

    Implmenração:

    - DependencyInjector.cs

- **Services (API)**

  Através desta camada que as aplicações se comunicarão com a nossa arquitetura, para que possamos buscar ou persistir informações

  Referências:

  - Application
  - Infra.IoC

  Pacotes:

  - ~~`Pomelo.EntityFrameworkCore.MySql`~~
  - `Npgsql.EntityFrameworkCore.PostgreSQL`: Para que a API reconheça o futuro contexto que criaremos para conexão ao banco ~~MySQL~~ PostgreSQL.
  - `Microsoft.Extensions.DependencyInjection`: Para que possamos realizarmos a injeção de tudo o que já fizemos na nossa API.

  Diretórios:

  - Controllers

- **Presentation**

  Front-end React, Angular, etc ...
