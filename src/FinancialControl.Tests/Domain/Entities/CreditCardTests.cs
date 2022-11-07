using FinancialControl.Domain.Entities;
using Xunit;

namespace FinancialControl.Tests.Domain.Entities;

public class CreditCardTests
{
    [Fact(DisplayName = "Dado um cartão de crédito válido o mesmo deve ser válido")]
    public void Dado_cartao_de_credito_valido_deve_criar()
    {
        var creditCard = new CreditCard("MasterCard", 10, 4, new User("André", "contato@andre-mit.dev"));

        Assert.True(creditCard.IsValid, creditCard.Notifications.Join());
    }

    [Fact(DisplayName = "Dado um cartão de crédito com nome inválido, o mesmo deve ser inválido")]
    public void Dado_cartao_de_credito__com_nome_invalido_o_mesmo_deve_ser_invalido()
    {
        var creditCard = new CreditCard(string.Empty, 10, 4, new User("André", "contato@andre-mit.dev"));

        Assert.False(creditCard.IsValid, creditCard.Notifications.Join());
    }
}