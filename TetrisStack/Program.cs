using System;

namespace TetrisStack
{
    /// <summary>
    /// Estrutura que representa uma peça do jogo Tetris Stack
    /// Contém o tipo da peça (formato) e um identificador único
    /// </summary>
    public struct Peca
    {
        /// <summary>
        /// Tipo da peça representado por um caractere ('I', 'O', 'T', 'L')
        /// Cada letra representa uma forma diferente de peça do Tetris
        /// </summary>
        public char tipo;
        
        /// <summary>
        /// Identificador único da peça (número sequencial de criação)
        /// </summary>
        public int id;

        /// <summary>
        /// Construtor da estrutura Peca
        /// </summary>
        /// <param name="tipoPeca">Tipo da peça ('I', 'O', 'T', 'L')</param>
        /// <param name="idPeca">Identificador único da peça</param>
        public Peca(char tipoPeca, int idPeca)
        {
            tipo = tipoPeca;
            id = idPeca;
        }
    }

    /// <summary>
    /// Classe principal que implementa o sistema de fila circular para o Tetris Stack
    /// Gerencia as peças futuras do jogo usando uma estrutura de fila FIFO
    /// </summary>
    public class TetrisStack
    {
        // === ATRIBUTOS PRIVADOS ===
        
        /// <summary>
        /// Array que implementa a fila circular de peças
        /// </summary>
        private Peca[] filaPecas;
        
        /// <summary>
        /// Capacidade máxima da fila (número fixo de elementos)
        /// </summary>
        private int capacidadeMaxima;
        
        /// <summary>
        /// Índice da frente da fila (próxima peça a ser jogada)
        /// </summary>
        private int indiceFrente;
        
        /// <summary>
        /// Índice do final da fila (onde será inserida a próxima peça)
        /// </summary>
        private int indiceFinal;
        
        /// <summary>
        /// Quantidade atual de peças na fila
        /// </summary>
        private int quantidadePecas;
        
        /// <summary>
        /// Contador para gerar IDs únicos para as peças
        /// </summary>
        private int proximoId;
        
        /// <summary>
        /// Array com os tipos de peças disponíveis no Tetris
        /// </summary>
        private char[] tiposPecasDisponiveis = { 'I', 'O', 'T', 'L' };
        
        /// <summary>
        /// Gerador de números aleatórios para criar peças variadas
        /// </summary>
        private Random geradorAleatorio;

        
        // === CONSTRUTOR ===
        
        /// <summary>
        /// Construtor da classe TetrisStack
        /// Inicializa a fila circular com capacidade fixa e gera peças iniciais
        /// </summary>
        /// <param name="capacidade">Capacidade máxima da fila (padrão: 5)</param>
        public TetrisStack(int capacidade = 5)
        {
            // Inicialização dos atributos da fila circular
            capacidadeMaxima = capacidade;
            filaPecas = new Peca[capacidadeMaxima];
            indiceFrente = 0;
            indiceFinal = 0;
            quantidadePecas = 0;
            proximoId = 1;
            geradorAleatorio = new Random();
            
            // Preenche a fila com peças iniciais
            InicializarFilaComPecas();
        }

        // === MÉTODOS PRIVADOS (FUNÇÕES AUXILIARES) ===
        
        /// <summary>
        /// Gera uma nova peça com tipo aleatório e ID único
        /// Função responsável pela criação automática de peças
        /// </summary>
        /// <returns>Nova peça gerada</returns>
        private Peca GerarNovaPeca()
        {
            // Seleciona um tipo aleatório do array de tipos disponíveis
            int indiceAleatorio = geradorAleatorio.Next(tiposPecasDisponiveis.Length);
            char tipoSelecionado = tiposPecasDisponiveis[indiceAleatorio];
            
            // Cria e retorna a nova peça com ID sequencial
            return new Peca(tipoSelecionado, proximoId++);
        }

