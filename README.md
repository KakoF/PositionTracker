# PositionTracker

Breve descrição
- `PositionTracker` é uma API ASP.NET Core (.NET 8) para gerenciar contas, ordens e integrações com o mercado Bitcoin (BitcoinMarket). Projetado como exemplo/serviço backend contendo separação em camadas: `WebApi`, `Application`, `Domain`, `Infrastructure`.

Principais responsabilidades
- `WebApi` — controllers e configuração da aplicação.
- `Application` — serviços de aplicação (casos de uso).
- `Domain` — modelos, interfaces e exceções de domínio (`Account`, `Order`, etc).
- `Infrastructure` — clientes HTTP externos (ex.: `BitconMarketClient`, `AuthBitconMarketClient`), configurações e handlers de autenticação.

Pré-requisitos
- .NET 8 SDK instalado.
- Variáveis de ambiente ou `appsettings.json`/`appsettings.Development.json` devidamente configurados para a API externa do BitcoinMarket.

Como executar (local)
1. Restaurar e build: