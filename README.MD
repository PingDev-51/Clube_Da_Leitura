<div align="center">

# 📚 Clube da Leitura

### Sistema de gerenciamento de empréstimos de revistas em **ASP.NET MVC com POO**
Controle de caixas, revistas, amigos e empréstimos com separação de responsabilidades e regras de negócio reais.

---

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![ASP.NET MVC](https://img.shields.io/badge/ASP.NET-MVC-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Bootstrap](https://img.shields.io/badge/Bootstrap-7952B3?style=for-the-badge&logo=bootstrap&logoColor=white)
![OOP](https://img.shields.io/badge/Paradigm-OOP-blue?style=for-the-badge)
![Status](https://img.shields.io/badge/Status-Concluído-brightgreen?style=for-the-badge)

</div>

---

# 📌 Sobre o Projeto

O **Clube da Leitura** foi desenvolvido com foco em:

- Organização em camadas (MVC)
- Separação de responsabilidades
- Regras de negócio reais
- Encapsulamento
- Comunicação entre objetos
- Estrutura limpa e legível

A aplicação permite cadastrar revistas organizadas em caixas, gerenciar os amigos do clube e controlar todos os empréstimos realizados, incluindo prazos e devoluções, por meio de uma interface web responsiva.

---

# ✅ Funcionalidades

## 📦 Caixas

- Cadastro de caixas
- Visualização, edição e exclusão
- Definição do prazo de empréstimo por caixa
- Associação com revistas

### Regras

- Etiqueta obrigatória e única (máx. 50 caracteres)
- Cor obrigatória (paleta ou hexadecimal)
- Dias de empréstimo obrigatórios (padrão: 7)
- Não é permitido excluir uma caixa com revistas vinculadas

---

## 📰 Revistas

- Cadastro de revistas
- Visualização, edição e exclusão
- Exibição do status atual (Disponível / Emprestada / Reservada)
- Associação com caixas

### Regras

- Título obrigatório (2–100 caracteres)
- Número da edição obrigatório (número positivo)
- Ano de publicação obrigatório (data válida)
- Caixa obrigatória
- Não pode haver duas revistas com o mesmo título e edição

---

## 👥 Amigos

- Cadastro de amigos
- Visualização, edição e exclusão
- Visualização dos empréstimos de um amigo específico

### Regras

- Nome obrigatório (3–100 caracteres)
- Nome do responsável obrigatório (3–100 caracteres)
- Telefone obrigatório (10–11 dígitos, formato validado)
- Não pode haver dois amigos com o mesmo nome e telefone
- Não é permitido excluir um amigo com empréstimos vinculados

---

## 🔄 Empréstimos

- Registro de novos empréstimos
- Registro de devoluções
- Visualização de empréstimos abertos e concluídos
- Destaque visual para empréstimos atrasados

### Regras

- Amigo obrigatório
- Revista obrigatória e disponível no momento
- Data de empréstimo gerada automaticamente
- Data de devolução calculada automaticamente (data de empréstimo + dias da caixa)
- Status possíveis: `Aberto` / `Concluído` / `Atrasado`
- Cada amigo pode ter apenas um empréstimo ativo por vez

---

# 🧠 Conceitos Aplicados

| Conceito | Aplicação |
|---|---|
| 🏗️ Classes e Objetos | Modelagem das entidades do sistema |
| 🔒 Encapsulamento | Proteção dos dados internos |
| 📐 Padrão MVC | Separação entre Model, View e Controller |
| ⚙️ Regras de Negócio | Controle de prazos, status e validações |
| 🔗 Comunicação entre Classes | Integração entre módulos |
| 🌐 Aplicação Web | Interface responsiva via navegador |

---

# ⚙️ Tecnologias Utilizadas

- C#
- ASP.NET MVC
- Bootstrap
- Programação Orientada a Objetos (POO)

---

# ▶️ Como Executar

## 1. Clone o repositório

```bash
git clone https://github.com/PingDev-51/Clube_Da_Leitura.git
```

## 2. Acesse a pasta do projeto

```bash
cd clube-da-leitura
```

## 3. Execute o projeto

```bash
dotnet run --project ClubeDaLeitura.WebApp
```

## 4. Acesse no navegador

```
https://localhost:5001
```

---

# 📋 Requisitos

- .NET SDK instalado
- Visual Studio 2022 ou superior

---

# 🎯 Objetivo de Aprendizado

Este projeto foi desenvolvido para praticar:

- ✔️ Programação Orientada a Objetos
- ✔️ Padrão de arquitetura MVC
- ✔️ Desenvolvimento de aplicações web com ASP.NET
- ✔️ Estilização responsiva com Bootstrap
- ✔️ Modelagem de entidades reais
- ✔️ Aplicação de regras de negócio
- ✔️ Organização limpa e reutilizável do código

---

## 👨‍💻 Autores

<div align="center">

Desenvolvido por **Kauan Galvani** e **Kauan Silva** como parte dos estudos em **C# e Programação Orientada a Objetos e Desenvolvimento Web**.

[![GitHub](https://img.shields.io/badge/GitHub-KauanGalvani-181717?style=for-the-badge&logo=github)](https://github.com/KauanGalvani)

[![GitHub](https://img.shields.io/badge/GitHub-k--silvax19-181717?style=for-the-badge&logo=github)](https://github.com/k-silvax19)

</div>
