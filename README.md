# CartsysControlPanel

Painel de controle interno desenvolvido para técnicos e equipe de suporte da **Cartsys**, utilizado na instalação, configuração e manutenção do ambiente de software em cartórios clientes.

---

## Visão Geral

O CartsysControlPanel centraliza em uma única ferramenta todas as operações que antes exigiam acesso manual ao sistema operacional, registro do Windows, linha de comando e arquivos de configuração. O objetivo é padronizar o processo de instalação, reduzir erros humanos e agilizar o atendimento ao cliente.

---

## Funcionalidades

### Serviços
- Instalação e desinstalação individual ou em lote dos serviços Cartsys
- Inicialização e parada de serviços
- Configuração de reinicialização automática em caso de falha
- Indicador de status em tempo real (Rodando / Parado / Não instalado)

### Configurações do Sistema
- Criação e configuração das chaves de registro do Windows necessárias para o funcionamento do Cartsys
- Liberação das portas de serviço e auxiliar no Firewall do Windows para comunicação com o Firebird

### Firebird / HQBird
- Redirecionamento para download do HQBird (página oficial ou link direto)
- Instalação do Firebird via installer embedado
- Aplicação do `firebird.conf` com suporte a portas personalizadas
- Aplicação do `DbCrypt.conf`
- Configuração da pasta de backup com suporte a criptografia
- Instalação da `UDR_SC.dll`
- Execução sequencial de todas as configurações em um único clique

### Calculadora de Cache HQBird
- Cálculo automático de `DefaultDBCachePages` para os bancos do cartório (`CARTORIO.FDB`, `ARQUIVOS.FDB`, `AUDITORIA.FDB`, `INDISPONIBILIDADE.FDB`, `NOTAFISCALDB.FDB`)
- Baseado no tamanho real do banco e na RAM disponível na máquina
- Suporte a múltiplos page sizes (4096, 8192, 16384)
- Geração e append automático no `databases.conf` do HQBird
- Preview dos valores calculados antes de aplicar

### Backup e Restore
- Backup e restore via `gbak` com verbose em janela de terminal
- Suporte a bancos com e sem criptografia DbCrypt
- Seleção de page size para restore
- Credenciais informadas por sessão

### Tela Inicial
- Diagnóstico rápido do ambiente: serial do HD, IP/hostname do servidor, status DHCP, quantidade de serviços Cartsys ativos

---

## Arquitetura

```
CartsysControlPanel/
├── Assets/                          # Recursos embedados (Firebird.exe, DLLs, configs, backup.zip)
├── Domain/                          # Lógica de negócio
│   ├── Backup.cs
│   ├── Restore.cs
│   ├── DatabaseConfigCalculator.cs
│   ├── DependencyManager.cs
│   └── ConversaoUTF8.cs
├── Infrastructure/
│   ├── FileSystem/
│   │   └── FileHandler.cs
│   ├── Hardware/
│   │   └── HardwareHandler.cs
│   ├── Network/
│   │   └── NetworkHandler.cs
│   └── System/
│       ├── FirewallHandler.cs
│       ├── RegistryHandler.cs
│       └── ServiceHandler.cs
├── Logging/
│   └── LoggingFile.cs
└── Views/
    ├── MenuPrincipal.cs
    ├── ServiceForm.cs
    ├── ConfiguracoesForm.cs
    ├── FirebirdHqbirdForm.cs
    ├── HqbirdCalculatorForm.cs
    ├── BackupRestore.cs
    ├── CredentialForm.cs
    └── FirebirdPortForm.cs
```

---

## Requisitos

- Windows 10 x64 ou superior
- Privilégios de administrador (obrigatório — declarado no `app.manifest`)
- .NET 8 Runtime (`net8.0-windows`)
- HQBird / Firebird 3.0 instalado para funcionalidades dependentes do serviço

---

## Publicação

O projeto é publicado como executável único para win-x64:

