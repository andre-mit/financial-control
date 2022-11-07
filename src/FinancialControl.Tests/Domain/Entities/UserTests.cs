using FinancialControl.Domain.Entities;
using Xunit;

namespace FinancialControl.Tests.Domain.Entities;

public class UserTests
{
    [Fact(DisplayName = "Dado um usuário válido o mesmo deve ser válido")]
    public void Dado_usuario_valido_deve_criar()
    {
        var user = new User("André", "contato@andre-mit.dev");

        Assert.True(user.IsValid, user.Notifications.Join());
    }

    [Fact(DisplayName = "Dado usuário com nome inválido o mesmo deve ser inválido")]
    public void Dado_usuario_com_nome_invalido_o_mesmo_deve_ser_inválido()
    {
        var user = new User(string.Empty, "contato@andre-mit.dev");

        Assert.False(user.IsValid, user.Notifications.Join());
    }

    [Fact(DisplayName = "Dado usuário com email inválido, o mesmo deve ser inválido")]
    public void Dado_usuario_com_email_invalido_o_mesmo_deve_ser_invalido()
    {
        var user = new User("André", "contatoandre-mit.dev");

        Assert.False(user.IsValid, user.Notifications.Join());
    }

    [Fact(DisplayName = "Dado usuário com email nulo, o mesmo deve ser inválido")]
    public void Dado_usuario_com_email_nulo_o_mesmo_deve_ser_invalido()
    {
        var user = new User("André", null);

        Assert.False(user.IsValid, user.Notifications.Join());
    }

    [Fact(DisplayName = "Dado usuário com telefone inválido, o mesmo deve ser inválido")]
    public void Dado_usuario_com_telefone_invalido_o_mesmo_deve_ser_invalido()
    {
        Assert.True(false, "Not Implemented");
    }

    [Fact(DisplayName = "Dado usuário com telefone nulo, o mesmo deve ser inválido")]
    public void Dado_usuario_com_telefone_nulo_o_mesmo_deve_ser_invalido()
    {
        Assert.True(false, "Not Implemented");
    }

    [Fact(DisplayName = "Dado um usuário e um cartão de crédito válidos, o mesmo deve ser adicionado ao usuario")]
    public void Dado_usuario_e_cartao_de_credito_o_mesmo_deve_ser_inserido()
    {
        var user = new User("André", "contato@andre-mit.dev");
        var creditCard = new CreditCard("Master Card", 10, 4, user);

        user.AddCreditCard(creditCard);

        Assert.Contains(creditCard, user.CreditCards);
    }

    [Fact(DisplayName = "Dado um usuário e um cartão de crédito inválido, o mesmo não deve ser adicionado ao usuario")]
    public void Dado_usuario_e_cartao_de_credito_invalido_o_mesmo_nao_deve_ser_inserido()
    {
        var user = new User("André", "contato@andre-mit.dev");
        var creditCard = new CreditCard(string.Empty, 10, 4, user);

        user.AddCreditCard(creditCard);

        Assert.DoesNotContain(creditCard, user.CreditCards);
    }
}