# 📱 Projeto Blog Mobile com .NET MAUI

Este repositório contém um aplicativo mobile de blog desenvolvido com .NET MAUI, que consome dados da [API JSONPlaceholder](https://jsonplaceholder.typicode.com/), uma API REST fake voltada para testes e prototipagem. O app exibe posts, comentários e informações de usuários em uma interface simples e responsiva.

## 🚀 Tecnologias Utilizadas

- [.NET MAUI](https://learn.microsoft.com/dotnet/maui/) — Framework cross-platform da Microsoft
- [JSONPlaceholder API](https://jsonplaceholder.typicode.com/) — API REST gratuita para prototipagem
- C# — Linguagem de programação principal
- MVVM — Padrão de arquitetura usado no projeto
- Refit — Para requisições HTTP
- CommunityToolkit.MVVM — Para facilitar o binding e gestão de estado

## 📦 Funcionalidades

- Listagem de posts com título e conteúdo
- Visualização de detalhes do post com comentários
- Consumo da API pública JSONPlaceholder com tratamento de erros
- Design adaptado para Android e iOS

## 🛠️ Como Executar

1. Clone o repositório:
   ```bash
   git clone https://github.com/seu-usuario/blog-maui-jsonplaceholder.git
   ```

2. Abra o projeto no Visual Studio 2022 ou superior com suporte a .NET MAUI.

3. Restaure os pacotes e compile o projeto.

4. Execute o app no emulador ou dispositivo físico (Android ou iOS).

## 📂 Estrutura do Projeto

```
BlogMaui/
├── Models/             # Representações dos dados da API
├── ViewModels/         # Lógica da interface e estado
├── Views/              # Telas do app
├── Services/           # Comunicação com a API
├── Resources/          # Estilos e imagens
└── App.xaml.cs         # Configuração inicial do app
```

## 🧪 Exemplos da API Utilizada

Algumas rotas consumidas do JSONPlaceholder:

| Endpoint              | Descrição                |
|----------------------|--------------------------|
| `/posts`             | Lista de posts           |
| `/posts/{id}`        | Detalhes de um post      |
| `/comments?postId={id}` | Comentários de um post |
| `/users/{id}`        | Informações do autor     |

## 📸 Capturas de Tela

## 📄 Licença

Este projeto está sob a licença MIT. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.