```xml
<PropertyGroup>
    <TargetFramework>net8.0-windows</TargetFramework>
    <RuntimeIdentifier>win-x64</RuntimeIdentifier>
    <SelfContained>true</SelfContained>
    <PublishSingleFile>true</PublishSingleFile>
    <PublishTrimmed>false</PublishTrimmed>
</PropertyGroup>
```

> `PublishTrimmed` está desabilitado pois o projeto utiliza reflexão, WMI e interop COM que são resolvidos em runtime e seriam incorretamente removidos pelo trimmer.

Para publicar via linha de comando:

```bash
dotnet publish -c Release -r win-x64  /p:PublishSingleFile=true
```

---

## Logging

Os logs são gerados automaticamente em:

```
%AppData%\CartsysControlPanelLogs\Logs\log_yyyy-MM-dd.txt
```

Um arquivo por dia. Em caso de falha no arquivo principal, o sistema tenta um arquivo de fallback no mesmo diretório antes de descartar silenciosamente — o log nunca interrompe a operação principal.

---

## Dependências e Licenças

| Dependência | Versão | Licença | Uso |
|---|---|---|---|
| [FontAwesome.Sharp](https://github.com/awesome-inc/FontAwesome.Sharp) | 6.x | [MIT](https://opensource.org/licenses/MIT) | Ícones da interface |
| System.Management | — | MIT (.NET) | Consultas WMI (RAM, serviços) |
| Microsoft.Win32.Registry | — | MIT (.NET) | Leitura e escrita no registro |
| NetFwTypeLib | — | Windows SDK | *(removido — substituído por `dynamic`)* |

### FontAwesome.Sharp — Aviso de Licença

Este projeto utiliza a biblioteca **FontAwesome.Sharp**, distribuída sob a licença **MIT**, que permite uso livre, comercial e modificação, desde que o aviso de copyright original seja mantido.

> Copyright (c) awesome-inc  
> Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction...

O uso dos ícones FontAwesome neste projeto está em conformidade com os termos da licença MIT. Para mais informações, consulte o repositório oficial: https://github.com/awesome-inc/FontAwesome.Sharp

---

## Paleta de Cores

| Elemento | Cor | Hex |
|---|---|---|
| Fundo principal | `#0b192c` | `Color.FromArgb(11, 25, 44)` |
| Menu lateral | `#1e2a38` | `Color.FromArgb(30, 42, 56)` |
| Botão ativo | `#1e3a5f` | `Color.FromArgb(30, 58, 95)` |
| Accent / borda ativa | `#63b3ed` | `Color.FromArgb(99, 179, 237)` |
| Texto primário | `#e2e8f0` | `Color.FromArgb(226, 232, 240)` |
| Texto secundário / ícones | `#64748b` | `Color.FromArgb(100, 116, 139)` |
| Ação positiva (instalar/iniciar) | — | `Color.FromArgb(20, 83, 45)` |
| Ação de atenção (parar) | — | `Color.FromArgb(146, 64, 14)` |
| Ação destrutiva (desinstalar) | — | `Color.FromArgb(127, 29, 29)` |

---

## Observações Técnicas

- A senha padrão do banco (`SYSDBA`) está hardcoded como valor padrão de instalação — não representa uma credencial de produção customizada e a mesma se encontra em criptografia padrão interna das aplicações Cartsys, não sendo exposta em texto puro em nenhum momento.
- Todos os recursos embedados (DLLs, configs, executáveis) são extraídos para `%TEMP%` quando necessário e removidos após uso
- O `Zone.Identifier` é removido dos executáveis antes da instalação via `InstallUtil` para evitar o erro `0x80131515`
- A classe `ConversaoUTF8` implementa o padrão Singleton via `Lazy<T>` para carregar as DLLs nativas de criptografia uma única vez por sessão

---

## Desenvolvido por

**Lucas Pieroni**  
Desenvolvedor — Cartsys  
Projeto interno — uso exclusivo da equipe de suporte técnico e funcionários autorizados da Cartsys.
