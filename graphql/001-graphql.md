# O que é GraphQL e como trabalha

- [O que é GraphQL?](#O-que-é-GraphQL)

- [Motivos](#Motivos)

- [Comparação](#Comparação)

- [SDL](#SDL)

  - [Definindo tipos](#Definindo-tipos)

## O que é GraphQL

É um novo padrão(especificação) de API que oferece maior flexibilidade, eficiencia e poder comparado ao REST. Foi desenvolvido pelo facebook e atualmente mantido pela comunidade.

Permite que o `client` obtenha os dados necessários de uma forma declarativa.

Ao invés de utilizar múltiplos `endpoints` que retornam estruturas de dados fixas, `GraphQL` expõe apenas um `endpoint` e responde somente com as informações que o usúario solicitou.

GraphQL utiliza um sistema de tipos para definir os recursos de uma API, todos os recursos são gravados em um `schema` usando [SDL](https://www.digitalocean.com/community/tutorials/graphql-graphql-sdl).

Esse `schema` também serve como um contrato `client-server` para definir como o `client` irá acessar os dados.

## Motivos

Alguns motivos para o `GraphQL` ser desenvolvido:

- Aumento do uso de mobiles

...

## Comparação

Ao utilizar REST geralmente possuímos uma arquitetura como a seguir:

Multiplus `endpoints` que retornam dados estruturados e dificilmente todos os campos são necessários:

```
/users/<id>

{
    user: {
        id: 123456,
        name: "User 1",
        address: {...},
        birthday: "..."
    }
}
```

```
/users/<id>/posts

{
    posts: [
        {
            id: 1234,
            title: "post 1",
            content: "content 1",
            ....
        },
        {
            id: 4321,
            title: "post 2",
            content: "content 2",
            ....
        }
    ]
}

```

Em GraphQL possúimos somente um `endpoint` e podemos enviar uma única solicitação declarando todos os dados que iremos precisar:

```
query {
    User(id: 123456) {
        name
        posts {
            title
        }
        followers(last: 3) {
            name
        }
    }
}
```

O que nos irá retornar um json com um campo data:

```
{
    data:{
        User: {
            name: "User 1",
            posts: [ { title: "post 1"
                }, { title: "post 2" } ],
            followers: [{name: "Angel"}, {name: "Brad"},
            {name: "Tommy"} ]
        }
    }
}

```

Diminuindo drasticamente o excesso de busca no servidor.

## SDL

- #### Definindo tipos
  - Três tipos de entrada existentes em GraphQL: Query(Consulta), Mutation(Manipulação de dados, create, update, delete) e Subscription(Listener para futuros eventos).
  - ! Indica que é um campo obrigatório.
  - Person 1 -> N Post
  - Enum(possui um conjunto fixo de valores)
  - Interface

```
enum Weekday {
  MONDAY
  TUESDAY
  WEDNESDAY
  THURSDAY
  FRIDAY
  SATURDAY
  SUNDAY
}

interface Node {
  id: ID!
}

type Post implements Node {
    id: ID!
    title: String!
    author: Person! --relation
}

type Person implements Node {
    id: ID!
    name: String!
    age: Int!
    posts: [Post!]!
}

type Query {
    allPersons(last: Int): [Person!]
    allPosts(last: Int): [Post!]
}

type Mutation {
    createPerson(name: String!, age: String!): Person!
    updatePerson(id: ID!, name: String!, age: string!): Person!
    deletePerson(id: ID!): Person!
}

type Subscription {
    newPerson: Person!
}

```

references:

- [GraphQL Server Basics: GraphQL Schemas, TypeDefs & Resolvers Explained](https://www.prisma.io/blog/graphql-server-basics-the-schema-ac5e2950214e)
- [GraphQL Server Basics: The Network Layer](https://www.prisma.io/blog/graphql-server-basics-the-network-layer-51d97d21861)
- [GraphQL Server Basics: Demystifying the info Argument in GraphQL Resolvers](https://www.prisma.io/blog/graphql-server-basics-demystifying-the-info-argument-in-graphql-resolvers-6f26249f613a)

## RESOLVER

Cada campo possui um resolver que nada mais é do que uma função que tem um único objetivo: buscar/montar os dados para o campo correspondente.

Recebe quatro argumentos:

- `obj` O objeto anterior, para o campo RAIZ geralemnte não é utilizado.
- `args` Argumentos fornecidos para o campo na consulta.
- `context` Um valor fornecido a todos os `resolvers` e mantém informações de context importantes, como usuário conectado, acesso a banco...
- `info` Detalhes de `schema` e informações específicas de campo.

## FRAGMENTS

É uma coleção de campos em um tipo específico, ex:

```
type User {
    name: String!
    age: Int!
    email: String!
    street: String!
    zipcode: String!
    city: String!
}

Todas informações relacionadas com o endereço do usuário
fragment addressDetails on User {
  name
  street
  zipcode
  city
}

Podemos usar dessa forma:
{
  allUsers {
    ... addressDetails
  }
}
o que substitui isso:
{
  allUsers {
    name
    street
    zipcode
    city
  }
}

```

## ALIAS

Podemos utiliar um alias para realizar a mesma consulta duas vez em uma unica
requisição: first, second.

```
{
  first: User(id: "1") {
    name
  }
  second: User(id: "2") {
    name
  }
}
```
