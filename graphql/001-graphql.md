# O que é GraphQL e como trabalha

- [O que é GraphQL?](#O-que-é-GraphQL)

- [Motivos](#Motivos)

- [Comparação](#Comparação)

- [SDL](#SDL)

  - [Definindo tipos](#Definindo-tipos)

## O que é GraphQL

É um novo padrão de API que oferece maior flexibilidade, eficiencia e poder comparado ao REST. Foi desenvolvido pelo facebook e atualmente mantido pela comunidade.

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
  - ! Indica que é um campo obrigatório.
  - Person 1 -> N Post

```
type Post {
    title: String!
    author: Person! --relation
}

type Person {
    name: String!
    age: Int!
    posts: [Post!]!
}
```
