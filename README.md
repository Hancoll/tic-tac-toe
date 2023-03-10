# tic-tac-toe API

## Lobby

### CreateLobby

```js
POST /api/lobby/create
```

#### CreateLobby Response

```js
"a53a3033-c2f3-4bbf-9ce1-8e9052309694"
```

### JoinLobby

Подключение к лобби происходит через SignalR.

Url хаба:

```
/lobbyHub
```
Имя метода

```
JoinLobby
```

Аргументы:

```
Guid lobbyId
```

Пример json запроса:

```js
{
    "arguments": ["a53a3033-c2f3-4bbf-9ce1-8e9052309694"],
    "target":"JoinLobby",
    "type":1
}

```

## Game

### MakeMove

Сделать ход.

Url хаба:

```
/lobbyHub
```

Имя метода

```
MakeMove
```

Аргументы:

```
Guid lobbyId
byte row
byte column
```

### RecieveField

Получение информации об игровом поле.

Url хаба:

```
/lobbyHub
```

Имя метода

```
ReceiveField
```

#### ReceiveField Response

```js
{
    "type":1,
    "target":"ReceiveField",
    "arguments":[[[1,1,1],[0,2,0],[2,0,0]]]
}
```

0 - Пустые ячейки, 1 - Крестики, 2 - Нолики.

### GameOver

Получить победителя.

Url хаба:

```
/lobbyHub
```

Имя метода

```
GameOver
```

#### GameOver Response

```js
{
    "type":1,
    "target":"ReceiveField",
    "arguments":[1]
}
```

1 - Крестики, 2 - Нолики.

## Exceptions

Получить исключения.

Url хаба:

```
/lobbyHub
```

Имя метода

```
Exceptions
```

#### Exceptions Response

```js
{
    "type":1,
    "target":"Exception",
    "arguments":["Lobby not found."]
}
```