        /// <summary>
        /// Inicializa a fila preenchendo-a com peças até a capacidade máxima
        /// Garante que o jogo comece com peças disponíveis para jogar
        /// </summary>
        private void InicializarFilaComPecas()
        {
            Console.WriteLine("═══════════════════════════════════════");
            Console.WriteLine("    INICIALIZANDO FILA DE PEÇAS");
            Console.WriteLine("═══════════════════════════════════════");
            
            // Adiciona peças até atingir a capacidade máxima
            for (int i = 0; i < capacidadeMaxima; i++)
            {
                Peca novaPeca = GerarNovaPeca();
                filaPecas[indiceFinal] = novaPeca;
                indiceFinal = (indiceFinal + 1) % capacidadeMaxima; // Movimento circular
                quantidadePecas++;
                
                Console.WriteLine($"  ➤ Peça {novaPeca.tipo} (ID: {novaPeca.id}) adicionada");
            }
            
            Console.WriteLine($"\n✓ Fila inicializada com {quantidadePecas} peças");
            Console.WriteLine("═══════════════════════════════════════\n");
        }

        /// <summary>
        /// Verifica se a fila está vazia
        /// </summary>
        /// <returns>True se a fila estiver vazia, False caso contrário</returns>
        private bool FilaEstaVazia()
        {
            return quantidadePecas == 0;
        }

        /// <summary>
        /// Verifica se a fila está cheia
        /// </summary>
        /// <returns>True se a fila estiver cheia, False caso contrário</returns>
        private bool FilaEstaCheia()
        {
            return quantidadePecas == capacidadeMaxima;
        }

        
        // === MÉTODOS PÚBLICOS (OPERAÇÕES DA FILA) ===
        
        /// <summary>
        /// Remove e retorna a peça da frente da fila (operação DEQUEUE)
        /// Simula o ato de "jogar" uma peça no Tetris
        /// </summary>
        /// <returns>True se a operação foi bem-sucedida, False se a fila estava vazia</returns>
        public bool JogarPeca()
        {
            // Validação: verifica se há peças para jogar
            if (FilaEstaVazia())
            {
                Console.WriteLine("❌ ERRO: Não há peças na fila para jogar!");
                Console.WriteLine("   Adicione novas peças antes de tentar jogar.");
                return false;
            }

            // Remove a peça da frente da fila
            Peca pecaJogada = filaPecas[indiceFrente];
            indiceFrente = (indiceFrente + 1) % capacidadeMaxima; // Movimento circular
            quantidadePecas--;

            // Exibe informações da peça jogada
            Console.WriteLine("🎮 PEÇA JOGADA COM SUCESSO!");
            Console.WriteLine($"   ➤ Tipo: {pecaJogada.tipo}");
            Console.WriteLine($"   ➤ ID: {pecaJogada.id}");
            
            // Adiciona automaticamente uma nova peça para manter o fluxo do jogo
            if (!FilaEstaCheia())
            {
                AdicionarNovaPecaAutomaticamente();
            }
            
            return true;
        }

        /// <summary>
        /// Adiciona uma nova peça ao final da fila (operação ENQUEUE)
        /// Permite ao jogador inserir novas peças na fila
        /// </summary>
        /// <returns>True se a operação foi bem-sucedida, False se a fila estava cheia</returns>
        public bool InserirNovaPeca()
        {
            // Validação: verifica se há espaço na fila
            if (FilaEstaCheia())
            {
                Console.WriteLine("❌ ERRO: Fila está cheia!");
                Console.WriteLine($"   Capacidade máxima: {capacidadeMaxima} peças");
                Console.WriteLine("   Jogue algumas peças antes de adicionar novas.");
                return false;
            }

            // Gera e adiciona nova peça
            Peca novaPeca = GerarNovaPeca();
            filaPecas[indiceFinal] = novaPeca;
            indiceFinal = (indiceFinal + 1) % capacidadeMaxima; // Movimento circular
            quantidadePecas++;

            // Confirma a inserção
            Console.WriteLine("✅ NOVA PEÇA ADICIONADA!");
            Console.WriteLine($"   ➤ Tipo: {novaPeca.tipo}");
            Console.WriteLine($"   ➤ ID: {novaPeca.id}");
            Console.WriteLine($"   ➤ Posição na fila: {quantidadePecas}");
            
            return true;
        }

