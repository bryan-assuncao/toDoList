Gerenciador de Tarefas em C#
Este é um simples gerenciador de tarefas em console desenvolvido em C#. Ele permite que você adicione, liste, marque como concluídas e remova tarefas, além de persistir esses dados em um arquivo de texto para que suas tarefas não sejam perdidas ao fechar o programa.

Funcionalidades
Adicionar Tarefa: Inclua novas tarefas na sua lista.

Listar Tarefas: Visualize todas as tarefas, indicando quais estão pendentes e quais foram concluídas.

Marcar como Concluída: Altere o status de uma tarefa para "concluída".

Remover Tarefa: Exclua tarefas da sua lista.

Persistência de Dados: Suas tarefas são salvas automaticamente em um arquivo de texto (tasks.txt) e carregadas ao iniciar o programa.

Como Usar
Pré-requisitos
Você precisará ter o .NET SDK instalado em sua máquina. Você pode baixá-lo do site oficial da Microsoft.

Rodando o Projeto
Clone ou baixe este repositório para o seu computador.

Abra um terminal ou prompt de comando na pasta raiz do projeto (onde o arquivo Program.cs está localizado).

Compile o projeto usando o comando:

Bash

dotnet build
Execute o programa:

Bash

dotnet run
Interagindo com o Gerenciador
Ao executar o programa, você verá um menu de opções no console:

=== GERENCIADOR DE TAREFAS ===
1. Listar tarefas
2. Adicionar tarefa
3. Marcar como concluída
4. Remover tarefa
5. Sair
------------------------------
Escolha uma opção:
Digite o número correspondente à opção desejada e pressione Enter.

1. Listar tarefas: Exibe todas as tarefas atuais.

2. Adicionar tarefa: Solicita uma descrição para a nova tarefa.

3. Marcar como concluída: Pede o número da tarefa na lista para marcá-la como concluída.

4. Remover tarefa: Pede o número da tarefa na lista para removê-la.

5. Sair: Salva todas as tarefas e fecha o programa.

