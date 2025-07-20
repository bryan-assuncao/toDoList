# Gerenciador de Tarefas (Console App em C#)

Este é um projeto simples de um **Gerenciador de Tarefas** desenvolvido em C#. Ele permite que o usuário gerencie uma lista de tarefas diretamente pelo console, com suporte para salvar e carregar os dados de um arquivo de texto.

## Funcionalidades

- Listar tarefas
- Adicionar nova tarefa
- Marcar tarefa como concluída
- Remover tarefa
- Persistência dos dados em arquivo `tasks.txt`

## Estrutura do Projeto

- `TaskItem`: Classe que representa uma tarefa, com propriedades de descrição e status de conclusão.
- `Program`: Contém a lógica principal do aplicativo, incluindo o menu interativo e manipulação das tarefas.

## Como Usar

1. Compile o código com o compilador C# ou no Visual Studio / VS Code.
2. Execute o programa pelo terminal.
3. Navegue pelo menu digitando o número da opção desejada.

## Requisitos

- .NET SDK (versão 6.0 ou superior recomendada)
- Sistema operacional: Windows, Linux ou macOS

## Exemplo de Execução

```
=== GERENCIADOR DE TAREFAS ===
1. Listar tarefas
2. Adicionar tarefa
3. Marcar como concluída
4. Remover tarefa
5. Sair
------------------------------
Escolha uma opção: 
```

## Autor

Bryan Assunção