        /// <summary>
        /// Adiciona automaticamente uma nova peça (usado após jogar uma peça)
        /// Mantém o fluxo contínuo do jogo
        /// </summary>
        private void AdicionarNovaPecaAutomaticamente()
        {
            Peca novaPeca = GerarNovaPeca();
            filaPecas[indiceFinal] = novaPeca;
            indiceFinal = (indiceFinal + 1) % capacidadeMaxima;
            quantidadePecas++;
            
            Console.WriteLine($"🔄 Nova peça gerada automaticamente: {novaPeca.tipo} (ID: {novaPeca.id})");
        }

        /// <summary>
        /// Remove uma peça específica da fila mantendo a ordem das demais peças
        /// Permite remover uma peça por ID ou posição na fila
        /// </summary>
        /// <returns>True se a remoção foi bem-sucedida, False caso contrário</returns>
        public bool RemoverPecaEspecifica()
        {
            // Validação: verifica se há peças na fila
            if (FilaEstaVazia())
            {
                Console.WriteLine("❌ ERRO: Não há peças na fila para remover!");
                return false;
            }

            // Exibe as peças disponíveis
            ExibirPecasParaRemocao();
            
            Console.Write("\n🎯 Digite o ID da peça que deseja remover: ");
            string entrada = Console.ReadLine();
            
            // Valida a entrada do usuário
            if (!int.TryParse(entrada, out int idParaRemover))
            {
                Console.WriteLine("❌ ERRO: Digite um número válido!");
                return false;
            }

            // Procura a peça com o ID especificado
            int posicaoParaRemover = -1;
            int indiceAtual = indiceFrente;
            
            for (int i = 0; i < quantidadePecas; i++)
            {
                if (filaPecas[indiceAtual].id == idParaRemover)
                {
                    posicaoParaRemover = i;
                    break;
                }
                indiceAtual = (indiceAtual + 1) % capacidadeMaxima;
            }

            // Verifica se a peça foi encontrada
            if (posicaoParaRemover == -1)
            {
                Console.WriteLine($"❌ ERRO: Peça com ID {idParaRemover} não encontrada na fila!");
                return false;
            }

            // Executa a remoção
            Peca pecaRemovida = RemoverPecaNaPosicao(posicaoParaRemover);
            
            // Confirma a remoção
            Console.WriteLine("🗑️  PEÇA REMOVIDA COM SUCESSO!");
            Console.WriteLine($"   ➤ Tipo: {pecaRemovida.tipo}");
            Console.WriteLine($"   ➤ ID: {pecaRemovida.id}");
            Console.WriteLine($"   ➤ Posição removida: {posicaoParaRemover + 1}");
            
            return true;
        }

        /// <summary>
        /// Exibe as peças disponíveis para remoção de forma organizada
        /// </summary>
        private void ExibirPecasParaRemocao()
        {
            Console.WriteLine("\n┌─────────────────────────────────────────┐");
            Console.WriteLine("│         PEÇAS DISPONÍVEIS               │");
            Console.WriteLine("├─────────────────────────────────────────┤");
            
            int indiceAtual = indiceFrente;
            for (int posicao = 1; posicao <= quantidadePecas; posicao++)
            {
                Peca pecaAtual = filaPecas[indiceAtual];
                string marcador = (posicao == 1) ? "👉" : "  ";
                
                Console.WriteLine($"│ {marcador} {posicao,2}. Peça {pecaAtual.tipo} (ID: {pecaAtual.id,3})       │");
                indiceAtual = (indiceAtual + 1) % capacidadeMaxima;
            }
            
            Console.WriteLine("└─────────────────────────────────────────┘");
        }

