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

  - Domain

  Pacotes:

  - AutoMapper.Extensions.Microsoft.DependencyInjection

  Diretórios:

  - **DTO**: São classes muito parecidas com as `Entities` do `Domain`, e geralmente são usadas para retornar à sua aplicação (`Presentation`) informações bem peculiares a ela, então é comum você vê classes `Entity` e `DTO` com mesmos nomes (ou conteúdos), assim: `Dish.cs` e `DishDTO.cs`.

  - **Interfaces**: estas interfaces são para as classes `Services` desta camada

  - **Services**: estas são as classes de serviços desta camada que implementam as interfaces que criamos anteriormente.

- **Infra**:

  Já deixamos prontas as camadas Domínio e Aplicação, agora iremos dar início a preparação da camada Infra, onde ela se divide em IoC e Data.

  - Infra.**Data**:

    Esta subcamada é praticamente o coração da camada Data, é onde persistiremos todas as informações, onde comunicaremos com o banco de dados propriamente dito.

    Referências:

    - Domain

    Pacotes:

    - Microsoft.EntityFrameworkCore
    - Microsoft.EntityFrameworkCore.Relational
    - Microsoft.EntityFrameworkCore.Design
    - Microsoft.EntityFrameworkCore.Tools
    - ~~Pomelo.EntityFrameworkCore.MySql~~
    - Npgsql.EntityFrameworkCore.PostgreSQL

    Diretórios:

    - Data.**Contexts**: Classe que herdamos o `DbContext` do `EntityFrameWork`, responsável por abrir transações e commita-las após término da persistência.

      - `Context.cs`

    - Data.**Repositories**: estes serão os repositórios, onde são realizadas as consultas e inserções do banco de dados, tudo isso usando o `Context`. É aqui são implementadas as interfaces de repositórios criadas em `Domain`.

  - Infra.**IoC**:

    Esta subcamada é responsável por ter referências de todas as demais camadas (exceto serviços), pois é ela quem coleta toda a.

    Referencias:

    - Domain
    - Application
    - Infra.Data

    Pacotes:

    - Microsoft.Extensions.DependencyInjection

- **Services**

  Através desta camada que as aplicações se comunicarão com a nossa arquitetura, para que possamos buscar ou persistir informações

  Referências:

  - Application
  - Infra.IoC

  Pacotes:

  - ~~Pomelo.EntityFrameworkCore.MySql~~
  - Npgsql.EntityFrameworkCore.PostgreSQL

    Para que a API reconheça o futuro contexto que criaremos para conexão ao banco ~~MySQL~~ PostgreSQL.

  - Microsoft.Extensions.DependencyInjection:

    Para que possamos realizarmos a injeção de tudo o que já fizemos na nossa API.
