# PositionTracker

Breve descri��o
- `PositionTracker` � uma API ASP.NET Core (.NET 8) para gerenciar contas, ordens e integra��es com o mercado Bitcoin (BitcoinMarket). Projetado como exemplo/servi�o backend contendo separa��o em camadas: `WebApi`, `Application`, `Domain`, `Infrastructure`.

Principais responsabilidades
- `WebApi` � controllers e configura��o da aplica��o.
- `Application` � servi�os de aplica��o (casos de uso).
- `Domain` � modelos, interfaces e exce��es de dom�nio (`Account`, `Order`, etc).
- `Infrastructure` � clientes HTTP externos (ex.: `BitconMarketClient`, `AuthBitconMarketClient`), configura��es e handlers de autentica��o.

Pr�-requisitos
- .NET 8 SDK instalado.
- Vari�veis de ambiente ou `appsettings.json`/`appsettings.Development.json` devidamente configurados para a API externa do BitcoinMarket.

Como executar (local)
1. Restaurar e build: