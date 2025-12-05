# Camada de Testes dos Repositories

Este projeto contém os testes unitários para a camada de infraestrutura (repositories) do CleanArchMvc.

## Estrutura do Projeto

```
CleanArchMvc.Infra.Data.Tests/
├── CleanArchMvc.Infra.Data.Tests.csproj
├── README.md
├── TestHelpers/
│   ├── TestDbContextFactory.cs
│   └── TestDataBuilder.cs
└── Repositories/
    ├── CategoryRepositoryTests.cs
    └── ProductRepositoryTests.cs
```

## Tecnologias Utilizadas

- **xUnit**: Framework de testes principal
- **FluentAssertions**: Para assertions mais legíveis e expressivas
- **Entity Framework InMemory**: Para testes com banco de dados em memória
- **Moq**: Para mocking (disponível caso necessário)

## Funcionalidades Testadas

### CategoryRepositoryTests
- ✅ Criação de categorias
- ✅ Busca por ID (válido e inválido)
- ✅ Listagem de todas as categorias
- ✅ Atualização de categorias
- ✅ Remoção de categorias
- ✅ Tratamento de exceções para entidades inexistentes

### ProductRepositoryTests
- ✅ Criação de produtos
- ✅ Busca por ID (válido e inválido)
- ✅ Listagem de todos os produtos (com categorias)
- ✅ Busca de produto com categoria
- ✅ Atualização de produtos
- ✅ Remoção de produtos
- ✅ Tratamento de exceções para entidades inexistentes

## Como Executar os Testes

### Executar todos os testes
```bash
cd CleanArchMvc.Infra.Data.Tests
dotnet test
```

### Executar testes com detalhes verbosos
```bash
dotnet test --verbosity normal
```

### Executar testes com cobertura de código
```bash
dotnet test --collect:"XPlat Code Coverage"
```

### Executar apenas testes de uma classe específica
```bash
dotnet test --filter "ClassName=CategoryRepositoryTests"
dotnet test --filter "ClassName=ProductRepositoryTests"
```

## Padrões de Teste Utilizados

### Arrange-Act-Assert (AAA)
Todos os testes seguem o padrão AAA:
- **Arrange**: Preparação dos dados de teste
- **Act**: Execução da operação a ser testada
- **Assert**: Verificação dos resultados

### Exemplo de Teste
```csharp
[Fact]
public async Task Create_ShouldAddCategoryToDatabase()
{
    // Arrange
    var category = TestDataBuilder.CreateValidCategory("Electronics");

    // Act
    var result = await _categoryRepository.Create(category);

    // Assert
    result.Should().NotBeNull();
    result.Name.Should().Be("Electronics");
    result.Id.Should().BeGreaterThan(0);
}
```

### Test Helpers

#### TestDbContextFactory
Responsável por criar contextos de banco de dados em memória para os testes, garantindo isolamento entre os testes.

#### TestDataBuilder
Fornece métodos para criar objetos de teste válidos de forma consistente.

## Isolamento de Testes

Cada teste utiliza uma instância única do contexto em memória, garantindo que:
- Os testes não interferem uns nos outros
- Cada teste começa com um banco de dados limpo
- Os dados são automaticamente limpos após cada teste

## Cobertura de Cenários

Os testes cobrem:
- **Cenários de sucesso**: Operações que devem funcionar normalmente
- **Cenários de erro**: Casos onde exceções são esperadas
- **Casos extremos**: IDs inválidos, entidades inexistentes, etc.
- **Validação de relacionamentos**: Produtos com categorias

## Executando no CI/CD

Os testes podem ser facilmente integrados em pipelines de CI/CD:

```yaml
# Exemplo para GitHub Actions
- name: Run tests
  run: dotnet test CleanArchMvc.Infra.Data.Tests/CleanArchMvc.Infra.Data.Tests.csproj
```

## Manutenção

Para adicionar novos testes:
1. Utilize os helpers existentes (`TestDataBuilder`, `TestDbContextFactory`)
2. Siga o padrão AAA
3. Use `FluentAssertions` para assertions mais legíveis
4. Garanta que cada teste seja independente
5. Teste tanto cenários de sucesso quanto de falha

## Dependências

O projeto de testes referencia:
- `CleanArchMvc.Infra.Data`: Para testar os repositories
- `CleanArchMvc.Domain`: Para acessar as entidades