        /// <summary>
        /// Remove a peça na posição especificada e reorganiza a fila mantendo a ordem
        /// Implementa o algoritmo de remoção com deslocamento de elementos
        /// </summary>
        /// <param name="posicao">Posição da peça a ser removida (0-indexada)</param>
        /// <returns>A peça que foi removida</returns>
        private Peca RemoverPecaNaPosicao(int posicao)
        {
            // Calcula o índice real da peça a ser removida
            int indiceParaRemover = (indiceFrente + posicao) % capacidadeMaxima;
            Peca pecaRemovida = filaPecas[indiceParaRemover];

            // Desloca todas as peças após a posição removida para preencher o espaço
            for (int i = posicao; i < quantidadePecas - 1; i++)
            {
                int indiceAtual = (indiceFrente + i) % capacidadeMaxima;
                int proximoIndice = (indiceFrente + i + 1) % capacidadeMaxima;
                
                // Move a próxima peça para a posição atual
                filaPecas[indiceAtual] = filaPecas[proximoIndice];
            }

            // Atualiza os ponteiros da fila
            quantidadePecas--;
            indiceFinal = (indiceFinal - 1 + capacidadeMaxima) % capacidadeMaxima;

            return pecaRemovida;
        }

        
        /// <summary>
        /// Exibe o estado atual da fila de forma organizada e clara
        /// Mostra todas as peças da frente para o final da fila
        /// </summary>
        public void ExibirEstadoDaFila()
        {
            Console.WriteLine("\n╔═══════════════════════════════════════╗");
            Console.WriteLine("║           ESTADO DA FILA              ║");
            Console.WriteLine("╠═══════════════════════════════════════╣");
            
            // Exibe informações gerais da fila
            Console.WriteLine($"║ Peças na fila: {quantidadePecas,2}/{capacidadeMaxima,-2}                 ║");
            Console.WriteLine($"║ Próximo ID: {proximoId,7}                    ║");
            
            // Verifica se a fila está vazia
            if (FilaEstaVazia())
            {
                Console.WriteLine("║                                       ║");
                Console.WriteLine("║          🚫 FILA VAZIA                ║");
                Console.WriteLine("║     Adicione peças para começar!      ║");
                Console.WriteLine("╚═══════════════════════════════════════╝\n");
                return;
            }

            Console.WriteLine("╠═══════════════════════════════════════╣");
            Console.WriteLine("║ PEÇAS (da frente → final):            ║");
            Console.WriteLine("╠═══════════════════════════════════════╣");
            
            // Percorre a fila circular do início ao fim
            int indiceAtual = indiceFrente;
            for (int posicao = 1; posicao <= quantidadePecas; posicao++)
            {
                Peca pecaAtual = filaPecas[indiceAtual];
                string marcador = (posicao == 1) ? "👉" : "  "; // Marca a próxima peça
                
                Console.WriteLine($"║ {marcador} {posicao,2}. Peça {pecaAtual.tipo} (ID: {pecaAtual.id,3})          ║");
                
                // Move para o próximo índice na fila circular
                indiceAtual = (indiceAtual + 1) % capacidadeMaxima;
            }
            
            Console.WriteLine("╚═══════════════════════════════════════╝\n");
        }

        // === MÉTODO PRINCIPAL DO PROGRAMA ===
        
        /// <summary>
        /// Executa o loop principal do jogo com menu interativo
        /// Controla o fluxo de execução e interação com o usuário
        /// </summary>
        public void ExecutarJogo()
        {
            // Cabeçalho inicial do jogo
            Console.Clear();
            ExibirCabecalhoJogo();
            
            // Exibe estado inicial da fila
            ExibirEstadoDaFila();
            
            // Loop principal do menu
            bool jogoAtivo = true;
            while (jogoAtivo)
            {
                // Exibe opções do menu
                ExibirMenuPrincipal();
                
                // Lê a escolha do usuário
                string opcaoEscolhida = Console.ReadLine();
                
                // Processa a opção escolhida
                jogoAtivo = ProcessarOpcaoMenu(opcaoEscolhida);
                
                // Pausa para o usuário ler as informações
                if (jogoAtivo)
                {
                    Console.WriteLine("\n⏸️  Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        /// <summary>
        /// Exibe o cabeçalho decorativo do jogo
        /// </summary>
        private void ExibirCabecalhoJogo()
        {
            Console.WriteLine("╔═══════════════════════════════════════════════════╗");
            Console.WriteLine("║                                                   ║");
            Console.WriteLine("║            🎮 TETRIS STACK 🎮                     ║");
            Console.WriteLine("║                                                   ║");
            Console.WriteLine("║          Desenvolvido por ByteBros                ║");
            Console.WriteLine("║     Sistema de Fila Circular para Peças          ║");
            Console.WriteLine("║                                                   ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════╝\n");
        }

        
        /// <summary>
        /// Exibe o menu principal com as opções disponíveis
        /// Interface simples e clara para o usuário
        /// </summary>
        private void ExibirMenuPrincipal()
        {
            Console.WriteLine("┌─────────────────────────────────────────┐");
            Console.WriteLine("│              MENU PRINCIPAL             │");
            Console.WriteLine("├─────────────────────────────────────────┤");
            Console.WriteLine("│                                         │");
            Console.WriteLine("│  1️⃣  Visualizar fila atual              │");
            Console.WriteLine("│  2️⃣  Jogar peça (remover da frente)     │");
            Console.WriteLine("│  3️⃣  Inserir nova peça                  │");
            Console.WriteLine("│  4️⃣  Remover peça específica            │");
            Console.WriteLine("│  5️⃣  Sair do jogo                       │");
            Console.WriteLine("│                                         │");
            Console.WriteLine("└─────────────────────────────────────────┘");
            Console.Write("\n🎯 Digite sua escolha (1-5): ");
        }

        /// <summary>
        /// Processa a opção escolhida pelo usuário no menu
        /// Implementa a lógica de controle de fluxo do programa
        /// </summary>
        /// <param name="opcao">Opção digitada pelo usuário</param>
        /// <returns>True se o jogo deve continuar, False para sair</returns>
        private bool ProcessarOpcaoMenu(string opcao)
        {
            Console.WriteLine(); // Linha em branco para organização
            
            // Utiliza operadores condicionais para processar cada opção
            switch (opcao)
            {
                case "1":
                    // Opção 1: Visualizar estado da fila
                    ExibirEstadoDaFila();
                    break;
                    
                case "2":
                    // Opção 2: Jogar uma peça (operação dequeue)
                    Console.WriteLine("🎮 JOGANDO PEÇA...\n");
                    bool sucessoJogar = JogarPeca();
                    
                    // Exibe estado atualizado após jogar
                    if (sucessoJogar)
                    {
                        Console.WriteLine();
                        ExibirEstadoDaFila();
                    }
                    break;
                    
                case "3":
                    // Opção 3: Inserir nova peça (operação enqueue)
                    Console.WriteLine("➕ INSERINDO NOVA PEÇA...\n");
                    bool sucessoInserir = InserirNovaPeca();
                    
                    // Exibe estado atualizado após inserir
                    if (sucessoInserir)
                    {
                        Console.WriteLine();
                        ExibirEstadoDaFila();
                    }
                    break;
                    
                case "4":
                    // Opção 4: Remover peça específica
                    Console.WriteLine("🗑️  REMOVENDO PEÇA ESPECÍFICA...\n");
                    bool sucessoRemover = RemoverPecaEspecifica();
                    
                    // Exibe estado atualizado após remover
                    if (sucessoRemover)
                    {
                        Console.WriteLine();
                        ExibirEstadoDaFila();
                    }
                    break;
                    
                case "5":
                    // Opção 5: Sair do jogo
                    ExibirMensagemDespedida();
                    return false; // Encerra o loop do jogo
                    
                default:
                    // Opção inválida: exibe mensagem de erro
                    Console.WriteLine("❌ OPÇÃO INVÁLIDA!");
                    Console.WriteLine("   Por favor, digite um número entre 1 e 5.");
                    break;
            }
            
            return true; // Continua o jogo para todas as opções exceto sair
        }

        /// <summary>
        /// Exibe mensagem de despedida ao sair do jogo
        /// </summary>
        private void ExibirMensagemDespedida()
        {
            Console.WriteLine("╔═══════════════════════════════════════════════════╗");
            Console.WriteLine("║                                                   ║");
            Console.WriteLine("║            👋 OBRIGADO POR JOGAR!                 ║");
            Console.WriteLine("║                                                   ║");
            Console.WriteLine("║              TETRIS STACK - ByteBros              ║");
            Console.WriteLine("║         Aprendendo programação com diversão!     ║");
            Console.WriteLine("║                                                   ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════╝");
        }

        // === MÉTODO MAIN (PONTO DE ENTRADA DO PROGRAMA) ===
        
        /// <summary>
        /// Método principal que inicia a execução do programa
        /// Cria uma instância do jogo e executa o loop principal
        /// </summary>
        /// <param name="args">Argumentos da linha de comando (não utilizados)</param>
        static void Main(string[] args)
        {
            // Cria uma nova instância do jogo com capacidade padrão (5 peças)
            TetrisStack jogo = new TetrisStack();
            
            // Inicia a execução do jogo
            jogo.ExecutarJogo();
        }
    }
}