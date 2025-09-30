# 🎮 Tetris Stack - Sistema de Fila Circular

## 📋 Descrição do Projeto

O **Tetris Stack** é um projeto educacional desenvolvido pela ByteBros para ensinar conceitos fundamentais de estruturas de dados, especificamente **filas circulares**. O programa simula o sistema de peças futuras do jogo Tetris, onde as peças são organizadas em uma fila FIFO (First In, First Out).

## 🎯 Objetivos Educacionais

- Compreender e implementar **estruturas de dados tipo fila**
- Aprender sobre **fila circular** e suas vantagens
- Praticar **manipulação de arrays** e **structs** em C#
- Desenvolver habilidades de **modularização** e **documentação de código**
- Aplicar **operadores lógicos e condicionais** para controle de fluxo

## ⚙️ Funcionalidades Implementadas

### 🔄 Operações da Fila

- **Enqueue (Inserir)**: Adiciona nova peça ao final da fila
- **Dequeue (Jogar)**: Remove peça da frente da fila
- **Remover Específica**: Remove uma peça específica por ID mantendo a ordem da fila
- **Visualizar**: Exibe estado atual da fila com todas as peças

### 🎲 Sistema de Peças

- **Tipos disponíveis**: I, O, T, L (formas clássicas do Tetris)
- **IDs únicos**: Cada peça recebe um identificador sequencial
- **Geração automática**: Peças são criadas aleatoriamente

### 🖥️ Interface de Usuário

- **Menu interativo** com 5 opções numeradas
- **Feedback visual** com emojis e formatação
- **Validação de entrada** com mensagens de erro claras
- **Layout organizado** com bordas ASCII decorativas
- **Seleção por ID** para remoção específica de peças

## 🏗️ Estrutura do Código

### 📦 Estruturas de Dados

```csharp
/// Representa uma peça do Tetris
public struct Peca
{
    public char tipo;    // Tipo da peça ('I', 'O', 'T', 'L')
    public int id;       // Identificador único
}
```

### 🔧 Componentes Principais

1. **Fila Circular**: Array fixo com índices circulares
2. **Controle de Estado**: Índices de frente e final
3. **Validações**: Verificações de fila vazia/cheia
4. **Interface**: Menu e exibição organizada

## 🚀 Como Executar

### Pré-requisitos

- .NET SDK 6.0 ou superior
- Terminal/Prompt de comando

### Passos de Execução

```bash
# 1. Navegue até o diretório do projeto
cd "d:\AulasFacul\dasfio-novato\TetrisStack"

# 2. Execute o programa
dotnet run
```

## 📖 Conceitos Técnicos Abordados

### 🔄 Fila Circular

- **Vantagem**: Reaproveitamento de espaço no array
- **Implementação**: Uso do operador módulo (%) para índices
- **Eficiência**: Operações O(1) para inserção e remoção

### 🏗️ Arquitetura Modular

- **Separação de responsabilidades**: Cada método tem função específica
- **Encapsulamento**: Atributos privados com métodos públicos
- **Reutilização**: Funções auxiliares para operações comuns

### ✅ Validação e Controle

- **Verificação de limites**: Previne overflow e underflow
- **Tratamento de erros**: Mensagens informativas para o usuário
- **Fluxo controlado**: Switch-case para navegação no menu

## 📝 Requisitos Atendidos

### ✅ Funcionais

- [x] Fila com capacidade fixa (5 peças)
- [x] Operação jogar peça (dequeue)
- [x] Operação inserir peça (enqueue)
- [x] **NOVO**: Operação remover peça específica mantendo ordem
- [x] Visualização do estado da fila
- [x] Geração automática de peças
- [x] IDs únicos para identificação
- [x] Seleção por ID para remoção específica

### ✅ Não Funcionais

- [x] **Usabilidade**: Interface clara e intuitiva
- [x] **Legibilidade**: Código bem estruturado e comentado
- [x] **Documentação**: Comentários explicativos detalhados
- [x] **Modularização**: Funções com responsabilidades específicas
- [x] **Nomes descritivos**: Variáveis e métodos autoexplicativos

## 🎓 Aprendizados Práticos

### 💡 Estruturas de Dados

- Como implementar uma fila usando arrays
- Vantagens da fila circular sobre fila linear
- Operações fundamentais: enqueue, dequeue, isEmpty, isFull
- **NOVO**: Remoção específica com reorganização mantendo ordem

### 🔧 Programação em C#

- Uso de structs para tipos de dados customizados
- Implementação de métodos privados e públicos
- Controle de fluxo com switch-case e operadores lógicos
- **NOVO**: Algoritmos de busca e remoção em arrays circulares

### 🎨 Design de Interface

- Criação de menus interativos em console
- Formatação com caracteres ASCII para visual atrativo
- Feedback adequado para ações do usuário
- **NOVO**: Interface de seleção por ID com validação

## 👨‍💻 Sobre o Desenvolvimento

**Desenvolvido por**: ByteBros  
**Linguagem**: C#  
**Paradigma**: Programação Orientada a Objetos  
**Estrutura de Dados**: Fila Circular  
**Propósito**: Educacional - Ensino de Programação

---

_Este projeto faz parte do currículo de ensino de lógica e programação, demonstrando na prática como estruturas de dados fundamentais são aplicadas em jogos e sistemas reais._
